using AxWMPLib;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
namespace AI_vs_HUMAN
{
    public partial class file_test : Form
    {
        private System.Drawing.Size originalSize; //Size: OpenCvSharp.Size, but we need System.Drawing.Size for scaling
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        public file_test()
        {
            LanguageManager.SetLanguage(LanguageManager.CurrentLanguage);
            InitializeComponent();
            ApplyLanguage();
            this.Shown += (s, e) =>
            {
                this.WindowState = FormWindowState.Maximized;
            };
            pictureToCheck.Hide();
            axWindowsMediaPlayer1.Hide();
            this.Load += startLoad;
            this.Resize += startResize;
        }

        //Language methods
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

        //Resize methods
        private void startLoad(object sender, EventArgs e)
        {
            originalSize = this.Size;
            ResizeControl.StoreOriginalBoundsRecursive(this, originalControlBounds);
        }
        private void startResize(object sender, EventArgs E)
        {
            ResizeControl.ResizeControlsRecursive(this, originalControlBounds, originalSize);
        }
        //Button methods
        private void challangeBitton_Click(object sender, EventArgs e)
        {
            this.Hide();
            research_tool form_research_tool = new research_tool();
            form_research_tool.ShowDialog();
            this.Close();
        }
        private void getPhotoButton_Click(object sender, EventArgs e)
        {
            photoPath.Filter = "Media Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.mp4;*.avi;*.mov";
            photoPath.Title = "Wybierz plik";
            if (photoPath.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = photoPath.FileName;
                    string ext = System.IO.Path.GetExtension(filePath).ToLower();
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif")
                    {
                        axWindowsMediaPlayer1.Hide();
                        pictureToCheck.Show();
                        System.Drawing.Image img = System.Drawing.Image.FromFile(photoPath.FileName);
                        pictureToCheck.Image = img;
                        pictureToCheck.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else if (ext == ".mp4" || ext == ".avi" || ext == ".mov")
                    {
                        pictureToCheck.Hide();
                        axWindowsMediaPlayer1.Show();
                        this.axWindowsMediaPlayer1.URL = filePath;
                        this.axWindowsMediaPlayer1.Ctlcontrols.play();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas ładowania pliku\n{ex.Message}");
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(photoPath.FileName))
            {
                MessageBox.Show("Nie podano pliku.");
                return;
            }
            try
            {
                string filePath=photoPath.FileName;
                string ext = System.IO.Path.GetExtension(filePath).ToLower();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif")
                {
                    checkButton.Enabled = false;
                    challangeBitton.Enabled = false;
                    getPhotoButton.Enabled = false;
                    int result_from_model = await ApiComunication.SendImageToModel(photoPath.FileName);
                    if (result_from_model == 0)
                        answerAIorNOT.Text = "Model mówi: to nie jest AI";
                    else if (result_from_model == 1)
                        answerAIorNOT.Text = "Model mówi: to jest AI";
                    checkButton.Enabled = true;
                    challangeBitton.Enabled = true;
                    getPhotoButton.Enabled = true;
                }
                else if (ext == ".mp4" || ext == ".avi" || ext == ".mov")
                {
                    
                    double result_from_model;
                    using (speed form_speed = new speed())
                    {
                        if(form_speed.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }
                        int speed=form_speed.SelectedSpeed;
                        checkButton.Enabled = false;
                        challangeBitton.Enabled = false;
                        getPhotoButton.Enabled = false;
                        answerAIorNOT.Text = "Analizowanie trwa...";
                        result_from_model = await ApiComunication.AnalizeVideo(photoPath.FileName, speed);
                    }
                    if (result_from_model == -1)
                    {
                        answerAIorNOT.Text = $"Bład podczas analizy wideo.";
                    }
                    else if(result_from_model < 50) //result_from_model is a percentage of frames classified as AI, so if it's less than 50%, we say it's not AI
                    {
                        answerAIorNOT.Text = $"Model mówi, to nie jest AI \nPewność: {100.0 - result_from_model:F2}%";
                    }
                    else
                    {
                        answerAIorNOT.Text = $"Model mówi, to jest AI \nPewność: {(result_from_model):F2}%";
                    }
                    checkButton.Enabled = true;
                    challangeBitton.Enabled = true;
                    getPhotoButton.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Nieobsługiwany format pliku.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania pliku\n{ex.Message}");
                return;
            }
        }
    }
}
