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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.youRight = new System.Windows.Forms.Label();
            this.youWrong = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.aiRight = new System.Windows.Forms.Label();
            this.aiWrong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // yesButton
            // 
            this.yesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.yesButton.Location = new System.Drawing.Point(335, 381);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(266, 57);
            this.yesButton.TabIndex = 0;
            this.yesButton.Text = "TAK";
            this.yesButton.UseVisualStyleBackColor = true;
            // 
            // noButton
            // 
            this.noButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.noButton.Location = new System.Drawing.Point(12, 381);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(266, 57);
            this.noButton.TabIndex = 1;
            this.noButton.Text = "NIE";
            this.noButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(589, 334);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(64, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(465, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Czy ta grafika została wygenerowana przez AI?";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button1.Location = new System.Drawing.Point(631, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 57);
            this.button1.TabIndex = 4;
            this.button1.Text = "Koniec, wróć";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(606, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Twój wynik";
            // 
            // youRight
            // 
            this.youRight.AutoSize = true;
            this.youRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.youRight.Location = new System.Drawing.Point(607, 109);
            this.youRight.Name = "youRight";
            this.youRight.Size = new System.Drawing.Size(144, 20);
            this.youRight.TabIndex = 6;
            this.youRight.Text = "Miałeś/-aś rację : ";
            // 
            // youWrong
            // 
            this.youWrong.AutoSize = true;
            this.youWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.youWrong.Location = new System.Drawing.Point(607, 140);
            this.youWrong.Name = "youWrong";
            this.youWrong.Size = new System.Drawing.Size(151, 20);
            this.youWrong.TabIndex = 7;
            this.youWrong.Text = "Pomyliłeś/-łaś się: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label3.Location = new System.Drawing.Point(607, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Wynik AI";
            // 
            // aiRight
            // 
            this.aiRight.AutoSize = true;
            this.aiRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.aiRight.Location = new System.Drawing.Point(607, 237);
            this.aiRight.Name = "aiRight";
            this.aiRight.Size = new System.Drawing.Size(121, 20);
            this.aiRight.TabIndex = 9;
            this.aiRight.Text = "AI miało rację: ";
            // 
            // aiWrong
            // 
            this.aiWrong.AutoSize = true;
            this.aiWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.aiWrong.Location = new System.Drawing.Point(607, 266);
            this.aiWrong.Name = "aiWrong";
            this.aiWrong.Size = new System.Drawing.Size(127, 20);
            this.aiWrong.TabIndex = 10;
            this.aiWrong.Text = "AI pomyliło się: ";
            // 
            // mini_gra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aiWrong);
            this.Controls.Add(this.aiRight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.youWrong);
            this.Controls.Add(this.youRight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Name = "mini_gra";
            this.Text = "mini_gra";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label youRight;
        private System.Windows.Forms.Label youWrong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label aiRight;
        private System.Windows.Forms.Label aiWrong;
    }
}