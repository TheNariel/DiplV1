using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DiplV1
{
    public partial class MainUI : Form
    {
        private double Z;

        double[,] B, A;

        public MainUI()
        {
            InitializeComponent();
            OpenList.DisplayMember = "Text";
            OpenList.ClearSelected();
            OpenList2.DisplayMember = "Text";
            OpenList2.ClearSelected();
        }

        private void OpenItem_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                Bitmap sourceImage = (Bitmap)Image.FromFile(path, true);
                String activeFileName = file.FileName.Substring(file.FileName.LastIndexOf("\\")) + DateTime.Now.TimeOfDay;
                CreateNewPicForm(sourceImage, activeFileName);
                file.Dispose();
                file = null;
            }
        }

        private double[,] BitmapToArray(Bitmap sourceImage)
        {
            int widht = sourceImage.Width;
            int height = sourceImage.Height;

            double[,] Input = new double[height, widht];
            for (int x = 0; x < widht; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Input[y, x] = GetInput(sourceImage.GetPixel(x, y).B);
                }
            }
            // Start.Enabled = true;
            return Input;
        }

        private double GetInput(int color)
        {
            double ret;
            if (rBBinOut.Checked)
            {
                ret = (double)color / 128;
                ret = (ret - 1) * (-1);
            }
            else
            {
                ret = color;
            }
            return ret;

        }

        private int GetOutput(double ret)
        {
            int color = 0;

            if (rBBinOut.Checked)
            {
                if (ret <= 0) color = 255;
            }
            else
            {
                color = (int)ret;
            }
            return color;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (GetGene())
            {
                Bitmap sourceImage1 = null;
                Bitmap sourceImage2 = null;

                SetInitAndInput(out string name, ref sourceImage1, ref sourceImage2, out int widht, out int height, out double[,] Input, out double[,] Init);

                string boundary = "";
                if (rBFixed.Checked) boundary = "Fixed";
                if (rBFlux.Checked) boundary = "Flux";
                if (rBArbBound.Checked) boundary = "Arbitrary";

                Network Net = new Network(widht, height, boundary, int.Parse(arbBound.Text))
                {
                    Z = Z,
                    B = B,
                    A = A,

                    Input = Input,
                    Init = Init
                };



                double[,] Output = Net.Start(int.Parse(nOfIteration.Text), 1);


                DrawIO(Output, name);
            }
        }

        private void SetInitAndInput(out string name, ref Bitmap sourceImage1, ref Bitmap sourceImage2, out int widht, out int height, out double[,] Input, out double[,] Init)
        {
            if (!arbIn1.Checked)
            {
                sourceImage1 = ((PicForm)OpenList.SelectedItem).sourceImage;
                widht = sourceImage1.Width;
                height = sourceImage1.Height;

                Input = BitmapToArray(sourceImage1);
                name = ((PicForm)OpenList.SelectedItem).Text;

                if (!arbIn2.Checked)
                {
                    sourceImage2 = ((PicForm)OpenList2.SelectedItem).sourceImage;
                    Init = BitmapToArray(sourceImage2);
                }
                else
                {
                    Init = AllZeores(widht, height);
                }
            }
            else
            {
                sourceImage2 = ((PicForm)OpenList2.SelectedItem).sourceImage;
                widht = sourceImage2.Width;
                height = sourceImage2.Height;

                Init = BitmapToArray(sourceImage2);
                Input = AllZeores(widht, height);
                name = ((PicForm)OpenList2.SelectedItem).Text;
            }
        }

        private double[,] AllZeores(int widht, int height)
        {
            double[,] ret = new double[height, widht];

            return ret;
        }

        private bool GetGene()
        {
            string gene = GeneText.Text;
            string[] G = gene.Split(';');

            if (G.Length % 2 == 0)
            {
                recomendLabel.ForeColor = Color.Red;
                recomendLabel.Text = "Gene is wrong.";
                return false;
            }

            Z = double.Parse(G[0]);
            int m = Convert.ToInt32(Math.Sqrt((G.Length - 1) / 2));
            A = new double[m, m];
            B = new double[m, m];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int x = j + (i * m) + 1;
                    try
                    {
                        A[i, j] = double.Parse(G[x]);
                        B[i, j] = double.Parse(G[x + (m * m)]);
                    }
                    catch (Exception)
                    {
                        recomendLabel.ForeColor = Color.Red;
                        recomendLabel.Text = "Gene is wrong.";
                        return false;
                    }
                }
            }

            return true;
        }

        private void RBFlux_CheckedChanged(object sender, EventArgs e)
        {
            arbBound.Enabled = false;
        }

        private void RBArbBound_CheckedChanged(object sender, EventArgs e)
        {
            arbBound.Enabled = true;
        }

        private void DrawIO(double[,] Output, String name)
        {
            int widht = Output.GetLength(1);
            int height = Output.GetLength(0);
            Bitmap BitO = new Bitmap(widht, height);

            int OC = 0;
            for (int x = 0; x < widht; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    OC = GetOutput(Output[y, x]);
                    try
                    {
                        BitO.SetPixel(x, y, Color.FromArgb(OC, OC, OC));

                    }
                    catch (Exception)
                    {
                        recomendLabel.ForeColor = Color.Red;
                        recomendLabel.Text = "Wrong output settings";
                    }
                }
            }


            CreateNewPicForm(BitO, "Result for: " + name);

        }

        public void Imageclosed(PicForm closed)
        {
            OpenList.Items.Remove(closed);
            OpenList2.Items.Remove(closed);
            if (OpenList.Items.Count == 0) Start.Enabled = false;
        }

        private void CreateNewPicForm(Bitmap image, String name)
        {
            PicForm picForm = new PicForm(image.Clone(), this)
            {
                Text = name
            };
            picForm.Show();

            OpenList.Items.Add(picForm);
            OpenList2.Items.Add(picForm);
        }

        private void ArbIn2_CheckedChanged(object sender, EventArgs e)
        {
            OpenList2.Enabled = !arbIn2.Checked;
            OpenList2.ClearSelected();
            if (!arbIn1.Checked && !arbIn2.Checked && (OpenList.SelectedIndex != -1 || OpenList2.SelectedIndex != -1)) Start.Enabled = false;
        }

        private void ArbIn1_CheckedChanged(object sender, EventArgs e)
        {
            OpenList.Enabled = !arbIn1.Checked;
            OpenList.ClearSelected();
            if (!arbIn1.Checked && !arbIn2.Checked && (OpenList.SelectedIndex != -1 || OpenList2.SelectedIndex != -1)) Start.Enabled = false;
        }

        private void OpenList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!arbIn1.Checked && !arbIn2.Checked)
            {
                Start.Enabled = OpenList.SelectedIndex != -1 && OpenList2.SelectedIndex != -1;
            }
            else
            {
                Start.Enabled = OpenList.SelectedIndex != -1 || OpenList2.SelectedIndex != -1;
            }

        }

        private void EdgeDetectionForGeyscaleImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneText.Text = "-0.5;0;0;0;0;2;0;0;0;0;-1;-1;-1;-1;8;-1;-1;-1;-1";

            recomendLabel.ForeColor = Color.Blue;
            recomendLabel.Text = "Recomended image for example is \n \"avergra2.bmp\" from PicLib";
        }

        private void BlackPropagationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneText.Text = "3.75;0.25;0.25;0.25;0.25;3;0.25;0.25;0.25;0.25;0;0;0;0;0;0;0;0;0";

            recomendLabel.ForeColor = Color.Blue;
            recomendLabel.Text = "Recomended image for example is \n \"dots.bmp\" from PicLib";
        }

        private void PatternMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneText.Text = "-6.5;0;0;0;0;1;0;0;0;0;1;-1;1;0;1;0;1;-1;1";

            recomendLabel.ForeColor = Color.Blue;
            recomendLabel.Text = "Recomended image for example is \n \"match.bmp\" from PicLib";
        }

        private void AverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneText.Text = "0;0;1;0;1;2;1;0;1;0;0;0;0;0;0;0;0;0;0";

            recomendLabel.ForeColor = Color.Blue;
            recomendLabel.Text = "Recomended image for example is \n \"madonna.bmp\" from PicLib";
        }

        private void logicalNotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneText.Text = "0;0;0;0;0;1;0;0;0;0;0;0;0;0;-2;0;0;0;0";

            recomendLabel.ForeColor = Color.Blue;
            recomendLabel.Text = "Recomended image for example is \n \"A_LETTER.bmp\" from PicLib";
        }

        private void VerticalDeletebineryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneText.Text = "-2;0;0;0;0;1;0;0;0;0;0;-1;0;0;1;0;0;-1;0";

            recomendLabel.ForeColor = Color.Blue;
            recomendLabel.Text = "Recomended image for example is \n \"Deldiag1.bmp\" from PicLib";
        }
    }
}
