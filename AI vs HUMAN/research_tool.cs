using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace AI_vs_HUMAN
{
    public partial class research_tool : Form
    {
        private System.Drawing.Size originalSize;
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private string mainFolderPath;
        private string selectdImagePath;
        private string[] allFiles;
        private int result_from_model = -1;
        private int rightHumanAnswers = 0;
        private int wrongHumanAnswers = 0;
        private int rightAiAnswers = 0;
        private int wrongAiAnswers = 0;
        private int timeLeft;
        private int timeOfResearch = 0;
        private int points = 0;
        private int AIpoints = 0;
        private Timer gameTimer;
        private bool isGameActive = false;
        private int imgLimit = 0;
        private double result_from_model_video;
        private bool gameCancelled = false;
        private Random rnd = new Random();


        public research_tool()
        {
            LanguageManager.SetLanguage(LanguageManager.CurrentLanguage);
            InitializeComponent();
            ApplyLanguage();
            axWindowsMediaPlayer1.Hide();
            textBoxRandomText.Hide();
            textBoxRandomText.ReadOnly = true;
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
            if (Properties.Settings.Default.askTimeMax || Properties.Settings.Default.askSaveHowLong)
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
        private void endButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            file_test test_Obrazu = new file_test();
            test_Obrazu.ShowDialog();
            this.Close();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            chooseFolder();
        }

        private void chooseFolder()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Wybierz główny folder z obrazami";
                folderDialog.ShowNewFolderButton = false;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    mainFolderPath = folderDialog.SelectedPath;
                    actualizeFolderFiles();
                    randomFilePrepare();
                    startGameButton.SendToBack();
                    MessageBox.Show($"Wybrano folder: {mainFolderPath}");
            }
        }
    }
        private void actualizeFolderFiles()
        {
            if (!string.IsNullOrEmpty(mainFolderPath))
            {
                var allowedExension = new List<String>();
                if (Properties.Settings.Default.askImageIn)
                    allowedExension.AddRange(new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" });
                if (Properties.Settings.Default.askVideoIn)
                    allowedExension.AddRange(new[] { ".mp4", ".avi", ".mov" });
                if (Properties.Settings.Default.askTextIn)
                    allowedExension.Add(".txt");
                allFiles = System.IO.Directory.GetFiles(mainFolderPath, "*.*", System.IO.SearchOption.AllDirectories)
                    .Where(file => allowedExension.Contains(System.IO.Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
                    .ToArray();
                if (allFiles.Length == 0)
                {
                    MessageBox.Show("Wybrany folder nie zawiera żadnych plików o wybranym formacie.");
                    return;
                }
            }
        }
        private async void randomFilePrepare()
        {
            selectdImagePath = allFiles[rnd.Next(allFiles.Length)];
            await Task.Delay(200);
            string ext = System.IO.Path.GetExtension(selectdImagePath).ToLower();
            try
            {
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif")
                {
                    axWindowsMediaPlayer1.URL = "";
                    axWindowsMediaPlayer1.Hide();
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    textBoxRandomText.Hide();
                    randomPhoto.Show();
                    randomPhoto.Image = System.Drawing.Image.FromFile(selectdImagePath);
                    randomPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else if (ext == ".mp4" || ext == ".avi" || ext == ".mov")
                {
                    randomPhoto.Hide();
                    textBoxRandomText.Hide();
                    axWindowsMediaPlayer1.Show();
                    this.axWindowsMediaPlayer1.URL = selectdImagePath;
                    this.axWindowsMediaPlayer1.Ctlcontrols.play();
                }
                else if (ext== ".txt")
                {
                    textBoxRandomText.Show();
                    randomPhoto.Hide();
                    axWindowsMediaPlayer1.Hide();
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    string textContent = File.ReadAllText(selectdImagePath);
                    textBoxRandomText.Text = textContent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania pliku\n{ex.Message}");
            }
            yesButton.Enabled = true;
            noButton.Enabled = true;
        }
        private async Task randomFileAiCheck()
        {
            string ext = System.IO.Path.GetExtension(selectdImagePath).ToLower();
            try
            {
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif")
                {
                    result_from_model = await ApiComunication.SendImageToModel(selectdImagePath);
                }
                else if (ext == ".mp4" || ext == ".avi" || ext == ".mov")
                {
                    result_from_model_video = await ApiComunication.AnalizeVideo(selectdImagePath, 180);
                    if (result_from_model_video < 50) //result_from_model is a percentage of frames classified as AI, so if it's less than 50%, we say it's not AI
                    {
                        result_from_model = 0;
                    }
                    else
                    {
                        result_from_model = 1;
                    }
                }
                else if (ext == ".txt")
                {
                    result_from_model = await ApiComunication.SentTextToModel(textBoxRandomText.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas sprawdzania pliku przez AI\n{ex.Message}");
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
                    timeLeft = Properties.Settings.Default.numericSeconds;
                    gameTimer.Stop();
                    gameTimer.Start();
                }
            }
            buttonsEnabledChange(false);
            if (Properties.Settings.Default.aiAnswersToo)
            {
                await randomFileAiCheck();
            }
            if (gameCancelled || !isGameActive)
            {
                return;
            }
            int answerHuman = 0;
            await liderBoard(selectdImagePath, result_from_model, answerHuman);
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
                    timeLeft = Properties.Settings.Default.numericSeconds;
                    gameTimer.Stop();
                    gameTimer.Start();
                }
            }
            buttonsEnabledChange(false);
            if (Properties.Settings.Default.aiAnswersToo)
            {
                await randomFileAiCheck();
            }
            if(gameCancelled || !isGameActive)
            {
                return;
            }
            int answerHuman = 1;
            await liderBoard(selectdImagePath, result_from_model, answerHuman);
        }
        private void buttonsEnabledChange(bool enabled)
        {
            settingsOfData.Enabled = enabled;
            changeLang.Enabled = enabled;
            restartButton.Enabled = enabled;
            endButton.Enabled = enabled;
            noButton.Enabled = enabled;
            yesButton.Enabled = enabled;
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectdImagePath))
            {
                MessageBox.Show("Najpierw rozpocznij grę.");
                return;
            }
            chooseFolder();
            ResetGameLogic();
        }
        private void AddToFile(string filePath, int correctAnswer, int answerHuman, int answerAi)
        {
            string folderPath = Properties.Settings.Default.SaveFolderPath;
            int sessionNumber = Properties.Settings.Default.numberOfSeasion;
            string saveFilePath = System.IO.Path.Combine(folderPath, $"session_{sessionNumber}.txt");
            string aiOrHuman = correctAnswer == 1 ? "AI" : "HUMAN";
            string humanAnswer = answerHuman == 1 ? "AI" : "HUMAN";
            string aiAnswer = answerAi == 1 ? "AI" : "HUMAN";

            List<string> list = new List<string>
            {
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                filePath,
                aiOrHuman,
                humanAnswer
            };
            if (Properties.Settings.Default.aiAnswersToo)
            {
                list.Add(aiAnswer);
            }
            string line = string.Join(";", list);
            try
            {
                bool fileExists = File.Exists(saveFilePath);
                bool fileEmpty = fileExists ? new FileInfo(saveFilePath).Length == 0 : true;
                using (StreamWriter writer = new StreamWriter(saveFilePath, append: true))
                {
                    if(!fileExists || fileEmpty)
                    {
                        List<string> headerList = new List<string>
                        {
                            "Timestamp",
                            "FilePath",
                            "CorrectAnswer",
                            "HumanAnswer"
                        };
                        if (Properties.Settings.Default.aiAnswersToo)
                        {
                            headerList.Add("AIAnswer");
                        }
                        string headerLine = string.Join(";", headerList);
                        writer.WriteLine(headerLine);
                    }
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
                    selectdImagePath = @"..\..\images_yes_no\NO.png";
                randomPhoto.Image = System.Drawing.Image.FromFile(selectdImagePath);
                randomPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                
            }
            if (Properties.Settings.Default.askSavePaths)
            {
                AddToFile(imagePath, rightAnswers,answerHuman,answerAI);
            }
            if (Properties.Settings.Default.askLimitImg)
            {
                imgLimit++;
                if (imgLimit >= Properties.Settings.Default.numericImgLimit)
                {
                    EndOfResearch();
                    return;
                }
            }
            randomFilePrepare();
        }
        
        private void GameTimerTick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
            }
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
            gameCancelled = true;
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
                points = 0;
                rightHumanAnswers = 0;
                wrongHumanAnswers = 0;
            }
            if (Properties.Settings.Default.aiAnswersToo)
            {
                AIpoints= (Properties.Settings.Default.addPoint * rightAiAnswers) + (Properties.Settings.Default.takePoint * wrongAiAnswers);
            }
            else
            {
                AIpoints = 0;
                rightAiAnswers = 0;
                wrongAiAnswers = 0;
            }
            if (!Properties.Settings.Default.funMode)
            {
                save_result results = new save_result(points, rightHumanAnswers, wrongHumanAnswers, AIpoints, rightAiAnswers, wrongAiAnswers, timeOfResearch);
                results.ShowDialog();
            }
            ResetGameLogic();
        }
        private void ResetGameLogic()
        {
            gameCancelled = false;
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
            randomFilePrepare();
            previousAnswer.Text = "";
            previousTitle.Text = "";
            points = 0;
            AIpoints = 0;
            buttonsEnabledChange(true);
            isGameActive = false;
            timeOfResearch = 0;
            rightHumanAnswers = 0;
            wrongHumanAnswers = 0;
            rightAiAnswers = 0;
            wrongAiAnswers = 0;
            imgLimit = 0;
            if (Properties.Settings.Default.showHumanAnswers)
            {
                youRight.Text = "Miałeś/-aś rację : " + rightHumanAnswers;
                youWrong.Text = "Pomyliłeś/-łaś się: " + wrongHumanAnswers;
            }
            if (Properties.Settings.Default.showAiAnswers)
            {
                aiRight.Text = "AI miało rację : " + rightAiAnswers;
                aiWrong.Text = "AI pomyliło się : " + wrongAiAnswers;
            }
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
                    youRight.Text = "Miałeś/-aś rację : 0";
                    youWrong.Text = "Pomyliłeś/-łaś się: 0";
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
                    aiRight.Text = "AI miało rację : 0";
                    aiWrong.Text = "AI pomyliło się : 0";
                }
                if(Properties.Settings.Default.newQuestion)
                {
                    questionMG.Text = Properties.Settings.Default.yourQuestion;
                }
                actualizeFolderFiles();
                if(!string.IsNullOrEmpty(mainFolderPath))
                    randomFilePrepare();
            };
            researchSetting.ShowDialog();
        }
    }
}