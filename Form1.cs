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
        Bitmap sampleImage;
        Bitmap pimage;
        Bitmap resizedImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sampleImage = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = sampleImage;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void greyScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Sepia g = new Sepia();
            pictureBox2.Image = g.Apply((Bitmap)sampleImage);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox3.Image.Save(@"E:\Pranavpic.bmp", ImageFormat.Bmp);
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Grayscale s = new Grayscale(0.2126, 0.7152, 0.0722);
            pictureBox2.Image = s.Apply((Bitmap)sampleImage);
        }

        private void extractRedChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractNormalizedRGBChannel n = new ExtractNormalizedRGBChannel();
            pictureBox2.Image = n.Apply((Bitmap)sampleImage);
        }

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int[] a = new int[pictureBox2.Height];
            String sum = "";
            Array.Clear(a, 0, pictureBox2.Height);
            Grayscale s = new Grayscale(0.2126, 0.7152, 0.0722);
            pictureBox2.Image = s.Apply((Bitmap)sampleImage);
            Threshold t = new Threshold(128);
            pictureBox2.Image = t.Apply((Bitmap)pictureBox2.Image);
            pimage = new Bitmap(pictureBox2.Image);
            ResizeBilinear b = new ResizeBilinear(200, 200);
            resizedImage = b.Apply((Bitmap)pimage);


            for (int y = 0; y < resizedImage.Height; y++)
            {
                for (int x = 0; x < resizedImage.Width; x++)
                {

                    Color pixel = resizedImage.GetPixel(x, y);
                    String hexc = System.Drawing.ColorTranslator.ToHtml(pixel);
                    if (hexc.Equals("#000000"))
                    {
                        a[y]++;
                    }

                }
            }

            for (int l = 0; l < a.Length; l++)
            {

                sum += Convert.ToString(a[l]);
                sum += " ";
            }

            textBox1.Text = sum;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 0)
                {

                    for (int d = 0; d < resizedImage.Width; d++)
                    {
                        if (i < resizedImage.Width)
                        {
                            resizedImage.SetPixel(d, i, Color.Red);
                        }

                    }
                }

                pictureBox3.Image = resizedImage;
            }


          
            



            int[] c = new int[resizedImage.Width];
            for (int y = 0; y < resizedImage.Width; y++)
            {
                for (int x = 0; x < resizedImage.Height; x++)
                {

                    Color pixel = resizedImage.GetPixel(x, y);
                    String hexc = System.Drawing.ColorTranslator.ToHtml(pixel);
                    if (hexc.Equals("#000000"))
                    {
                        c[y]++;
                    }

                }
            }

            for (int l = 0; l < a.Length; l++)
            {

                sum += Convert.ToString(a[l]);
                sum += " ";
            }

            textBox1.Text = sum;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 0)
                {

                    for (int d = 0; d < resizedImage.Height; d++)
                    {
                        if (i < resizedImage.Width)
                        {
                            resizedImage.SetPixel(i, d, Color.Red);
                        }


                    }
                }
            }
            pictureBox3.Image = resizedImage;
        }
       

        }
    }


    
