using PDI_Tarea2.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PDI_Tarea2
{
    public partial class Form1 : Form
    {
        Bitmap currentImage;
        int zoomValue;
        public Form1()
        {
            InitializeComponent();
            // Habilitamos double buffer en el contenedor de bitmaps para mejorar el performance
            Form1.SetDoubleBuffered(this.pictureBox1);
            // Asignamos la ventana principal como dueña de todas las subventanas de edicion
            Cache.SetOwner(this, 10);
            // Configuracion de variables
            zoomValue = 1;
        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                return;
            }

            System.Reflection.PropertyInfo aProp =
                typeof(System.Windows.Forms.Control).GetProperty(
                    "DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        private Bitmap convertoTo24(Bitmap orig)
        {
            Bitmap res = new Bitmap(orig.Width, orig.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics gr = Graphics.FromImage(res))
            {
                gr.DrawImage(orig, new Rectangle(0, 0, res.Width, res.Height));
            }
            return res;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentImage = (Bitmap)Image.FromFile(openFileDialog1.FileName);

                if (currentImage.PixelFormat != PixelFormat.Format24bppRgb)
                {
                    if (currentImage.PixelFormat != PixelFormat.Format32bppArgb)
                    {
                        currentImage = convertoTo24((Bitmap)Image.FromFile(openFileDialog1.FileName));
                    }
                }

                pictureBox1.Width = currentImage.Width;
                pictureBox1.Height = currentImage.Height;
                pictureBox2.Width = currentImage.Width;
                pictureBox2.Height = currentImage.Height;
                Form1_Resize(null, null);
                pictureBox1.Image = currentImage;
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                zoomValue = 1;
                this.toolStripLabel5.Text = "100%";
                Cache.Start(currentImage);
                EnableImageControls();
            }
        }

        private void EnableImageControls()
        {
            this.DownloadOriginalToolStripMenuItem.Enabled = true;
            this.ScaleToolStripMenuItem.Enabled = true;
            this.InformacionToolStripMenuItem.Enabled = true;
            this.BarGraphRGBToolStripMenuItem.Enabled = true;
            this.brilloYContrasteToolStripMenuItem.Enabled = true;
            this.NegativeToolStripMenuItem.Enabled = true;
            this.ShadowToolStripMenuItem.Enabled = true;
            this.detectarBordesToolStripMenuItem.Enabled = true;
            this.reduccionDeRuidoToolStripMenuItem.Enabled = true;
            this.RotateToolStripMenuItem.Enabled = true;
            this.HorizontalViewToolStripMenuItem.Enabled = true;
            this.VerticalViewToolStripMenuItem.Enabled = true;
            this.GeneratetoolStripLabel6.Enabled = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                pictureBox1.Left = (this.ImagePanel.Width - currentImage.Width) / 2;
                pictureBox1.Top = (this.ImagePanel.Height - currentImage.Height) / 2;
            }

            this.toolStrip2.Left = this.toolStripContainer1.Width - this.toolStrip2.Width;
        }

        private void negativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setPictureBoxBitmap(Colors.Negativo(this.currentImage));
            Cache.StoreCurrentBitmapData();
        }

        private void informacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                Bitmap bitmap = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                string text = "";
                text += "Розмір у пікселях\t:\t" + currentImage.Width + "x" + currentImage.Height + " пікселів\n";
                text += "Кількість пікселів\t:\t" + currentImage.Width * currentImage.Height + " пікселів\n\n";
                text += "Колірний формат\t:\t" + bitmap.PixelFormat.ToString() + "\n";
                text += "Глибина пікселів\t:\t" + System.Drawing.Bitmap.GetPixelFormatSize(bitmap.PixelFormat) + "\n";
                text += "Кількість кольорів:\t" + Math.Pow(2, System.Drawing.Bitmap.GetPixelFormatSize(bitmap.PixelFormat)) + "\n\n";
                text += "Тип файлу\t:\t * " + Path.GetExtension(openFileDialog1.FileName) + "\n";
                text += "Розмір файлу\t:\t" + fi.Length / 1024.0f + " KB\n";
                MessageBox.Show(text, fi.Name);
            }
        }

        private void histogramaRGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Histogram ht = new Histogram();
            ht.Owner = this;
            ht.Show();
        }

        private void brilloYContrasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brightness_Contrast bc = new Brightness_Contrast();
            bc.Owner = this;
            bc.Show();
        }

        public Bitmap getCurrentBitmap()
        {
            if (this.pictureBox1.Image != null)
            {
                return (Bitmap)this.pictureBox1.Image;
            }

            else
            {
                return null;
            }
        }

        public void setPictureBoxBitmap(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                currentImage = bitmap;

                if (this.pictureBox1.Image.Width != bitmap.Width || this.pictureBox1.Image.Height != bitmap.Height)
                {
                    this.pictureBox1.Width = bitmap.Width;
                    this.pictureBox1.Height = bitmap.Height;
                    Form1_Resize(null, null);
                }

                this.pictureBox1.Image = bitmap;
                this.pictureBox1.Refresh();
                UpdateZoomPictureBox();
            }
        }

        private void umbralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Threshold th = new Threshold();
            th.Owner = this;
            th.Show();
        }

        private void cargarOriginalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cache.RestoreToOriginalBitmap();
            this.zoomValue = 1;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
        }

        private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cache.UndoBitmap();
        }

        private void rehacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cache.RedoBitmap();
        }

        public void SetRedo(bool value)
        {
            this.rehacerToolStripMenuItem.Enabled = value;
        }

        public void SetUndo(bool value)
        {
            this.RedoToolStripMenuItem.Enabled = value;
        }

        private void detectarBordesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.currentImage != null)
            {
                EdgeDetection ed = new EdgeDetection();
                ed.Owner = this;
                ed.Show();
            }
        }

        private void promedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.currentImage != null)
            {
                ImageFilters.LoadCurrentBitmap();
                Cache.SetMainformPictureBox(ImageFilters.ApplyMeanFilter());
                Cache.StoreCurrentBitmapData();
            }
        }

        private void medianaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.currentImage != null)
            {
                ImageFilters.LoadCurrentBitmap();
                Cache.SetMainformPictureBox(ImageFilters.ApplyMedianFilter());
                Cache.StoreCurrentBitmapData();
            }
        }

        private void escalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scaling scalingui = new Scaling();
            scalingui.Owner = this;
            scalingui.Show();
        }

        private void zoomPlusButton_Click(object sender, EventArgs e)
        {
            if (this.currentImage != null)
            {
                zoomValue += 1;

                if (zoomValue != 1)
                {
                    float ratio = 1;
                    if (zoomValue < 0)
                    {
                        float temp = (-1 + zoomValue) * -5;
                        ratio = 1 - ((temp) / 100.0f);
                        ratio += 0.05f;
                    }
                    //float ratio = (1 + (float)((zoomValue - 1) * Math.Pow(Math.Abs(zoomValue - 1) + 1, 2)) / 100.0f);
                    int finalWith = (int)(ratio * pictureBox1.Image.Width);
                    int finalHeight = (int)(ratio * pictureBox1.Image.Height);
                    this.pictureBox2.Image = ScalingAlgorithms.NearestNeighbor((Bitmap)pictureBox1.Image, finalWith, finalHeight);
                    this.pictureBox2.Width = this.pictureBox2.Image.Width;
                    this.pictureBox2.Height = this.pictureBox2.Image.Height;
                    this.pictureBox2.Left = (this.ImagePanel.Width - this.pictureBox2.Width) / 2;
                    this.pictureBox2.Top = (this.ImagePanel.Height - this.pictureBox2.Height) / 2;
                    this.toolStripLabel5.Text = ((int)(ratio * 100.0)).ToString() + "%";
                    this.pictureBox1.Visible = false;
                    this.pictureBox2.Visible = true;
                    this.pictureBox2.Refresh();
                }

                else
                {
                    this.toolStripLabel5.Text = "100%";
                    this.pictureBox1.Visible = true;
                    this.pictureBox2.Visible = false;
                }
            }
        }

        private void zoomMinusButton_Click(object sender, EventArgs e)
        {
            if (this.currentImage != null)
            {
                zoomValue -= 1;

                if (zoomValue != 1)
                {
                    float ratio = 0;
                    if (zoomValue > -18)
                    {
                        float temp = (-1 + zoomValue) * -5;
                        ratio = 1 - ((temp) / 100.0f);
                    }

                  //  float ratio = (1 + (float)((zoomValue - 1) * Math.Pow(Math.Abs(zoomValue - 1) + 1, 2)) / 100.0f);
                    int finalWith = (int)(ratio * pictureBox1.Image.Width);
                    int finalHeight = (int)(ratio * pictureBox1.Image.Height);

                    if (finalHeight == 0 && finalWith == 0)
                    {
                        zoomValue += 1;
                        return;
                    }

                    this.pictureBox2.Image = ScalingAlgorithms.NearestNeighbor((Bitmap)pictureBox1.Image, finalWith, finalHeight);
                    this.pictureBox2.Width = this.pictureBox2.Image.Width;
                    this.pictureBox2.Height = this.pictureBox2.Image.Height;
                    this.pictureBox2.Left = (this.ImagePanel.Width - this.pictureBox2.Width) / 2;
                    this.pictureBox2.Top = (this.ImagePanel.Height - this.pictureBox2.Height) / 2;
                    this.toolStripLabel5.Text = ((int)(ratio * 100.0)).ToString() + "%";
                    this.pictureBox1.Visible = false;
                    this.pictureBox2.Visible = true;
                    this.pictureBox2.Refresh();
                }

                else
                {
                    this.toolStripLabel5.Text = "100%";
                    this.pictureBox1.Visible = true;
                    this.pictureBox2.Visible = false;
                }
            }
        }

        private void UpdateZoomPictureBox()
        {
            if (zoomValue != 1 && this.pictureBox2.Visible)
            {
                this.pictureBox2.Image = ScalingAlgorithms.NearestNeighbor((Bitmap)pictureBox1.Image, this.pictureBox2.Image.Width, this.pictureBox2.Image.Height);
            }
        }

        public void RefreshPictureBox()
        {
            if (this.currentImage != null)
            {
                pictureBox1.Refresh();
                pictureBox2.Refresh();
            }
        }

        private void voltearHorizontalmenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cache.SetMainformPictureBox(Mirror.MirrorHorizontal(Cache.GetCurrentBitmap()));
            Cache.StoreCurrentBitmapData();
        }

        private void voltearVerticalmenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cache.SetMainformPictureBox(Mirror.MirrorVertical(Cache.GetCurrentBitmap()));
            Cache.StoreCurrentBitmapData();
        }

        private void girarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rotation rt = new Rotation();
            rt.Owner = this;
            rt.Show();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentImage.Save(Path.GetDirectoryName(openFileDialog1.FileName) + "\\(1)" + Path.GetFileName(openFileDialog1.FileName));
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            if (currentImage != null) //если в currentImage не == нулю
            {
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Зберегти зображення як...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Усі доступні зображення (*.BMP;*.GIF;*.JPG;*.PNG;*.TIF)|*.BMP;*.GIF;*.JPG;*.PNG;|*.TIF|BMP (*.BMP)|*.BMP|GIF (*.GIF)|*.GIF|JPG (*.JPG)|*.JPG|PNG (*.PNG)|*.PNG||TIF (*.TIF)|*.TIF| All files(*.*) | *.* ";
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        currentImage.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Неможливо зберегти зображення", "Помилка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void NegativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setPictureBoxBitmap(Colors.Negativo(this.currentImage));
            Cache.StoreCurrentBitmapData();
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            GCODE Form = new GCODE();
            Form.Owner = this;
            Form.Show();

            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            USB Form = new USB();
            Form.Owner = this;
            Form.Show();
        }
    }

}
