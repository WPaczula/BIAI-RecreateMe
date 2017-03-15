using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecreateMeGenetics;

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
        //TODO change number of drawings???
        private EvoDrawing drawingData;
        public RecreateMe()
        {
            InitializeComponent();
            duringDrawing = false;
            originalBitmap = (Bitmap)originalPictureBox.Image;
            //TODO change values to variables
            drawingData = new EvoDrawing(3, 10);
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
                redrawGenerator.Start();
                startButton.Text = "Stop";
            }
            else
            {
                redrawGenerator.Stop();
                startButton.Text = "Start";
            }

        }

        //TODO redraw picture if needed and change labels
        private void redrawImpulse(object sender, EventArgs e)
        {
            drawingData.Mutate();
            if(drawingData.NeedRepaint)
                drawing.Invalidate();
        }

        //TODO opening variables form as a dialog and allowing to change values
        private void geneticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void drawing_Paint(object sender, PaintEventArgs e)
        {
            var templateBitmap = new Bitmap(originalPictureBox.Width, originalPictureBox.Height, PixelFormat.Format24bppRgb);
            Graphics graphic = Graphics.FromImage(templateBitmap);
            drawingData.Draw(graphic);
            e.Graphics.DrawImage(templateBitmap, new Point(0, 0));
        }
    }
}
