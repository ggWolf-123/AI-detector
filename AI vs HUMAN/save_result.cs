using AI_vs_HUMAN;
using AI_vs_HUMAN.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_vs_HUMAN
{
    public partial class save_result : Form
    {
        private int points;
        private int goodAnswers;
        private int badAnswers;
        private int AIpoints;
        private int AIgoodAnswers;
        private int AIbadAnswers;
        private int timeOfRechearch;
        private string pathWithoutExtension = Path.Combine(
            Properties.Settings.Default.SaveFolderPath,
            Path.GetFileNameWithoutExtension(Properties.Settings.Default.FileName)
            );
        private TextBox[] yourAskText;
        private NumericUpDown[] numericYourData;
        public save_result(int points, int goodAnswers, int badAnswers, int AIpoints, int AIgoodAnswers, int AIbadAnswers, int timeOfRechearch)
        {
            this.Load += startLoad;
            this.Resize += startResize;
            LanguageManager.SetLanguage(LanguageManager.CurrentLanguage);
            InitializeComponent();
            ApplyLanguage();
            bool[] yourSettings =
            {
                Properties.Settings.Default.YourAsk1Enabled,
                Properties.Settings.Default.YourAsk2Enabled,
                Properties.Settings.Default.YourAsk3Enabled,
                Properties.Settings.Default.YourAsk4Enabled,
                Properties.Settings.Default.YourAsk5Enabled
            };
            bool[] yourSettingsText =
            {
                Properties.Settings.Default.YourAsk1IsString,
                Properties.Settings.Default.YourAsk2IsString,
                Properties.Settings.Default.YourAsk3IsString,
                Properties.Settings.Default.YourAsk4IsString,
                Properties.Settings.Default.YourAsk5IsString
            };
            string[] yourDataName =
            {
                Properties.Settings.Default.YourAsk1Text,
                Properties.Settings.Default.YourAsk2Text,
                Properties.Settings.Default.YourAsk3Text,
                Properties.Settings.Default.YourAsk4Text,
                Properties.Settings.Default.YourAsk5Text
            };
            Control[] yourAskControl =
            {
                privateData1,
                privateData2,
                privateData3,
                privateData4,
                privateData5
            };
            yourAskText = new TextBox[]
            {
                textYourData1,
                textYourData2,
                textYourData3,
                textYourData4,
                textYourData5
            };
            numericYourData = new NumericUpDown[]
            {
                numericYourData1,
                numericYourData2,
                numericYourData3,
                numericYourData4,
                numericYourData5
            };
            this.points = points;
            this.goodAnswers = goodAnswers;
            this.badAnswers = badAnswers;
            this.AIpoints = AIpoints;
            this.AIgoodAnswers = AIgoodAnswers;
            this.AIbadAnswers = AIbadAnswers;
            this.timeOfRechearch = timeOfRechearch;

            if (!Properties.Settings.Default.askGender)
            {
                genderGroupBox.Visible = false;
                genderGroupBox.Enabled = false;
            }
            if (!Properties.Settings.Default.askYears)
            {
                ageLabel.Visible = false;
                ageLabel.Enabled = false;
                ageNumeric.Visible = false;
                ageNumeric.Enabled = false;
            }
            if (!Properties.Settings.Default.askPopulation)
            {
                populationBox.Visible = false;
                populationBox.Enabled = false;
            }
            for(int i=0; i<yourSettings.Length;i++)
            {
                if (!yourSettings[i])
                {
                    yourAskControl[i].Visible = false;
                    yourAskControl[i].Enabled = false;
                }
                else
                {
                    yourAskControl[i].Text = yourDataName[i];
                }
                if (yourSettingsText[i])
                {
                    numericYourData[i].Visible = false;
                    numericYourData[i].Enabled = false;
                }
                else
                {
                    yourAskText[i].Visible = false;
                    yourAskText[i].Enabled = false;
                }
            }
        }
        /// <summary>
        ///    Change the language of the form and all controls on it. The text for each control is taken from the resources file, so it will be automatically updated when the language is changed. This method is called after changing the language to update the UI.
        /// </summary>
        private void ApplyLanguage()
        {
            LanguageManager.ApplyLanguageToControls(this);
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
        /// Check if the required group boxes ( gender and population) have a selected option. It iterates through the controls in each group box and checks if any of the radio buttons are checked. If a required group box does not have a selected option, it returns false, otherwise it returns true. This method is called before saving the results to ensure that all necessary data is collected. If any required data is missing, it will display a message box indicating which data is missing.
        /// </summary>
        /// <returns>True if all required group boxes have a selected option; otherwise, false.</returns>
        private bool groupBoxChecker()
        {
            bool genderBoxCheck = true;
            bool populationBoxCheck= true;
            if (Properties.Settings.Default.askGender)
            {
                genderBoxCheck = false;
                foreach (Control cnrl in genderGroupBox.Controls)
                {
                    if (cnrl is RadioButton radioButton && radioButton.Checked)
                    {
                        genderBoxCheck = true;
                        break;
                    }
                }
            }
            if (Properties.Settings.Default.askPopulation)
            {
                populationBoxCheck = false;
                foreach (Control cnrl in populationBox.Controls)
                {
                    if (cnrl is RadioButton radioButton && radioButton.Checked)
                    {
                        populationBoxCheck = true;
                        break;
                    }
                }
            }
            if (genderBoxCheck && populationBoxCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Check if the required text boxes for custom data have been filled out. It iterates through the text boxes and checks if any of them are visible and empty. If a visible text box is empty, it returns false and displays a message box indicating which data is missing. If all required text boxes are filled out, it returns true. This method is called before saving the results to ensure that all necessary data is collected.
        /// </summary>
        /// <returns>True if all required text boxes have been filled out; otherwise, false.</returns>
        private bool yourDataTextChecker()
        {
            bool yourDataCheck = true;
            Control[] yourAskText =
            {
                textYourData1,
                textYourData2,
                textYourData3,
                textYourData4,
                textYourData5
            };
            for(int i=0; i<yourAskText.Length;i++)
            {
                if (yourAskText[i].Visible && string.IsNullOrWhiteSpace(yourAskText[i].Text))
                {
                    yourDataCheck = false;
                    MessageBox.Show($"{Resources.noData} {yourAskText[i].Name}");
                    break;
                }
            }
            return yourDataCheck;
        }

        /// <summary>
        /// Add custom data to the list of lines to be saved. It checks if the custom data for the specified number is enabled and whether it is a string or numeric value. If it is enabled, it adds the corresponding value (either from a text box or a numeric up-down control) to the list of lines. This method is called when saving the results to include any additional custom data that the user has entered.
        /// </summary>
        /// <param name="lines">The list of lines to which the custom data will be added.</param>
        /// <param name="number">The number of the custom data to be added.</param>
        private void addCustomData(List<string> lines, int number)
        {
            bool isEnabled= (bool)Properties.Settings.Default[$"YourAsk{number}Enabled"];
            bool isString = (bool)Properties.Settings.Default[$"YourAsk{number}IsString"];
            if (isEnabled)
            {
                if (isString)
                {
                    lines.Add(yourAskText[number-1].Text);
                }
                else
                {
                    lines.Add(numericYourData[number-1].Value.ToString());
                }
            }
        }
        /// <summary>
        /// Button click event handler for saving the results. It first checks if the required group boxes have a selected option and if the required text boxes for custom data have been filled out. If any required data is missing, it displays a message box indicating which data is missing and returns without saving. If all required data is present, it creates a list of lines to be saved, including points, answers, time of research and any additional custom data. It then saves the results to a new file or an existing file based on the user's settings and displays a message box confirming that the results have been saved. Finally, it closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_results_button_Click(object sender, EventArgs e)
        {
            if (!groupBoxChecker())
            {
                if (!Properties.Settings.Default.askGender)
                {
                    MessageBox.Show(Resources.noSexData);
                }
                if (!Properties.Settings.Default.askPopulation)
                {
                    MessageBox.Show(Resources.noPopulationData);
                }
                return;
            }
            if (!yourDataTextChecker())
            {
                return;
            }
            List<string> lines = new List<string>
            {
            };
            if (Properties.Settings.Default.pointAskBox)
            {
                lines.Add($"{points}");
                lines.Add($"{goodAnswers}");
                lines.Add($"{badAnswers}");
            }
            if (Properties.Settings.Default.askSaveHowLong)
            {
                lines.Add($"{timeOfRechearch}");
            }
            if (Properties.Settings.Default.askLimitImg)
            {
                lines.Add($"{Properties.Settings.Default.numericImgLimit}");
            }
            if (Properties.Settings.Default.askGender)
            {
                if (maleRadio.Checked)
                {
                    lines.Add("M");
                }
                else if (femaleRadio.Checked)
                {
                    lines.Add("F");
                }
                else if (otherRadio.Checked)
                {
                    lines.Add("O");
                }
                else if (privateRadio.Checked)
                {
                    lines.Add("-");
                }
            }
            if (Properties.Settings.Default.askYears)
            {
                lines.Add($"{ageNumeric.Value}");
            }
            if (Properties.Settings.Default.askPopulation)
            {
                if (villageRadio.Checked)
                {
                    lines.Add("V");
                }
                else if (to50Radio.Checked)
                {
                    lines.Add("<50");
                }
                else if (from50to150Radio.Checked)
                {
                    lines.Add("50_150");
                }
                else if (from150to500Radio.Checked)
                {
                    lines.Add("150_500");
                }
                else if (over500Radio.Checked)
                {
                    lines.Add(">500");
                }
            }
            if (Properties.Settings.Default.showAnswerByColor && Properties.Settings.Default.showHumanAnswers)
            {
                lines.Add("3");
            }
            else if (Properties.Settings.Default.showAnswerByColor)
            {
                lines.Add("2");
            }
            else if (Properties.Settings.Default.showHumanAnswers)
            {
                lines.Add("1");
            }
            if (Properties.Settings.Default.aiAnswersToo)
            {
                lines.Add($"{AIpoints}");
                lines.Add($"{AIgoodAnswers}");
                lines.Add($"{AIbadAnswers}");
                if (Properties.Settings.Default.showAiAnswers)
                {
                    lines.Add("1");
                }
            }
            addCustomData(lines, 1);
            addCustomData(lines, 2);
            addCustomData(lines, 3);
            addCustomData(lines, 4);
            addCustomData(lines, 5);
            lines.Add($"{Properties.Settings.Default.numberOfSeasion}");
            string filePath ="";
            string row=string.Join(";", lines);
            if (Properties.Settings.Default.newFileToCSV)
            {
                filePath = pathWithoutExtension + ".csv";
                File.AppendAllText(filePath, row + Environment.NewLine);
                MessageBox.Show($"{Resources.dataSaveTo} {filePath}");
            }
            if(Properties.Settings.Default.newFileToTXT)
            {
                filePath = pathWithoutExtension + ".txt";
                File.AppendAllText(filePath, row + Environment.NewLine);
                MessageBox.Show($"{Resources.dataSaveTo} {filePath}");
            }
            if (!(string.IsNullOrWhiteSpace(Properties.Settings.Default.ExistingFilePath)))
            {
                File.AppendAllText(Properties.Settings.Default.ExistingFilePath, row + Environment.NewLine);
                MessageBox.Show($"{Resources.dataSaveToOld} {Properties.Settings.Default.ExistingFilePath}");
            }
            this.Close();
            
        }
    }
}