using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_vs_HUMAN
{
    public class LanguageManager
    {
        public static string CurrentLanguage { get; private set; } = "pl";

        /// <summary>
        /// Function to set the application's language based on the provided culture code (e.g., "en" for English, "pl" for Polish), soon to others.
        /// </summary>
        /// <param name="cultureCode">The culture code representing the desired language.</param>
        public static void SetLanguage(string cultureCode)
        {
            try
            {
                CurrentLanguage = cultureCode;
                CultureInfo culture = new CultureInfo(cultureCode);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        /// <summary>
        ///  Function to change the application's language at runtime. It calls SetLanguage to update the culture and then applies the new language settings to all controls in the application.
        /// </summary>
        /// <param name="cultureCode">The culture code representing the desired language.</param>
        public static void ChangeLanguage(string cultureCode)
        {
            LanguageManager.SetLanguage(cultureCode);
        }
        /// <summary>
        ///  Function to apply the current language settings to all controls in the application. It iterates through all controls and updates their text properties based on the resource manager's values for the current language.
        /// </summary>
        /// <param name="parent">The parent control whose child controls' text properties are to be updated.</param>
        public static void ApplyLanguageToControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                try
                {
                    var prop = Properties.Resources.ResourceManager.GetString(ctrl.Name);
                    if (!string.IsNullOrEmpty(prop))
                    {
                        ctrl.Text = prop;
                    }
                }
                catch { }
                if (ctrl.Controls.Count > 0)
                {
                    ApplyLanguageToControls(ctrl);
                }
            }
        }
    }
}
