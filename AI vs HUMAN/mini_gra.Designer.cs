namespace AI_vs_HUMAN
{
    partial class mini_gra
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.youRight = new System.Windows.Forms.Label();
            this.youWrong = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.aiRight = new System.Windows.Forms.Label();
            this.aiWrong = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.startGameButton = new System.Windows.Forms.Button();
            this.previousTitle = new System.Windows.Forms.Label();
            this.previousAnswer = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(891, 47);
            this.label1.TabIndex = 3;
            this.label1.Text = "Czy ta grafika została wygenerowana przez AI?";
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.button1.Location = new System.Drawing.Point(1422, 780);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(310, 153);
            this.button1.TabIndex = 4;
            this.button1.Text = "Koniec, wróć";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 50.25F);
            this.label2.Location = new System.Drawing.Point(1264, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 76);
            this.label2.TabIndex = 5;
            this.label2.Text = "Twój wynik";
            // 
            // youRight
            // 
            this.youRight.AutoSize = true;
            this.youRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.youRight.Location = new System.Drawing.Point(1253, 102);
            this.youRight.Name = "youRight";
            this.youRight.Size = new System.Drawing.Size(368, 47);
            this.youRight.TabIndex = 6;
            this.youRight.Text = "Miałeś/-aś rację : 0";
            // 
            // youWrong
            // 
            this.youWrong.AutoSize = true;
            this.youWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.youWrong.Location = new System.Drawing.Point(1233, 168);
            this.youWrong.Name = "youWrong";
            this.youWrong.Size = new System.Drawing.Size(388, 47);
            this.youWrong.TabIndex = 7;
            this.youWrong.Text = "Pomyliłeś/-łaś się: 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 50.25F);
            this.label3.Location = new System.Drawing.Point(1285, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 76);
            this.label3.TabIndex = 8;
            this.label3.Text = "Wynik AI";
            // 
            // aiRight
            // 
            this.aiRight.AutoSize = true;
            this.aiRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.aiRight.Location = new System.Drawing.Point(1269, 334);
            this.aiRight.Name = "aiRight";
            this.aiRight.Size = new System.Drawing.Size(327, 47);
            this.aiRight.TabIndex = 9;
            this.aiRight.Text = "AI miało rację:  0";
            // 
            // aiWrong
            // 
            this.aiWrong.AutoSize = true;
            this.aiWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.aiWrong.Location = new System.Drawing.Point(1269, 397);
            this.aiWrong.Name = "aiWrong";
            this.aiWrong.Size = new System.Drawing.Size(333, 47);
            this.aiWrong.TabIndex = 10;
            this.aiWrong.Text = "AI pomyliło się: 0";
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
            this.startGameButton.Text = "Zacznij grę";
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
            // mini_gra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 1061);
            this.Controls.Add(this.previousAnswer);
            this.Controls.Add(this.previousTitle);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.aiWrong);
            this.Controls.Add(this.aiRight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.youWrong);
            this.Controls.Add(this.youRight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.randomPhoto);
            this.Name = "mini_gra";
            this.Text = "mini_gra";
            ((System.ComponentModel.ISupportInitialize)(this.randomPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.PictureBox randomPhoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label youRight;
        private System.Windows.Forms.Label youWrong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label aiRight;
        private System.Windows.Forms.Label aiWrong;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Label previousTitle;
        private System.Windows.Forms.Label previousAnswer;
    }
}