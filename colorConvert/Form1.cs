using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace colorConvert
{
    public partial class Form1 : Form
    {
        public static Bitmap image, undoImage;
        string mode;
        int stage = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "image files| *.png; *.jpg; *.bmp | All Files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
            {
                if (stage == 0)
                    undoImage = image;
                image = newImage;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (mode == "edges")
            {
                switch (stage)
                {
                    case 0:
                        Filters filter = new Sobel();
                        backgroundWorker1.RunWorkerAsync(filter);
                        stage = 1;
                        break;
                    case 1:
                        filter = new Maximum();
                        backgroundWorker1.RunWorkerAsync(filter);
                        stage = 2;
                        break;
                    case 2:
                        pictureBox1.Image = image;
                        pictureBox1.Refresh();
                        stage = 0;
                        mode = "";
                        progressBar1.Value = 0;
                        break;
                }
                return;
            }
            else if (mode == "opening")
            {
                switch (stage)
                {
                    case 0:
                        Filters filter = new Dilation();
                        backgroundWorker1.RunWorkerAsync(filter);
                        stage = 1;
                        break;
                    case 1:
                        pictureBox1.Image = image;
                        pictureBox1.Refresh();
                        stage = 0;
                        mode = "";
                        progressBar1.Value = 0;
                        break;
                }
                return;
            }
            else if (mode == "closing")
            {
                switch (stage)
                {
                    case 0:
                        Filters filter = new Erosion();
                        backgroundWorker1.RunWorkerAsync(filter);
                        stage = 1;
                        break;
                    case 1:
                        pictureBox1.Image = image;
                        pictureBox1.Refresh();
                        stage = 0;
                        mode = "";
                        progressBar1.Value = 0;
                        break;
                }
                return;
            }
            else if (mode == "tophat")
            {
                switch (stage)
                {
                    case 0:
                        Filters filter = new TopHat();
                        backgroundWorker1.RunWorkerAsync(filter);
                        stage = 1;
                        break;
                    case 1:
                        pictureBox1.Image = image;
                        pictureBox1.Refresh();
                        stage = 0;
                        mode = "";
                        progressBar1.Value = 0;
                        break;
                }
                return;
            }

            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void чернобелоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sepia();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Bright();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Wave();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sobel();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Harshness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Emboss();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Glass();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MotionBlur();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Filters filter = new Dilation();
            backgroundWorker1.RunWorkerAsync(filter);            
        }

        private void эрозияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Erosion();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void замыканиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = "closing";
            stage = 0;
            Filters filter = new Dilation();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размыканиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = "opening";
            stage = 0;
            Filters filter = new Erosion();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = "tophat";
            stage = 0;
            Filters filter = new Dilation();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
