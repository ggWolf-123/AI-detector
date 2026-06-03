namespace AI_vs_HUMAN
{
    partial class language
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
            this.polishButton = new System.Windows.Forms.Button();
            this.englishButton = new System.Windows.Forms.Button();
            this.spanishButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // polishButton
            // 
            this.polishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.polishButton.Location = new System.Drawing.Point(12, 12);
            this.polishButton.Name = "polishButton";
            this.polishButton.Size = new System.Drawing.Size(179, 87);
            this.polishButton.TabIndex = 0;
            this.polishButton.Text = "POLSKI";
            this.polishButton.UseVisualStyleBackColor = true;
            this.polishButton.Click += new System.EventHandler(this.polishButton_Click);
            // 
            // englishButton
            // 
            this.englishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.englishButton.Location = new System.Drawing.Point(210, 12);
            this.englishButton.Name = "englishButton";
            this.englishButton.Size = new System.Drawing.Size(179, 87);
            this.englishButton.TabIndex = 1;
            this.englishButton.Text = "ENGLISH";
            this.englishButton.UseVisualStyleBackColor = true;
            this.englishButton.Click += new System.EventHandler(this.englishButton_Click);
            // 
            // spanishButton
            // 
            this.spanishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.spanishButton.Location = new System.Drawing.Point(12, 124);
            this.spanishButton.Name = "spanishButton";
            this.spanishButton.Size = new System.Drawing.Size(179, 87);
            this.spanishButton.TabIndex = 2;
            this.spanishButton.Text = "ESPAÑOL";
            this.spanishButton.UseVisualStyleBackColor = true;
            this.spanishButton.Click += new System.EventHandler(this.spanishButton_Click);
            // 
            // language
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 223);
            this.Controls.Add(this.spanishButton);
            this.Controls.Add(this.englishButton);
            this.Controls.Add(this.polishButton);
            this.Name = "language";
            this.Text = "language";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button polishButton;
        private System.Windows.Forms.Button englishButton;
        private System.Windows.Forms.Button spanishButton;
    }
}