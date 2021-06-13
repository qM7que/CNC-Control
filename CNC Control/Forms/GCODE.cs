using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.IO;


using TheTravelingSalesman;
using TheTravelingSalesman.Solvers;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

using static GCODE.GCODE;

namespace PDI_Tarea2
{
    public partial class GCODE : Form
    {

         private static VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

        public GCODE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            float FeedSpeed = Convert.ToSingle(Speed.Value);
            float DrawDepth = Convert.ToSingle(Deepth.Value)/ -1000;
            float Scale = Convert.ToSingle(Scale1.Text);
            Feed(FeedSpeed);             

            // Rapid(0, 0, 1);              // холостий хід
            // SelectTool(Tool);            //Виібр інструменту
            Offset = new Vector3(Convert.ToSingle(X.Value), Convert.ToSingle(Y.Value), Convert.ToSingle(Z.Value));  //зміщення
            ToolDrawDepth = DrawDepth;

            VectorOfVectorOfPoint code_contours = new VectorOfVectorOfPoint();
            VectorOfVectorOfPoint contours_t = new VectorOfVectorOfPoint();
            contours_t = Cache.GetContours();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    code_contours.Push(contours[i]);
                }
            }


            //GravityCenterFind

            MCvPoint2D64f center;
            Moments moments;
            IList<GravityPoint> PathPoints = new List<GravityPoint>();

            for (int i = 0; i< code_contours.Size; i++)
            {
                moments = CvInvoke.Moments(code_contours[i]);
                center = moments.GravityCenter;
                PathPoints.Add(new GravityPoint(i, center.X, center.Y));       
            }


            IProblem<GravityPoint> problem = new ProblemBuilder<GravityPoint>(typeof(GravityPoint))
                .Locations(PathPoints)
                .Distances((GravityPoint p1, GravityPoint p2) => DistFrom(p1.X, p1.Y, p2.X, p2.Y))
                .FixedFirstLocation(0)
                .BuildIntegerArray();

            ISolver<GravityPoint> solver;

            if (code_contours.Size < 12)
            {
                solver = new ParallelBranchBoundSolver<GravityPoint>(problem);
            }
            else
            {
                solver = new NearestNeighborSolver<GravityPoint>(problem);
            } 
            IPath<GravityPoint> path = solver.Solve();
            int[] loc = path.GetLocations();
           
           



            VectorOfVectorOfPoint optimized_contours = new VectorOfVectorOfPoint();
           for (int i = 0; i < loc.Length; i++)
            {
                optimized_contours.Push(code_contours[loc[i]]);
            }

            ClearAll();

            for (int i = 0; i < code_contours.Size; i++)
            {
                Rapid(optimized_contours[i][0].X* Scale, optimized_contours[i][0].Y * Scale, 5);
               
                for (int j = 0; j < optimized_contours[i].Size; j++)
                {
                    Linear(optimized_contours[i][j].X * Scale, optimized_contours[i][j].Y * Scale, DrawDepth);
                }
              
                if (CvInvoke.ContourArea(optimized_contours[i]) > CvInvoke.ArcLength(optimized_contours[i], true))
                {

                    Linear(optimized_contours[i][0].X * Scale, optimized_contours[i][0].Y * Scale, DrawDepth);
                    Rapid(optimized_contours[i][0].X * Scale, optimized_contours[i][0].Y * Scale, 5);   
                } 
                else
                {
                    Rapid(optimized_contours[i][optimized_contours[i].Size-1].X * Scale, optimized_contours[i][optimized_contours[i].Size-1].Y * Scale, 5); 
                }
            }
            File.WriteAllText("test.gcode", Compile());
            //создание диалогового окна "Сохранить как..", для сохранения изображения
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Зберегти програму як...";
            //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
            savedialog.OverwritePrompt = true;
            //отображать ли предупреждение, если пользователь указывает несуществующий путь
            savedialog.CheckPathExists = true;
            //список форматов файла, отображаемый в поле "Тип файла"
            savedialog.Filter = "Текстові файли(*.txt)|*.txt|Всі файли(*.*)|*.*";

            if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        File.WriteAllText(savedialog.FileName, Compile());

                    }
                    catch
                    {
                        MessageBox.Show("Неможливо зберегти програму", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            Cache.StoreFileName(savedialog.FileName); 
        }


        public static double DistFrom(double X1, double Y1, double X2, double Y2)
        {
            double dist = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            return dist;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Contour_size = Convert.ToInt32(thickness.Value);
          
            double lower_sensitivity_limit = Decimal.ToDouble(lower_sens.Value);
            double upper_sensitivity_limit = Decimal.ToDouble(upper_sens.Value);

            Bitmap bitmap = Cache.GetCurrentBitmap();
            Mat hierarchy = new Mat();
            Image<Bgr, byte> input_image = new Image<Bgr, byte>(bitmap);
            Image<Gray, byte> output_image = input_image.Convert<Gray, byte>().ThresholdBinary(new Gray(lower_sensitivity_limit), new Gray(upper_sensitivity_limit));
            if (Gsmoth.Checked == true)
            {
                CvInvoke.GaussianBlur(output_image, output_image, new Size(Decimal.ToInt32(MatrixX.Value), Decimal.ToInt32(MatrixY.Value)), Convert.ToDouble(Sigma.Text));
            }
          
            
           

           

           //Cache.SetMainformPictureBox(input_image.Bitmap);
           // Cache.SetMainformPictureBox(blackBackground.Bitmap);
           
            if ((this.checkBox1.Checked == false) && (this.checkBox3.Checked == false))
            {
                CvInvoke.FindContours(output_image, contours, hierarchy, Emgu.CV.CvEnum.RetrType.Tree, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);
            }

            else if ((this.checkBox1.Checked == false) && (this.checkBox3.Checked == true))
            {
                CvInvoke.FindContours(output_image, contours, hierarchy, Emgu.CV.CvEnum.RetrType.Tree, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            }

            else if ((this.checkBox1.Checked == true) && (this.checkBox3.Checked == false))
            {
                CvInvoke.FindContours(output_image, contours, hierarchy, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);
            }

            else if ((this.checkBox1.Checked == true) && (this.checkBox3.Checked == true))
            {
                CvInvoke.FindContours(output_image, contours, hierarchy, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            }
            
            if (checkBox2.Checked == true)
            {
                int min_lenght = Convert.ToInt32(this.min_lenght.Value);
                VectorOfVectorOfPoint temp_contours = new VectorOfVectorOfPoint();
                for (int i = 0; i < contours.Size; i++)
                {
                   if (contours[i].Size >= min_lenght)
                    {
                        temp_contours.Push(contours[i]);
                    }
                }
                contours = temp_contours;
            }

            checkedListBox1.Items.Clear();
          //  Random rnd = new Random();
          //  Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            for (int i = 0; i < contours.Size; i++)
            {
                checkedListBox1.Items.Add("Контур " + i + " розміром " + contours[i].Size, true);
            }

            Image<Gray, byte> blackBackground = new Image<Gray, byte>(bitmap.Width, bitmap.Height, new Gray(0));
            CvInvoke.DrawContours(blackBackground, contours, -1, new MCvScalar(255, 0, 0), Contour_size);
            Cache.SetMainformPictureBox(blackBackground.Bitmap);
            Cache.StoreCurrentBitmapData();
            Cache.StoreContours(contours);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked == true)
            {
                min_lenght.Enabled = true;
            }
            else
            {
                min_lenght.Enabled = false;
            };
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap bitmap = Cache.GetCurrentBitmap();
            Image<Gray, byte> checked_contours = new Image<Gray, byte>(bitmap.Width, bitmap.Height, new Gray(0));
            int Contour_size = Convert.ToInt32(thickness.Value);
            VectorOfVectorOfPoint draw_contours = new VectorOfVectorOfPoint();
            VectorOfVectorOfPoint contours_t = new VectorOfVectorOfPoint();
            contours_t = Cache.GetContours();


            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    draw_contours.Push(contours[i]);
                }
            }
            CvInvoke.DrawContours(checked_contours, draw_contours, -1, new MCvScalar(255, 0, 0), Contour_size);
            Cache.SetMainformPictureBox(checked_contours.Bitmap);
            Cache.StoreCurrentBitmapData();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Scale1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                if (this.Text.IndexOf(",") >= 0 || this.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void Scale1_Validating(object sender, CancelEventArgs e)
        {
            float value;
            if (!float.TryParse(Scale1.Text, out value)) { Scale1.Text = ""; }
        }

        private void Gsmoth_CheckedChanged(object sender, EventArgs e)
        {
            if (Gsmoth.Checked == true)
            {
                MatrixY.Enabled = true;
                MatrixX.Enabled = true;
                Sigma.Enabled = true;
            }
            else
            {
                MatrixY.Enabled = false;
                MatrixX.Enabled = false;
                Sigma.Enabled = false;
            }
            

        }

        private void Sigma_Validating(object sender, CancelEventArgs e)
        {
            float value;
            if (!float.TryParse(Scale1.Text, out value)) { Scale1.Text = ""; }
        }

        private void Sigma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                if (this.Text.IndexOf(",") >= 0 || this.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int Contour_size = Convert.ToInt32(thickness.Value);

            double lower_sensitivity_limit = Decimal.ToDouble(lower_sens.Value);
            double upper_sensitivity_limit = Decimal.ToDouble(upper_sens.Value);

            Bitmap bitmap = Cache.GetCurrentBitmap();
            Mat hierarchy = new Mat();
            Image<Bgr, byte> input_image = new Image<Bgr, byte>(bitmap);
            if (Gsmoth.Checked == true)
            {
                Image<Bgr, byte> blured = new Image<Bgr, byte>(bitmap);
                CvInvoke.GaussianBlur(blured, input_image, new Size(Decimal.ToInt32(MatrixX.Value), Decimal.ToInt32(MatrixY.Value)), Convert.ToDouble(Sigma.Text));
            }
            Cache.SetMainformPictureBox(input_image.Bitmap);
            Cache.StoreCurrentBitmapData();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

     
    }
    public class GravityPoint
    {
        internal int id;

        internal double X;

        internal double Y;

        public GravityPoint(int id, double X, double Y)
        {
            this.id = id;
            this.X = X;
            this.Y = Y;
        }

    }
}
