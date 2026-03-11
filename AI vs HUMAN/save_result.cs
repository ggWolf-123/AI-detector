using AI_vs_HUMAN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public save_result(int points, int goodAnswers, int badAnswers, int AIpoints, int AIgoodAnswers, int AIbadAnswers)
        {
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
            Control[] yourAskText =
            {
                textYourData1,
                textYourData2,
                textYourData3,
                textYourData4,
                textYourData5
            };
            Control[] numericYourData =
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
                    yourAskControl[i].Name = yourDataName[i];
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
        private void ApplyLanguage()
        {
            this.Text = Properties.Resources.challangeBitton;
            LanguageManager.ApplyLanguageToControls(this);
        }
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
                    MessageBox.Show($"Brakuje danej: {yourAskText[i].Name}");
                    break;
                }
            }
            return yourDataCheck;
        }
        private void save_results_button_Click(object sender, EventArgs e)
        {
            if (!groupBoxChecker())
            {
                if(!Properties.Settings.Default.askGender)
                {
                    MessageBox.Show("Brakuje danej o płci.");
                }
                if(!Properties.Settings.Default.askPopulation)
                {
                    MessageBox.Show("Brakuje danej o wielkości miejsca zamieszkania.");
                }
                return;
            }
            if (!yourDataTextChecker())
            {
                return;
            }
        }
    }
}