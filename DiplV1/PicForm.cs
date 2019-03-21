using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplV1
{
    public partial class PicForm : Form
    {
        int drawWidht = 500, drawHeight = 500;
        public Bitmap sourceImage = null;
        Form UI;
        public PicForm(Bitmap image,Form ui)
        {
            UI = ui;
            sourceImage = image;
            InitializeComponent();
        }

        public PicForm(object v, Form ui)
        {
            UI = ui;
            sourceImage = (Bitmap)v;
            InitializeComponent();
        }

        private void PicForm_Load(object sender, EventArgs e)
        {
            double heightFactor = (double)sourceImage.Height / sourceImage.Width, widthFactor = sourceImage.Width / sourceImage.Height;
            ResizeNearestNeighbor resize;
            if (heightFactor > widthFactor)
            {
                resize = new ResizeNearestNeighbor(drawWidht, (int)(drawHeight * heightFactor));
            }
            else
            {
                resize = new ResizeNearestNeighbor((int)(drawWidht * widthFactor), drawHeight);
            }

            pictureBox.Image = resize.Apply(sourceImage);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;

            saveFileDialog1.DefaultExt = "bmp";
            saveFileDialog1.Filter =
                "Bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
        }

        private void PicForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainUI)UI).Imageclosed(this);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            sourceImage.Save(saveFileDialog1.FileName);
        }
    }
}
