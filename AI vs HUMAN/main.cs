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
using System.Globalization;
using System.Threading;
namespace AI_vs_HUMAN
{
    public partial class main : Form
    {
        private Size originalSize;
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private Process fastApiProcess;
        public main()
        {
            LanguageManager.SetLanguage(LanguageManager.CurrentLanguage);
            InitializeComponent();
            ApplyLanguage();
            this.Shown += (s, e) =>
            {
                this.WindowState = FormWindowState.Maximized;
            };

            this.Load += startLoad;
            this.Resize += startResize;
        }
        
        private void ApplyLanguage()
        {
            this.Text = Properties.Resources.challangeBitton;
            LanguageManager.ApplyLanguageToControls(this);
        }
        private void changeLang_Click(object sender, EventArgs e)
        {
            if (LanguageManager.CurrentLanguage == "en")
            {
                LanguageManager.ChangeLanguage("pl");
            }
            else
            {
                LanguageManager.ChangeLanguage("en");
            }
            ApplyLanguage();
        }
        private void startLoad(object sender, EventArgs e)
        {
            originalSize = this.Size;
            ResizeControl.StoreOriginalBoundsRecursive(this, originalControlBounds);
        }
        private void startResize(object sender, EventArgs E)
        {
            ResizeControl.ResizeControlsRecursive(this, originalControlBounds, originalSize);
        }
        private async void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            changeLang.Enabled= false;
            fastApiProcess = await ApiComunication.StartFastApiServer();
            this.Hide();
            file_test test_Obrazu = new file_test();
            test_Obrazu.ShowDialog();
            this.Close();
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
