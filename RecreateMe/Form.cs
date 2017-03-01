using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecreateMe
{
    public partial class RecreateMe : Form
    {
        //Bitmap of the original image
        private Bitmap originalBitmap;
        //Size of the image
        private int imageSize;
        //Rectangle bordering the image
        private Rectangle imageRectangle;
        //Program running
        private bool duringDrawing;

        public RecreateMe()
        {
            InitializeComponent();
            duringDrawing = false;
        }

        //Opening image from dialog
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Enable components
            startButton.Enabled = true;
            //Allow to choose file
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files(*.BMG)|*.BMP";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    originalBitmap = (Bitmap)Image.FromFile(fileDialog.FileName);
                    originalPictureBox.Image = originalBitmap;
                    this.imageSize = originalBitmap.Height * originalBitmap.Width * 3;
                    imageRectangle.Height = originalBitmap.Height;
                    imageRectangle.Width = originalBitmap.Width;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not open the file. Original error: " + ex.Message);
                }
            }
        }

        //Save the drawing to a file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var safeDialog = new SaveFileDialog();
            safeDialog.Filter = "Image Files(*.BMG)|*.BMP";
            if (safeDialog.ShowDialog() == DialogResult.OK)
            {
                //save drawing to file
            }
        }

        //Exit forms application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        //Start or stop algorithm 
        private void startButton_Click(object sender, EventArgs e)
        {
            duringDrawing = !duringDrawing;

            if(duringDrawing)
            {
                startButton.Text = "Stop";
            }
            else
            {
                startButton.Text = "Start";
            }
        }
    }
}
