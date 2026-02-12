using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AI_vs_HUMAN
{
    public partial class speed : Form
    {
        public int SelectedSpeed {get; private set; }
        private Size originalSize;
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        public speed()
        {
            LanguageManager.SetLanguage(LanguageManager.CurrentLanguage);
            InitializeComponent();
            ApplyLanguage();

            this.Load += startLoad;
            this.Resize += startResize;
        }
        private void ApplyLanguage()
        {
            this.Text = Properties.Resources.challangeBitton;
            LanguageManager.ApplyLanguageToControls(this);
        }
        private void startLoad(object sender, EventArgs e)
        {
            originalSize = this.Size;
            ResizeControl.StoreOriginalBoundsRecursive(this, originalControlBounds);
        }
        private void startResize(object sender, EventArgs E)
        {
            ResizeControl.ResizeControlsRecursive(this, originalControlBounds, originalSize);
        }
        
        private void acceptSpeedButton_Click(object sender, EventArgs e)
        {
            int speed = 0;
            if(superSlowRadio.Checked) speed=1;
            else if(slowRadio.Checked) speed=15;
            else if(normalRadio.Checked) speed=30;
            else if(fastRadio.Checked) speed=60;
            else if(superFastRadio.Checked) speed=120;

            if(speed==0 && (speedUserNumeric.Value>=1))
            {
                speed = (int)speedUserNumeric.Value;
                if (speed < 1 || speed > 1000)
                {
                    MessageBox.Show($"Proszę podać prędkość z zakresu 1-1000.\nLub wybrać jedną z opcji");
                    return;
                }
            }
            if (speed == 0)
            {
                MessageBox.Show($"Proszę wybrać prędkość lub podać własną.");
                return;
            }
            SelectedSpeed = speed;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
