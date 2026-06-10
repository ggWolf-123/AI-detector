using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_vs_HUMAN
{
    internal class ApiComunication
    {
        private static readonly HttpClient client = new HttpClient();
        public class PythonEnvConfig
        {
            public string PythonExe { get; set; }
            public string WorkingDir { get; set; }
        }
        /// <summary>
        /// Function to start all FastAPI servers and wait until they are ready. It returns a list of Process objects representing the running API servers, which can be used later to stop them when the application exits.
        /// </summary>
        /// <returns>A list of Process objects representing the running API servers.</returns>
        public static async Task<List<Process>> StartFastApiServers()
        {

            var env = StartENV();
            var processes = StartFasApiProcesses(env);
            await Task.Delay(2000);
            await WaitForAllApisReady(300);
            return processes;
        }
        /// <summary>
        /// Function to start all FastAPI processes. It takes a PythonEnvConfig object as a parameter, which contains the path to the Python executable and the working directory for the API servers. It returns a list of Process objects representing the running API servers.
        /// </summary>
        /// <param name="env">The Python environment configuration containing the path to the Python executable and the working directory for the API servers.</param>
        /// <returns>A list of Process objects representing the running API servers.</returns>
        public static List<Process> StartFasApiProcesses(PythonEnvConfig env)
        {
            return new List<Process>
            {
                StartFastApi("main", 8000, env)
            };
        }
        /// <summary>
        /// Function to start the FastAPI environment. It checks for the existence of the FastAPI directory and the Python executable in the virtual environment. If either of them is not found, it throws an exception with a descriptive error message. If both are found, it returns a PythonEnvConfig object containing the paths to the Python executable and the working directory for the API servers.
        /// </summary>
        /// <returns>A PythonEnvConfig object containing the paths to the Python executable and the working directory for the API servers.</returns>
        /// <exception cref="Exception"></exception>
        private static PythonEnvConfig StartENV()
        {
            string baseDir=AppContext.BaseDirectory;

            ///Debug
            string solutionRoot=Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;
            string fastApiDir = Path.Combine(solutionRoot, "AI vs HUMAN", "fastapi_model");
            string venvPath = Path.Combine(solutionRoot, "env", "Scripts", "python.exe");
            ///
            ///Release
            ///string fastApiDir = Path.Combine(baseDir, "fastapi_model");
            ///string venvPath = Path.Combine(baseDir, "env", "Scripts", "python.exe");

            if (!Directory.Exists(fastApiDir))
            {
                MessageBox.Show(fastApiDir);
                throw new Exception($"FastAPI directory not found at {fastApiDir}.");
            }
            if (!File.Exists(venvPath))
            {
                MessageBox.Show(venvPath);
                throw new Exception($"Python executable not found at {venvPath}.");
            }
            MessageBox.Show($"WorkingDir: {fastApiDir}");
            return new PythonEnvConfig
            {

                PythonExe = venvPath,
                WorkingDir = fastApiDir
            };
        }
        /// <summary>
        /// Function to start a FastAPI server as a separate process. It takes the module name, port number, and Python environment configuration as parameters. It configures the process to run the FastAPI server using Uvicorn, redirects the standard output and error streams to the console, and starts the process. It returns a Process object representing the running API server.
        /// </summary>
        /// <param name="module">The name of the module containing the FastAPI app.</param>
        /// <param name="port">The port number on which the FastAPI server will listen.</param>
        /// <param name="env">The Python environment configuration containing the path to the Python executable and the working directory for the API server.</param>
        /// <returns>A Process object representing the running FastAPI server.</returns>
        public static Process StartFastApi(string module, int port, PythonEnvConfig env)
        {
            var process= new Process();
            process.StartInfo.FileName = env.PythonExe;
            process.StartInfo.WorkingDirectory = env.WorkingDir;
            process.StartInfo.Arguments = $"-m uvicorn {module}:app --host 127.0.0.1 --port {port}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    Console.WriteLine($"[{module} OUTPUT] {e.Data}");
                }
            };
            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    Console.WriteLine($"[{module} ERROR] {e.Data}");
                }
            };
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            return process;
        }
        /// <summary>
        /// Function to wait until all FastAPI servers are ready. It checks the health endpoint of each API server in a loop until it receives a response indicating that the server is ready or until a specified timeout is reached. If any API server does not become ready within the timeout period, it throws an exception with a descriptive error message.
        /// </summary>
        /// <param name="timeout">The maximum time to wait for the API servers to become ready, in seconds.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task WaitForAllApisReady(int timeout=300) //this function can be expanded if more APIs are added, currently it only checks one API
        {
            await WaitForHealth("http://127.0.0.1:8000/health", timeout);
        }
        /// <summary>
        /// Function to wait until a specific API server is ready by checking its health endpoint. It sends HTTP GET requests to the specified URL in a loop until it receives a response indicating that the server is ready or until a specified timeout is reached. If the server does not become ready within the timeout period, it throws an exception with a descriptive error message.
        /// </summary>
        /// <param name="url">The URL of the API server's health endpoint.</param>
        /// <param name="timeout">The maximum time to wait for the API server to become ready, in seconds.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="Exception">Thrown if the API server does not become ready within the specified timeout.</exception>
        public static async Task WaitForHealth(string url,int timeout=300)
        {
            var start=DateTime.UtcNow;
            while((DateTime.UtcNow-start).TotalSeconds<timeout)
            {
                try
                {
                    var response = await client.GetAsync(url);
                    var content = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"API at {url} returned status code {response.StatusCode}: {content}");
                        Console.WriteLine(await response.Content.ReadAsStringAsync());
                        await Task.Delay(1000);
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        Console.WriteLine($"API at {url} returned empty response");
                        await Task.Delay(500);
                        continue;
                    }
                    try
                    {
                        using (var doc = JsonDocument.Parse(content))
                        {
                            var root = doc.RootElement;
                            if (root.TryGetProperty("status", out var status) && status.GetString() == "ready")
                            {
                                return;
                            }
                        }
                    }
                    catch (JsonException)
                    {
                        Console.WriteLine($"API at {url} returned invalid JSON: {content}");
                        await Task.Delay(500);
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error connecting to API at {url}: {ex.Message}");
                }
                await Task.Delay(500);
            }
            throw new Exception($"API at {url} did not become ready in time.");
        }
        /// <summary>
        /// Function to send an image file to the FastAPI model for prediction. It takes the file path of the image as a parameter, reads the image file, and sends it as a multipart/form-data POST request to the API endpoint. It then parses the JSON response from the API to extract the prediction result and returns it as an integer.
        /// </summary>
        /// <param name="filePath">The file path of the image to be sent for prediction.</param>
        /// <returns>A task representing the asynchronous operation, with the prediction result as an integer.</returns>
        public static async Task<int> SendImageToModel(string filePath)
        {
            using (var content = new MultipartFormDataContent())
            {
                var imageContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filePath));
                string ext = System.IO.Path.GetExtension(filePath).ToLower();
                string mime = "image/jpeg";
                if (ext == ".png") mime = "image/png";
                else if (ext == ".bmp") mime = "image/bmp";
                else if (ext == ".gif") mime = "image/gif";
                imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mime);
                content.Add(imageContent, "file", System.IO.Path.GetFileName(filePath));

                HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:8000/predict/image", content);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                using (var doc = JsonDocument.Parse(responseString))
                {
                    int prediction = doc.RootElement.GetProperty("result").GetInt32();
                    return prediction;
                }
            }
        }
        /// <summary>
        /// Function to analyze a video file by sending it to the FastAPI model for prediction. It takes the file path of the video and a frame step value as parameters, reads the video file, and sends it as a multipart/form-data POST request to the API endpoint. The frame step value indicates how many frames to skip between each analyzed frame. It then parses the JSON response from the API to extract the percentage of AI-generated content in the video and returns it as a double.
        /// </summary>
        /// <param name="videoPath">The file path of the video to be analyzed.</param>
        /// <param name="frameStep">The number of frames to skip between each analyzed frame.</param>
        /// <returns>A task representing the asynchronous operation, with the percentage of AI-generated content in the video as a double.</returns>
        public static async Task<double> AnalizeVideo(string videoPath, int frameStep)
        {
            using (var content = new MultipartFormDataContent())
            {
                var videoBytes=File.ReadAllBytes(videoPath);
                var videoContent = new ByteArrayContent(videoBytes);
                videoContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("video/mp4");
                content.Add(videoContent, "file", System.IO.Path.GetFileName(videoPath));
                content.Add(new StringContent(frameStep.ToString()), "frame_step");
                var response = await client.PostAsync("http://127.0.0.1:8000/predict/video", content);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                using (var doc = JsonDocument.Parse(responseString))
                {
                    double aiPercentage = doc.RootElement.GetProperty("ai_percentage").GetDouble();
                    return aiPercentage;
                }
            }
        }
        /// <summary>
        /// Function to send a text string to the FastAPI model for translation. It takes the text string as a parameter, sends it as a JSON POST request to the API endpoint, and parses the JSON response to extract the translated text, which is returned as a string.
        /// </summary>
        /// <param name="text">The text string to be translated.</param>
        /// <returns>A task representing the asynchronous operation, with the translated text as a string.</returns>
        public static async Task<string> SentTextToTranslate(string text)
        {
            var json=JsonSerializer.Serialize(new { text = text });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://127.0.0.1:8000/translate", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            using (var doc = JsonDocument.Parse(responseString))
            {
                if (doc.RootElement.TryGetProperty("translated_text", out var el))
                {
                    return el.GetString();
                }
                string translation = doc.RootElement.GetProperty("translated_text").GetString();
                return translation;
            }
        }
        /// <summary>
        /// Function to send a text string to the FastAPI model for prediction. It takes the text string as a parameter, sends it as a JSON POST request to the API endpoint, and parses the JSON response to extract the prediction result, which is returned as an integer.
        /// </summary>
        /// <param name="text">The text string to be predicted.</param>
        /// <returns>A task representing the asynchronous operation, with the prediction result as an integer.</returns>
        public static async Task<int> SentTextToModel(string text)
        {
            var json = JsonSerializer.Serialize(new { text = text });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://127.0.0.1:8000/predict/text", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            using (var doc = JsonDocument.Parse(responseString))
            {
                int result = doc.RootElement.GetProperty("result").GetInt32();
                return result;
            }
        }
    }
}
