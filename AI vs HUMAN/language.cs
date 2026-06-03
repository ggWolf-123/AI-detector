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
    public partial class language : Form
    {
        public language()
        {
            InitializeComponent();
            this.Load += startLoad;
            this.Resize += startResize;
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
        ///    Change the language of the form and all controls on it. The text for each control is taken from the resources file, so it will be automatically updated when the language is changed. This method is called after changing the language to update the UI.
        /// </summary>
        private void ApplyLanguage()
        {
            LanguageManager.ApplyLanguageToControls(this);
        }
        /// <summary>
        ///     Change the language to Spanish when the Spanish button is clicked. It calls the SetLanguage method of the LanguageManager class to change the current language to Spanish (using the culture code "es") and then calls the ApplyLanguage method to update the UI with the new language settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spanishButton_Click(object sender, EventArgs e)
        {
            LanguageManager.SetLanguage("es");
            ApplyLanguage();
        }
        /// <summary>
        ///     Change the language to Polish when the Polish button is clicked. It calls the SetLanguage method of the LanguageManager class to change the current language to Polish (using the culture code "pl") and then calls the ApplyLanguage method to update the UI with the new language settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void polishButton_Click(object sender, EventArgs e)
        {
            LanguageManager.SetLanguage("pl");
            ApplyLanguage();
        }
        /// <summary>
        ///     Change the language to English when the English button is clicked. It calls the SetLanguage method of the LanguageManager class to change the current language to English (using the culture code "en") and then calls the ApplyLanguage method to update the UI with the new language settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void englishButton_Click(object sender, EventArgs e)
        {
            LanguageManager.SetLanguage("en");
            ApplyLanguage();
        }
    }
}
