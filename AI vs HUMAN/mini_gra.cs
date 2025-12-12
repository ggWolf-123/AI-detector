using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_vs_HUMAN
{
    public partial class mini_gra : Form
    {
        private Size originalSize;
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private string mainFolderPath;
        private string selectdImagePath;
        private string[] allImages;
        private int result_from_model = -1;
        private int rightHumanAnswers = 0;
        private int wrongHumanAnswers = 0;
        private int rightAiAnswers = 0;
        private int wrongAiAnswers = 0;
        public mini_gra()
        {
            InitializeComponent();
            this.Shown += (s, e) =>
            {
                this.WindowState = FormWindowState.Maximized;
            };

            this.Load += miniGameLoad;
            this.Resize += miniGameResize;
        }
        private void miniGameLoad(object sender, EventArgs e)
        {
            originalSize = this.Size;
            StoreOriginalBoundsRecursive(this);
        }
        private void miniGameResize(object sender, EventArgs E)
        {
            ResizeControlsRecursive(this);
        }
        private void StoreOriginalBoundsRecursive(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (!originalControlBounds.ContainsKey(ctrl))
                    originalControlBounds[ctrl] = ctrl.Bounds;

                if (ctrl.Controls.Count > 0)
                    StoreOriginalBoundsRecursive(ctrl);
            }
        }
        private void ResizeControlsRecursive(Control parent)
        {
            if (originalSize.Width == 0 || originalSize.Height == 0) return;

            float xRatio = (float)this.Width / originalSize.Width;
            float yRatio = (float)this.Height / originalSize.Height;

            foreach (Control ctrl in parent.Controls)
            {
                if (originalControlBounds.ContainsKey(ctrl))
                {
                    Rectangle orig = originalControlBounds[ctrl];
                    int newX = (int)(orig.X * xRatio);
                    int newY = (int)(orig.Y * yRatio);
                    int newWidth = (int)(orig.Width * xRatio);
                    int newHeight = (int)(orig.Height * yRatio);
                    ctrl.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
                }
                if (ctrl.Controls.Count > 0)
                {
                    ResizeControlsRecursive(ctrl);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            test_obrazu test_Obrazu = new test_obrazu();
            test_Obrazu.ShowDialog();
            this.Close();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Wybierz główny folder z obrazami";
                folderDialog.ShowNewFolderButton = false;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    mainFolderPath = folderDialog.SelectedPath;
                    allImages = System.IO.Directory.GetFiles(mainFolderPath, "*.*", System.IO.SearchOption.AllDirectories)
                        .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                        .ToArray();
                    if(allImages.Length==0)
                    {
                        MessageBox.Show("Wybrany folder nie zawiera żadnych obrazów.");
                        return;
                    }
                    Random rnd = new Random();
                    selectdImagePath = allImages[rnd.Next(allImages.Length)];
                    randomPhoto.Image = Image.FromFile(selectdImagePath);
                    randomPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                    startGameButton.SendToBack();
                    MessageBox.Show($"Wybrano folder: {mainFolderPath}");
                }
            }
        }

        private async void noButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectdImagePath))
            {
                MessageBox.Show("Najpierw rozpocznij grę.");
                return;
            }
            result_from_model = await SendImageToModel(selectdImagePath);
            int answerHuman = 0;
            liderBoard(selectdImagePath, result_from_model, answerHuman);
        }

        private async void yesButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(selectdImagePath))
            {
                MessageBox.Show("Najpierw rozpocznij grę.");
                return;
            }
            result_from_model = await SendImageToModel(selectdImagePath);
            int answerHuman = 1;
            liderBoard(selectdImagePath, result_from_model, answerHuman);
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectdImagePath))
            {
                MessageBox.Show("Najpierw rozpocznij grę.");
                return;
            }
            rightHumanAnswers = 0;
            youRight.Text = "Miałeś/-aś rację : " + rightHumanAnswers;
            wrongHumanAnswers = 0;
            youWrong.Text = "Pomyliłeś/-łaś się: "+wrongHumanAnswers;
            rightAiAnswers = 0;
            aiRight.Text = "AI miało rację : " + rightAiAnswers;
            wrongAiAnswers = 0;
            aiWrong.Text = "AI pomyliło się : " + wrongAiAnswers;
            Random rnd = new Random();
            selectdImagePath = allImages[rnd.Next(allImages.Length)];
            randomPhoto.Image = Image.FromFile(selectdImagePath);
            randomPhoto.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void liderBoard(string imagePath, int answerAI, int answerHuman)
        {
            int rightAnswers = -1;
            string diretoryOfImage = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(imagePath));
            if (diretoryOfImage == "AI")
            {
                rightAnswers = 1;
            }
            else if (diretoryOfImage == "HUMAN")
            {
                rightAnswers = 0;
            }
            if (rightAnswers==answerHuman)
            {
                rightHumanAnswers++;
                youRight.Text = "Miałeś/-aś rację : "+rightHumanAnswers;
            }
            else
            {
                wrongHumanAnswers++;
                youWrong.Text = "Pomyliłeś/-łaś się: "+wrongHumanAnswers;
            }
            if (rightAnswers==answerAI)
            {
                rightAiAnswers++;
                aiRight.Text = "AI miało rację : " + rightAiAnswers;
            }
            else
            {
                wrongAiAnswers++;
                aiWrong.Text = "AI pomyliło się : " + wrongAiAnswers;
            }
            Random rnd = new Random();
            selectdImagePath = allImages[rnd.Next(allImages.Length)];
            randomPhoto.Image = Image.FromFile(selectdImagePath);
            randomPhoto.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private async Task<int> SendImageToModel(string filePath)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://127.0.0.1:8000/");
                using (var content = new MultipartFormDataContent())
                {
                    var imageContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filePath));
                    string ext = System.IO.Path.GetExtension(filePath).ToLower();
                    string mime = "image/jpeg";
                    if (ext == ".png") mime = "image/png";
                    else if (ext == ".bmp") mime = "image/bmp";
                    else if (ext == ".gif") mime = "image/gif";
                    imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mime);
                    content.Add(imageContent, "file", System.IO.Path.GetFileName(filePath));

                    HttpResponseMessage response = await client.PostAsync("predict", content);
                    response.EnsureSuccessStatusCode();

                    var responseString = await response.Content.ReadAsStringAsync();
                    using (var doc = JsonDocument.Parse(responseString))
                    {
                        int prediction = doc.RootElement.GetProperty("result").GetInt32();
                        return prediction;
                    }
                }
            }
        }
    }
}
