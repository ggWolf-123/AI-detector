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
            ((System.ComponentModel.ISupportInitialize)(this.pictureToCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // challangeBitton
            // 
            this.challangeBitton.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.challangeBitton.Location = new System.Drawing.Point(1225, 902);
            this.challangeBitton.Name = "challangeBitton";
            this.challangeBitton.Size = new System.Drawing.Size(507, 147);
            this.challangeBitton.TabIndex = 0;
            this.challangeBitton.Text = "Mini gra, pojedynek z AI";
            this.challangeBitton.UseVisualStyleBackColor = true;
            this.challangeBitton.Click += new System.EventHandler(this.challangeBitton_Click);
            // 
            // getPhotoButton
            // 
            this.getPhotoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 40.25F);
            this.getPhotoButton.Location = new System.Drawing.Point(12, 902);
            this.getPhotoButton.Name = "getPhotoButton";
            this.getPhotoButton.Size = new System.Drawing.Size(1207, 147);
            this.getPhotoButton.TabIndex = 1;
            this.getPhotoButton.Text = "Podaj obraz do sprawdzenia";
            this.getPhotoButton.UseVisualStyleBackColor = true;
            this.getPhotoButton.Click += new System.EventHandler(this.getPhotoButton_Click);
            // 
            // pictureToCheck
            // 
            this.pictureToCheck.Location = new System.Drawing.Point(12, 12);
            this.pictureToCheck.Name = "pictureToCheck";
            this.pictureToCheck.Size = new System.Drawing.Size(1207, 884);
            this.pictureToCheck.TabIndex = 2;
            this.pictureToCheck.TabStop = false;
            // 
            // photoPath
            // 
            this.photoPath.FileName = "photoPath";
            // 
            // checkButton
            // 
            this.checkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.checkButton.Location = new System.Drawing.Point(1225, 128);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(507, 211);
            this.checkButton.TabIndex = 5;
            this.checkButton.Text = "SPRAWDŹ!!!";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // answerAIorNOT
            // 
            this.answerAIorNOT.AutoSize = true;
            this.answerAIorNOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.answerAIorNOT.Location = new System.Drawing.Point(1228, 526);
            this.answerAIorNOT.Name = "answerAIorNOT";
            this.answerAIorNOT.Size = new System.Drawing.Size(31, 46);
            this.answerAIorNOT.TabIndex = 4;
            this.answerAIorNOT.Text = " ";
            // 
            // answerFileCheck
            // 
            this.answerFileCheck.AutoSize = true;
            this.answerFileCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.answerFileCheck.Location = new System.Drawing.Point(1225, 342);
            this.answerFileCheck.Name = "answerFileCheck";
            this.answerFileCheck.Size = new System.Drawing.Size(204, 63);
            this.answerFileCheck.TabIndex = 3;
            this.answerFileCheck.Text = "WYNIK";
            // 
            // changeLang
            // 
            this.changeLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.changeLang.Location = new System.Drawing.Point(1225, 12);
            this.changeLang.Name = "changeLang";
            this.changeLang.Size = new System.Drawing.Size(507, 110);
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
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(1207, 884);
            this.axWindowsMediaPlayer1.TabIndex = 7;
            // 
            // test_obrazu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 1061);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.changeLang);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.answerAIorNOT);
            this.Controls.Add(this.answerFileCheck);
            this.Controls.Add(this.pictureToCheck);
            this.Controls.Add(this.getPhotoButton);
            this.Controls.Add(this.challangeBitton);
            this.Name = "test_obrazu";
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
    }
}