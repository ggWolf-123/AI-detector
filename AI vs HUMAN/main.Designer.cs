namespace AI_vs_HUMAN
{
    partial class main
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
            this.startButton = new System.Windows.Forms.Button();
            this.changeLang = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 50.25F);
            this.startButton.Location = new System.Drawing.Point(12, 239);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(1720, 810);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Uruchom model (może to chwile zająć)";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // changeLang
            // 
            this.changeLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 50.25F);
            this.changeLang.Location = new System.Drawing.Point(12, 12);
            this.changeLang.Name = "changeLang";
            this.changeLang.Size = new System.Drawing.Size(1720, 221);
            this.changeLang.TabIndex = 1;
            this.changeLang.Text = "Zmień język";
            this.changeLang.UseVisualStyleBackColor = true;
            this.changeLang.Click += new System.EventHandler(this.changeLang_Click);
            // 
            // uruchom_model
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 1061);
            this.Controls.Add(this.changeLang);
            this.Controls.Add(this.startButton);
            this.Name = "uruchom_model";
            this.Text = "uruchom_model";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button changeLang;
    }
}