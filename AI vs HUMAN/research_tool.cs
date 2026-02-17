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
using System.Threading.Tasks;
using System.IO;

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
        private int timeLeft;
        private int timeOfResearch=0;
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
            if (!Properties.Settings.Default.showHumanAnswers)
            {
                humanScore.Text = "";
                youRight.Text = "";
                youWrong.Text = "";
            }
            else
            {
                humanScore.Text = "Twój wynik";
                youRight.Text = "Miałeś/-aś rację : ";
                youWrong.Text = "Pomyliłeś/-łaś się: ";
            }

            if (!Properties.Settings.Default.showAiAnswers)
            {
                aiScore.Text = "";
                aiRight.Text = "";
                aiWrong.Text = "";
            }
            else
            {
                aiScore.Text = "Wynik AI";
                aiRight.Text = "AI miało rację : ";
                aiWrong.Text = "AI pomyliło się : ";
            }
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
            if(Properties.Settings.Default.askTimeMax || Properties.Settings.Default.askSaveHowLong)
            {
                gameTimer = new System.Windows.Forms.Timer();
                gameTimer.Interval = 1000;
                gameTimer.Tick += GameTimerTick;
            }
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
                if (Properties.Settings.Default.askTimeMax || Properties.Settings.Default.askSaveHowLong)
                {
                    gameTimer.Stop();
                    gameTimer.Start();
                }
                settingsOfData.Enabled = false;
            }
            if(Properties.Settings.Default.aiAnswersToo)
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
                if (Properties.Settings.Default.askTimeMax || Properties.Settings.Default.askSaveHowLong)
                {
                    gameTimer.Stop();
                    gameTimer.Start();
                }
                settingsOfData.Enabled = false;
            }
            if (Properties.Settings.Default.aiAnswersToo)
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
        private void AddToFile(string imagePath, int correctAnswer, int answerHuman, int answerAi)
        {
            string folderPath = Properties.Settings.Default.SaveFolderPath;
            int sessionNumber = Properties.Settings.Default.numberOfSeasion;
            string filePath = System.IO.Path.Combine(folderPath, $"session_{sessionNumber}.txt");
            string line;
            string aiOrHuman = correctAnswer == 1 ? "AI" : "HUMAN";
            string humanAnswer = answerHuman == 1 ? "AI" : "HUMAN";
            string aiAnswer = answerAi == 1 ? "AI" : "HUMAN";

            if (Properties.Settings.Default.aiAnswersToo)
            {
                line = $" {DateTime.Now}: {selectdImagePath} | Right answer: {aiOrHuman} | Your answer: {humanAnswer} | AI answer: {aiAnswer}";
            }
            else
            {
                line = $" {DateTime.Now}: {selectdImagePath} | Right answer: {aiOrHuman} | Your answer: {humanAnswer}";
            }
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zapisywania danych: {ex.Message}");
            }
        }
        private async Task liderBoard(string imagePath, int answerAI, int answerHuman)
        {
            yesButton.Enabled = false;
            noButton.Enabled = false;
            int rightAnswers = -1;
            string diretoryOfImage = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(imagePath));
            if(Properties.Settings.Default.wasThatAi)
                previousTitle.Text = "Poprzednie zdjęcie/grafika";
            if (diretoryOfImage == "AI")
            {
                rightAnswers = 1;
                if (Properties.Settings.Default.wasThatAi)
                    previousAnswer.Text = " była wygenerowana przez AI";
            }
            else if (diretoryOfImage == "HUMAN")
            {
                rightAnswers = 0;
                if (Properties.Settings.Default.wasThatAi)
                    previousAnswer.Text = "nie była wygenerowana przez AI";
            }
            if (rightAnswers == answerHuman)
            {
                rightHumanAnswers++;
                if(Properties.Settings.Default.showHumanAnswers)
                    youRight.Text = "Miałeś/-aś rację : " + rightHumanAnswers;
            }
            else
            {
                wrongHumanAnswers++;
                if (Properties.Settings.Default.showHumanAnswers)
                    youWrong.Text = "Pomyliłeś/-łaś się: " + wrongHumanAnswers;
            }
            if (rightAnswers == answerAI)
            {
                rightAiAnswers++;
                if (Properties.Settings.Default.showAiAnswers)
                    aiRight.Text = "AI miało rację : " + rightAiAnswers;
            }
            else
            {
                wrongAiAnswers++;
                if (Properties.Settings.Default.showAiAnswers)
                    aiWrong.Text = "AI pomyliło się : " + wrongAiAnswers;
            }
            if(Properties.Settings.Default.showAnswerByColor)
            {
                if (rightAnswers == answerHuman)
                    selectdImagePath = @"..\..\images_yes_no\YES.png";
                else
                    selectdImagePath = @"..\..\images_yes_no\YES.png";
                randomPhoto.Image = Image.FromFile(selectdImagePath);
                randomPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                
            }
            if (Properties.Settings.Default.askSavePaths)
            {
                AddToFile(imagePath, rightAnswers,answerHuman,answerAI);
            }
            Random rnd = new Random();
            if (Properties.Settings.Default.askLimitImg)
            {
                imgLimit++;
                if (imgLimit >= Properties.Settings.Default.numericImgLimit)
                {
                    MessageBox.Show("Koniec.");
                    EndOfResearch();
                    return;
                }
            }
            selectdImagePath = allImages[rnd.Next(allImages.Length)];
            await Task.Delay(200);
            randomPhoto.Image = Image.FromFile(selectdImagePath);
            randomPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            yesButton.Enabled = true;
            noButton.Enabled = true;
        }
        
        private void GameTimerTick(object sender, EventArgs e)
        {
            timeLeft--;
            timeOfResearch++;
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;
            if(Properties.Settings.Default.askTimeMax)
            {
                timeLabel.Text = $"{minutes:D2}:{seconds:D2}";
            }
            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                yesButton.Enabled = false;
                noButton.Enabled = false;
                EndOfResearch();
            }
        }
        private void EndOfResearch()
        {
            if (Properties.Settings.Default.pointAskBox)
            {
                points = (Properties.Settings.Default.addPoint * rightHumanAnswers) + (Properties.Settings.Default.takePoint * wrongHumanAnswers);
                if (Properties.Settings.Default.showResult)
                {
                    MessageBox.Show($"Koniec gry!. Zdobyłeś tyle punktów {points}");
                }
                else
                {
                    MessageBox.Show($"Koniec gry!");
                }
            }
            else
            {
                MessageBox.Show($"Koniec gry! Twój czas minął.");
            }
            if(!Properties.Settings.Default.funMode)
            {
                zapis_wyników zapisWynikówForm = new zapis_wyników(points);
                zapisWynikówForm.ShowDialog();
            }
            ResetGameLogic();
        }
        private void ResetGameLogic()
        {
            isGameActive = false;
            if (Properties.Settings.Default.askTimeMax || Properties.Settings.Default.askSaveHowLong)
            {
                gameTimer.Stop();
                timeLeft = Properties.Settings.Default.numericSeconds;
                if(Properties.Settings.Default.askTimeMax)
                    timeLabel.Text = $"Czas: {Properties.Settings.Default.numericSeconds}s";
            }
            else
            {
                timeLabel.Text = "";
            }
            timeOfResearch = 0;
            yesButton.Enabled = true;
            noButton.Enabled = true;
            rightHumanAnswers = 0;
            wrongHumanAnswers = 0;
            rightAiAnswers = 0;
            wrongAiAnswers = 0;
            if (Properties.Settings.Default.showHumanAnswers)
            {
                youRight.Text = "Miałeś/-aś rację : " + rightHumanAnswers;
                youWrong.Text = "Pomyliłeś/-łaś się: " + wrongHumanAnswers;
            }
            if (Properties.Settings.Default.wasThatAi)
            {
                aiRight.Text = "AI miało rację : " + rightAiAnswers;
                aiWrong.Text = "AI pomyliło się : " + wrongAiAnswers;
            }
            Random rnd = new Random();
            selectdImagePath = allImages[rnd.Next(allImages.Length)];
            randomPhoto.Image = Image.FromFile(selectdImagePath);
            randomPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            previousAnswer.Text = "";
            previousTitle.Text = "";
            points = 0;
            settingsOfData.Enabled = true;
            isGameActive = false;
            if (Properties.Settings.Default.askSavePaths)
            {
                Properties.Settings.Default.numberOfSeasion++;
                Properties.Settings.Default.Save();
            }
        }

        private void settingsOfData_Click(object sender, EventArgs e)
        {
            research_setting researchSetting = new research_setting();
            researchSetting.FormClosed += (s, args) =>
            {
                if (Properties.Settings.Default.askTimeMax)
                {
                    timeLeft = Properties.Settings.Default.numericSeconds;
                    timeLabel.Text = $"Czas: {Properties.Settings.Default.numericSeconds}s";
                }
                else
                {
                    timeLabel.Text = "";
                }
                if (!Properties.Settings.Default.showHumanAnswers)
                {
                    humanScore.Text = "";
                    youRight.Text = "";
                    youWrong.Text = "";
                }
                else
                {
                    humanScore.Text = "Twój wynik";
                    youRight.Text = "Miałeś/-aś rację : ";
                    youWrong.Text = "Pomyliłeś/-łaś się: ";
                }

                if (!Properties.Settings.Default.showAiAnswers)
                {
                    aiScore.Text = "";
                    aiRight.Text = "";
                    aiWrong.Text = "";
                }
                else
                {
                    aiScore.Text = "Wynik AI";
                    aiRight.Text = "AI miało rację : ";
                    aiWrong.Text = "AI pomyliło się : ";
                }
            };
            researchSetting.ShowDialog();
        }
    }
}