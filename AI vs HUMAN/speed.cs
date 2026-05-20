using AI_vs_HUMAN.Properties;
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
        public speed()
        {
            LanguageManager.SetLanguage(LanguageManager.CurrentLanguage);
            InitializeComponent();
            ApplyLanguage();

            this.Load += startLoad;
            this.Resize += startResize;
        }
        /// <summary>
        ///    Change the language of the form and all controls on it. The text for each control is taken from the resources file, so it will be automatically updated when the language is changed. This method is called after changing the language to update the UI.
        /// </summary>
        private void ApplyLanguage()
        {
            LanguageManager.ApplyLanguageToControls(this);
        }
        /// <summary>
        ///     Initialize the form and store the original size and bounds of controls for resizing. It calls the Initialize method of the ResizeControl class, which stores the original size of the form and the original bounds of all controls in a dictionary. This allows the application to resize controls proportionally when the form is resized, maintaining a consistent layout regardless of the form's size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startLoad(object sender, EventArgs e)
        {
            ResizeControl.Initialize(this);
        }
        /// <summary>
        ///     Change the size of the form and all controls on it when the form is resized. It calls the ResizeControlsRecursive method to resize all controls based on the original size and bounds stored during the startLoad event. This ensures that the layout of the form remains consistent regardless of its size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="E"></param>
        private void startResize(object sender, EventArgs E)
        {
            ResizeControl.ResizeControlsRecursive(this);
        }
        /// <summary>
        /// Button click event handler for accepting the selected speed. It checks which radio button is selected and sets the speed variable accordingly. If the user has entered a custom speed, it validates that the speed is within the range of 1-1000. If the speed is valid, it sets the SelectedSpeed property and closes the form with a DialogResult of OK. If the speed is invalid, it shows an error message to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    MessageBox.Show(Resources.chooseSpeed);
                    return;
                }
            }
            if (speed == 0)
            {
                MessageBox.Show(Resources.chooseSpeedOrEnter);
                return;
            }
            SelectedSpeed = speed;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
