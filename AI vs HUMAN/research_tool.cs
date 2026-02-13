using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_vs_HUMAN
{
    public partial class research_tool : Form
    {
        private Size originalSize;
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private string mainFolderPath;
        private string selectdImagePath;
        private string[] allImages;
        private int result_from_model = -1;
        private int rightHumanAnswers = 0;
        private int wrongHumanAnswers = 0;
        private int rightAiAnswers = 0;
        private int wrongAiAnswers = 0;
        private int timeLeft = 60;
        private int points = 0;
        private System.Windows.Forms.Timer gameTimer;
        private bool isGameActive = false;
        private int imgLimit = 0;

        public research_tool()
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
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimerTick;
            timeLabel.Text = "Czas: 60s"; //do zmiany na podstawie języka
        }
        private void startResize(object sender, EventArgs E)
        {
            ResizeControl.ResizeControlsRecursive(this, originalControlBounds, originalSize);
        }
        private void button1_Click(object sender, EventArgs e) //endButton
        {
            this.Hide();
            file_test test_Obrazu = new file_test();
            test_Obrazu.ShowDialog();
            this.Close();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Wybierz główny folder z obrazami";
                folderDialog.ShowNewFolderButton = false;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    mainFolderPath = folderDialog.SelectedPath;
                    allImages = System.IO.Directory.GetFiles(mainFolderPath, "*.*", System.IO.SearchOption.AllDirectories)
                        .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                        .ToArray();
                    if (allImages.Length == 0)
                    {
                        MessageBox.Show("Wybrany folder nie zawiera żadnych obrazów.");
                        return;
                    }
                    Random rnd = new Random();
                    selectdImagePath = allImages[rnd.Next(allImages.Length)];
                    randomPhoto.Image = Image.FromFile(selectdImagePath);
                    randomPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                    startGameButton.SendToBack();
                    MessageBox.Show($"Wybrano folder: {mainFolderPath}");
                }
            }
        }

        private async void noButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectdImagePath))
            {
                MessageBox.Show("Najpierw rozpocznij grę.");
                return;
            }
            if (!isGameActive)
            {
                isGameActive = true;
                gameTimer.Stop();
                timeLeft = 60;
                timeLabel.Text = "Czas: 60s";
                gameTimer.Start();
                settingsOfData.Enabled = false;
            }
            result_from_model = await ApiComunication.SendImageToModel(selectdImagePath);
            int answerHuman = 0;
            liderBoard(selectdImagePath, result_from_model, answerHuman);
        }

        private async void yesButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectdImagePath))
            {
                MessageBox.Show("Najpierw rozpocznij grę.");
                return;
            }
            if (!isGameActive)
            {
                isGameActive = true;
                gameTimer.Stop();
                timeLeft = 60;
                timeLabel.Text = "Czas: 60s";
                gameTimer.Start();
                settingsOfData.Enabled = false;
            }
            result_from_model = await ApiComunication.SendImageToModel(selectdImagePath);
            int answerHuman = 1;
            liderBoard(selectdImagePath, result_from_model, answerHuman);
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectdImagePath))
            {
                MessageBox.Show("Najpierw rozpocznij grę.");
                return;
            }
            ResetGameLogic();
        }
        private void liderBoard(string imagePath, int answerAI, int answerHuman)
        {
            int rightAnswers = -1;
            string diretoryOfImage = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(imagePath));
            previousTitle.Text = "Poprzednie zdjęcie/grafika";
            if (diretoryOfImage == "AI")
            {
                rightAnswers = 1;
                previousAnswer.Text = "była wygenerowana przez AI";
            }
            else if (diretoryOfImage == "HUMAN")
            {
                rightAnswers = 0;
                previousAnswer.Text = "nie była wygenerowana przez AI";
            }
            if (rightAnswers == answerHuman)
            {
                rightHumanAnswers++;
                youRight.Text = "Miałeś/-aś rację : " + rightHumanAnswers;
                points++;
            }
            else
            {
                wrongHumanAnswers++;
                youWrong.Text = "Pomyliłeś/-łaś się: " + wrongHumanAnswers;
                points--;
            }
            if (rightAnswers == answerAI)
            {
                rightAiAnswers++;
                aiRight.Text = "AI miało rację : " + rightAiAnswers;
            }
            else
            {
                wrongAiAnswers++;
                aiWrong.Text = "AI pomyliło się : " + wrongAiAnswers;
                if (rightAnswers == answerHuman)
                {
                    points += 3;
                }
            }
            Random rnd = new Random();
            if (Properties.Settings.Default.askLimitImg)
            {
                imgLimit++;
                if (imgLimit >= Properties.Settings.Default.numericImgLimit)
                {
                    MessageBox.Show("Koniec.");
                    ResetGameLogic();
                    return;
                }
            }
            selectdImagePath = allImages[rnd.Next(allImages.Length)];
            randomPhoto.Image = Image.FromFile(selectdImagePath);
            randomPhoto.SizeMode = PictureBoxSizeMode.Zoom;
        }
        
        private void GameTimerTick(object sender, EventArgs e)
        {
            timeLeft--;
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;
            timeLabel.Text = $"{minutes:D2}:{seconds:D2}";
            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                yesButton.Enabled = false;
                noButton.Enabled = false;
                MessageBox.Show($"Koniec gry! Twój czas minął. Zdobyłeś tyle punktów {points}");
                zapis_wyników zapisWynikówForm = new zapis_wyników(points);
                zapisWynikówForm.ShowDialog();
                ResetGameLogic();
            }
        }
        private void ResetGameLogic()
        {
            isGameActive = false;
            gameTimer.Stop();
            timeLeft = 60;
            timeLabel.Text = "Czas: 60s";
            yesButton.Enabled = true;
            noButton.Enabled = true;
            rightHumanAnswers = 0;
            youRight.Text = "Miałeś/-aś rację : " + rightHumanAnswers;
            wrongHumanAnswers = 0;
            youWrong.Text = "Pomyliłeś/-łaś się: " + wrongHumanAnswers;
            rightAiAnswers = 0;
            aiRight.Text = "AI miało rację : " + rightAiAnswers;
            wrongAiAnswers = 0;
            aiWrong.Text = "AI pomyliło się : " + wrongAiAnswers;
            Random rnd = new Random();
            selectdImagePath = allImages[rnd.Next(allImages.Length)];
            randomPhoto.Image = Image.FromFile(selectdImagePath);
            randomPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            previousAnswer.Text = "";
            previousTitle.Text = "";
            previousTitle.Text = "";
            points = 0;
            settingsOfData.Enabled = true;
            isGameActive = false;
        }

        private void settingsOfData_Click(object sender, EventArgs e)
        {
            research_setting researchSetting = new research_setting();
            researchSetting.ShowDialog();
        }
    }
}