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
        Bitmap sourceImage = null;
        private object v;

        public PicForm(Bitmap image)
        {
            sourceImage = image;
            InitializeComponent();
        }

        public PicForm(object v)
        {
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
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            sourceImage.Save(saveFileDialog1.FileName);
        }
    }
}
