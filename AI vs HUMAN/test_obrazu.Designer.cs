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
            this.checkButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.answerAIorNOT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // challangeBitton
            // 
            this.challangeBitton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.challangeBitton.Location = new System.Drawing.Point(447, 352);
            this.challangeBitton.Name = "challangeBitton";
            this.challangeBitton.Size = new System.Drawing.Size(280, 86);
            this.challangeBitton.TabIndex = 0;
            this.challangeBitton.Text = "Mini gra, pojedynek z AI";
            this.challangeBitton.UseVisualStyleBackColor = true;
            // 
            // checkButton
            // 
            this.checkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.checkButton.Location = new System.Drawing.Point(12, 352);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(429, 86);
            this.checkButton.TabIndex = 1;
            this.checkButton.Text = "Sprawdź czy ten obraz został wygenerowany przez AI";
            this.checkButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(497, 334);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(577, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "WYNIK";
            // 
            // answerAIorNOT
            // 
            this.answerAIorNOT.AutoSize = true;
            this.answerAIorNOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.answerAIorNOT.Location = new System.Drawing.Point(515, 181);
            this.answerAIorNOT.Name = "answerAIorNOT";
            this.answerAIorNOT.Size = new System.Drawing.Size(216, 20);
            this.answerAIorNOT.TabIndex = 4;
            this.answerAIorNOT.Text = "Nie wygenerowane przez AI";
            // 
            // test_obrazu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 450);
            this.Controls.Add(this.answerAIorNOT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.challangeBitton);
            this.Name = "test_obrazu";
            this.Text = "test_obrazu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button challangeBitton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label answerAIorNOT;
    }
}