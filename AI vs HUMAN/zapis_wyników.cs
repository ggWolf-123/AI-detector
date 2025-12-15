using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AI_vs_HUMAN
{
    public partial class zapis_wyników : Form
    {
        private int points;
        public zapis_wyników(int points)
        {
            InitializeComponent();
            this.points = points;
        }

        private void submmitButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(nameText.Text) || string.IsNullOrEmpty(surnameText.Text) || string.IsNullOrEmpty(schoolText.Text))
            {
                MessageBox.Show("Proszę wpisać imię, nazwisko i szkołę.");
                return;
            }
            string filePath = "wyniki.txt";
            bool fileExists = File.Exists(filePath);
            using (StreamWriter writer = new StreamWriter(filePath, append: true, Encoding.UTF8))
            {
                if (!fileExists)
                {
                    writer.WriteLine("Imię,Nazwisko,Szkoła,Punkty,Data");
                }
                string line = $"{nameText.Text},{surnameText.Text},{schoolText.Text},{points},{DateTime.Now}";
                writer.WriteLine(line);
            }
            this.Close();
        }
    }
}
