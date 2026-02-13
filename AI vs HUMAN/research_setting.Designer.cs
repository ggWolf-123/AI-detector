namespace AI_vs_HUMAN
{
    partial class research_setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.settingsAsk = new System.Windows.Forms.Label();
            this.pointAskBox = new System.Windows.Forms.CheckBox();
            this.addPoint = new System.Windows.Forms.NumericUpDown();
            this.takePoint = new System.Windows.Forms.NumericUpDown();
            this.goodAnswer = new System.Windows.Forms.Label();
            this.badAnswer = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.settingAcceptButton = new System.Windows.Forms.Button();
            this.askTimeMax = new System.Windows.Forms.CheckBox();
            this.askSaveHowLong = new System.Windows.Forms.CheckBox();
            this.askLimitImg = new System.Windows.Forms.CheckBox();
            this.askSavePaths = new System.Windows.Forms.CheckBox();
            this.askGender = new System.Windows.Forms.CheckBox();
            this.askYears = new System.Windows.Forms.CheckBox();
            this.askPopulation = new System.Windows.Forms.CheckBox();
            this.numericSeconds = new System.Windows.Forms.NumericUpDown();
            this.numericImgLimit = new System.Windows.Forms.NumericUpDown();
            this.whereToSaveFolderButton = new System.Windows.Forms.Button();
            this.askExistingData = new System.Windows.Forms.Button();
            this.yourAsk1 = new System.Windows.Forms.CheckBox();
            this.yourAsk1Box = new System.Windows.Forms.GroupBox();
            this.yourAsk1StringRadio = new System.Windows.Forms.RadioButton();
            this.yourAsk1NumericRadio = new System.Windows.Forms.RadioButton();
            this.yourAsk1Name = new System.Windows.Forms.Label();
            this.yourAsk1TextBox = new System.Windows.Forms.TextBox();
            this.yourAsk2TextBox = new System.Windows.Forms.TextBox();
            this.yourAsk2Name = new System.Windows.Forms.Label();
            this.yourAsk2Box = new System.Windows.Forms.GroupBox();
            this.yourAsk2StringRadio = new System.Windows.Forms.RadioButton();
            this.yourAsk2NumericRadio = new System.Windows.Forms.RadioButton();
            this.yourAsk2 = new System.Windows.Forms.CheckBox();
            this.yourAsk3TextBox = new System.Windows.Forms.TextBox();
            this.yourAsk3Name = new System.Windows.Forms.Label();
            this.yourAsk3Box = new System.Windows.Forms.GroupBox();
            this.yourAsk3StringRadio = new System.Windows.Forms.RadioButton();
            this.yourAsk3NumericRadio = new System.Windows.Forms.RadioButton();
            this.yourAsk3 = new System.Windows.Forms.CheckBox();
            this.yourAsk4TextBox = new System.Windows.Forms.TextBox();
            this.yourAsk4Name = new System.Windows.Forms.Label();
            this.yourAsk4Box = new System.Windows.Forms.GroupBox();
            this.yourAsk4StringRadio = new System.Windows.Forms.RadioButton();
            this.yourAsk4NumericRadio = new System.Windows.Forms.RadioButton();
            this.yourAsk4 = new System.Windows.Forms.CheckBox();
            this.yourAsk5TextBox = new System.Windows.Forms.TextBox();
            this.yourAsk5Name = new System.Windows.Forms.Label();
            this.yourAsk5Box = new System.Windows.Forms.GroupBox();
            this.yourAsk5StringRadio = new System.Windows.Forms.RadioButton();
            this.yourAsk5NumericRadio = new System.Windows.Forms.RadioButton();
            this.yourAsk5 = new System.Windows.Forms.CheckBox();
            this.chosenFileToWrite = new System.Windows.Forms.Label();
            this.chosenFolderToSave = new System.Windows.Forms.Label();
            this.nameOfNewFileLabel = new System.Windows.Forms.Label();
            this.newFileNameTextBox = new System.Windows.Forms.TextBox();
            this.newFileToTXT = new System.Windows.Forms.CheckBox();
            this.newFileToCSV = new System.Windows.Forms.CheckBox();
            this.showAnswerByColor = new System.Windows.Forms.CheckBox();
            this.aiAnswersToo = new System.Windows.Forms.CheckBox();
            this.aiAnswersTooShow = new System.Windows.Forms.CheckBox();
            this.showHumanAnswers = new System.Windows.Forms.CheckBox();
            this.resetFileButton = new System.Windows.Forms.Button();
            this.resetFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.addPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.takePoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericImgLimit)).BeginInit();
            this.yourAsk1Box.SuspendLayout();
            this.yourAsk2Box.SuspendLayout();
            this.yourAsk3Box.SuspendLayout();
            this.yourAsk4Box.SuspendLayout();
            this.yourAsk5Box.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsAsk
            // 
            this.settingsAsk.AutoSize = true;
            this.settingsAsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.settingsAsk.Location = new System.Drawing.Point(12, 25);
            this.settingsAsk.Name = "settingsAsk";
            this.settingsAsk.Size = new System.Drawing.Size(217, 37);
            this.settingsAsk.TabIndex = 0;
            this.settingsAsk.Text = "Wybierz opcje";
            // 
            // pointAskBox
            // 
            this.pointAskBox.AutoSize = true;
            this.pointAskBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.pointAskBox.Location = new System.Drawing.Point(12, 96);
            this.pointAskBox.Name = "pointAskBox";
            this.pointAskBox.Size = new System.Drawing.Size(129, 29);
            this.pointAskBox.TabIndex = 1;
            this.pointAskBox.Text = "Licz punkty";
            this.pointAskBox.UseVisualStyleBackColor = true;
            this.pointAskBox.CheckedChanged += new System.EventHandler(this.pointAskBox_CheckedChanged);
            // 
            // addPoint
            // 
            this.addPoint.Location = new System.Drawing.Point(147, 104);
            this.addPoint.Name = "addPoint";
            this.addPoint.Size = new System.Drawing.Size(120, 20);
            this.addPoint.TabIndex = 2;
            this.addPoint.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // takePoint
            // 
            this.takePoint.Location = new System.Drawing.Point(273, 105);
            this.takePoint.Name = "takePoint";
            this.takePoint.Size = new System.Drawing.Size(120, 20);
            this.takePoint.TabIndex = 3;
            // 
            // goodAnswer
            // 
            this.goodAnswer.AutoSize = true;
            this.goodAnswer.Location = new System.Drawing.Point(147, 88);
            this.goodAnswer.Name = "goodAnswer";
            this.goodAnswer.Size = new System.Drawing.Size(109, 13);
            this.goodAnswer.TabIndex = 4;
            this.goodAnswer.Text = "Poprawna odpowiedz";
            // 
            // badAnswer
            // 
            this.badAnswer.AutoSize = true;
            this.badAnswer.Location = new System.Drawing.Point(270, 88);
            this.badAnswer.Name = "badAnswer";
            this.badAnswer.Size = new System.Drawing.Size(124, 13);
            this.badAnswer.TabIndex = 5;
            this.badAnswer.Text = "Niepoprawna odpowiedz";
            // 
            // settingAcceptButton
            // 
            this.settingAcceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.settingAcceptButton.Location = new System.Drawing.Point(937, 507);
            this.settingAcceptButton.Name = "settingAcceptButton";
            this.settingAcceptButton.Size = new System.Drawing.Size(267, 183);
            this.settingAcceptButton.TabIndex = 6;
            this.settingAcceptButton.Text = "Zatwierdz";
            this.settingAcceptButton.UseVisualStyleBackColor = true;
            this.settingAcceptButton.Click += new System.EventHandler(this.settingAcceptButton_Click);
            // 
            // askTimeMax
            // 
            this.askTimeMax.AutoSize = true;
            this.askTimeMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.askTimeMax.Location = new System.Drawing.Point(12, 131);
            this.askTimeMax.Name = "askTimeMax";
            this.askTimeMax.Size = new System.Drawing.Size(326, 29);
            this.askTimeMax.TabIndex = 7;
            this.askTimeMax.Text = "Ustaw czas badania w sekundach";
            this.askTimeMax.UseVisualStyleBackColor = true;
            this.askTimeMax.CheckedChanged += new System.EventHandler(this.askTimeMax_CheckedChanged);
            // 
            // askSaveHowLong
            // 
            this.askSaveHowLong.AutoSize = true;
            this.askSaveHowLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.askSaveHowLong.Location = new System.Drawing.Point(12, 166);
            this.askSaveHowLong.Name = "askSaveHowLong";
            this.askSaveHowLong.Size = new System.Drawing.Size(291, 29);
            this.askSaveHowLong.TabIndex = 8;
            this.askSaveHowLong.Text = "Mierz ile czasu trwało badanie";
            this.askSaveHowLong.UseVisualStyleBackColor = true;
            // 
            // askLimitImg
            // 
            this.askLimitImg.AutoSize = true;
            this.askLimitImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.askLimitImg.Location = new System.Drawing.Point(12, 201);
            this.askLimitImg.Name = "askLimitImg";
            this.askLimitImg.Size = new System.Drawing.Size(306, 29);
            this.askLimitImg.TabIndex = 9;
            this.askLimitImg.Text = "Ustaw limit wylosowanych zdjęć";
            this.askLimitImg.UseVisualStyleBackColor = true;
            this.askLimitImg.CheckedChanged += new System.EventHandler(this.askLimitImg_CheckedChanged);
            // 
            // askSavePaths
            // 
            this.askSavePaths.AutoSize = true;
            this.askSavePaths.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.askSavePaths.Location = new System.Drawing.Point(12, 236);
            this.askSavePaths.Name = "askSavePaths";
            this.askSavePaths.Size = new System.Drawing.Size(393, 29);
            this.askSavePaths.TabIndex = 10;
            this.askSavePaths.Text = "Zapisuj ścieżki wylosowanych zdjęć do txt";
            this.askSavePaths.UseVisualStyleBackColor = true;
            // 
            // askGender
            // 
            this.askGender.AutoSize = true;
            this.askGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.askGender.Location = new System.Drawing.Point(12, 271);
            this.askGender.Name = "askGender";
            this.askGender.Size = new System.Drawing.Size(152, 29);
            this.askGender.TabIndex = 11;
            this.askGender.Text = "Zapytaj o płeć";
            this.askGender.UseVisualStyleBackColor = true;
            // 
            // askYears
            // 
            this.askYears.AutoSize = true;
            this.askYears.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.askYears.Location = new System.Drawing.Point(9, 306);
            this.askYears.Name = "askYears";
            this.askYears.Size = new System.Drawing.Size(155, 29);
            this.askYears.TabIndex = 12;
            this.askYears.Text = "Zapytaj o wiek";
            this.askYears.UseVisualStyleBackColor = true;
            // 
            // askPopulation
            // 
            this.askPopulation.AutoSize = true;
            this.askPopulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.askPopulation.Location = new System.Drawing.Point(8, 341);
            this.askPopulation.Name = "askPopulation";
            this.askPopulation.Size = new System.Drawing.Size(385, 29);
            this.askPopulation.TabIndex = 13;
            this.askPopulation.Text = "Zapytaj o wielkość miejsca zamieszkania";
            this.askPopulation.UseVisualStyleBackColor = true;
            // 
            // numericSeconds
            // 
            this.numericSeconds.Location = new System.Drawing.Point(344, 139);
            this.numericSeconds.Name = "numericSeconds";
            this.numericSeconds.Size = new System.Drawing.Size(120, 20);
            this.numericSeconds.TabIndex = 14;
            // 
            // numericImgLimit
            // 
            this.numericImgLimit.Location = new System.Drawing.Point(324, 209);
            this.numericImgLimit.Name = "numericImgLimit";
            this.numericImgLimit.Size = new System.Drawing.Size(120, 20);
            this.numericImgLimit.TabIndex = 15;
            // 
            // whereToSaveFolderButton
            // 
            this.whereToSaveFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.whereToSaveFolderButton.Location = new System.Drawing.Point(344, 524);
            this.whereToSaveFolderButton.Name = "whereToSaveFolderButton";
            this.whereToSaveFolderButton.Size = new System.Drawing.Size(328, 112);
            this.whereToSaveFolderButton.TabIndex = 16;
            this.whereToSaveFolderButton.Text = "Wybierz folder do zapisywania wyników";
            this.whereToSaveFolderButton.UseVisualStyleBackColor = true;
            // 
            // askExistingData
            // 
            this.askExistingData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.askExistingData.Location = new System.Drawing.Point(8, 524);
            this.askExistingData.Name = "askExistingData";
            this.askExistingData.Size = new System.Drawing.Size(295, 112);
            this.askExistingData.TabIndex = 17;
            this.askExistingData.Text = "Wybierz istniejące badania do dopisania (muszi mieć te same ustawienia)";
            this.askExistingData.UseVisualStyleBackColor = true;
            // 
            // yourAsk1
            // 
            this.yourAsk1.AutoSize = true;
            this.yourAsk1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.yourAsk1.Location = new System.Drawing.Point(623, 25);
            this.yourAsk1.Name = "yourAsk1";
            this.yourAsk1.Size = new System.Drawing.Size(163, 29);
            this.yourAsk1.TabIndex = 18;
            this.yourAsk1.Text = "Własna dana 1";
            this.yourAsk1.UseVisualStyleBackColor = true;
            // 
            // yourAsk1Box
            // 
            this.yourAsk1Box.Controls.Add(this.yourAsk1StringRadio);
            this.yourAsk1Box.Controls.Add(this.yourAsk1NumericRadio);
            this.yourAsk1Box.Location = new System.Drawing.Point(792, 25);
            this.yourAsk1Box.Name = "yourAsk1Box";
            this.yourAsk1Box.Size = new System.Drawing.Size(102, 76);
            this.yourAsk1Box.TabIndex = 19;
            this.yourAsk1Box.TabStop = false;
            this.yourAsk1Box.Text = "Własna dana 1";
            // 
            // yourAsk1StringRadio
            // 
            this.yourAsk1StringRadio.AutoSize = true;
            this.yourAsk1StringRadio.Location = new System.Drawing.Point(6, 43);
            this.yourAsk1StringRadio.Name = "yourAsk1StringRadio";
            this.yourAsk1StringRadio.Size = new System.Drawing.Size(50, 17);
            this.yourAsk1StringRadio.TabIndex = 1;
            this.yourAsk1StringRadio.TabStop = true;
            this.yourAsk1StringRadio.Text = "napis";
            this.yourAsk1StringRadio.UseVisualStyleBackColor = true;
            // 
            // yourAsk1NumericRadio
            // 
            this.yourAsk1NumericRadio.AutoSize = true;
            this.yourAsk1NumericRadio.Location = new System.Drawing.Point(6, 20);
            this.yourAsk1NumericRadio.Name = "yourAsk1NumericRadio";
            this.yourAsk1NumericRadio.Size = new System.Drawing.Size(82, 17);
            this.yourAsk1NumericRadio.TabIndex = 0;
            this.yourAsk1NumericRadio.TabStop = true;
            this.yourAsk1NumericRadio.Text = "numeryczna";
            this.yourAsk1NumericRadio.UseVisualStyleBackColor = true;
            // 
            // yourAsk1Name
            // 
            this.yourAsk1Name.AutoSize = true;
            this.yourAsk1Name.Location = new System.Drawing.Point(900, 25);
            this.yourAsk1Name.Name = "yourAsk1Name";
            this.yourAsk1Name.Size = new System.Drawing.Size(83, 13);
            this.yourAsk1Name.TabIndex = 20;
            this.yourAsk1Name.Text = "Nazwa tej danej";
            // 
            // yourAsk1TextBox
            // 
            this.yourAsk1TextBox.Location = new System.Drawing.Point(903, 44);
            this.yourAsk1TextBox.Name = "yourAsk1TextBox";
            this.yourAsk1TextBox.Size = new System.Drawing.Size(100, 20);
            this.yourAsk1TextBox.TabIndex = 21;
            // 
            // yourAsk2TextBox
            // 
            this.yourAsk2TextBox.Location = new System.Drawing.Point(903, 124);
            this.yourAsk2TextBox.Name = "yourAsk2TextBox";
            this.yourAsk2TextBox.Size = new System.Drawing.Size(100, 20);
            this.yourAsk2TextBox.TabIndex = 25;
            // 
            // yourAsk2Name
            // 
            this.yourAsk2Name.AutoSize = true;
            this.yourAsk2Name.Location = new System.Drawing.Point(900, 105);
            this.yourAsk2Name.Name = "yourAsk2Name";
            this.yourAsk2Name.Size = new System.Drawing.Size(83, 13);
            this.yourAsk2Name.TabIndex = 24;
            this.yourAsk2Name.Text = "Nazwa tej danej";
            // 
            // yourAsk2Box
            // 
            this.yourAsk2Box.Controls.Add(this.yourAsk2StringRadio);
            this.yourAsk2Box.Controls.Add(this.yourAsk2NumericRadio);
            this.yourAsk2Box.Location = new System.Drawing.Point(792, 105);
            this.yourAsk2Box.Name = "yourAsk2Box";
            this.yourAsk2Box.Size = new System.Drawing.Size(102, 76);
            this.yourAsk2Box.TabIndex = 23;
            this.yourAsk2Box.TabStop = false;
            this.yourAsk2Box.Text = "Własna dana 2";
            // 
            // yourAsk2StringRadio
            // 
            this.yourAsk2StringRadio.AutoSize = true;
            this.yourAsk2StringRadio.Location = new System.Drawing.Point(6, 43);
            this.yourAsk2StringRadio.Name = "yourAsk2StringRadio";
            this.yourAsk2StringRadio.Size = new System.Drawing.Size(50, 17);
            this.yourAsk2StringRadio.TabIndex = 1;
            this.yourAsk2StringRadio.TabStop = true;
            this.yourAsk2StringRadio.Text = "napis";
            this.yourAsk2StringRadio.UseVisualStyleBackColor = true;
            // 
            // yourAsk2NumericRadio
            // 
            this.yourAsk2NumericRadio.AutoSize = true;
            this.yourAsk2NumericRadio.Location = new System.Drawing.Point(6, 20);
            this.yourAsk2NumericRadio.Name = "yourAsk2NumericRadio";
            this.yourAsk2NumericRadio.Size = new System.Drawing.Size(82, 17);
            this.yourAsk2NumericRadio.TabIndex = 0;
            this.yourAsk2NumericRadio.TabStop = true;
            this.yourAsk2NumericRadio.Text = "numeryczna";
            this.yourAsk2NumericRadio.UseVisualStyleBackColor = true;
            // 
            // yourAsk2
            // 
            this.yourAsk2.AutoSize = true;
            this.yourAsk2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.yourAsk2.Location = new System.Drawing.Point(623, 105);
            this.yourAsk2.Name = "yourAsk2";
            this.yourAsk2.Size = new System.Drawing.Size(163, 29);
            this.yourAsk2.TabIndex = 22;
            this.yourAsk2.Text = "Własna dana 2";
            this.yourAsk2.UseVisualStyleBackColor = true;
            // 
            // yourAsk3TextBox
            // 
            this.yourAsk3TextBox.Location = new System.Drawing.Point(903, 206);
            this.yourAsk3TextBox.Name = "yourAsk3TextBox";
            this.yourAsk3TextBox.Size = new System.Drawing.Size(100, 20);
            this.yourAsk3TextBox.TabIndex = 29;
            // 
            // yourAsk3Name
            // 
            this.yourAsk3Name.AutoSize = true;
            this.yourAsk3Name.Location = new System.Drawing.Point(900, 187);
            this.yourAsk3Name.Name = "yourAsk3Name";
            this.yourAsk3Name.Size = new System.Drawing.Size(83, 13);
            this.yourAsk3Name.TabIndex = 28;
            this.yourAsk3Name.Text = "Nazwa tej danej";
            // 
            // yourAsk3Box
            // 
            this.yourAsk3Box.Controls.Add(this.yourAsk3StringRadio);
            this.yourAsk3Box.Controls.Add(this.yourAsk3NumericRadio);
            this.yourAsk3Box.Location = new System.Drawing.Point(792, 187);
            this.yourAsk3Box.Name = "yourAsk3Box";
            this.yourAsk3Box.Size = new System.Drawing.Size(102, 76);
            this.yourAsk3Box.TabIndex = 27;
            this.yourAsk3Box.TabStop = false;
            this.yourAsk3Box.Text = "Własna dana 2";
            // 
            // yourAsk3StringRadio
            // 
            this.yourAsk3StringRadio.AutoSize = true;
            this.yourAsk3StringRadio.Location = new System.Drawing.Point(6, 43);
            this.yourAsk3StringRadio.Name = "yourAsk3StringRadio";
            this.yourAsk3StringRadio.Size = new System.Drawing.Size(50, 17);
            this.yourAsk3StringRadio.TabIndex = 1;
            this.yourAsk3StringRadio.TabStop = true;
            this.yourAsk3StringRadio.Text = "napis";
            this.yourAsk3StringRadio.UseVisualStyleBackColor = true;
            // 
            // yourAsk3NumericRadio
            // 
            this.yourAsk3NumericRadio.AutoSize = true;
            this.yourAsk3NumericRadio.Location = new System.Drawing.Point(6, 20);
            this.yourAsk3NumericRadio.Name = "yourAsk3NumericRadio";
            this.yourAsk3NumericRadio.Size = new System.Drawing.Size(82, 17);
            this.yourAsk3NumericRadio.TabIndex = 0;
            this.yourAsk3NumericRadio.TabStop = true;
            this.yourAsk3NumericRadio.Text = "numeryczna";
            this.yourAsk3NumericRadio.UseVisualStyleBackColor = true;
            // 
            // yourAsk3
            // 
            this.yourAsk3.AutoSize = true;
            this.yourAsk3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.yourAsk3.Location = new System.Drawing.Point(623, 187);
            this.yourAsk3.Name = "yourAsk3";
            this.yourAsk3.Size = new System.Drawing.Size(163, 29);
            this.yourAsk3.TabIndex = 26;
            this.yourAsk3.Text = "Własna dana 3";
            this.yourAsk3.UseVisualStyleBackColor = true;
            // 
            // yourAsk4TextBox
            // 
            this.yourAsk4TextBox.Location = new System.Drawing.Point(903, 290);
            this.yourAsk4TextBox.Name = "yourAsk4TextBox";
            this.yourAsk4TextBox.Size = new System.Drawing.Size(100, 20);
            this.yourAsk4TextBox.TabIndex = 33;
            // 
            // yourAsk4Name
            // 
            this.yourAsk4Name.AutoSize = true;
            this.yourAsk4Name.Location = new System.Drawing.Point(900, 271);
            this.yourAsk4Name.Name = "yourAsk4Name";
            this.yourAsk4Name.Size = new System.Drawing.Size(83, 13);
            this.yourAsk4Name.TabIndex = 32;
            this.yourAsk4Name.Text = "Nazwa tej danej";
            // 
            // yourAsk4Box
            // 
            this.yourAsk4Box.Controls.Add(this.yourAsk4StringRadio);
            this.yourAsk4Box.Controls.Add(this.yourAsk4NumericRadio);
            this.yourAsk4Box.Location = new System.Drawing.Point(792, 271);
            this.yourAsk4Box.Name = "yourAsk4Box";
            this.yourAsk4Box.Size = new System.Drawing.Size(102, 76);
            this.yourAsk4Box.TabIndex = 31;
            this.yourAsk4Box.TabStop = false;
            this.yourAsk4Box.Text = "Własna dana 2";
            // 
            // yourAsk4StringRadio
            // 
            this.yourAsk4StringRadio.AutoSize = true;
            this.yourAsk4StringRadio.Location = new System.Drawing.Point(6, 43);
            this.yourAsk4StringRadio.Name = "yourAsk4StringRadio";
            this.yourAsk4StringRadio.Size = new System.Drawing.Size(50, 17);
            this.yourAsk4StringRadio.TabIndex = 1;
            this.yourAsk4StringRadio.TabStop = true;
            this.yourAsk4StringRadio.Text = "napis";
            this.yourAsk4StringRadio.UseVisualStyleBackColor = true;
            // 
            // yourAsk4NumericRadio
            // 
            this.yourAsk4NumericRadio.AutoSize = true;
            this.yourAsk4NumericRadio.Location = new System.Drawing.Point(6, 20);
            this.yourAsk4NumericRadio.Name = "yourAsk4NumericRadio";
            this.yourAsk4NumericRadio.Size = new System.Drawing.Size(82, 17);
            this.yourAsk4NumericRadio.TabIndex = 0;
            this.yourAsk4NumericRadio.TabStop = true;
            this.yourAsk4NumericRadio.Text = "numeryczna";
            this.yourAsk4NumericRadio.UseVisualStyleBackColor = true;
            // 
            // yourAsk4
            // 
            this.yourAsk4.AutoSize = true;
            this.yourAsk4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.yourAsk4.Location = new System.Drawing.Point(623, 271);
            this.yourAsk4.Name = "yourAsk4";
            this.yourAsk4.Size = new System.Drawing.Size(163, 29);
            this.yourAsk4.TabIndex = 30;
            this.yourAsk4.Text = "Własna dana 4";
            this.yourAsk4.UseVisualStyleBackColor = true;
            // 
            // yourAsk5TextBox
            // 
            this.yourAsk5TextBox.Location = new System.Drawing.Point(903, 373);
            this.yourAsk5TextBox.Name = "yourAsk5TextBox";
            this.yourAsk5TextBox.Size = new System.Drawing.Size(100, 20);
            this.yourAsk5TextBox.TabIndex = 37;
            // 
            // yourAsk5Name
            // 
            this.yourAsk5Name.AutoSize = true;
            this.yourAsk5Name.Location = new System.Drawing.Point(900, 354);
            this.yourAsk5Name.Name = "yourAsk5Name";
            this.yourAsk5Name.Size = new System.Drawing.Size(83, 13);
            this.yourAsk5Name.TabIndex = 36;
            this.yourAsk5Name.Text = "Nazwa tej danej";
            // 
            // yourAsk5Box
            // 
            this.yourAsk5Box.Controls.Add(this.yourAsk5StringRadio);
            this.yourAsk5Box.Controls.Add(this.yourAsk5NumericRadio);
            this.yourAsk5Box.Location = new System.Drawing.Point(792, 354);
            this.yourAsk5Box.Name = "yourAsk5Box";
            this.yourAsk5Box.Size = new System.Drawing.Size(102, 76);
            this.yourAsk5Box.TabIndex = 35;
            this.yourAsk5Box.TabStop = false;
            this.yourAsk5Box.Text = "Własna dana 2";
            // 
            // yourAsk5StringRadio
            // 
            this.yourAsk5StringRadio.AutoSize = true;
            this.yourAsk5StringRadio.Location = new System.Drawing.Point(6, 43);
            this.yourAsk5StringRadio.Name = "yourAsk5StringRadio";
            this.yourAsk5StringRadio.Size = new System.Drawing.Size(50, 17);
            this.yourAsk5StringRadio.TabIndex = 1;
            this.yourAsk5StringRadio.TabStop = true;
            this.yourAsk5StringRadio.Text = "napis";
            this.yourAsk5StringRadio.UseVisualStyleBackColor = true;
            // 
            // yourAsk5NumericRadio
            // 
            this.yourAsk5NumericRadio.AutoSize = true;
            this.yourAsk5NumericRadio.Location = new System.Drawing.Point(6, 20);
            this.yourAsk5NumericRadio.Name = "yourAsk5NumericRadio";
            this.yourAsk5NumericRadio.Size = new System.Drawing.Size(82, 17);
            this.yourAsk5NumericRadio.TabIndex = 0;
            this.yourAsk5NumericRadio.TabStop = true;
            this.yourAsk5NumericRadio.Text = "numeryczna";
            this.yourAsk5NumericRadio.UseVisualStyleBackColor = true;
            // 
            // yourAsk5
            // 
            this.yourAsk5.AutoSize = true;
            this.yourAsk5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.yourAsk5.Location = new System.Drawing.Point(623, 354);
            this.yourAsk5.Name = "yourAsk5";
            this.yourAsk5.Size = new System.Drawing.Size(163, 29);
            this.yourAsk5.TabIndex = 34;
            this.yourAsk5.Text = "Własna dana 5";
            this.yourAsk5.UseVisualStyleBackColor = true;
            // 
            // chosenFileToWrite
            // 
            this.chosenFileToWrite.AutoSize = true;
            this.chosenFileToWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chosenFileToWrite.Location = new System.Drawing.Point(-2, 639);
            this.chosenFileToWrite.Name = "chosenFileToWrite";
            this.chosenFileToWrite.Size = new System.Drawing.Size(320, 20);
            this.chosenFileToWrite.TabIndex = 38;
            this.chosenFileToWrite.Text = "Ścieżka wybranego pliku do roższerzenia to:";
            // 
            // chosenFolderToSave
            // 
            this.chosenFolderToSave.AutoSize = true;
            this.chosenFolderToSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chosenFolderToSave.Location = new System.Drawing.Point(384, 639);
            this.chosenFolderToSave.Name = "chosenFolderToSave";
            this.chosenFolderToSave.Size = new System.Drawing.Size(221, 20);
            this.chosenFolderToSave.TabIndex = 39;
            this.chosenFolderToSave.Text = "Ścieżka wybranego folderu to:";
            // 
            // nameOfNewFileLabel
            // 
            this.nameOfNewFileLabel.AutoSize = true;
            this.nameOfNewFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.nameOfNewFileLabel.Location = new System.Drawing.Point(733, 535);
            this.nameOfNewFileLabel.Name = "nameOfNewFileLabel";
            this.nameOfNewFileLabel.Size = new System.Drawing.Size(130, 26);
            this.nameOfNewFileLabel.TabIndex = 40;
            this.nameOfNewFileLabel.Text = "Nazwa pliku";
            // 
            // newFileNameTextBox
            // 
            this.newFileNameTextBox.Location = new System.Drawing.Point(708, 564);
            this.newFileNameTextBox.Name = "newFileNameTextBox";
            this.newFileNameTextBox.Size = new System.Drawing.Size(186, 20);
            this.newFileNameTextBox.TabIndex = 41;
            // 
            // newFileToTXT
            // 
            this.newFileToTXT.AutoSize = true;
            this.newFileToTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.newFileToTXT.Location = new System.Drawing.Point(734, 590);
            this.newFileToTXT.Name = "newFileToTXT";
            this.newFileToTXT.Size = new System.Drawing.Size(129, 24);
            this.newFileToTXT.TabIndex = 42;
            this.newFileToTXT.Text = "Zapisz jako txt";
            this.newFileToTXT.UseVisualStyleBackColor = true;
            // 
            // newFileToCSV
            // 
            this.newFileToCSV.AutoSize = true;
            this.newFileToCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.newFileToCSV.Location = new System.Drawing.Point(734, 620);
            this.newFileToCSV.Name = "newFileToCSV";
            this.newFileToCSV.Size = new System.Drawing.Size(135, 24);
            this.newFileToCSV.TabIndex = 43;
            this.newFileToCSV.Text = "Zapisz jako csv";
            this.newFileToCSV.UseVisualStyleBackColor = true;
            // 
            // showAnswerByColor
            // 
            this.showAnswerByColor.AutoSize = true;
            this.showAnswerByColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.showAnswerByColor.Location = new System.Drawing.Point(6, 373);
            this.showAnswerByColor.Name = "showAnswerByColor";
            this.showAnswerByColor.Size = new System.Drawing.Size(312, 29);
            this.showAnswerByColor.TabIndex = 44;
            this.showAnswerByColor.Text = "Pokaż odpowiedź po przez kolor";
            this.showAnswerByColor.UseVisualStyleBackColor = true;
            // 
            // aiAnswersToo
            // 
            this.aiAnswersToo.AutoSize = true;
            this.aiAnswersToo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.aiAnswersToo.Location = new System.Drawing.Point(6, 401);
            this.aiAnswersToo.Name = "aiAnswersToo";
            this.aiAnswersToo.Size = new System.Drawing.Size(144, 29);
            this.aiAnswersToo.TabIndex = 45;
            this.aiAnswersToo.Text = "AI też ocenia";
            this.aiAnswersToo.UseVisualStyleBackColor = true;
            // 
            // aiAnswersTooShow
            // 
            this.aiAnswersTooShow.AutoSize = true;
            this.aiAnswersTooShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.aiAnswersTooShow.Location = new System.Drawing.Point(150, 401);
            this.aiAnswersTooShow.Name = "aiAnswersTooShow";
            this.aiAnswersTooShow.Size = new System.Drawing.Size(324, 29);
            this.aiAnswersTooShow.TabIndex = 46;
            this.aiAnswersTooShow.Text = "Pokaż poprawność odpowiedzi AI";
            this.aiAnswersTooShow.UseVisualStyleBackColor = true;
            // 
            // showHumanAnswers
            // 
            this.showHumanAnswers.AutoSize = true;
            this.showHumanAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.showHumanAnswers.Location = new System.Drawing.Point(6, 436);
            this.showHumanAnswers.Name = "showHumanAnswers";
            this.showHumanAnswers.Size = new System.Drawing.Size(409, 29);
            this.showHumanAnswers.TabIndex = 47;
            this.showHumanAnswers.Text = "Pokaż poprawność udzielanych odpowiedzi";
            this.showHumanAnswers.UseVisualStyleBackColor = true;
            // 
            // resetFileButton
            // 
            this.resetFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.resetFileButton.Location = new System.Drawing.Point(12, 471);
            this.resetFileButton.Name = "resetFileButton";
            this.resetFileButton.Size = new System.Drawing.Size(291, 47);
            this.resetFileButton.TabIndex = 48;
            this.resetFileButton.Text = "Reset pliku do dopisania";
            this.resetFileButton.UseVisualStyleBackColor = true;
            this.resetFileButton.Click += new System.EventHandler(this.resetFileButton_Click);
            // 
            // resetFolder
            // 
            this.resetFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.resetFolder.Location = new System.Drawing.Point(344, 471);
            this.resetFolder.Name = "resetFolder";
            this.resetFolder.Size = new System.Drawing.Size(328, 47);
            this.resetFolder.TabIndex = 49;
            this.resetFolder.Text = "Zrestartuj wybrany folder";
            this.resetFolder.UseVisualStyleBackColor = true;
            this.resetFolder.Click += new System.EventHandler(this.resetFolder_Click);
            // 
            // research_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 702);
            this.Controls.Add(this.resetFolder);
            this.Controls.Add(this.resetFileButton);
            this.Controls.Add(this.showHumanAnswers);
            this.Controls.Add(this.aiAnswersTooShow);
            this.Controls.Add(this.aiAnswersToo);
            this.Controls.Add(this.showAnswerByColor);
            this.Controls.Add(this.newFileToCSV);
            this.Controls.Add(this.newFileToTXT);
            this.Controls.Add(this.newFileNameTextBox);
            this.Controls.Add(this.nameOfNewFileLabel);
            this.Controls.Add(this.chosenFolderToSave);
            this.Controls.Add(this.chosenFileToWrite);
            this.Controls.Add(this.yourAsk5TextBox);
            this.Controls.Add(this.yourAsk5Name);
            this.Controls.Add(this.yourAsk5Box);
            this.Controls.Add(this.yourAsk5);
            this.Controls.Add(this.yourAsk4TextBox);
            this.Controls.Add(this.yourAsk4Name);
            this.Controls.Add(this.yourAsk4Box);
            this.Controls.Add(this.yourAsk4);
            this.Controls.Add(this.yourAsk3TextBox);
            this.Controls.Add(this.yourAsk3Name);
            this.Controls.Add(this.yourAsk3Box);
            this.Controls.Add(this.yourAsk3);
            this.Controls.Add(this.yourAsk2TextBox);
            this.Controls.Add(this.yourAsk2Name);
            this.Controls.Add(this.yourAsk2Box);
            this.Controls.Add(this.yourAsk2);
            this.Controls.Add(this.yourAsk1TextBox);
            this.Controls.Add(this.yourAsk1Name);
            this.Controls.Add(this.yourAsk1Box);
            this.Controls.Add(this.yourAsk1);
            this.Controls.Add(this.askExistingData);
            this.Controls.Add(this.whereToSaveFolderButton);
            this.Controls.Add(this.numericImgLimit);
            this.Controls.Add(this.numericSeconds);
            this.Controls.Add(this.askPopulation);
            this.Controls.Add(this.askYears);
            this.Controls.Add(this.askGender);
            this.Controls.Add(this.askSavePaths);
            this.Controls.Add(this.askLimitImg);
            this.Controls.Add(this.askSaveHowLong);
            this.Controls.Add(this.askTimeMax);
            this.Controls.Add(this.settingAcceptButton);
            this.Controls.Add(this.badAnswer);
            this.Controls.Add(this.goodAnswer);
            this.Controls.Add(this.takePoint);
            this.Controls.Add(this.addPoint);
            this.Controls.Add(this.pointAskBox);
            this.Controls.Add(this.settingsAsk);
            this.Name = "research_setting";
            this.Text = "research_setting";
            ((System.ComponentModel.ISupportInitialize)(this.addPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.takePoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericImgLimit)).EndInit();
            this.yourAsk1Box.ResumeLayout(false);
            this.yourAsk1Box.PerformLayout();
            this.yourAsk2Box.ResumeLayout(false);
            this.yourAsk2Box.PerformLayout();
            this.yourAsk3Box.ResumeLayout(false);
            this.yourAsk3Box.PerformLayout();
            this.yourAsk4Box.ResumeLayout(false);
            this.yourAsk4Box.PerformLayout();
            this.yourAsk5Box.ResumeLayout(false);
            this.yourAsk5Box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label settingsAsk;
        private System.Windows.Forms.CheckBox pointAskBox;
        private System.Windows.Forms.NumericUpDown addPoint;
        private System.Windows.Forms.NumericUpDown takePoint;
        private System.Windows.Forms.Label goodAnswer;
        private System.Windows.Forms.Label badAnswer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button settingAcceptButton;
        private System.Windows.Forms.CheckBox askTimeMax;
        private System.Windows.Forms.CheckBox askSaveHowLong;
        private System.Windows.Forms.CheckBox askLimitImg;
        private System.Windows.Forms.CheckBox askSavePaths;
        private System.Windows.Forms.CheckBox askGender;
        private System.Windows.Forms.CheckBox askYears;
        private System.Windows.Forms.CheckBox askPopulation;
        private System.Windows.Forms.NumericUpDown numericSeconds;
        private System.Windows.Forms.NumericUpDown numericImgLimit;
        private System.Windows.Forms.Button whereToSaveFolderButton;
        private System.Windows.Forms.Button askExistingData;
        private System.Windows.Forms.CheckBox yourAsk1;
        private System.Windows.Forms.GroupBox yourAsk1Box;
        private System.Windows.Forms.RadioButton yourAsk1StringRadio;
        private System.Windows.Forms.RadioButton yourAsk1NumericRadio;
        private System.Windows.Forms.Label yourAsk1Name;
        private System.Windows.Forms.TextBox yourAsk1TextBox;
        private System.Windows.Forms.TextBox yourAsk2TextBox;
        private System.Windows.Forms.Label yourAsk2Name;
        private System.Windows.Forms.GroupBox yourAsk2Box;
        private System.Windows.Forms.RadioButton yourAsk2StringRadio;
        private System.Windows.Forms.RadioButton yourAsk2NumericRadio;
        private System.Windows.Forms.CheckBox yourAsk2;
        private System.Windows.Forms.TextBox yourAsk3TextBox;
        private System.Windows.Forms.Label yourAsk3Name;
        private System.Windows.Forms.GroupBox yourAsk3Box;
        private System.Windows.Forms.RadioButton yourAsk3StringRadio;
        private System.Windows.Forms.RadioButton yourAsk3NumericRadio;
        private System.Windows.Forms.CheckBox yourAsk3;
        private System.Windows.Forms.TextBox yourAsk4TextBox;
        private System.Windows.Forms.Label yourAsk4Name;
        private System.Windows.Forms.GroupBox yourAsk4Box;
        private System.Windows.Forms.RadioButton yourAsk4StringRadio;
        private System.Windows.Forms.RadioButton yourAsk4NumericRadio;
        private System.Windows.Forms.CheckBox yourAsk4;
        private System.Windows.Forms.TextBox yourAsk5TextBox;
        private System.Windows.Forms.Label yourAsk5Name;
        private System.Windows.Forms.GroupBox yourAsk5Box;
        private System.Windows.Forms.RadioButton yourAsk5StringRadio;
        private System.Windows.Forms.RadioButton yourAsk5NumericRadio;
        private System.Windows.Forms.CheckBox yourAsk5;
        private System.Windows.Forms.Label chosenFileToWrite;
        private System.Windows.Forms.Label chosenFolderToSave;
        private System.Windows.Forms.Label nameOfNewFileLabel;
        private System.Windows.Forms.TextBox newFileNameTextBox;
        private System.Windows.Forms.CheckBox newFileToTXT;
        private System.Windows.Forms.CheckBox newFileToCSV;
        private System.Windows.Forms.CheckBox showAnswerByColor;
        private System.Windows.Forms.CheckBox aiAnswersToo;
        private System.Windows.Forms.CheckBox aiAnswersTooShow;
        private System.Windows.Forms.CheckBox showHumanAnswers;
        private System.Windows.Forms.Button resetFileButton;
        private System.Windows.Forms.Button resetFolder;
    }
}