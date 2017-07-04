using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using RecreateMeGenetics;
using RecreateMeUtils;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace RecreateMe
{
    public partial class RecreateMe : Form
    {
        //Shape used to paint
        private ShapeType shapeType = ShapeType.elipse;
        //Number of the current generation
        private long generation;
        //Background color
        private Color backgroundColor;
        //Number of steps forward to the solution
        private long childrenSelected;
        //Fitness of current solution
        private double fitness;
        //Evolution thread
        private Thread evoThread;
        //Bitmap to image scale
        private double resizeFactor;
        //Bitmap of the original image
        private Bitmap originalBitmap;
        //Table containing colors of original image
        private float[] colorTable;
        //Rectangle bordering the image
        private Rectangle imageRectangle;
        //Program running
        private bool duringDrawing;
        //TODO change number of drawings???
        private EvoDrawing drawingData;
        //drawing being shown on gui
        private EvoDrawing drawingToBeShown;
        //curent children
        private List<EvoDrawing> parents;
        public RecreateMe()
        {
            InitializeComponent();
            elipseRadio.Checked = true;
            duringDrawing = false;
            originalBitmap = (Bitmap)originalPictureBox.Image;
        }

        //Opening image from dialog
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Allow to choose file
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files(*.BMG)|*.BMP";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //Enable components
                startButton.Enabled = true;
                resetButton.Enabled = true;
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
                    colorTable = BitmapConverter.FloatTableFrom(originalBitmap);
                    Numbers.MaxHeight = originalBitmap.Height;
                    Numbers.MaxWidth = originalBitmap.Width;
                    setupStart();
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
            if (drawingToBeShown != null)
            {
                var safeDialog = new SaveFileDialog();
                safeDialog.Filter = "Image Files(*.BMG)|*.BMP";
                if (safeDialog.ShowDialog() == DialogResult.OK)
                {
                    var templateBitmap = new Bitmap((int)(originalBitmap.Width / resizeFactor), (int)(originalBitmap.Height / resizeFactor), PixelFormat.Format24bppRgb);
                    Graphics graphic = Graphics.FromImage(templateBitmap);
                    drawingToBeShown.Draw(graphic, backgroundColor, shapeType, resizeFactor);
                    templateBitmap.Save(safeDialog.FileName);
                }
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
            if (duringDrawing)
                stopEvolution();
            else
                startEvolution();

            duringDrawing = !duringDrawing;
        }
        //Evolve algorithm
        public void Evolve()
        {

            while (true)
            {
                generation++;
                if (Numbers.GenerationQuantity > 1)
                {
                    var children = EvoManager.Crossover(Numbers.GenerationQuantity, parents.ElementAt(0), parents.ElementAt(1));
                    EvoManager.Mutate(children, colorTable);
                    children = (from child in children
                                orderby child.Fitness
                                select child).ToList();
                    var mostFitChild = children.First();
                    if (mostFitChild.NeedRepaint)
                    {
                        if (fitness >= mostFitChild.Fitness)
                        {
                            childrenSelected++;
                            fitness = mostFitChild.Fitness;
                            parents = children;
                            lock (drawingData)
                            {
                                drawingData = mostFitChild;
                            }
                        }
                    }
                }
                else
                {
                    EvoDrawing child;
                    lock (drawingData)
                    {
                        child = drawingData.Clone();
                    }
                    child.Mutate();
                    child.Fitness = EvoManager.Fitness(child, colorTable);
                    if (child.NeedRepaint)
                    {
                        if(fitness >= child.Fitness)
                        {
                            childrenSelected++;
                            fitness = child.Fitness;
                            //Keep possibility to come back
                            parents.Clear();
                            parents.Add(child.Clone());
                            parents.Add(child.Clone());
                            lock (drawingData)
                            {
                                drawingData = child;
                            }
                        }
                    }
                }
            }
        }

        private void startEvolution()
        {
            redrawGenerator.Start();
            startButton.Text = "Stop";
            parents = (from parent in parents
                       orderby parent.Fitness
                       select parent).ToList();
            drawingData = parents.ElementAt(0);

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

        private void redrawImpulse(object sender, EventArgs e)
        {
            if (drawingData == null)
                return;
            lock (drawingData)
            {
                if (drawingData.NeedRepaint)
                {
                    drawingToBeShown = drawingData.Clone();
                    drawingData.NeedRepaint = false;
                    numberOfShapesLabel.Text = drawingToBeShown.ShapesNumber.ToString();
                    drawing.Invalidate();
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
            if (duringDrawing)
            {
                var templateBitmap = new Bitmap((int)(originalBitmap.Width / resizeFactor), (int)(originalBitmap.Height / resizeFactor), PixelFormat.Format24bppRgb);
                Graphics graphic = Graphics.FromImage(templateBitmap);
                drawingToBeShown.Draw(graphic, backgroundColor, shapeType, resizeFactor);
                e.Graphics.DrawImage(templateBitmap, 0, 0);
            }
        }


        //TODO opening variables form as a dialog and allowing to change values
        private void geneticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form settingsForm = new GeneticsForm();
            settingsForm.ShowDialog();
        }

        private void elipseRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (elipseRadio.Checked)
            {
                shapeType = ShapeType.elipse;
            }
            else
            {
                shapeType = ShapeType.polygon;
            }
            fitness = Double.MaxValue;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            stopEvolution();
            setupStart();
            startEvolution();
        }

        private void setupStart()
        {
            if (parents != null)
                parents.Clear();
            else
                parents = new List<EvoDrawing>();
            for (int i = 0; i < Numbers.GenerationQuantity; i++)
            {
                var adam = new EvoDrawing(Numbers.MinPointsPerShape, Numbers.MaxPointsPerShape, colorTable);
                parents.Add(adam.Clone());
            }
            generation = 0;
            childrenSelected = 0;
            fitness = Double.MaxValue;
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog cDialog = new ColorDialog();
            cDialog.Color = backgroundColor;
            if(cDialog.ShowDialog() == DialogResult.OK)
            {
                backgroundColor = cDialog.Color;
                colorButton.BackColor = backgroundColor;
            }
        }
    }
}
