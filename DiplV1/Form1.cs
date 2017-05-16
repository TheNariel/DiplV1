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
        Bitmap sourceImage = null;
        Bitmap resultImage = null;
        double z;
        double[,] B = new double[3, 3], A = new double[3, 3];
        double[,] I, O;
        int widht = 20, height = 20;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                sourceImage = (Bitmap)Image.FromFile(path, true);
                resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

                ResizeNearestNeighbor resize = new ResizeNearestNeighbor(500, 500);
                SISThreshold treshold = new SISThreshold();
                Grayscale grayscale = new Grayscale(0.2125, 0.7154, 0.0721);


                sourceImage = grayscale.Apply(sourceImage);
                treshold.ApplyInPlace(sourceImage);

                Bitmap resizedImage = resize.Apply(sourceImage);
                sourcePictureBox.Image = resizedImage;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            fillParametrs();
            Network Net = new Network(widht, height);
            Net.Z = z;
            Net.B = B;
            Net.A = A;
            Net.I = I;
            Net.O = O;

            for (int i = 0; i < 1; i++)
            {
                O = Net.ProcessNetwork();
                Net.NetworkStates = Net.NewNetworkStates;
                drawIO();
            }

        }

        private void Z_TextChanged(object sender, EventArgs e)
        {

        }
        private void fillParametrs()
        {
            z = Double.Parse(Z.Text);

            B[0, 0] = Double.Parse(B11.Text);
            B[0, 1] = Double.Parse(B12.Text);
            B[0, 2] = Double.Parse(B13.Text);
            B[1, 0] = Double.Parse(B21.Text);
            B[1, 1] = Double.Parse(B22.Text);
            B[1, 2] = Double.Parse(B23.Text);
            B[2, 0] = Double.Parse(B31.Text);
            B[2, 1] = Double.Parse(B32.Text);
            B[2, 2] = Double.Parse(B33.Text);

            A[0, 0] = Double.Parse(A11.Text);
            A[0, 1] = Double.Parse(A12.Text);
            A[0, 2] = Double.Parse(A13.Text);
            A[1, 0] = Double.Parse(A21.Text);
            A[1, 1] = Double.Parse(A22.Text);
            A[1, 2] = Double.Parse(A23.Text);
            A[2, 0] = Double.Parse(A31.Text);
            A[2, 1] = Double.Parse(A32.Text);
            A[2, 2] = Double.Parse(A33.Text);

            setIO();
        }

        private void setIO()
        {
            //I = new double[height, widht];asdadsadasd
            O = new double[height, widht];

            for (int x = 0; x < widht; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    O[y, x] = -1;
                }
            }
            I = new double[,] {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,1,1,1,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0},
            {0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0},
            {0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0},
            {0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0},
            {0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0},
            {0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,1,0,0,0,0,0,0,0,1,1,1,0,0,0,0},
            {0,0,0,0,1,1,1,0,0,0,0,0,0,1,1,1,0,0,0,0},
            {0,0,0,1,1,1,1,1,0,0,0,1,1,1,1,1,1,0,0,0},
            {0,0,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,0,0},
            {0,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,0,0},
            {0,0,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,1,0,0},
            {0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,0},
            {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};
            //for (int x = 0; x < widht; x++)
            //{
            //    for (int y = 0; y < height; y++)
            //    {
            //        if (x < 2 || x > 7)
            //        {
            //                I[y, x] = 0;

            //        }
            //        else
            //        {
            //            if (y < 2 || y > 7)
            //            {
            //                I[y, x] = 0;
            //            }
            //            else
            //            {
            //                I[y, x] = 1;
            //            }
            //        }


            //    }
            //}
        }
        private void drawIO()
        {
            Bitmap BitI = new Bitmap(widht, height);
            Bitmap BitO = new Bitmap(widht, height);
            int IC = 0, OC = 0;
            for (int x = 0; x < widht; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    OC = 0;
                    if (O[y, x] >= 0)
                    {
                        OC = 255;
                    }
                    IC = Math.Abs((int)(I[y, x] * 255));
                    BitO.SetPixel(x, y, Color.FromArgb(OC, OC, OC));
                    BitI.SetPixel(x, y, Color.FromArgb(IC, IC, IC));
                }
            }

            ResizeNearestNeighbor resize = new ResizeNearestNeighbor(500, 500);
            Bitmap resizedImage = resize.Apply(BitO);
            resultPictureBox.Image = resizedImage;
            resizedImage = resize.Apply(BitI);
            sourcePictureBox.Image = resizedImage;
        }
    }
}
