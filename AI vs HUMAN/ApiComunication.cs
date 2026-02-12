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
        public static async Task<Process> StartFastApiServer()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync("http://127.0.0.1:8000/docs");

                    if (response.IsSuccessStatusCode)
                    {
                        // Server is already running
                        return null;
                    }
                }
            }
            catch { }// Server is not running, proceed to start it
            Process fastApiProcess = new Process();
            fastApiProcess.StartInfo.FileName = "uvicorn";
            string fastApiPath = Path.Combine(Application.StartupPath, @"..\..\fastapi_model");
            fastApiPath = Path.GetFullPath(fastApiPath);
            fastApiProcess.StartInfo.Arguments = "api_photos_and_videos:app --host 0.0.0.0 --port 8000";
            fastApiProcess.StartInfo.WorkingDirectory = fastApiPath;
            fastApiProcess.StartInfo.CreateNoWindow = true;
            fastApiProcess.StartInfo.UseShellExecute = false;
            fastApiProcess.Start();

            using (HttpClient http = new HttpClient())
            {
                for (int i = 0; i < 40; i++)
                {
                    try
                    {
                        var r = await http.GetAsync("http://127.0.0.1:8000/docs");
                        if (r.IsSuccessStatusCode)
                        {
                            return fastApiProcess;
                        }
                    }
                    catch
                    {
                        await Task.Delay(250);
                    }
                }
            }

            MessageBox.Show("Nie udało się udostępnić serwera FastAPI.\n\nNie udało się uruchomić serwera FastAPI.");
            return null;
        }
        public static async Task<int> SendImageToModel(string filePath)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://127.0.0.1:8000/");
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

                    HttpResponseMessage response = await client.PostAsync("predict", content);
                    response.EnsureSuccessStatusCode();

                    var responseString = await response.Content.ReadAsStringAsync();
                    using (var doc = JsonDocument.Parse(responseString))
                    {
                        int prediction = doc.RootElement.GetProperty("result").GetInt32();
                        return prediction;
                    }
                }
            }
        }
        public static async Task<int> SendFrameToModel(byte[] imageBytes)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://127.0.0.1:8000/");
                using (var content = new MultipartFormDataContent())
                {
                    var imageContent = new ByteArrayContent(imageBytes);
                    imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                    content.Add(imageContent, "file", "frame.jpg");
                    var response = await client.PostAsync("predict", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    using (var doc = JsonDocument.Parse(responseString))
                    {
                        int prediction = doc.RootElement.GetProperty("result").GetInt32();
                        return prediction;
                    }
                }
            }
        }
        public static async Task<double> AnalizeVideo(string videoPath, int frameStep)
        {
            //MessageBox.Show($"FrameStep: {frameStep}");
            using (var capture = new VideoCapture(videoPath))
            {
                if (!capture.IsOpened())
                {
                    MessageBox.Show("Unable to open video.\n\nNie można otworzyć wideo.");
                    return -1;
                }
                int currentFrame = 0;
                int analyzedFrames = 0;
                int aiCount = 0;
                int humanCount = 0;

                Mat frame = new Mat();
                while (true)
                {
                    if (!capture.Read(frame) || frame.Empty())
                        break;
                    if (currentFrame % frameStep == 0)
                    {
                        Cv2.ImEncode(".jpg", frame, out var buffer);
                        int result = await SendFrameToModel(buffer);
                        analyzedFrames++;
                        //MessageBox.Show($"Analyzed frames: {analyzedFrames}");

                        if (result == 1)
                        {
                            aiCount++;
                        }
                        else
                        {
                            humanCount++;
                        }
                    }
                    currentFrame++;
                }
                if (analyzedFrames == 0)
                {
                    MessageBox.Show("Could not find frames to analyze.\n\nNie można znaleźć klatek do analizy.");
                    return -1;
                }
                double aiPercentage = (double)aiCount / analyzedFrames * 100;
                return aiPercentage;
            }
        }
    }
}
