namespace AI_vs_HUMAN
{
    partial class research_tool
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
            this.yesButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.randomPhoto = new System.Windows.Forms.PictureBox();
            this.questionMG = new System.Windows.Forms.Label();
            this.endButton = new System.Windows.Forms.Button();
            this.humanScore = new System.Windows.Forms.Label();
            this.youRight = new System.Windows.Forms.Label();
            this.youWrong = new System.Windows.Forms.Label();
            this.aiScore = new System.Windows.Forms.Label();
            this.aiRight = new System.Windows.Forms.Label();
            this.aiWrong = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.startGameButton = new System.Windows.Forms.Button();
            this.previousTitle = new System.Windows.Forms.Label();
            this.previousAnswer = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.settingsOfData = new System.Windows.Forms.Button();
            this.changeLang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.randomPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // yesButton
            // 
            this.yesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.yesButton.Location = new System.Drawing.Point(872, 939);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(860, 110);
            this.yesButton.TabIndex = 0;
            this.yesButton.Text = "TAK";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // noButton
            // 
            this.noButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.noButton.Location = new System.Drawing.Point(12, 939);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(860, 110);
            this.noButton.TabIndex = 1;
            this.noButton.Text = "NIE";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // randomPhoto
            // 
            this.randomPhoto.Location = new System.Drawing.Point(12, 102);
            this.randomPhoto.Name = "randomPhoto";
            this.randomPhoto.Size = new System.Drawing.Size(1088, 831);
            this.randomPhoto.TabIndex = 2;
            this.randomPhoto.TabStop = false;
            // 
            // questionMG
            // 
            this.questionMG.AutoSize = true;
            this.questionMG.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.questionMG.Location = new System.Drawing.Point(12, 27);
            this.questionMG.Name = "questionMG";
            this.questionMG.Size = new System.Drawing.Size(891, 47);
            this.questionMG.TabIndex = 3;
            this.questionMG.Text = "Czy ta grafika została wygenerowana przez AI?";
            // 
            // endButton
            // 
            this.endButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.endButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.endButton.Location = new System.Drawing.Point(1422, 780);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(310, 153);
            this.endButton.TabIndex = 4;
            this.endButton.Text = "Koniec, wróć";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // humanScore
            // 
            this.humanScore.AutoSize = true;
            this.humanScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 50.25F);
            this.humanScore.Location = new System.Drawing.Point(1264, 9);
            this.humanScore.Name = "humanScore";
            this.humanScore.Size = new System.Drawing.Size(357, 76);
            this.humanScore.TabIndex = 5;
            this.humanScore.Text = "Twój wynik";
            // 
            // youRight
            // 
            this.youRight.AutoSize = true;
            this.youRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.youRight.Location = new System.Drawing.Point(1253, 102);
            this.youRight.Name = "youRight";
            this.youRight.Size = new System.Drawing.Size(0, 47);
            this.youRight.TabIndex = 6;
            // 
            // youWrong
            // 
            this.youWrong.AutoSize = true;
            this.youWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.youWrong.Location = new System.Drawing.Point(1233, 168);
            this.youWrong.Name = "youWrong";
            this.youWrong.Size = new System.Drawing.Size(0, 47);
            this.youWrong.TabIndex = 7;
            // 
            // aiScore
            // 
            this.aiScore.AutoSize = true;
            this.aiScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 50.25F);
            this.aiScore.Location = new System.Drawing.Point(1285, 244);
            this.aiScore.Name = "aiScore";
            this.aiScore.Size = new System.Drawing.Size(296, 76);
            this.aiScore.TabIndex = 8;
            this.aiScore.Text = "Wynik AI";
            // 
            // aiRight
            // 
            this.aiRight.AutoSize = true;
            this.aiRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.aiRight.Location = new System.Drawing.Point(1269, 334);
            this.aiRight.Name = "aiRight";
            this.aiRight.Size = new System.Drawing.Size(0, 47);
            this.aiRight.TabIndex = 9;
            // 
            // aiWrong
            // 
            this.aiWrong.AutoSize = true;
            this.aiWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.aiWrong.Location = new System.Drawing.Point(1269, 397);
            this.aiWrong.Name = "aiWrong";
            this.aiWrong.Size = new System.Drawing.Size(0, 47);
            this.aiWrong.TabIndex = 10;
            // 
            // restartButton
            // 
            this.restartButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.restartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.restartButton.Location = new System.Drawing.Point(1106, 780);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(310, 153);
            this.restartButton.TabIndex = 11;
            this.restartButton.Text = "Reset";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // startGameButton
            // 
            this.startGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.startGameButton.Location = new System.Drawing.Point(94, 428);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(860, 110);
            this.startGameButton.TabIndex = 12;
            this.startGameButton.Text = "Zacznij";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // previousTitle
            // 
            this.previousTitle.AutoSize = true;
            this.previousTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.previousTitle.Location = new System.Drawing.Point(1095, 502);
            this.previousTitle.Name = "previousTitle";
            this.previousTitle.Size = new System.Drawing.Size(0, 63);
            this.previousTitle.TabIndex = 13;
            // 
            // previousAnswer
            // 
            this.previousAnswer.AutoSize = true;
            this.previousAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.previousAnswer.Location = new System.Drawing.Point(1126, 606);
            this.previousAnswer.Name = "previousAnswer";
            this.previousAnswer.Size = new System.Drawing.Size(0, 47);
            this.previousAnswer.TabIndex = 14;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.timeLabel.Location = new System.Drawing.Point(909, 27);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 47);
            this.timeLabel.TabIndex = 15;
            // 
            // settingsOfData
            // 
            this.settingsOfData.Location = new System.Drawing.Point(1627, 57);
            this.settingsOfData.Name = "settingsOfData";
            this.settingsOfData.Size = new System.Drawing.Size(105, 52);
            this.settingsOfData.TabIndex = 16;
            this.settingsOfData.Text = "Ustawienia";
            this.settingsOfData.UseVisualStyleBackColor = true;
            this.settingsOfData.Click += new System.EventHandler(this.settingsOfData_Click);
            // 
            // changeLang
            // 
            this.changeLang.Location = new System.Drawing.Point(1627, 12);
            this.changeLang.Name = "changeLang";
            this.changeLang.Size = new System.Drawing.Size(105, 39);
            this.changeLang.TabIndex = 17;
            this.changeLang.Text = "Zmień język";
            this.changeLang.UseVisualStyleBackColor = true;
            this.changeLang.Click += new System.EventHandler(this.changeLang_Click);
            // 
            // research_tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 1061);
            this.Controls.Add(this.changeLang);
            this.Controls.Add(this.settingsOfData);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.previousAnswer);
            this.Controls.Add(this.previousTitle);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.aiWrong);
            this.Controls.Add(this.aiRight);
            this.Controls.Add(this.aiScore);
            this.Controls.Add(this.youWrong);
            this.Controls.Add(this.youRight);
            this.Controls.Add(this.humanScore);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.questionMG);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.randomPhoto);
            this.Name = "research_tool";
            this.Text = "mini_gra";
            ((System.ComponentModel.ISupportInitialize)(this.randomPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.PictureBox randomPhoto;
        private System.Windows.Forms.Label questionMG;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Label humanScore;
        private System.Windows.Forms.Label youRight;
        private System.Windows.Forms.Label youWrong;
        private System.Windows.Forms.Label aiScore;
        private System.Windows.Forms.Label aiRight;
        private System.Windows.Forms.Label aiWrong;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Label previousTitle;
        private System.Windows.Forms.Label previousAnswer;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button settingsOfData;
        private System.Windows.Forms.Button changeLang;
    }
}