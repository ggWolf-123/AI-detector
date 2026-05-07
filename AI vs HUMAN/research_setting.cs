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
            this.Load += startLoad;
            this.Resize += startResize;
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
        ///     Load the settings for the research form when it is opened. It checks if there are saved settings for the folder path and file path, and if so, it populates the corresponding text boxes with those values. It also loads the settings for all controls on the form, including custom fields, and toggles their enabled state based on whether they are checked or not. This ensures that the form reflects the user's previously saved preferences when it is opened.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            yourQuestion.Enabled = newQuestion.Checked;
        }
        /// <summary>
        ///     Change the enabled state of the custom field controls based on whether the corresponding checkbox is checked or not. It finds the checkbox, text box, and radio buttons for the specified index, and if they exist, it sets their enabled state to match the checked state of the checkbox. This allows users to enable or disable custom fields and their associated settings dynamically based on their preferences.
        /// </summary>
        /// <param name="index"></param>
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
        /// <summary>
        ///     Create a new file with the specified name and header based on the selected options. It checks if the user has chosen to create a new file in either TXT or CSV format, and if so, it constructs the file path using the selected folder and file name. It then checks if a file with that name already exists, and if not, it creates the file and writes the header line containing the expected columns. If a file with the same name already exists, it shows a message to the user and returns false to indicate that the file creation was unsuccessful. This method ensures that new files are created with the correct structure and prevents overwriting existing files without confirmation.
        /// </summary>
        /// <returns></returns>
        private bool CreateNewFile()
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
                    MessageBox.Show("Plik o tej nazwie już istnieje. Wybierz inną nazwę lub użyj istniejącego pliku. Jeśli chcesz korzystać z pliku o tej nazwie to wyjdź z ustawien, a wszystkie ustawienia zostaną przywrócone do ostatniej zaakceptowanej konfiguracji. Dzięki temu będziesz mógł/mogła kontynuować pracę na tym pliku.");
                    return false;
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
                    MessageBox.Show("Plik o tej nazwie już istnieje. Wybierz inną nazwę lub użyj istniejącego pliku. Jeśli chcesz korzystać z pliku o tej nazwie to wyjdź z ustawien, a wszystkie ustawienia zostaną przywrócone do ostatniej zaakceptowanej konfiguracji. Dzięki temu będziesz mógł/mogła kontynuować pracę na tym pliku.");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///     Add the name of a custom column to the list of columns if the corresponding checkbox is enabled and the text box for the column name is not empty. It retrieves the enabled state and column name from the settings for the specified index, and if the custom field is enabled and has a valid name, it adds that name to the list of columns. This method is used to dynamically generate the list of expected columns based on the user's configuration of custom fields.
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="index"></param>
        private void AddIfEnabled(List<string> columns, int index)
        {
            bool enabled= (bool)Properties.Settings.Default[$"YourAsk{index}Enabled"];
            string name= (string)Properties.Settings.Default[$"YourAsk{index}Text"];
            if (enabled && !string.IsNullOrEmpty(name))
            {
                columns.Add(name);
            }
        }
        /// <summary>
        ///     Load a custom field's settings into the corresponding controls on the form. It retrieves the enabled state, column name, and data type (numeric or string) from the settings for the specified index, and then populates the checkbox, text box, and radio buttons accordingly. It also sets the enabled state of the text box and radio buttons based on whether the custom field is enabled or not. This method ensures that the custom field controls reflect the user's saved preferences when the form is loaded.
        /// </summary>
        /// <param name="askCheckBox"></param>
        /// <param name="askTextBox"></param>
        /// <param name="numericRadio"></param>
        /// <param name="stringRadio"></param>
        /// <param name="index"></param>
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
        /// <summary>
        ///     Save a custom field's settings from the corresponding controls on the form into the application settings. It checks if the custom field is enabled and if the column name is provided, and if so, it saves the enabled state, column name, and data type (numeric or string) into the settings for the specified index. If the custom field is enabled but the column name is missing or no data type is selected, it shows a message to the user and stops the saving process. This method ensures that only valid configurations for custom fields are saved into the application settings.
        /// </summary>
        /// <param name="askCheckBox"></param>
        /// <param name="askTextBox"></param>
        /// <param name="numericRadio"></param>
        /// <param name="stringRadio"></param>
        /// <param name="index"></param>
        private void SaveCustomField(CheckBox askCheckBox, TextBox askTextBox, RadioButton numericRadio, RadioButton stringRadio, int index)
        {
            if (askCheckBox.Checked && string.IsNullOrWhiteSpace(askTextBox.Text))
            {
                MessageBox.Show($"Pole 'Your Ask {index}' jest zaznaczone, ale nie podano nazwy kolumny. Zapis zostaje zatrzymany.");
                return;
            }
            if (askCheckBox.Checked && !numericRadio.Checked && !stringRadio.Checked)
            {
                MessageBox.Show($"Pole 'Your Ask {index}' jest zaznaczone, ale nie wybrano typu danych (Numeric/String). Zapis zostaje zatrzymany.");
                return;
            }
            Properties.Settings.Default[$"YourAsk{index}Enabled"] = askCheckBox.Checked;
            Properties.Settings.Default[$"YourAsk{index}Text"] = askTextBox.Text;
            Properties.Settings.Default[$"YourAsk{index}IsNumeric"] = numericRadio.Checked;
            Properties.Settings.Default[$"YourAsk{index}IsString"] = stringRadio.Checked;
        }
        /// <summary>
        ///     Check if the selected file is compatible with the expected format by reading the first line of the file and comparing the column names to the expected columns based on the current settings. It reads the first line of the file, splits it into columns, and then compares those columns to the list of expected columns generated from the current settings. If the columns match in terms of count and names (ignoring case and whitespace), it returns true, indicating that the file is compatible. If there is any mismatch or an error occurs while reading the file, it returns false, indicating that the file is not compatible. This method ensures that only files with the correct structure are accepted for use in the application.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
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
        /// <summary>
        ///     Generate a list of expected column names based on the current settings of the form. It checks each relevant setting (such as whether to ask for points, time
        /// </summary>
        /// <returns></returns>
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
            columns.Add("SessionID");
            return columns;
        }
        /// <summary>
        ///     Get all controls on the form, including nested controls within containers, by recursively iterating through the Controls collection of each control. It uses a yield return statement to return each control one at a time, allowing for efficient enumeration of all controls without needing to store them all in memory at once. This method is useful for applying settings or performing actions on all controls within the form, regardless of their depth in the control hierarchy.
        /// </summary>
        /// <param name="root">The root control from which to start the search.</param>
        /// <returns>An enumerable collection of all controls within the form.</returns>
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
        /// <summary>
        ///     Load all control settings from the application settings into the corresponding controls on the form. It iterates through all controls on the form, checks if there are saved settings for each control based on its name, and if so, it populates the control with the saved value. It handles different types of controls such as CheckBox, NumericUpDown, and TextBox, and it also updates the text for the chosen folder and file paths. This method ensures that all controls reflect the user's previously saved preferences when the form is loaded.
        /// </summary>
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
        /// <summary>
        ///     Save all control settings from the corresponding controls on the form into the application settings. It iterates through all controls on the form, checks if there are corresponding settings for each control based on its name, and if so, it saves the current value of the control into the settings. It handles different types of controls such as CheckBox, NumericUpDown, and TextBox, and it also updates the settings for the chosen folder and file paths. Finally, it calls the Save method to persist all changes to the application settings. This method ensures that all user preferences are saved when they accept the settings.
        /// </summary>
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
            Properties.Settings.Default.FileName = newFileNameTextBox.Text;
            Properties.Settings.Default.SaveFolderPath = chosenFolderToSave.Text;
            Properties.Settings.Default.ExistingFilePath = chosenFileToWrite.Text;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        ///     Validate the custom fields to ensure that if a custom field is enabled, it has a valid column name and a selected data type. It iterates through each of the five custom fields, checks if the corresponding checkbox is checked, and if so, it verifies that the text box for the column name is not empty and that either the numeric or string radio button is selected. If any of these conditions are not met for an enabled custom field, it shows a message to the user indicating the issue and returns false to indicate that the validation failed. If all enabled custom fields are valid, it returns true. This method ensures that only properly configured custom fields are accepted when saving the settings.
        /// </summary>
        /// <returns>True if all enabled custom fields are valid; otherwise, false.</returns>
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
        /// <summary>
        ///     Check or uncheck the related controls for points based on the state of the pointAskBox checkbox. If the pointAskBox is checked, it enables the addPoint, takePoint, and showResult controls; if it is unchecked, it disables those controls. This allows users to configure whether they want to include point-related settings in their research configuration dynamically based on their preferences.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void pointAskBox_CheckedChanged(object sender, EventArgs e)
        {
            addPoint.Enabled = pointAskBox.Checked;
            takePoint.Enabled = pointAskBox.Checked;
            showResult.Enabled = pointAskBox.Checked;
        }
        /// <summary>
        ///     Check or uncheck the related control for image limit based on the state of the askLimitImg checkbox. If the askLimitImg is checked, it enables the numericImgLimit control; if it is unchecked, it disables that control. This allows users to configure whether they want to include an image limit setting in their research configuration dynamically based on their preferences.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void askLimitImg_CheckedChanged(object sender, EventArgs e)
        {
            numericImgLimit.Enabled = askLimitImg.Checked;
        }
        /// <summary>
        /// Check or uncheck the related control for time limit based on the state of the askTimeMax checkbox. If the askTimeMax is checked, it enables the numericSeconds control; if it is unchecked, it disables that control. This allows users to configure whether they want to include a time limit setting in their research configuration dynamically based on their preferences.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void askTimeMax_CheckedChanged(object sender, EventArgs e)
        {
            numericSeconds.Enabled = askTimeMax.Checked;
        }
        /// <summary>
        ///     Check or uncheck the related control for a new question based on the state of the newQuestion checkbox. If the newQuestion is checked, it enables the yourQuestion control; if it is unchecked, it disables that control. This allows users to configure whether they want to include a custom question setting in their research configuration dynamically based on their preferences.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newQuestion_CheckedChanged(object sender, EventArgs e)
        {
            yourQuestion.Enabled = newQuestion.Checked;
        }
        /// <summary>
        ///     Check or uncheck the related control for showing AI answers based on the state of the aiAnswersToo checkbox. If the aiAnswersToo is checked, it enables the showAiAnswers control; if it is unchecked, it disables that control and also unchecks it. This allows users to configure whether they want to include AI answer feedback in their research configuration dynamically based on their preferences.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void AiAnswersToo_CheckedChanged(object sender, EventArgs e)
        {
            showAiAnswers.Enabled = aiAnswersToo.Checked;
            if (!aiAnswersToo.Checked)
            {
                showAiAnswers.Checked = false;
            }
        }
        // ==========================buttons
        /// <summary>
        ///     Click event handler for the button that allows the user to choose a folder to save results. It opens a FolderBrowserDialog, and if the user selects a folder and clicks OK, it saves the selected folder path into the application settings and updates the corresponding text box on the form to display the chosen folder path. This allows users to easily specify where they want to save their research results.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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

        /// <summary>
        ///  Click event handler for the button that allows the user to choose an existing file to save results. It opens an OpenFileDialog, and if the user selects a file and clicks OK, it checks if the selected file is compatible with the expected format. If the file is compatible, it saves the selected file path into the application settings and updates the corresponding text box on the form to display the chosen file path. If the file is not compatible, it shows a message to the user indicating that the selected file is not suitable for use. This allows users to easily specify an existing file for saving their research results while ensuring that the file structure is correct.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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
        /// <summary>
        ///     Click event handler for the button that accepts the settings configured by the user. It performs various validation checks to ensure that the necessary settings are provided and valid, such as checking if a save folder is selected when required, if at least one file type is selected for consideration during randomization, if custom fields are properly configured, and if the selected existing file is compatible. If all validations pass, it saves the custom field settings and all other control settings into the application settings, creates a new file if needed, and then closes the settings form with a DialogResult of OK to indicate that the settings were successfully accepted. This method ensures that only valid configurations are saved and applied in the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void settingAcceptButton_Click(object sender, EventArgs e)
        {
            if (askSavePaths.Checked && string.IsNullOrWhiteSpace(Properties.Settings.Default.SaveFolderPath))
            {
                MessageBox.Show("Musisz wybrać folder docelowy, aby zapisać ścieżki plików.");
                return;
            }
            if (!(askImageIn.Checked || askVideoIn.Checked || askTextIn.Checked))
            {
                MessageBox.Show("Musisz wybrać jaki rodzaj pliku będzie brany pod uwage podczas losowania.");
                return;
            }
            if (funMode.Checked)
            {
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
            if (!(CheckFileCompatibility(Properties.Settings.Default.ExistingFilePath)) && !(string.IsNullOrWhiteSpace(Properties.Settings.Default.ExistingFilePath)))
            {
                MessageBox.Show("Wybrany plik nie jest kompatybilny. Upewnij się, że zawiera odpowiednie kolumny lub odznacz go.");
                return;
            }
            if (!ValidateCustomFields())
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
            if (!((newFileToTXT.Checked || newFileToCSV.Checked) && CreateNewFile()))
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        ///     Click event handler for the button that resets the selected existing file path. It clears the ExistingFilePath setting, saves the settings, and updates the corresponding text box on the form to indicate that no file is currently selected. This allows users to easily reset their choice of an existing file if they decide to create a new file or simply want to clear their selection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void resetFileButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ExistingFilePath ="";
            Properties.Settings.Default.Save();
            chosenFileToWrite.Text = "Ścieżka wybranego pliku do roższerzenia to:";
        }
        /// <summary>
        ///     Click event handler for the button that resets the selected folder path. It clears the SaveFolderPath setting, saves the settings, and updates the corresponding text box on the form to indicate that no folder is currently selected. This allows users to easily reset their choice of a save folder if they want to choose a different one or simply want to clear their selection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void resetFolder_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveFolderPath = "";
            Properties.Settings.Default.Save();
            chosenFolderToSave.Text = "Ścieżka wybranego folderu to:";
        }
    }
}
