using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_vs_HUMAN
{
    public partial class uruchom_model : Form
    {
        private Size originalSize;
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private Process fastApiProcess;
        public uruchom_model()
        {
            InitializeComponent();
            this.Shown += (s, e) =>
            {
                this.WindowState = FormWindowState.Maximized;
            };

            this.Load += startLoad;
            this.Resize += startResize;
        }
        private void startLoad(object sender, EventArgs e)
        {
            originalSize = this.Size;
            StoreOriginalBoundsRecursive(this);
        }
        private void startResize(object sender, EventArgs E)
        {
            ResizeControlsRecursive(this);
        }
        private void StoreOriginalBoundsRecursive(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (!originalControlBounds.ContainsKey(ctrl))
                    originalControlBounds[ctrl] = ctrl.Bounds;

                if (ctrl.Controls.Count > 0)
                    StoreOriginalBoundsRecursive(ctrl);
            }
        }
        private void ResizeControlsRecursive(Control parent)
        {
            if (originalSize.Width == 0 || originalSize.Height == 0) return;

            float xRatio = (float)this.Width / originalSize.Width;
            float yRatio = (float)this.Height / originalSize.Height;

            foreach (Control ctrl in parent.Controls)
            {
                if (originalControlBounds.ContainsKey(ctrl))
                {
                    Rectangle orig = originalControlBounds[ctrl];
                    int newX = (int)(orig.X * xRatio);
                    int newY = (int)(orig.Y * yRatio);
                    int newWidth = (int)(orig.Width * xRatio);
                    int newHeight = (int)(orig.Height * yRatio);
                    ctrl.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
                }
                if (ctrl.Controls.Count > 0)
                {
                    ResizeControlsRecursive(ctrl);
                }
            }
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            await StartFastApiServer();
            this.Hide();
            test_obrazu test_Obrazu = new test_obrazu();
            test_Obrazu.ShowDialog();
            this.Close();
        }
        private async Task StartFastApiServer()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync("http://127.0.0.1:8000/docs");

                    if (response.IsSuccessStatusCode)
                    {
                        // Server is already running
                        return;
                    }
                }            }
            catch { }// Server is not running, proceed to start it
            fastApiProcess = new Process();
            fastApiProcess.StartInfo.FileName = "uvicorn";
            string fastApiPath = Path.Combine(Application.StartupPath, @"..\..\fastapi_model");
            fastApiPath = Path.GetFullPath(fastApiPath);
            fastApiProcess.StartInfo.Arguments = "test_zdjecie_api:app --host 0.0.0.0 --port 8000";
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
                            return;
                        }
                    }
                    catch
                    {
                        await Task.Delay(250);
                    }
                }
            }
                
            MessageBox.Show("Nie udało się uruchomić serwera FastAPI.");
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (fastApiProcess != null && !fastApiProcess.HasExited)
            {
                try
                {
                    fastApiProcess.CloseMainWindow();
                    fastApiProcess.WaitForExit(2000);
                    if (!fastApiProcess.HasExited)
                    {
                        fastApiProcess.Kill();
                    }
                }
                catch { }
                finally
                {
                    fastApiProcess.Dispose();
                }
            }
            base.OnFormClosing(e);
        }
    }
}
