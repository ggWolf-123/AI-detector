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
        private bool isVideoProcessing = false;
        private Random rnd = new Random();


        public research_tool()
        {
            LanguageManager.SetLanguage(LanguageManager.CurrentLanguage);
            InitializeComponent();
            ApplyLanguage();
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimerTick;
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
                LanguageManager.ChangeLanguage("pl");
            }
            else
            {
                LanguageManager.ChangeLanguage("en");
            }
            ApplyLanguage();
        }

        /// <summary>
        ///     Change the size of the form and all controls on it when the form is resized. It stores the original size of the form and the original bounds of all controls when the form is loaded, and then resizes the controls proportionally to the new size of the form when it is resized. This ensures that the layout of the form remains consistent regardless of its size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startLoad(object sender, EventArgs e)
        {
            originalSize = this.Size;
            ResizeControl.StoreOriginalBoundsRecursive(this, originalControlBounds);
        }
        /// <summary>
        ///     Change the size of the form and all controls on it when the form is resized. It calls the ResizeControlsRecursive method to resize all controls based on the original size and bounds stored during the startLoad event. This ensures that the layout of the form remains consistent regardless of its size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="E"></param>
        private void startResize(object sender, EventArgs E)
        {
            ResizeControl.ResizeControlsRecursive(this, originalControlBounds, originalSize);
        }
        /// <summary>
        ///  Choose a folder containing images for the game. It opens a FolderBrowserDialog to allow the user to select a folder, and then checks if the selected folder is valid (contains the required structure). If the folder is valid, it prepares a random file from the folder for the game and updates the UI accordingly. If the folder is not valid or if no folder is selected, it shows an error message.
        /// </summary>
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
                    if (string.IsNullOrEmpty(mainFolderPath))
                    {
                        MessageBox.Show("Nie wybrano folderu.");
                        return;
                    }
                    if (!isFolderOK())
                    {
                        MessageBox.Show("Strtuktura wybranego folderu jest nieprawidłowa, sprawdź ją w README.");
                        return;
                    }
                    randomFilePrepare();
                    startGameButton.SendToBack();
                    MessageBox.Show($"Wybrano folder: {mainFolderPath}");
            }
        }
    }
        /// <summary>
        /// Check if the selected folder has the correct structure for the game. It verifies that the folder contains exactly two subfolders named "AI" and "HUMAN" (case-insensitive). If the folder structure is correct, it returns true; otherwise, it returns false. This method is used to ensure that the game can properly access the files needed for the gameplay.
        /// </summary>
        /// <returns>True if the folder structure is correct; otherwise, false.</returns>
        private bool isFolderOK()
        {
            int folderCount = 0;
            string dirName;
            bool aiFolder = false, humanFolder = false;
            foreach (var dir in Directory.GetDirectories(mainFolderPath))
            {
                dirName = Path.GetFileName(dir);
                if (dirName.Equals("AI", StringComparison.OrdinalIgnoreCase))
                {
                    aiFolder = true;
                }
                else if (dirName.Equals("HUMAN", StringComparison.OrdinalIgnoreCase))
                {
                    humanFolder = true;
                }
                folderCount++;
            }
            if (folderCount != 2 || !aiFolder || !humanFolder)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        ///     Actualize the list of files in the selected folder based on the allowed extensions. It checks the settings to determine which types of files (images, videos, text) are allowed, and then retrieves all files from the selected folder and its subfolders that match the allowed extensions. If no valid files are found, it shows an error message. This method is called after selecting a folder to ensure that the game has a valid set of files to work with.
        /// </summary>
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
        /// <summary>
        ///     Prepeara a random file from the list of files in the selected folder for the game. It randomly selects a file from the list of valid files, checks its extension to determine how to display it (as an image, video, or text), and updates the UI accordingly. If the file is an image, it displays it in a PictureBox; if it's a video, it plays it in a media player; if it's a text file, it shows the content in a TextBox. This method is called at the start of the game and after each round to present a new file for the player to evaluate.
        /// </summary>
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
                    using (var img = System.Drawing.Image.FromFile(selectdImagePath))
                    {
                        randomPhoto.Image = new Bitmap(img);
                    }
                    randomPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else if (ext == ".mp4" || ext == ".avi" || ext == ".mov")
                {
                    isVideoProcessing = true;
                    randomPhoto.Hide();
                    textBoxRandomText.Hide();
                    axWindowsMediaPlayer1.Show();
                    this.axWindowsMediaPlayer1.URL = selectdImagePath;
                    this.axWindowsMediaPlayer1.Ctlcontrols.play();
                    _= randomFileAiCheck();
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
        /// <summary>
        ///  Check a file using an AI model by sending it to an API. It determines the type of the file based on its extension and sends it to the appropriate API endpoint for analysis. If the file is an image, it sends it to the image analysis endpoint; if it's a video, it sends it to the video analysis endpoint; if it's a text file, it sends the text content to the text analysis endpoint. The result from the model is stored in variables for later use in determining the player's score. This method is called after the player makes a choice (yes or no) to evaluate their answer against the AI's analysis.
        /// </summary>
        /// <returns>0 if the file is not AI, 1 if the file is AI</returns>
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
                isVideoProcessing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas sprawdzania pliku przez AI\n{ex.Message}");
            }
        }

        /// <summary>
        ///  Add the result of a round to a file for later analysis. It constructs a line of data containing the timestamp, file path, correct answer (whether the file was AI or HUMAN), the player's answer, and optionally the AI's answer if that setting is enabled. It then writes this line to a text file in a specified folder, creating the file if it doesn't exist and adding a header if the file is new or empty. This allows the player to keep a record of their gameplay and analyze their performance over time.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="correctAnswer"></param>
        /// <param name="answerHuman"></param>
        /// <param name="answerAi"></param>
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
        /// <summary>
        ///  Change the leaderboard and update the player's score based on their answer and the AI's answer. It checks the correct answer for the current file, compares it with the player's answer and the AI's answer, and updates the counts of right and wrong answers for both the player and the AI. It also updates the UI to show the current scores and, if enabled, changes the color of the displayed image to indicate whether the player's answer was correct or not. Finally, it prepares a new random file for the next round of the game. This method is called after each round to keep track of the player's performance and provide feedback on their answers.
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="answerAI"></param>
        /// <param name="answerHuman"></param>
        /// <returns></returns>
        private async Task liderBoard(string imagePath, int answerAI, int answerHuman)
        {
            yesButton.Enabled = false;
            noButton.Enabled = false;
            string ext = System.IO.Path.GetExtension(imagePath).ToLower();
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
        /// <summary>
        ///     Time management for the game. It decreases the time left for the player to answer each question every second, and when the time runs out, it ends the game. It also keeps track of the total time of research and updates the UI to show the remaining time in minutes and seconds format. This method is called by a Timer control that ticks every second during the game to manage the time limit for each round.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        ///     Event handler for the end of the research/game. It calculates the final points for the player and the AI based on the number of right and wrong answers, shows a message with the final score (if enabled), and then resets the game logic to allow for a new game to be started. It also saves the results if that setting is enabled. This method is called when the time runs out or when the player reaches the image limit, signaling the end of the current game session.
        /// </summary>
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
        /// <summary>
        ///     Function to reset the game logic and prepare for a new game. It resets all relevant variables, stops the timer, updates the UI to reflect the reset state, and prepares a new random file for the next game. This method is called at the end of each game session to allow the player to start a new game with a fresh state. It ensures that all counters and settings are reset to their initial values, providing a consistent starting point for each new game.
        /// </summary>
        private void ResetGameLogic()
        {
            gameCancelled = false;
            isGameActive = false;
            if (Properties.Settings.Default.askTimeMax || Properties.Settings.Default.askSaveHowLong)
            {
                if(gameTimer != null)
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
        /// <summary>
        ///     Button click event handler to enable or disable the game buttons based on the current state of the game. It takes a boolean parameter "enabled" to determine whether the buttons should be enabled or disabled. This method is called to prevent the player from interacting with the game buttons when it's not appropriate (e.g., when the game is over or when a new file is being prepared), ensuring a smooth and controlled gameplay experience.
        /// </summary>
        /// <param name="enabled"></param>
        private void buttonsEnabledChange(bool enabled)
        {
            settingsOfData.Enabled = enabled;
            if (Properties.Settings.Default.askLimitImg || Properties.Settings.Default.askTimeMax)
            {
                restartButton.Enabled = enabled;
                goBackButton.Enabled = enabled;
            }
            changeLang.Enabled = enabled;
            noButton.Enabled = enabled;
            yesButton.Enabled = enabled;
        }
        /// <summary>
        ///     Function to handle the click event for both the "Yes" and "No" buttons. It checks if a folder has been selected and if the game is active, and if not, it shows a message prompting the user to start the game first. If the game is not active, it starts the game and initializes the timer if necessary. It then disables the buttons to prevent further clicks while processing the current answer, and if the setting to have AI answers is enabled, it calls the method to check the file with the AI model. This method serves as a common handler for both answer buttons to manage the game state and prepare for evaluating the player's answer against the AI's analysis.
        /// </summary>
        private async Task yes_no_Click()
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
                    if (gameTimer != null)
                    {
                        gameTimer.Stop();
                        gameTimer.Start();
                    }
                }
            }
            buttonsEnabledChange(false);
            string ext = System.IO.Path.GetExtension(selectdImagePath).ToLower();
            if (ext==".mp4" || ext==".mov" || ext == ".avi")
            {
                while (isVideoProcessing)
                {
                    await Task.Delay(100);
                }
            }
            if (Properties.Settings.Default.aiAnswersToo && !System.IO.Path.GetExtension(selectdImagePath).ToLower().Equals(".mp4") && !System.IO.Path.GetExtension(selectdImagePath).ToLower().Equals(".mov") && !System.IO.Path.GetExtension(selectdImagePath).ToLower().Equals(".avi"))
            {
                await randomFileAiCheck();
            }
        }
        /// <summary>
        ///  Button click event handler for the "No" button. It calls the common handler yes_no_Click() to manage the game state and prepare for evaluating the player's answer. If the game has been cancelled or is not active, it returns early. Otherwise, it sets the player's answer to 0 (indicating "No") and calls the liderBoard() method to update the leaderboard and prepare for the next round of the game. This method allows the player to submit their answer and proceed with the game flow after clicking "No".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void noButton_Click(object sender, EventArgs e)
        {
            await yes_no_Click();
            if (gameCancelled || !isGameActive)
            {
                return;
            }
            await liderBoard(selectdImagePath, result_from_model, 0);
        }

        /// <summary>
        ///     Button click event handler for the "Yes" button. It calls the common handler yes_no_Click() to manage the game state and prepare for evaluating the player's answer. If the game has been cancelled or is not active, it returns early. Otherwise, it sets the player's answer to 1 (indicating "Yes") and calls the liderBoard() method to update the leaderboard and prepare for the next round of the game. This method allows the player to submit their answer and proceed with the game flow after clicking "Yes".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void yesButton_Click(object sender, EventArgs e)
        {
            await yes_no_Click();
            if (gameCancelled || !isGameActive)
            {
                return;
            }
            await liderBoard(selectdImagePath, result_from_model, 1);
        }
        /// <summary>
        /// Button click event handler for the "End" button. It calls the ResetGameLogic() method to reset the game state and prepare for a new game. This allows the player to end the current game session and start fresh without having to close and reopen the application. It ensures that all relevant variables and UI elements are reset to their initial state, providing a consistent starting point for the next game session.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endButton_Click(object sender, EventArgs e)
        {
            ResetGameLogic();
        }
        /// <summary>
        /// Button click event handler for the "Go Back" button. It hides the current form, opens the file_test form as a dialog, and then closes the current form after the file_test form is closed. This allows the player to go back to the previous screen (file_test) where they can select a new folder or perform other actions before starting a new game session. It provides a way to navigate back to the main menu or folder selection screen without having to close and reopen the application manually.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            file_test test_Obrazu = new file_test();
            test_Obrazu.ShowDialog();
            this.Close();
        }
        /// <summary>
        /// Button click event handler for the "Start Game" button. It calls the chooseFolder() method to allow the user to select a folder containing the files for the game. This is the initial step to start the game, as it sets up the necessary files and prepares the game logic based on the selected folder. It ensures that the player can easily start a new game session by selecting the appropriate folder with the required structure and files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startGameButton_Click(object sender, EventArgs e)
        {
            chooseFolder();
        }
        /// <summary>
        ///     Button click event handler for the restart button. It checks if a folder has been selected (if selectdImagePath is not empty), and if so, it calls the chooseFolder() method to allow the user to select a new folder and then resets the game logic by calling ResetGameLogic(). If no folder has been selected, it shows a message prompting the user to start the game first. This allows the player to restart the game with a new set of files without having to close and reopen the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Button click event handler for the settings button. It opens the research_setting form as a dialog, and when the research_setting form is closed, it updates the game settings based on the user's choices in the research_setting form. It updates the time limit, score display, question text, and prepares a new random file if necessary. This allows the player to customize their game experience by changing various settings before starting or during the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if (Properties.Settings.Default.newQuestion)
                {
                    questionMG.Text = Properties.Settings.Default.yourQuestion;
                }
                actualizeFolderFiles();
                if (!string.IsNullOrEmpty(mainFolderPath))
                    randomFilePrepare();
            };
            researchSetting.ShowDialog();
        }
    }
}