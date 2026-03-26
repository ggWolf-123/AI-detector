namespace AI_vs_HUMAN
{
    partial class file_test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(file_test));
            this.challangeBitton = new System.Windows.Forms.Button();
            this.getPhotoButton = new System.Windows.Forms.Button();
            this.pictureToCheck = new System.Windows.Forms.PictureBox();
            this.photoPath = new System.Windows.Forms.OpenFileDialog();
            this.checkButton = new System.Windows.Forms.Button();
            this.answerAIorNOT = new System.Windows.Forms.Label();
            this.answerFileCheck = new System.Windows.Forms.Label();
            this.changeLang = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.checkFolderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureToCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // challangeBitton
            // 
            this.challangeBitton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.challangeBitton.Location = new System.Drawing.Point(904, 559);
            this.challangeBitton.Name = "challangeBitton";
            this.challangeBitton.Size = new System.Drawing.Size(298, 90);
            this.challangeBitton.TabIndex = 0;
            this.challangeBitton.Text = "Moduł badawczy";
            this.challangeBitton.UseVisualStyleBackColor = true;
            this.challangeBitton.Click += new System.EventHandler(this.challangeBitton_Click);
            // 
            // getPhotoButton
            // 
            this.getPhotoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.getPhotoButton.Location = new System.Drawing.Point(12, 562);
            this.getPhotoButton.Name = "getPhotoButton";
            this.getPhotoButton.Size = new System.Drawing.Size(445, 90);
            this.getPhotoButton.TabIndex = 1;
            this.getPhotoButton.Text = "Podaj obraz do sprawdzenia";
            this.getPhotoButton.UseVisualStyleBackColor = true;
            this.getPhotoButton.Click += new System.EventHandler(this.getPhotoButton_Click);
            // 
            // pictureToCheck
            // 
            this.pictureToCheck.Location = new System.Drawing.Point(12, 12);
            this.pictureToCheck.Name = "pictureToCheck";
            this.pictureToCheck.Size = new System.Drawing.Size(886, 544);
            this.pictureToCheck.TabIndex = 2;
            this.pictureToCheck.TabStop = false;
            // 
            // photoPath
            // 
            this.photoPath.FileName = "photoPath";
            // 
            // checkButton
            // 
            this.checkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.checkButton.Location = new System.Drawing.Point(904, 124);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(298, 211);
            this.checkButton.TabIndex = 5;
            this.checkButton.Text = "SPRAWDŹ!!!";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // answerAIorNOT
            // 
            this.answerAIorNOT.AutoSize = true;
            this.answerAIorNOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.answerAIorNOT.Location = new System.Drawing.Point(904, 438);
            this.answerAIorNOT.Name = "answerAIorNOT";
            this.answerAIorNOT.Size = new System.Drawing.Size(106, 25);
            this.answerAIorNOT.TabIndex = 4;
            this.answerAIorNOT.Text = "TO NIE AI";
            // 
            // answerFileCheck
            // 
            this.answerFileCheck.AutoSize = true;
            this.answerFileCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.answerFileCheck.Location = new System.Drawing.Point(921, 338);
            this.answerFileCheck.Name = "answerFileCheck";
            this.answerFileCheck.Size = new System.Drawing.Size(130, 39);
            this.answerFileCheck.TabIndex = 3;
            this.answerFileCheck.Text = "WYNIK";
            // 
            // changeLang
            // 
            this.changeLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.changeLang.Location = new System.Drawing.Point(912, 8);
            this.changeLang.Name = "changeLang";
            this.changeLang.Size = new System.Drawing.Size(290, 110);
            this.changeLang.TabIndex = 6;
            this.changeLang.Text = "Zmień język";
            this.changeLang.UseVisualStyleBackColor = true;
            this.changeLang.Click += new System.EventHandler(this.changeLang_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 12);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(886, 544);
            this.axWindowsMediaPlayer1.TabIndex = 7;
            // 
            // checkFolderButton
            // 
            this.checkFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.checkFolderButton.Location = new System.Drawing.Point(463, 562);
            this.checkFolderButton.Name = "checkFolderButton";
            this.checkFolderButton.Size = new System.Drawing.Size(435, 90);
            this.checkFolderButton.TabIndex = 8;
            this.checkFolderButton.Text = "Sprawdź pliki z wybranego folderu";
            this.checkFolderButton.UseVisualStyleBackColor = true;
            this.checkFolderButton.Click += new System.EventHandler(this.checkFolderButton_Click);
            // 
            // file_test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 661);
            this.Controls.Add(this.checkFolderButton);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.changeLang);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.answerAIorNOT);
            this.Controls.Add(this.answerFileCheck);
            this.Controls.Add(this.pictureToCheck);
            this.Controls.Add(this.getPhotoButton);
            this.Controls.Add(this.challangeBitton);
            this.Name = "file_test";
            this.Text = "test_obrazu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureToCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button challangeBitton;
        private System.Windows.Forms.Button getPhotoButton;
        private System.Windows.Forms.PictureBox pictureToCheck;
        private System.Windows.Forms.OpenFileDialog photoPath;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Label answerAIorNOT;
        private System.Windows.Forms.Label answerFileCheck;
        private System.Windows.Forms.Button changeLang;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button checkFolderButton;
    }
}