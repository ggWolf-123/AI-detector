namespace AI_vs_HUMAN
{
    partial class speed
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
            this.groupBoxSpeed = new System.Windows.Forms.GroupBox();
            this.superFastRadio = new System.Windows.Forms.RadioButton();
            this.fastRadio = new System.Windows.Forms.RadioButton();
            this.normalRadio = new System.Windows.Forms.RadioButton();
            this.slowRadio = new System.Windows.Forms.RadioButton();
            this.superSlowRadio = new System.Windows.Forms.RadioButton();
            this.labelFast = new System.Windows.Forms.Label();
            this.acceptSpeedButton = new System.Windows.Forms.Button();
            this.speedUserNumeric = new System.Windows.Forms.NumericUpDown();
            this.groupBoxSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedUserNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxSpeed
            // 
            this.groupBoxSpeed.Controls.Add(this.superFastRadio);
            this.groupBoxSpeed.Controls.Add(this.fastRadio);
            this.groupBoxSpeed.Controls.Add(this.normalRadio);
            this.groupBoxSpeed.Controls.Add(this.slowRadio);
            this.groupBoxSpeed.Controls.Add(this.superSlowRadio);
            this.groupBoxSpeed.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSpeed.Name = "groupBoxSpeed";
            this.groupBoxSpeed.Size = new System.Drawing.Size(343, 152);
            this.groupBoxSpeed.TabIndex = 0;
            this.groupBoxSpeed.TabStop = false;
            this.groupBoxSpeed.Text = "Wybierz prędkość przetwarzania wideo";
            // 
            // superFastRadio
            // 
            this.superFastRadio.AutoSize = true;
            this.superFastRadio.Location = new System.Drawing.Point(6, 129);
            this.superFastRadio.Name = "superFastRadio";
            this.superFastRadio.Size = new System.Drawing.Size(163, 17);
            this.superFastRadio.TabIndex = 4;
            this.superFastRadio.Text = "Super szybko (co 120 klatkę)";
            this.superFastRadio.UseVisualStyleBackColor = true;
            // 
            // fastRadio
            // 
            this.fastRadio.AutoSize = true;
            this.fastRadio.Location = new System.Drawing.Point(6, 106);
            this.fastRadio.Name = "fastRadio";
            this.fastRadio.Size = new System.Drawing.Size(128, 17);
            this.fastRadio.TabIndex = 3;
            this.fastRadio.Text = "Szybko (co 60 klatkę)";
            this.fastRadio.UseVisualStyleBackColor = true;
            // 
            // normalRadio
            // 
            this.normalRadio.AutoSize = true;
            this.normalRadio.Location = new System.Drawing.Point(6, 83);
            this.normalRadio.Name = "normalRadio";
            this.normalRadio.Size = new System.Drawing.Size(140, 17);
            this.normalRadio.TabIndex = 2;
            this.normalRadio.Text = "Normalnie (co 30 klatkę)";
            this.normalRadio.UseVisualStyleBackColor = true;
            // 
            // slowRadio
            // 
            this.slowRadio.AutoSize = true;
            this.slowRadio.Location = new System.Drawing.Point(6, 60);
            this.slowRadio.Name = "slowRadio";
            this.slowRadio.Size = new System.Drawing.Size(221, 17);
            this.slowRadio.TabIndex = 1;
            this.slowRadio.Text = "Wolno (co 15 klatka ma być sprawdzona)";
            this.slowRadio.UseVisualStyleBackColor = true;
            // 
            // superSlowRadio
            // 
            this.superSlowRadio.AutoSize = true;
            this.superSlowRadio.Location = new System.Drawing.Point(6, 37);
            this.superSlowRadio.Name = "superSlowRadio";
            this.superSlowRadio.Size = new System.Drawing.Size(251, 17);
            this.superSlowRadio.TabIndex = 0;
            this.superSlowRadio.Text = "Super wolno (każda klatka ma być sprawdzona)";
            this.superSlowRadio.UseVisualStyleBackColor = true;
            // 
            // labelFast
            // 
            this.labelFast.AutoSize = true;
            this.labelFast.Location = new System.Drawing.Point(9, 167);
            this.labelFast.Name = "labelFast";
            this.labelFast.Size = new System.Drawing.Size(397, 13);
            this.labelFast.TabIndex = 1;
            this.labelFast.Text = "Co ile klatek ma być sprawdzane wideo (wartości wpisane nie mają pierwszeństwa)";
            // 
            // acceptSpeedButton
            // 
            this.acceptSpeedButton.Location = new System.Drawing.Point(187, 183);
            this.acceptSpeedButton.Name = "acceptSpeedButton";
            this.acceptSpeedButton.Size = new System.Drawing.Size(214, 26);
            this.acceptSpeedButton.TabIndex = 3;
            this.acceptSpeedButton.Text = "Potwierdzam prędkość";
            this.acceptSpeedButton.UseVisualStyleBackColor = true;
            this.acceptSpeedButton.Click += new System.EventHandler(this.acceptSpeedButton_Click);
            // 
            // speedUserNumeric
            // 
            this.speedUserNumeric.Location = new System.Drawing.Point(12, 183);
            this.speedUserNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speedUserNumeric.Name = "speedUserNumeric";
            this.speedUserNumeric.Size = new System.Drawing.Size(169, 20);
            this.speedUserNumeric.TabIndex = 4;
            // 
            // speed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 214);
            this.Controls.Add(this.speedUserNumeric);
            this.Controls.Add(this.acceptSpeedButton);
            this.Controls.Add(this.labelFast);
            this.Controls.Add(this.groupBoxSpeed);
            this.Name = "speed";
            this.Text = "speed";
            this.groupBoxSpeed.ResumeLayout(false);
            this.groupBoxSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedUserNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSpeed;
        private System.Windows.Forms.RadioButton superFastRadio;
        private System.Windows.Forms.RadioButton fastRadio;
        private System.Windows.Forms.RadioButton normalRadio;
        private System.Windows.Forms.RadioButton slowRadio;
        private System.Windows.Forms.RadioButton superSlowRadio;
        private System.Windows.Forms.Label labelFast;
        private System.Windows.Forms.Button acceptSpeedButton;
        private System.Windows.Forms.NumericUpDown speedUserNumeric;
    }
}