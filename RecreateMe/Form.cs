using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using RecreateMeGenetics;
using RecreateMeUtils;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace RecreateMe
{
    public partial class RecreateMe : Form
    {
        private long generation = 0;
        private long childrenSelected = 0;
        private double fitness = double.MaxValue;
        //Evolution thread
        private Thread evoThread;
        //Bitmap to image scale
        private double resizeFactor;
        //Bitmap of the original image
        private Bitmap originalBitmap;
        //Table containing colors of original image
        private byte[] colorTable;
        //Rectangle bordering the image
        private Rectangle imageRectangle;
        //Program running
        private bool duringDrawing;
        //TODO change number of drawings???
        private EvoDrawing drawingData;
        //drawing being shown on gui
        private EvoDrawing drawingToBeShown;
        private int tryout = 0;
        public RecreateMe()
        {
            InitializeComponent();
            duringDrawing = false;
            originalBitmap = (Bitmap)originalPictureBox.Image;
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
                    //Set variables' values
                    originalBitmap = (Bitmap)Image.FromFile(fileDialog.FileName);
                    originalPictureBox.Image = originalBitmap;
                    imageRectangle.Height = originalBitmap.Height;
                    imageRectangle.Width = originalBitmap.Width;
                    //Set size and location of the drawing
                    drawing.Size = getDrawingSize(originalBitmap, originalPictureBox);
                    var location = drawing.Location;
                    location.Offset(0, getYOffset(originalBitmap, originalPictureBox, drawing));
                    drawing.Location = location;
                    //Set up colors of the original image
                    colorTable = BitmapConverter.ByteTableFrom(originalBitmap);
                    Numbers.MaxHeight = originalBitmap.Height;
                    Numbers.MaxWidth = originalBitmap.Width;
                    //TODO change values to variables
                    drawingData = new EvoDrawing(3, 10);
                    drawingToBeShown = drawingData.Clone();
                    this.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not open the file. Original error: " + ex.Message);
                }
            }
        }

        //Get size of the zoomed picture on form
        private Size getDrawingSize(Image image, PictureBox box)
        {
            var wfactor = (double)image.Width / box.ClientSize.Width;
            var hfactor = (double)image.Height / box.ClientSize.Height;

            resizeFactor = Math.Max(wfactor, hfactor);
            return new Size((int)(image.Width / resizeFactor), (int)(image.Height / resizeFactor));
        }

        //Get Y location on form to align drawing with picture
        private int getYOffset(Image image, PictureBox box, Drawing drawing)
        {
            Size imageSize = getDrawingSize(image, box);
            return (box.Height - imageSize.Height) / 2 + (box.Location.Y - drawing.Location.Y);
        }

        //Save the drawing to a file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var safeDialog = new SaveFileDialog();
            safeDialog.Filter = "Image Files(*.BMG)|*.BMP";
            if (safeDialog.ShowDialog() == DialogResult.OK)
            {
                var templateBitmap = new Bitmap((int)(originalBitmap.Width / resizeFactor), (int)(originalBitmap.Height / resizeFactor), PixelFormat.Format24bppRgb);
                Graphics graphic = Graphics.FromImage(templateBitmap);
                //TODO add user's choice
                drawingToBeShown.Draw(graphic, Color.Black, ShapeType.elipse, resizeFactor);
                templateBitmap.Save(safeDialog.FileName);
            }
        }

        //Exit forms application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Start or stop algorithm 
        private void startButton_Click(object sender, EventArgs e)
        {
            if(duringDrawing)
                stopEvolution();
            else
                startEvolution();

            duringDrawing = !duringDrawing;
        }
        //Evolve algorithm
        public void Evolve()
        {
            //double childsFitness = 0;
            //while (true)
            //{
            //    EvoDrawing child;
            //    lock (drawingData)
            //    {
            //        child = drawingData.Clone();
            //    }
            //    child.Mutate();
            //    if (child.NeedRepaint)
            //    {
            //        childsFitness = EvolutionManager.Fitness(child, colorTable);
            //        if (fitness > childsFitness)
            //        {
            //            lock (drawingData)
            //            {
            //                drawingData = child;
            //            }
            //            fitness = childsFitness;
            //        }
            //    }
            //}
            while (true)
            {
                generation++;
                lock (drawingData)
                {
                    for (int i = 0; i < children.Length; i++)
                    {
                        children[i] = drawingData.Clone();
                    }
                }

                foreach (var child in children)
                {
                    child.Mutate();
                    if (child.NeedRepaint)
                            child.Fitness = EvolutionManager.Fitness(child, colorTable);
                    else
                        child.Fitness = int.MaxValue;
                }

                int minFitness = children[0].Fitness;
                int minFitnessIndex = 0;
                for (int i = 1; i < children.Length; i++)
                {
                    if (children[i].Fitness < minFitness)
                    {
                        minFitness = children[i].Fitness;
                        minFitnessIndex = i;
                    }
                }

                if (children[minFitnessIndex].Fitness < fitness)
                {
                    lock (drawingData)
                    {
                        drawingData = children[minFitnessIndex];
                    }
                    fitness = children[minFitnessIndex].Fitness;
                    childrenSelected++;
                }
            }
        }

        private int[] childFitness = new int[5];
        private EvoDrawing[] children = new EvoDrawing[5];

        private void startEvolution()
        {
            redrawGenerator.Start();
            startButton.Text = "Stop";
            evoThread = new Thread(Evolve)
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };
            evoThread.Start();
        }

        private void stopEvolution()
        {
            redrawGenerator.Stop();
            startButton.Text = "Start";
            evoThread.Abort();
        }
        
        //TODO redraw picture if needed and change labels
        private void redrawImpulse(object sender, EventArgs e)
        {
            lock (drawingData)
            {
                if (drawingData.NeedRepaint)
                {
                    drawing.Invalidate();
                    drawingToBeShown = drawingData.Clone();
                    drawingData.NeedRepaint = false;
                }
            }
            generationLabel.Text = generation.ToString();
            childrenNumberLabel.Text = childrenSelected.ToString();
            fitnessLabel.Text = fitness.ToString();
        }

        private void drawing_Paint(object sender, PaintEventArgs e)
        {
            if (originalBitmap == null)
                return;

                var templateBitmap = new Bitmap((int)(originalBitmap.Width / resizeFactor), (int)(originalBitmap.Height / resizeFactor), PixelFormat.Format24bppRgb);
                Graphics graphic = Graphics.FromImage(templateBitmap);
                //TODO add user's choice
                drawingToBeShown.Draw(graphic, Color.Black, ShapeType.elipse, resizeFactor);
                e.Graphics.DrawImage(templateBitmap, 0, 0);
        }


        //TODO opening variables form as a dialog and allowing to change values
        private void geneticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
