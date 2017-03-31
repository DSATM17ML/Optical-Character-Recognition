using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AForge;
using AForge.Imaging.Filters;
using AForge.Imaging.ComplexFilters;
using AForge.Imaging;
using System.Drawing.Imaging;

namespace imageprocessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void greyScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Sepia g = new Sepia();
            pictureBox2.Image = g.Apply((Bitmap)pictureBox1.Image);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image.Save(@"E:\Pranavpic.bmp", ImageFormat.Bmp);
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grayscale s = new Grayscale(0.2126, 0.7152, 0.0722);
            pictureBox2.Image = s.Apply((Bitmap)pictureBox1.Image);
        }

        private void extractRedChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractNormalizedRGBChannel n = new ExtractNormalizedRGBChannel();
            pictureBox2.Image = n.Apply((Bitmap)pictureBox1.Image);
        }
    }
}
       