using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace card_creator
{
    public partial class Form1 : Form
    {
        Color color1, color2;
        Bitmap? IconImage;

        int width = 1280, height = 512;

        string cardGeneratedText, fileopenTitle, openFilter, savefileTitle;

        string R1_last = "", R2_last = "", G1_last = "", G2_last = "", B1_last = "", B2_last = "";

        string[] sub_images;

        public Form1()
        {
            InitializeComponent();
            languageCombo.SelectedIndex = 0;
            languageCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            color1_generate();
            color2_generate();
            generate_gradient_preview();
        }

        private Image CreateTextImage(string text, string font_path, int font_size, int bufferX, int bufferY)
        {
            if (text == "")
                text = " ";
            using (Bitmap tempImage = new Bitmap(1, 1))
            {
                using (Graphics tempGraphics = Graphics.FromImage(tempImage))
                {
                    PrivateFontCollection fontCollection = new PrivateFontCollection();
                    fontCollection.AddFontFile(font_path);
                    FontFamily fontFamily = fontCollection.Families[0];
                    Font font = new Font(fontFamily, font_size, FontStyle.Regular, GraphicsUnit.Pixel);
                    StringFormat format = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center
                    };

                    SizeF textSize = tempGraphics.MeasureString(text, font);

                    int width = (int)Math.Ceiling(textSize.Width) + bufferX;
                    int height = (int)Math.Ceiling(textSize.Height) + bufferY;

                    using (Bitmap image = new Bitmap(width, height))
                    {
                        using (Graphics graphics = Graphics.FromImage(image))
                        {
                            graphics.Clear(Color.Transparent);
                            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                            graphics.DrawString(text, font, Brushes.White, new RectangleF(0, 0, width, height), format);
                        }

                        return (Image)image.Clone();
                    }
                }
            }
        }

        private void iconButton_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog()
            {
                RestoreDirectory = true,
                Title = fileopenTitle,
                Filter = openFilter,
                CheckFileExists = true,
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var FileName = openFileDialog1.FileName;
                var OriginalIconImage = new Bitmap(FileName);

                var stretchedImage = new Bitmap(450, 450);

                using (Graphics graphics = Graphics.FromImage(stretchedImage))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    graphics.DrawImage(OriginalIconImage, new Rectangle(0, 0, stretchedImage.Width, stretchedImage.Height));
                }

                using (Graphics graphics = Graphics.FromImage(stretchedImage))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    GraphicsPath circlePath = new GraphicsPath();
                    circlePath.AddEllipse(new Rectangle(0, 0, stretchedImage.Width, stretchedImage.Height));
                    Region circleRegion = new Region(circlePath);
                    circleRegion.Xor(new Region(new Rectangle(0, 0, stretchedImage.Width, stretchedImage.Height)));
                    graphics.SetClip(circleRegion, CombineMode.Replace);
                    graphics.Clear(Color.Transparent);
                }

                iconDisplay.Image = stretchedImage;
                IconImage = stretchedImage;
            }
        }

        private void flagsButton_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog()
            {
                RestoreDirectory = true,
                Title = fileopenTitle,
                Filter = openFilter,
                CheckFileExists = true,
                Multiselect = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sub_images = openFileDialog1.FileNames;
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string? strWorkPath = Path.GetDirectoryName(strExeFilePath);

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                RestoreDirectory = true,
                Title = savefileTitle,
                Filter = ".png|*.png|.jpg|*.jpg|.bmp|*.bmp"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap gradient = new Bitmap(width, height);

                for (int y = 0; y < height; y++)
                {
                    float interpolation = (float)y / (height - 1);

                    for (int x = 0; x < width; x++)
                    {
                        int red = (int)((1 - interpolation) * color1.R + interpolation * color2.R);
                        int green = (int)((1 - interpolation) * color1.G + interpolation * color2.G);
                        int blue = (int)((1 - interpolation) * color1.B + interpolation * color2.B);

                        gradient.SetPixel(x, y, Color.FromArgb(red, green, blue));
                    }
                }

                Bitmap finalBitmap = new Bitmap(width, height);

                using (Graphics g = Graphics.FromImage(finalBitmap))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    g.DrawImage(gradient, 0, 0);

                    int boxWidth = 1256;
                    int boxHeight = 488;
                    int boxX = (width - boxWidth) / 2;
                    int boxY = (height - boxHeight) / 2;

                    GraphicsPath path = new GraphicsPath();
                    int cornerRadius = boxHeight / 4;
                    path.AddArc(boxX, boxY, cornerRadius * 2, cornerRadius * 2, 180, 90);
                    path.AddArc(boxX + boxWidth - cornerRadius * 2, boxY, cornerRadius * 2, cornerRadius * 2, 270, 90);
                    path.AddArc(boxX + boxWidth - cornerRadius * 2, boxY + boxHeight - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                    path.AddArc(boxX, boxY + boxHeight - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                    path.CloseFigure();

                    Color blackWithTransparency = Color.FromArgb(180, 0, 0, 0);
                    using (Brush brush = new SolidBrush(blackWithTransparency))
                    {
                        g.FillPath(brush, path);
                    }

                    if (IconImage != null)
                    {
                        int IconX = 264 - (IconImage.Width / 2);
                        int IconY = 256 - (IconImage.Height / 2);

                        g.DrawImage(IconImage, IconX, IconY);
                    }

                    if (strWorkPath != null)
                    {
                        Image titleText = CreateTextImage(titleInput.Text, Path.Combine(strWorkPath, "Fonts/IMPACT.TTF"), 80, 0, 0);
                        Image Sub1 = CreateTextImage(subtitle1Input.Text, Path.Combine(strWorkPath, "Fonts/NotoSans-Light.ttf"), 30, 0, 0);
                        Image Sub2 = CreateTextImage(subtitle2Input.Text, Path.Combine(strWorkPath, "Fonts/NotoSans-Italic.ttf"), 45, 0, 0);

                        if (titleInput.Text != "")
                        {
                            int TitleX = 475;
                            int TitleY = 137 - titleText.Height;

                            g.DrawImage(titleText, TitleX, TitleY);
                        }

                        if (subtitle1Input.Text != "")
                        {
                            int Sub1X = 460 + titleText.Width;
                            int Sub1Y = 141 - titleText.Height + Sub1.Height;

                            g.DrawImage(Sub1, Sub1X, Sub1Y);
                        }

                        if (subtitle2Input.Text != "")
                        {
                            int Sub2X = 500;
                            int Sub2Y = 225 - titleText.Height;

                            g.DrawImage(Sub2, Sub2X, Sub2Y);
                        }

                        int sub_image_X = 525;
                        int sub_image_Y = 300 - titleText.Height + 10;
                        for (int i=0; i < sub_images.Length; i++)
                        {
                            string imagePath = sub_images[i];

                            using (Image originalImage = Image.FromFile(imagePath))
                            {
                                int originalWidth = originalImage.Width;
                                int originalHeight = originalImage.Height;

                                int targetHeight = 64;
                                int targetWidth = (int)Math.Round(originalWidth * (double)targetHeight / originalHeight);

                                using (Image resizedImage = new Bitmap(targetWidth, targetHeight))
                                {
                                    using (Graphics graphics = Graphics.FromImage(resizedImage))
                                    {
                                        graphics.DrawImage(originalImage, 0, 0, targetWidth, targetHeight);
                                    }

                                    g.DrawImage(resizedImage, sub_image_X, sub_image_Y);
                                    sub_image_X += resizedImage.Width + 10;
                                }
                            }
                        }
                    }
                }

                if (saveFileDialog.FileName.EndsWith(".png"))
                {
                    finalBitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                }
                else if (saveFileDialog.FileName.EndsWith(".jpg"))
                {
                    finalBitmap.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                }
                else if (saveFileDialog.FileName.EndsWith(".bmp"))
                {
                    finalBitmap.Save(saveFileDialog.FileName);
                }

                MessageBox.Show(cardGeneratedText);
            }
        }

        private void languageCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languageCombo.SelectedIndex == 0) // English
            {
                this.Text = "Card Creator";
                this.Update();

                label1.Text = "Title";
                label2.Text = "Subtitle 1";
                label3.Text = "Subtitle 2";
                label4.Text = "Created by Elite Watermelon";
                label5.Text = "R";
                label6.Text = "G";
                label7.Text = "B";
                label8.Text = "R";
                label9.Text = "G";
                label10.Text = "B";
                label11.Text = "Recommended image size is 1:1";

                iconButton.Text = "Select Icon";
                flagsButton.Text = "Select Sub-Images";
                generateButton.Text = "Generate Card";

                cardGeneratedText = "Card generated successfully!";
                fileopenTitle = "Open an image file";
                openFilter = "Image Files (*.png, *.jpg, *.bmp)|*.jpg;*.png;*.bmp";
                savefileTitle = "Select a save location";
            }
            else if (languageCombo.SelectedIndex == 1) // Japanese
            {
                this.Text = "カード作成者";
                this.Update();

                label1.Text = "タイトル";
                label2.Text = "サブタイトル一";
                label3.Text = "サブタイトル二";
                label4.Text = "エリート・ウォーターメロンによって作成されました";
                label5.Text = "赤";
                label6.Text = "緑";
                label7.Text = "青";
                label8.Text = "赤";
                label9.Text = "緑";
                label10.Text = "青";
                label11.Text = "推奨画像サイズは一対一です";

                iconButton.Text = "アイコンを選択";
                flagsButton.Text = "サブイメージを選択する";
                generateButton.Text = "カードを生成する";

                cardGeneratedText = "カードが正常に生成されました！";
                fileopenTitle = "画像ファイルを開く";
                openFilter = "画像ファイル (*.png, *.jpg, *.bmp)|*.jpg;*.png;*.bmp";
                savefileTitle = "保存場所を選択してください";
            }
            else if (languageCombo.SelectedIndex == 2) // Spanish
            {
                this.Text = "Creadora de naipes";
                this.Update();

                label1.Text = "Título";
                label2.Text = "Subtítulos 1";
                label3.Text = "Subtítulos 2";
                label4.Text = "Creado por Elite Watermelon | ¡traducido por Leah!";
                label5.Text = "R";
                label6.Text = "G";
                label7.Text = "B";
                label8.Text = "R";
                label9.Text = "G";
                label10.Text = "B";
                label11.Text = "El tamaño de imagen recomendado es 1:1";

                iconButton.Text = "Seleccionar icono";
                flagsButton.Text = "Seleccionar subimágenes";
                generateButton.Text = "Generar tarjeta";

                cardGeneratedText = "¡Tarjeta generada con éxito!";
                fileopenTitle = "Abrir un archivo de imagen";
                openFilter = "Archivos de imagen (*.png, *.jpg, *.bmp)|*.jpg;*.png;*.bmp";
                savefileTitle = "Seleccione una ubicación para guardar";
            }
        }

        private string RGB_Verify(string last_text, string current_text)
        {
            string text = current_text;

            if (text == "")
            {
                text = "0";
            }

            if (int.TryParse(text, out int i))
            {
                if (i < 0)
                {
                    text = "0";
                }
                else if (i > 255)
                {
                    text = "255";
                }
            }
            else
            {
                text = last_text;
            }

            if (text[0] == '0' && text.Length > 1)
            {
                text = text.Substring(1);
            }

            return text;
        }

        private void color1_generate()
        {
            int R = int.Parse(R1.Text);
            int G = int.Parse(G1.Text);
            int B = int.Parse(B1.Text);
            color1 = Color.FromArgb(R, G, B);
            color1preview.BackColor = color1;
        }

        private void color2_generate()
        {
            int R = int.Parse(R2.Text);
            int G = int.Parse(G2.Text);
            int B = int.Parse(B2.Text);
            color2 = Color.FromArgb(R, G, B);
            color2preview.BackColor = color2;
        }

        private void generate_gradient_preview()
        {
            Bitmap gradientImage = new Bitmap(258, 23);
            using (Graphics graphics = Graphics.FromImage(gradientImage))
            {
                LinearGradientBrush brush = new LinearGradientBrush(
                    new Rectangle(0, 0, gradientImage.Width, gradientImage.Height),
                    color1, color2, LinearGradientMode.Horizontal);

                graphics.FillRectangle(brush, 0, 0, gradientImage.Width, gradientImage.Height);
            }

            gradientPreview.Image = gradientImage;
        }

        private void R1_TextChanged(object sender, EventArgs e)
        {
            R1.Text = RGB_Verify(R1_last, R1.Text);
            R1.SelectionStart = R1.Text.Length;
            R1_last = R1.Text;
            color1_generate();
            generate_gradient_preview();
        }

        private void G1_TextChanged(object sender, EventArgs e)
        {
            G1.Text = RGB_Verify(G1_last, G1.Text);
            G1.SelectionStart = G1.Text.Length;
            G1_last = G1.Text;
            color1_generate();
            generate_gradient_preview();
        }

        private void B1_TextChanged(object sender, EventArgs e)
        {
            B1.Text = RGB_Verify(B1_last, B1.Text);
            B1.SelectionStart = B1.Text.Length;
            B1_last = B1.Text;
            color1_generate();
            generate_gradient_preview();
        }

        private void R2_TextChanged(object sender, EventArgs e)
        {
            R2.Text = RGB_Verify(R2_last, R2.Text);
            R2.SelectionStart = R2.Text.Length;
            R2_last = R2.Text;
            color2_generate();
            generate_gradient_preview();
        }

        private void G2_TextChanged(object sender, EventArgs e)
        {
            G2.Text = RGB_Verify(G2_last, G2.Text);
            G2.SelectionStart = G2.Text.Length;
            G2_last = G2.Text;
            color2_generate();
            generate_gradient_preview();
        }

        private void B2_TextChanged(object sender, EventArgs e)
        {
            B2.Text = RGB_Verify(B2_last, B2.Text);
            B2.SelectionStart = B2.Text.Length;
            B2_last = B2.Text;
            color2_generate();
            generate_gradient_preview();
        }
    }
}