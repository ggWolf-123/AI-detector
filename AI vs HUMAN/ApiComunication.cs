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
        public static async Task<List<Process>> StartFastApiServers()
        {

            var env = StartENV();
            var processes = StartFasApiProcesses(env);
            await Task.Delay(2000);
            await WaitForAllApisReady(300);
            return processes;
        }
        public static List<Process> StartFasApiProcesses(PythonEnvConfig env)
        {
            return new List<Process>
            {
                StartFastApi("main", 8000, env)
            };
        }
        private static PythonEnvConfig StartENV()
        {
            string baseDir=AppContext.BaseDirectory;
            string solutionRoot=Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;
            string fastApiDir = Path.Combine(solutionRoot, "AI vs HUMAN", "fastapi_model");
            string venvPath = Path.Combine(solutionRoot, "env", "Scripts", "python.exe");
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
        public static async Task WaitForAllApisReady(int timeout=300) //this function can be expanded if more APIs are added, currently it only checks one API
        {
            await WaitForHealth("http://127.0.0.1:8000/health", timeout);
        }
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
        public static async Task<int> SendFrameToModel(byte[] imageBytes)
        {
            using (var content = new MultipartFormDataContent())
            {
                var imageContent = new ByteArrayContent(imageBytes);
                imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                content.Add(imageContent, "file", "frame.jpg");
                var response = await client.PostAsync("http://127.0.0.1:8000/predict/image", content);
                var responseString = await response.Content.ReadAsStringAsync();
                using (var doc = JsonDocument.Parse(responseString))
                {
                    int prediction = doc.RootElement.GetProperty("result").GetInt32();
                    return prediction;
                }
            }
        }
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
