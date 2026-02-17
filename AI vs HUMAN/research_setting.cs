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
    public partial class research_setting : Form
    {
        public research_setting()
        {
            InitializeComponent();
            this.Load += Research_setting_Load;
            whereToSaveFolderButton.Click += whereToSaveFolderButton_Click;
            askExistingData.Click += askExistingData_Click;
            pointAskBox.CheckedChanged += pointAskBox_CheckedChanged;
            askLimitImg.CheckedChanged += askLimitImg_CheckedChanged;
            askTimeMax.CheckedChanged += askTimeMax_CheckedChanged;
            yourAsk1.CheckedChanged += (s, e) => ToggleCustomField(1);
            yourAsk2.CheckedChanged += (s, e) => ToggleCustomField(2);
            yourAsk3.CheckedChanged += (s, e) => ToggleCustomField(3);
            yourAsk4.CheckedChanged += (s, e) => ToggleCustomField(4);
            yourAsk5.CheckedChanged += (s, e) => ToggleCustomField(5);


            askTimeMax.CheckedChanged += (s, e) => numericSeconds.Enabled=askTimeMax.Checked;
            askLimitImg.CheckedChanged += (s, e) => numericImgLimit.Enabled=askLimitImg.Checked;

            aiAnswersToo.CheckedChanged += AiAnswersToo_CheckedChanged;
        }
        private void Research_setting_Load(object sender, EventArgs e)
        {
            //folder
            if(!string.IsNullOrEmpty(Properties.Settings.Default.SaveFolderPath))
            {
                chosenFolderToSave.Text = Properties.Settings.Default.SaveFolderPath;
            }
            //file
            if (!string.IsNullOrEmpty(Properties.Settings.Default.ExistingFilePath))
            {
                chosenFileToWrite.Text = Properties.Settings.Default.ExistingFilePath;
            }
            //your data
            LoadAllControlsSetings();
            LoadCustomField(yourAsk1, yourAsk1TextBox, yourAsk1NumericRadio,yourAsk1StringRadio, 1);
            LoadCustomField(yourAsk2, yourAsk2TextBox, yourAsk2NumericRadio, yourAsk2StringRadio, 2);
            LoadCustomField(yourAsk3, yourAsk3TextBox, yourAsk3NumericRadio, yourAsk3StringRadio, 3);
            LoadCustomField(yourAsk4, yourAsk4TextBox, yourAsk4NumericRadio, yourAsk4StringRadio, 4);
            LoadCustomField(yourAsk5, yourAsk5TextBox, yourAsk5NumericRadio, yourAsk5StringRadio, 5);
            ToggleCustomField(1);
            ToggleCustomField(2);
            ToggleCustomField(3);
            ToggleCustomField(4);
            ToggleCustomField(5);

            addPoint.Enabled = pointAskBox.Checked;
            takePoint.Enabled = pointAskBox.Checked;
            showResult.Enabled = pointAskBox.Checked;
            numericSeconds.Enabled = askTimeMax.Checked;
            numericImgLimit.Enabled = askLimitImg.Checked;
            showAiAnswers.Enabled = aiAnswersToo.Checked;
        }
        private void ToggleCustomField(int index)
        {
            CheckBox askCheckBox = (CheckBox)this.Controls.Find($"yourAsk{index}", true).FirstOrDefault();
            TextBox askTextBox = (TextBox)this.Controls.Find($"yourAsk{index}TextBox", true).FirstOrDefault();
            RadioButton numericRadio = (RadioButton)this.Controls.Find($"yourAsk{index}NumericRadio", true).FirstOrDefault();
            RadioButton stringRadio = (RadioButton)this.Controls.Find($"yourAsk{index}StringRadio", true).FirstOrDefault();
            if (askCheckBox != null && askTextBox != null && numericRadio != null && stringRadio!=null)
            {
                bool enabled = askCheckBox.Checked;
                askTextBox.Enabled = enabled;
                numericRadio.Enabled = enabled;
                stringRadio.Enabled = enabled;

            }
        }
        private void CreateNewFile()
        {
            string folderPath = Properties.Settings.Default.SaveFolderPath;
            string fileName = newFileNameTextBox.Text.Trim();
            string header = string.Join(";", GenerateExpectedColumns());
            if(newFileToTXT.Checked)
            {
                string path=System.IO.Path.Combine(folderPath, fileName + ".txt");
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.WriteAllText(path, header+Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("Plik o tej nazwie już istnieje. Wybierz inną nazwę lub użyj istniejącego pliku.");
                }
            }
            if (newFileToCSV.Checked)
            {
                string path = System.IO.Path.Combine(folderPath, fileName + ".csv");
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.WriteAllText(path, header + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("Plik o tej nazwie już istnieje. Wybierz inną nazwę lub użyj istniejącego pliku.");
                }
            }
        }
        private List<string> GenerateExpectedColumns()
        {
            List<string> columns = new List<string>
            {
            };
            if (pointAskBox.Checked)
            {
                columns.Add("Points");
                columns.Add("GoodAnswers");
                columns.Add("BadAnswers");
            }
            if (askSaveHowLong.Checked) columns.Add("TestTime");
            if (askLimitImg.Checked) columns.Add("NumberOfImg");
            if (askGender.Checked) columns.Add("Sex");
            if (askYears.Checked) columns.Add("Age");
            if (askPopulation.Checked) columns.Add("SPR");
            if (showAnswerByColor.Checked || showHumanAnswers.Checked) columns.Add("Feedback");
            if (aiAnswersToo.Checked)
            {
                columns.Add("AIPoints");
                columns.Add("AiGoodAnswer");
                columns.Add("AiBadAnswer");
                if (showAiAnswers.Checked)
                {
                    columns.Add("AIAnswerFeedback");
                }
            }
            AddIfEnabled(columns, 1);
            AddIfEnabled(columns, 2);
            AddIfEnabled(columns, 3);
            AddIfEnabled(columns, 4);
            AddIfEnabled(columns, 5);
            return columns;
        }
        private void AddIfEnabled(List<string> columns, int index)
        {
            bool enabled= (bool)Properties.Settings.Default[$"YourAsk{index}Enabled"];
            string name= (string)Properties.Settings.Default[$"YourAsk{index}Text"];
            if (enabled && !string.IsNullOrEmpty(name))
            {
                columns.Add(name);
            }
        }
        private void LoadCustomField(CheckBox askCheckBox, TextBox askTextBox, RadioButton numericRadio, RadioButton stringRadio, int index)
        {
            object enabledObj=Properties.Settings.Default[$"YourAsk{index}Enabled"];
            object textObj = Properties.Settings.Default[$"YourAsk{index}Text"];
            object numericObj = Properties.Settings.Default[$"YourAsk{index}IsNumeric"];
            object stringObj = Properties.Settings.Default[$"YourAsk{index}IsString"];

            askCheckBox.Checked = enabledObj is bool b && b;
            askTextBox.Text = textObj?.ToString() ?? "";
            numericRadio.Checked = numericObj is bool n && n;
            stringRadio.Checked = stringObj is bool s && s;

            askTextBox.Enabled = askCheckBox.Checked;
            numericRadio.Enabled = askCheckBox.Checked;
            stringRadio.Enabled = askCheckBox.Checked;
        }
        private void SaveCustomField(CheckBox askCheckBox, TextBox askTextBox, RadioButton numericRadio, RadioButton stringRadio, int index)
        {
            Properties.Settings.Default[$"YourAsk{index}Enabled"] = askCheckBox.Checked;
            Properties.Settings.Default[$"YourAsk{index}Text"] = askTextBox.Text;
            Properties.Settings.Default[$"YourAsk{index}IsNumeric"] = numericRadio.Checked;
            Properties.Settings.Default[$"YourAsk{index}IsString"] = stringRadio.Checked;
        }
        private void AiAnswersToo_CheckedChanged(object sender, EventArgs e)
        {
            showAiAnswers.Enabled = aiAnswersToo.Checked;
            if(!aiAnswersToo.Checked)
            {
                showAiAnswers.Checked = false;
            }
        }
        private bool CheckFileCompatibility(string filePath)
        {
            try
            {
                string firstLine = System.IO.File.ReadLines(filePath).FirstOrDefault();
                if(string.IsNullOrWhiteSpace(firstLine))
                    return false;
                string[] columns = firstLine.Split(';').Select(c =>c.Trim().ToLower()).ToArray();

                List<string> expectedColumns = GenerateExpectedColumns().Select(c => c.Trim().ToLower()).ToList();
                if(columns.Length != expectedColumns.Count)
                {
                    return false;
                }
                foreach (var col in expectedColumns)
                {
                    if (!columns.Contains(col))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private IEnumerable<Control> GetAllContrils(Control root)
        {
            foreach (Control control in root.Controls)
            {
                yield return control;
                foreach (var child in GetAllContrils(control))
                {
                    yield return child;
                }
            }
        }
        private void LoadAllControlsSetings()
        {
            foreach(Control control in GetAllContrils(this))
            {
                if (control is Label || control is Button) continue;
                if (control is CheckBox cb && Properties.Settings.Default.Properties.Cast<System.Configuration.SettingsProperty>().Any(p => p.Name == cb.Name))
                {
                    cb.Checked = (bool)Properties.Settings.Default[cb.Name];
                }
                else if (control is NumericUpDown num && Properties.Settings.Default.Properties.Cast<System.Configuration.SettingsProperty>().Any(p => p.Name == num.Name))
                {
                    num.Value = (int)Properties.Settings.Default[num.Name];
                }
                else if (control is TextBox tb && Properties.Settings.Default.Properties.Cast<System.Configuration.SettingsProperty>().Any(p => p.Name == tb.Name))
                {
                    tb.Text = (string)Properties.Settings.Default[tb.Name];
                }
            }
            chosenFolderToSave.Text = Properties.Settings.Default.SaveFolderPath;
            chosenFileToWrite.Text = Properties.Settings.Default.ExistingFilePath;
        }
        private void SaveAllControlsSettings()
        {
            foreach (Control control in GetAllContrils(this))
            {
                if (control is Label || control is Button) continue;
                if (control is CheckBox cb && Properties.Settings.Default.Properties.Cast<System.Configuration.SettingsProperty>().Any(p => p.Name == cb.Name))
                {
                    Properties.Settings.Default[cb.Name] = cb.Checked;
                }
                else if (control is NumericUpDown num && Properties.Settings.Default.Properties.Cast<System.Configuration.SettingsProperty>().Any(p => p.Name == num.Name))
                {
                    Properties.Settings.Default[num.Name] = (int)num.Value;
                }
                else if (control is TextBox tb && Properties.Settings.Default.Properties.Cast<System.Configuration.SettingsProperty>().Any(p => p.Name == tb.Name))
                {
                    Properties.Settings.Default[tb.Name] = tb.Text;
                }
            }
            Properties.Settings.Default.Save();
        }
        private bool ValidateCustomFields()
        {
            for(int i=1; i<=5; i++)
            {
                CheckBox askCheckBox = (CheckBox)this.Controls.Find($"yourAsk{i}", true).FirstOrDefault();
                TextBox askTextBox = (TextBox)this.Controls.Find($"yourAsk{i}TextBox", true).FirstOrDefault();
                RadioButton numericRadio = (RadioButton)this.Controls.Find($"yourAsk{i}NumericRadio", true).FirstOrDefault();
                RadioButton stringRadio = (RadioButton)this.Controls.Find($"yourAsk{i}StringRadio", true).FirstOrDefault();
                if (askCheckBox != null && askCheckBox.Checked)
                {
                    if (askCheckBox==null && string.IsNullOrWhiteSpace(askTextBox.Text))
                    {
                        MessageBox.Show($"Pole 'Your Ask {i}' jest zaznaczone, ale nie podano nazwy kolumny.");
                        return false;
                    }
                    if(numericRadio != null && stringRadio != null && !numericRadio.Checked && !stringRadio.Checked)
                    {
                        MessageBox.Show($"Pole 'Your Ask {i}' jest zaznaczone, ale nie wybrano typu danych (Numeric/String).");
                        return false;
                    }
                }
            }
            return true;
        }

        private void pointAskBox_CheckedChanged(object sender, EventArgs e)
        {
            addPoint.Enabled = pointAskBox.Checked;
            takePoint.Enabled = pointAskBox.Checked;
            showResult.Enabled = pointAskBox.Checked;
        }
        private void askLimitImg_CheckedChanged(object sender, EventArgs e)
        {
            numericImgLimit.Enabled = askLimitImg.Checked;
        }

        private void askTimeMax_CheckedChanged(object sender, EventArgs e)
        {
            numericSeconds.Enabled = askTimeMax.Checked;
        }
        // ==========================buttons
        private void whereToSaveFolderButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Wybierz folder docelowy do zapisywania wyników.";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.SaveFolderPath = folderDialog.SelectedPath;
                    Properties.Settings.Default.Save();
                    chosenFolderToSave.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void askExistingData_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Wybierz istniejący plik do zapisywania wyników.";
                fileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Pliki CSV (*.csv)|*.csv";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (CheckFileCompatibility(fileDialog.FileName))
                    {
                        Properties.Settings.Default.ExistingFilePath = fileDialog.FileName;
                        Properties.Settings.Default.Save();
                        chosenFileToWrite.Text = fileDialog.FileName;
                        MessageBox.Show("Plik został pomyślnie wybrany.");
                    }
                    else
                    {
                        MessageBox.Show("Wybrany plik nie jest kompatybilny. Upewnij się, że zawiera odpowiednie kolumny.");
                    }
                }
            }
        }
        private void settingAcceptButton_Click(object sender, EventArgs e)
        {
            if(funMode.Checked)
            {
                if (askSavePaths .Checked&& string.IsNullOrWhiteSpace(Properties.Settings.Default.SaveFolderPath))
                {
                    MessageBox.Show("Musisz wybrać folder docelowy, aby zapisać ścieżki do obrazów.");
                    return;
                }
                SaveCustomField(yourAsk1, yourAsk1TextBox, yourAsk1NumericRadio, yourAsk1StringRadio, 1);
                SaveCustomField(yourAsk2, yourAsk2TextBox, yourAsk2NumericRadio, yourAsk2StringRadio, 2);
                SaveCustomField(yourAsk3, yourAsk3TextBox, yourAsk3NumericRadio, yourAsk3StringRadio, 3);
                SaveCustomField(yourAsk4, yourAsk4TextBox, yourAsk4NumericRadio, yourAsk4StringRadio, 4);
                SaveCustomField(yourAsk5, yourAsk5TextBox, yourAsk5NumericRadio, yourAsk5StringRadio, 5);
                SaveAllControlsSettings();
                Properties.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            if (!newFileToTXT.Checked && !newFileToCSV.Checked && string.IsNullOrWhiteSpace(Properties.Settings.Default.ExistingFilePath))
            {
                MessageBox.Show("Musisz wybrać istniejący plik lub utworzyć nowy, aby kontynuować.");
                return;
            }
            if ((newFileToTXT.Checked || newFileToCSV.Checked) && string.IsNullOrWhiteSpace(newFileNameTextBox.Text))
            {
                MessageBox.Show("Podaj nazwe nowego pliku.");
                return;
            }
            if ((newFileToTXT.Checked || newFileToCSV.Checked) && string.IsNullOrWhiteSpace(Properties.Settings.Default.SaveFolderPath))
            {
                MessageBox.Show("Musisz wybrać folder docelowy, aby utworzyć nowy plik.");
                return;
            }
            if(!ValidateCustomFields())
            {
                return;
            }
            SaveCustomField(yourAsk1, yourAsk1TextBox, yourAsk1NumericRadio,yourAsk1StringRadio, 1);
            SaveCustomField(yourAsk2, yourAsk2TextBox, yourAsk2NumericRadio, yourAsk2StringRadio, 2);
            SaveCustomField(yourAsk3, yourAsk3TextBox, yourAsk3NumericRadio, yourAsk3StringRadio, 3);
            SaveCustomField(yourAsk4, yourAsk4TextBox, yourAsk4NumericRadio, yourAsk4StringRadio, 4);
            SaveCustomField(yourAsk5, yourAsk5TextBox, yourAsk5NumericRadio, yourAsk5StringRadio, 5);
            SaveAllControlsSettings();
            Properties.Settings.Default.Save();
            if (newFileToTXT.Checked || newFileToCSV.Checked)
            {
                CreateNewFile();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void resetFileButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ExistingFilePath ="";
            Properties.Settings.Default.Save();
            chosenFileToWrite.Text = "Ścieżka wybranego pliku do roższerzenia to:";
        }

        private void resetFolder_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveFolderPath = "";
            Properties.Settings.Default.Save();
            chosenFileToWrite.Text = "Ścieżka wybranego folderu to:";
        }
    }
}
