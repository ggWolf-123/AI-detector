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

        /// <summary>
        ///    Change the language of the form and all controls on it. The text for each control is taken from the resources file, so it will be automatically updated when the language is changed. This method is called after changing the language to update the UI.
        /// </summary>
        private void ApplyLanguage()
        {
            LanguageManager.ApplyLanguageToControls(this);
        }
        /// <summary>
        ///     Open the language selection form when the changeLang button is clicked. This allows the user to select a different language for the application. After the user selects a language and closes the language form, the main form will update its UI to reflect the new language selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeLang_Click(object sender, EventArgs e)
        {
            language langForm = new language();
            langForm.ShowDialog();
            ApplyLanguage();
        }
        /// <summary>
        ///     Initialize the form and store the original size and bounds of controls for resizing. It calls the Initialize method of the ResizeControl class, which stores the original size of the form and the original bounds of all controls in a dictionary. This allows the application to resize controls proportionally when the form is resized, maintaining a consistent layout regardless of the form's size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startLoad(object sender, EventArgs e)
        {
            ResizeControl.Initialize(this);
        }
        /// <summary>
        ///     Change the size of the form and all controls on it when the form is resized. It calls the ResizeControlsRecursive method to resize all controls based on the original size and bounds stored during the startLoad event. This ensures that the layout of the form remains consistent regardless of its size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startResize(object sender, EventArgs e)
        {
            ResizeControl.ResizeControlsRecursive(this);
        }
        /// <summary>
        ///     Click event handler for the startButton. When the button is clicked, it starts the FastAPI servers by calling the StartFastApiServers method from the ApiComunication class. It then hides the current form and opens a new form called file_test. After the file_test form is closed, it closes the main form. This allows the user to interact with the file_test form while the FastAPI servers are running in the background.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            changeLang.Enabled= false;
            var processes = await ApiComunication.StartFastApiServers();
            fastApiProcess = processes.FirstOrDefault();
            this.Hide();
            file_test test_Obrazu = new file_test();
            test_Obrazu.ShowDialog();
            this.Close();
        }

        /// <summary>
        ///     Function to handle the form closing event. It checks if the FastAPI process is still running and attempts to close it gracefully by sending a close signal to the main window. If the process does not exit within 2 seconds, it forcefully kills the process. Finally, it disposes of the process resources. This ensures that the FastAPI servers are properly shut down when the main form is closed.
        /// </summary>
        /// <param name="e"></param>
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
