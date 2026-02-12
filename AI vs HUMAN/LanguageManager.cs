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
        public static void ChangeLanguage(string cultureCode)
        {
            LanguageManager.SetLanguage(cultureCode);
        }
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
