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
        String activeFileName;
        double Z;
        double[,] B = new double[3, 3], A = new double[3, 3];
        double[,] O;
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
                activeFileName= "..."+file.FileName.Substring(file.FileName.LastIndexOf("\\"));
                fileName.Text = activeFileName;
                createNewPicForm(sourceImage, "Source Image: "+ activeFileName);

                Start.Enabled = true;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            fillParametrs();
            Network Net = new Network(widht, height);

            Net.Z = Z;
            Net.B = B;
            Net.A = A;
            Net.I = sourceImage;
            Net.Output = O;

            O = Net.ProcessNetwork();


            drawIO();
        }

        private void fillParametrs()
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

            O = new double[height, widht];

            for (int x = 0; x < widht; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    O[y, x] = 0;
                }
            }
        }

        private void drawIO()
        {
            Bitmap BitO = new Bitmap(widht, height);
            int OC = 0;
            for (int x = 0; x < widht; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    OC = 255;
                    if (O[y, x] > 0)
                    {
                        OC = 0;
                    }

                    //OC = (int)O[y, x];
                    BitO.SetPixel(x, y, Color.FromArgb(OC, OC, OC));
                }
            }


            createNewPicForm(BitO, "Result for: " + activeFileName);

        }
        private void createNewPicForm(Bitmap image, String name)
        {
            PicForm picForm = new PicForm(image);
            picForm.Text = name;
            picForm.Show();
        }

    }


}
