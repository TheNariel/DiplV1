using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DiplV1
{
    public partial class MainUI : Form
    {    
        double Z;

        double[,] B, A, Output, Input;

        public MainUI()
        {
            InitializeComponent();
            OpenList.DisplayMember = "Text";
            OpenList.ClearSelected();
            OpenList2.DisplayMember = "Text";
            OpenList2.ClearSelected();
        }

        private void openItem_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                Bitmap sourceImage = (Bitmap)Image.FromFile(path, true);
                String activeFileName = file.FileName.Substring(file.FileName.LastIndexOf("\\"))+DateTime.Now.TimeOfDay; 
                CreateNewPicForm(sourceImage, activeFileName);

            }
        }

        private void selectInput(Bitmap sourceImage)
        {
            int widht = sourceImage.Width;
            int height = sourceImage.Height;

            Input = new double[height, widht];
            for (int x = 0; x < widht; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Input[y, x] = getInput(sourceImage.GetPixel(x, y).B);
                }
            }
            Start.Enabled = true;
        }

        private double getInput(int color)
        {
            double ret = (double)color / 128;
            return (ret - 1) * (-1);
        }

        private int getOutput(double ret)
        {
            int color;
            if (rBGreyScale.Checked)
            {
                ret = ret * (-1);
                color = (int)((ret + 1) * 128);
                if (color > 255) color = 255;
                if (color < 0) color = 0;
            }
            else
            {
                color = 0;
                if (ret <= Z) color = 255;
            }




            return color;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (FillParametrs())
            {
                
                Bitmap sourceImage = ((PicForm)OpenList.SelectedItem).sourceImage;
                int widht = sourceImage.Width;
                int height = sourceImage.Height;

                selectInput(sourceImage);

                Network Net = new Network(widht, height);

                Net.Z = Z;
                Net.B = B;
                Net.A = A;
                Net.I = Input;
                Net.BounVaule = Double.Parse(arbBound.Text);
                Net.FluxBoundry = rBFlux.Checked;
                Net.Output = new double[height, widht];
                Net.inicializeNetwork(rBInput.Checked, arbState.Text);


                Output = Net.ProcessNetwork();


                DrawIO(widht, height);
            }
        }

        private Boolean FillParametrs()
        {
            String gene = GeneText.Text;
            String[] G = gene.Split(';');

            if (G.Length % 2 == 0) {
                recomendLabel.Text = "Gene is wrong.";
                return false;
            }

            Z = Double.Parse(G[0]);
            int m = Convert.ToInt32(Math.Sqrt((G.Length - 1)/2));
            A = new double[m, m];
            B = new double[m, m];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int x =  j+(i * m) + 1;
                    A[i, j] = Double.Parse(G[x]);
                    B[i, j] = Double.Parse(G[x+(m*m)]);
                }
            }

            return true;
        }

      /*  private void rBInput_CheckedChanged(object sender, EventArgs e)
        {
            arbState.Enabled = false;
        }

        private void rBArb_CheckedChanged(object sender, EventArgs e)
        {
            arbState.Enabled = true;
        }

        private void rBFlux_CheckedChanged(object sender, EventArgs e)
        {
            arbBound.Enabled = false;
        }

        private void rBArbBound_CheckedChanged(object sender, EventArgs e)
        {
            arbBound.Enabled = true;
        }*/

        private void DrawIO(int widht, int height)
        {
            Bitmap BitO = new Bitmap(widht, height);

            int OC = 0;
            for (int x = 0; x < widht; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    OC = getOutput(Output[y, x]);
                    BitO.SetPixel(x, y, Color.FromArgb(OC, OC, OC));

                }
            }


            CreateNewPicForm(BitO,"Result for: " + ((PicForm)OpenList.SelectedItem).Text);

        }

        public void Imageclosed(PicForm closed)
        {
           OpenList.Items.Remove(closed);
           OpenList2.Items.Remove(closed);
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
         
        private void OpenList_SelectedValueChanged(object sender, EventArgs e)
        {
            Start.Enabled = true;
        }
     
        private void EdgeDetectionForGeyscaleImageToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            GeneText.Text = "-0.5;0;0;0;0;2;0;0;0;0;-1;-1;-1;-1;8;-1;-1;-1;-1";

            rBBinOut.Checked = true;
            rBArb.Checked = true;
            arbState.Text = "0";
            rBFlux.Checked = true;

            recomendLabel.Text = "Recomended image for example is \n \"avergra2.bmp\" from PicLib";
        }

        private void VerticalDeletebineryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneText.Text = "-2;0;0;0;0;1;0;0;0;0;0;-1;0;0;1;0;0;-1;0";

            rBGreyScale.Checked = true;
            rBArb.Checked = true;
            arbState.Text = "0";
            rBArbBound.Checked = true;
            arbBound.Text = "-1";


            recomendLabel.Text = "Recomended image for example is \n \"Deldiag1.bmp\" from PicLib";
        }
    }
}
