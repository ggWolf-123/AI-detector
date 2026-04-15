using AxWMPLib;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
namespace AI_vs_HUMAN
{
    public partial class file_test : Form
    {
        private System.Drawing.Size originalSize; //Size: OpenCvSharp.Size, but we need System.Drawing.Size for scaling
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private string[] allImages;
        private string mainFolderPath;
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
            photoPath.Filter = "Media Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.mp4;*.avi;*.mov;*.txt";
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
                else if (ext == ".txt")
                {
                    string text = System.IO.File.ReadAllText(filePath);
                    text=await ApiComunication.SentTextToTranslate(text);
                    int result_from_model = await ApiComunication.SentTextToModel(text);
                    if (result_from_model == 0)
                        answerAIorNOT.Text = "Model mówi: to nie jest AI";
                    else if (result_from_model == 1)
                        answerAIorNOT.Text = "Model mówi: to jest AI";
                }
                else
                {
                    MessageBox.Show("Nieobsługiwany format pliku.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania pliku\n{ex.Message}");
                checkButton.Enabled = true;
                challangeBitton.Enabled = true;
                getPhotoButton.Enabled = true;
                return;
            }
        }
        private async void checkFolderButton_Click(object sender, EventArgs e)
        {
            chooseFolder();
            string path = System.IO.Path.Combine(mainFolderPath, "result_of_folder_AI_DETECTOR.csv");
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            var header = "File Name;Result";
            System.IO.File.WriteAllText(path, header + Environment.NewLine);
            foreach (string file in allImages)
            {
                var columns = new List<string> {System.IO.Path.GetFileName(file)};
                string ext = System.IO.Path.GetExtension(file).ToLower();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif")
                {
                    int result_from_model = await ApiComunication.SendImageToModel(file);
                    if (result_from_model == 0)
                        columns.Add("Not AI");
                    else if (result_from_model == 1)
                        columns.Add("AI");
                }
                else if (ext == ".mp4" || ext == ".avi" || ext == ".mov")
                {
                    double result_from_model;
                    result_from_model = await ApiComunication.AnalizeVideo(file, 180);
                    if (result_from_model == -1)
                    {
                        MessageBox.Show($"Bład podczas analizy wideo {System.IO.Path.GetFileName(file)}.");
                        columns.Add("Error during analysis");
                    }
                    else if (result_from_model < 50) //result_from_model is a percentage of frames classified as AI, so if it's less than 50%, we say it's not AI
                    {
                        columns.Add($"Not AI, Confidence: {100.0 - result_from_model:F2}%");
                    }
                    else
                    {
                        columns.Add($"AI, Confidence: {(result_from_model):F2}%");
                    }
                }
                string row=string.Join(";", columns);
                System.IO.File.AppendAllText(path, row + Environment.NewLine);
            }
            MessageBox.Show($"Sprawdznie folderu {mainFolderPath} zakończyło się.");
        }
        private void chooseFolder()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Wybierz folder z plikami do sprawdzenia. Plik csv z wynikami zostanie do niego zapisany.";
                folderDialog.ShowNewFolderButton = false;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    mainFolderPath = folderDialog.SelectedPath;
                    allImages = System.IO.Directory.GetFiles(mainFolderPath, "*.*", System.IO.SearchOption.AllDirectories)
                        .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".avi", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".mov", StringComparison.OrdinalIgnoreCase))
                        .ToArray();
                    if (allImages.Length == 0)
                    {
                        MessageBox.Show("Wybrany folder nie zawiera żadnych obrazów i/lub filmów.");
                        return;
                    }
                    MessageBox.Show($"Wybrano folder: {mainFolderPath}");
                }
            }
        }
    }
}
