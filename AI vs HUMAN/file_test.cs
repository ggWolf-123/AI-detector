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
        private string[] allFiles;
        private string mainFolderPath;
        private int folderFilesNumber=0;
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
            textBoxCheck.Hide();
            this.Load += startLoad;
            this.Resize += startResize;
        }

        /// <summary>
        ///    Change the language of the form and all controls on it. The text for each control is taken from the resources file, so it will be automatically updated when the language is changed. This method is called after changing the language to update the UI.
        /// </summary>
        private void ApplyLanguage()
        {
            this.Text = Properties.Resources.challangeBitton;
            LanguageManager.ApplyLanguageToControls(this);
        }
        /// <summary>
        ///     Change the language of the application when the changeLang button is clicked. It toggles between English and Polish. After changing the language, it calls ApplyLanguage() to update the UI with the new language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeLang_Click(object sender, EventArgs e)
        {
            if (LanguageManager.CurrentLanguage == "en")
            {
                LanguageManager.SetLanguage("pl");
            }
            else
            {
                LanguageManager.SetLanguage("en");
            }
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
        /// <param name="E"></param>
        private void startResize(object sender, EventArgs E)
        {
            ResizeControl.ResizeControlsRecursive(this);
        }
        /// <summary>
        ///     Go to the research tool form when the challangeBitton is clicked. It hides the current form, creates a new instance of the research_tool form, shows it as a dialog, and then closes the current form after the research_tool form is closed. This allows the user to switch between the file test form and the research tool form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void challangeBitton_Click(object sender, EventArgs e)
        {
            this.Hide();
            research_tool form_research_tool = new research_tool();
            form_research_tool.ShowDialog();
            this.Close();
        }
        /// <summary>
        ///     Chose a file to check when the getFileButton is clicked. It opens a file dialog that allows the user to select a media file (image, video, or text). After the user selects a file, it gets the file path and extension, and then calls the showFile method to display the selected file in the appropriate control (picture box for images, media player for videos, or text box for text files). This allows the user to see the content of the file they want to check before sending it to the model for analysis.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getFileButton_Click(object sender, EventArgs e)
        {
            filePathMain.Filter = "Media Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.mp4;*.avi;*.mov;*.txt";
            filePathMain.Title = "Wybierz plik";
            if (filePathMain.ShowDialog() == DialogResult.OK)
            {
                string filePath = this.filePathMain.FileName;
                string ext = System.IO.Path.GetExtension(filePath).ToLower();
                showFile(filePath,ext);
            }
        }
        /// <summary>
        ///     Send the selected file to the model for analysis when the checkButton is clicked. It first checks if a file has been selected, and if not, it shows a message box asking the user to select a file. If a file has been selected, it gets the file path and extension, and then sends the file to the appropriate API endpoint based on its type (image, video, or text). It then waits for the response from the model and updates the answerAIorNOT label with the result of the analysis. This allows the user to see whether the model thinks the content of the file is AI-generated or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void checkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePathMain.FileName))
            {
                MessageBox.Show("Nie podano pliku.");
                return;
            }
            try
            {
                buttonChange();
                string filePath= this.filePathMain.FileName;
                string ext = System.IO.Path.GetExtension(filePath).ToLower();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif")
                {
                    int result_from_model = await ApiComunication.SendImageToModel(this.filePathMain.FileName);
                    if (result_from_model == 0)
                        answerAIorNOT.Text = "Model mówi: to nie jest AI";
                    else if (result_from_model == 1)
                        answerAIorNOT.Text = "Model mówi: to jest AI";
                }
                else if (ext == ".mp4" || ext == ".avi" || ext == ".mov")
                {
                    
                    double result_from_model;
                    using (speed form_speed = new speed())
                    {
                        if(form_speed.ShowDialog() != DialogResult.OK)
                        {
                            buttonChange();
                            return;
                        }
                        int speed=form_speed.SelectedSpeed;
                        answerAIorNOT.Text = "Analizowanie trwa...";
                        result_from_model = await ApiComunication.AnalizeVideo(this.filePathMain.FileName, speed);
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
                buttonChange();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania pliku\n{ex.Message}");
                buttonChange();
                return;
            }
        }
        /// <summary>
        ///     Choose a folder and check all supported files in it when the checkFolderButton is clicked. It opens a folder browser dialog that allows the user to select a folder. After the user selects a folder, it gets all supported files (images, videos, and text files) in the folder and its subfolders, and then iterates through each file to analyze it using the same logic as in the checkButton_Click method. The results of the analysis for each file are saved in a CSV file named "result_of_folder_AI_DETECTOR.csv" in the selected folder. This allows the user to quickly analyze multiple files in a folder and have the results saved for later reference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            buttonChange();
            foreach (string file in allFiles)
            {
                var columns = new List<string> {System.IO.Path.GetFileName(file)};
                string ext = System.IO.Path.GetExtension(file).ToLower();
                showFile(file, ext);
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
                else if (ext == ".txt")
                {
                    string text = System.IO.File.ReadAllText(file);
                    text = await ApiComunication.SentTextToTranslate(text);
                    int result_from_model = await ApiComunication.SentTextToModel(text);
                    if (result_from_model == 0)
                        columns.Add("Not AI");
                    else if (result_from_model == 1)
                        columns.Add("AI");
                }
                else
                {
                    columns.Add("Unsupported file format");
                }
                string row = string.Join(";", columns);
                System.IO.File.AppendAllText(path, row + Environment.NewLine);
                answerAIorNOT.Hide();
                folderStatus.Text= $"Sprawdzono\n {columns[0]}\n ({allFiles.ToList().IndexOf(file) + 1}/{folderFilesNumber})";
            }
            buttonChange();
            MessageBox.Show($"Sprawdznie folderu {mainFolderPath} zakończyło się.");
        }
        /// <summary>
        /// Function to change the enabled state of the buttons on the form. It is used to disable the buttons while the model is analyzing a file, and then re-enable them after the analysis is complete. This prevents the user from trying to analyze another file while the current analysis is still in progress, which could cause errors or unexpected behavior.
        /// </summary>
        private void buttonChange()
        {
            checkButton.Enabled = !checkButton.Enabled;
            challangeBitton.Enabled = !challangeBitton.Enabled;
            getFileButton.Enabled = !getFileButton.Enabled;
            checkFolderButton.Enabled = !checkFolderButton.Enabled;
            changeLang.Enabled = !changeLang.Enabled;
        }
        /// <summary>
        ///     Choose a folder and get all supported files in it. It opens a folder browser dialog that allows the user to select a folder. After the user selects a folder, it gets all supported files (images, videos, and text files) in the folder and its subfolders, and stores them in the allFiles array. It also updates the folderFilesNumber variable with the number of supported files found in the folder. If no supported files are found, it shows a message box informing the user. This method is called when the user clicks the checkFolderButton to analyze multiple files in a folder.
        /// </summary>
        private void chooseFolder()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Wybierz folder z plikami do sprawdzenia. Plik csv z wynikami zostanie do niego zapisany.";
                folderDialog.ShowNewFolderButton = false;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    mainFolderPath = folderDialog.SelectedPath;
                    allFiles = System.IO.Directory.GetFiles(mainFolderPath, "*.*", System.IO.SearchOption.AllDirectories)
                        .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".avi", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".mov", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                        .ToArray();
                    folderFilesNumber= allFiles.Length;
                    if (allFiles.Length == 0)
                    {
                        MessageBox.Show("Wybrany folder nie zawiera żadnych obrazów, filmów ani plików tekstowych.");
                        return;
                    }
                    MessageBox.Show($"Wybrano folder: {mainFolderPath}");
                }
            }
        }
        /// <summary>
        ///     Show the selected file in the appropriate control based on its type. If the file is an image, it displays it in the pictureToCheck PictureBox. If the file is a video, it plays it in the axWindowsMediaPlayer1 control. If the file is a text file, it shows its content in the textBoxCheck TextBox. This method is called after the user selects a file to check, allowing them to see the content of the file before sending it to the model for analysis.
        /// </summary>
        /// <param name="filePath">The path of the file to display.</param>
        /// <param name="ext">The file extension of the file to display.</param>
        private void showFile(string filePath, string ext)
        {
            try
            {
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif")
                {
                    axWindowsMediaPlayer1.Hide();
                    textBoxCheck.Hide();
                    pictureToCheck.Show();
                    System.Drawing.Image img = System.Drawing.Image.FromFile(filePath);
                    pictureToCheck.Image = img;
                    pictureToCheck.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else if (ext == ".mp4" || ext == ".avi" || ext == ".mov")
                {
                    pictureToCheck.Hide();
                    textBoxCheck.Hide();
                    axWindowsMediaPlayer1.Show();
                    this.axWindowsMediaPlayer1.URL = filePath;
                    this.axWindowsMediaPlayer1.Ctlcontrols.play();
                }
                else if (ext == ".txt")
                {
                    pictureToCheck.Hide();
                    axWindowsMediaPlayer1.Hide();
                    textBoxCheck.Show();
                    textBoxCheck.ReadOnly = true;
                    string text = System.IO.File.ReadAllText(filePath);
                    textBoxCheck.Text = text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania pliku\n{ex.Message}");
            }
        }
    }
}
