namespace AI_vs_HUMAN
{
    partial class test_obrazu
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
            this.challangeBitton = new System.Windows.Forms.Button();
            this.getPhotoButton = new System.Windows.Forms.Button();
            this.pictureToCheck = new System.Windows.Forms.PictureBox();
            this.photoPath = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.answerAIorNOT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureToCheck)).BeginInit();
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.button1.Location = new System.Drawing.Point(1225, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(507, 327);
            this.button1.TabIndex = 5;
            this.button1.Text = "SPRAWDŹ!!!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // answerAIorNOT
            // 
            this.answerAIorNOT.AutoSize = true;
            this.answerAIorNOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.answerAIorNOT.Location = new System.Drawing.Point(1228, 526);
            this.answerAIorNOT.Name = "answerAIorNOT";
            this.answerAIorNOT.Size = new System.Drawing.Size(515, 46);
            this.answerAIorNOT.TabIndex = 4;
            this.answerAIorNOT.Text = "Nie wygenerowane przez AI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.label1.Location = new System.Drawing.Point(1225, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 63);
            this.label1.TabIndex = 3;
            this.label1.Text = "WYNIK";
            // 
            // test_obrazu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 1061);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.answerAIorNOT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureToCheck);
            this.Controls.Add(this.getPhotoButton);
            this.Controls.Add(this.challangeBitton);
            this.Name = "test_obrazu";
            this.Text = "test_obrazu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureToCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button challangeBitton;
        private System.Windows.Forms.Button getPhotoButton;
        private System.Windows.Forms.PictureBox pictureToCheck;
        private System.Windows.Forms.OpenFileDialog photoPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label answerAIorNOT;
        private System.Windows.Forms.Label label1;
    }
}