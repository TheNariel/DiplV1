using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplV1
{
    public partial class Form1 : Form
    {
        int t;
        Bitmap sourceImage = null;
        Bitmap resultImage = null;
        String activeFileName;
        double Z;
        double[,] B = new double[3, 3], A = new double[3, 3];
        double[,] O;
        public double[,] Input;
        int widht = 0, height = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void openItem_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                sourceImage = (Bitmap)Image.FromFile(path, true);
                widht = sourceImage.Width;
                height = sourceImage.Height;
                resultImage = new Bitmap(widht, height);
                activeFileName = "..." + file.FileName.Substring(file.FileName.LastIndexOf("\\"));
                fileName.Text = activeFileName;
                createNewPicForm(sourceImage, "Source Image: " + activeFileName);

                Input = new double[widht, height];
                for (int x = 0; x < widht; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Input[y, x] = getInput(sourceImage.GetPixel(x, y).B);
                    }
                }

                Start.Enabled = true;

            }
        }
        private double getInput(int color)
        {
            double ret = (double)color / 128;
            return  (ret - 1)*(-1);
        }
        private int getOutput(double ret)
        {
            ret = ret * (-1);
            int color = (int)((ret + 1) * 128);
            if (color > 255) color = 255;
            if (color < 0) color = 0;

            return color;
        }
        private void Start_Click(object sender, EventArgs e)
        {
            FillParametrs();
            t = 0;
            Network Net = new Network(widht, height);

            Net.Z = Z;
            Net.B = B;
            Net.A = A;
            Net.I = Input;
            Net.Output = new double[height, widht];
            Net.inicializeNetwork(rBInput.Checked);


            O = Net.ProcessNetwork();


            drawIO();

          /*  for (int i = 0; i < 2; i++)
            {
                t++;
                Net.I = (double[,])O.Clone();
                O = Net.ProcessNetwork();


                drawIO();
                
            }*/
        }

        private void FillParametrs()
        {
            Z = Double.Parse(Z19.Text);

            B[0, 0] = Double.Parse(B10.Text);
            B[0, 1] = Double.Parse(B11.Text);
            B[0, 2] = Double.Parse(B12.Text);
            B[1, 0] = Double.Parse(B13.Text);
            B[1, 1] = Double.Parse(B14.Text);
            B[1, 2] = Double.Parse(B15.Text);
            B[2, 0] = Double.Parse(B16.Text);
            B[2, 1] = Double.Parse(B17.Text);
            B[2, 2] = Double.Parse(B18.Text);

            A[0, 0] = Double.Parse(A01.Text);
            A[0, 1] = Double.Parse(A02.Text);
            A[0, 2] = Double.Parse(A03.Text);
            A[1, 0] = Double.Parse(A04.Text);
            A[1, 1] = Double.Parse(A05.Text);
            A[1, 2] = Double.Parse(A06.Text);
            A[2, 0] = Double.Parse(A07.Text);
            A[2, 1] = Double.Parse(A08.Text);
            A[2, 2] = Double.Parse(A09.Text);


        }

        private void button1_Click(object sender, EventArgs e)
        {

            Bitmap BitO = new Bitmap(5, 5);

            BitO.SetPixel(0, 0, Color.FromArgb(255, 255, 255));
            BitO.SetPixel(0, 1, Color.FromArgb(255, 255, 255));
            BitO.SetPixel(0, 2, Color.FromArgb(255, 255, 255));
            BitO.SetPixel(0, 3, Color.FromArgb(255, 255, 255));
            BitO.SetPixel(0, 4, Color.FromArgb(255, 255, 255));

            BitO.SetPixel(1, 0, Color.FromArgb(255, 255, 255));
            BitO.SetPixel(1, 1, Color.FromArgb(0, 0, 0));
            BitO.SetPixel(1, 2, Color.FromArgb(0, 0, 0));
            BitO.SetPixel(1, 3, Color.FromArgb(0, 0, 0));
            BitO.SetPixel(1, 4, Color.FromArgb(255, 255, 255));

            BitO.SetPixel(2, 0, Color.FromArgb(255, 255, 255));
            BitO.SetPixel(2, 1, Color.FromArgb(0, 0, 0));
            BitO.SetPixel(2, 2, Color.FromArgb(0, 0, 0));
            BitO.SetPixel(2, 3, Color.FromArgb(0, 0, 0));
            BitO.SetPixel(2, 4, Color.FromArgb(255, 255, 255));

            BitO.SetPixel(3, 0, Color.FromArgb(255, 255, 255));
            BitO.SetPixel(3, 1, Color.FromArgb(0, 0, 0));
            BitO.SetPixel(3, 2, Color.FromArgb(0, 0, 0));
            BitO.SetPixel(3, 3, Color.FromArgb(0, 0, 0));
            BitO.SetPixel(3, 4, Color.FromArgb(255, 255, 255));

            BitO.SetPixel(4, 0, Color.FromArgb(255, 255, 255));
            BitO.SetPixel(4, 1, Color.FromArgb(255, 255, 255));
            BitO.SetPixel(4, 2, Color.FromArgb(255, 255, 255));
            BitO.SetPixel(4, 3, Color.FromArgb(255, 255, 255));
            BitO.SetPixel(4, 4, Color.FromArgb(255, 255, 255));


            sourceImage = BitO;
            widht = sourceImage.Width;
            height = sourceImage.Height;
            activeFileName = "...test...";
            fileName.Text = activeFileName;
            createNewPicForm(sourceImage, "Source Image: " + activeFileName);


            Input = new double[widht, height];
            for (int x = 0; x < widht; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Input[y, x] = getInput(sourceImage.GetPixel(x, y).B);
                }
            }

            Start.Enabled = true;
        }

        private void drawIO()
        {
            Bitmap BitO = new Bitmap(widht, height);
            int OC = 0;
            for (int x = 0; x < widht; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    OC = getOutput(O[y, x]);
                    BitO.SetPixel(x, y, Color.FromArgb(OC, OC, OC));

                }
            }


            createNewPicForm(BitO, t+" :Result for: " + activeFileName);

        }
        private void createNewPicForm(Bitmap image, String name)
        {
            PicForm picForm = new PicForm(image.Clone());
            picForm.Text = name;
            picForm.Show();
        }

    }


}
