namespace AI_vs_HUMAN
{
    partial class zapis_wyników
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.surnameText = new System.Windows.Forms.TextBox();
            this.schoolText = new System.Windows.Forms.TextBox();
            this.submmitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(823, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Podaj informacje by wziąć udział w konkursie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label2.Location = new System.Drawing.Point(270, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Imię";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label3.Location = new System.Drawing.Point(270, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nazwisko";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label4.Location = new System.Drawing.Point(270, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "Szkoła";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(408, 157);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(187, 20);
            this.nameText.TabIndex = 4;
            // 
            // surnameText
            // 
            this.surnameText.Location = new System.Drawing.Point(408, 246);
            this.surnameText.Name = "surnameText";
            this.surnameText.Size = new System.Drawing.Size(187, 20);
            this.surnameText.TabIndex = 5;
            // 
            // schoolText
            // 
            this.schoolText.Location = new System.Drawing.Point(408, 334);
            this.schoolText.Name = "schoolText";
            this.schoolText.Size = new System.Drawing.Size(187, 20);
            this.schoolText.TabIndex = 6;
            // 
            // submmitButton
            // 
            this.submmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.submmitButton.Location = new System.Drawing.Point(276, 415);
            this.submmitButton.Name = "submmitButton";
            this.submmitButton.Size = new System.Drawing.Size(319, 57);
            this.submmitButton.TabIndex = 7;
            this.submmitButton.Text = "Potwierdzam dane";
            this.submmitButton.UseVisualStyleBackColor = true;
            this.submmitButton.Click += new System.EventHandler(this.submmitButton_Click);
            // 
            // zapis_wyników
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 498);
            this.Controls.Add(this.submmitButton);
            this.Controls.Add(this.schoolText);
            this.Controls.Add(this.surnameText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "zapis_wyników";
            this.Text = "zapis_wyników";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox surnameText;
        private System.Windows.Forms.TextBox schoolText;
        private System.Windows.Forms.Button submmitButton;
    }
}