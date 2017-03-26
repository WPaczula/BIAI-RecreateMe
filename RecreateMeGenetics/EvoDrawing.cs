using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using RecreateMeUtils;
using System.Drawing.Imaging;

namespace RecreateMeGenetics
{
    //Possible drawing shapes
    //TODO add more shapes??
    public enum ShapeType{ elipse, polygon };

    //TODO: comments and the rest of drawing
    //Class of a single drawing
    public class EvoDrawing
    {
        //Shape used for drawing 
        private ShapeType shape;
        //List containing figures on the drawing
        private List<EvoShape> shapes;
        //Variable showing if repaint of the drawing is needed
        private bool needRepaint;
        public bool NeedRepaint
        {
            get { return needRepaint; }
            set { needRepaint = value; }
        }
        //Minimum points per shape
        private int minShapePoints;
        public int MinShapePoints
        {
            get { return minShapePoints; }
            set { minShapePoints = value; }
        }
        //Maximum points per shape
        private int maxShapePoints;
        public int MaxShapePoints
        {
            get { return maxShapePoints; }
            set { maxShapePoints = value; }
        }

        public EvoDrawing Clone()
        {
            return new EvoDrawing(shapes, shape, MinShapePoints, MaxShapePoints);
        }

        private EvoDrawing(List<EvoShape> shapeList, ShapeType type, int minPoints, int maxPoints )
        {
            shapes = shapeList;
            shape = type;
            minShapePoints = minPoints;
            MaxShapePoints = maxPoints;
        }

        public EvoDrawing(int minShapePoints, int maxShapePoints)
        {
            shapes = new List<EvoShape>();
            needRepaint = false;
            MinShapePoints = minShapePoints;
            MaxShapePoints = maxShapePoints;
        }

        //TODO change mutation rates to variables
        public void Mutate()
        {
            //Mutate shape
            if (Probability.MutationShouldOccur(Probability.prob+0.01))
            {
                foreach (var figure in shapes)
                {
                    figure.Mutate(this);
                }
            }
            //Add shape
            if (Probability.MutationShouldOccur(Probability.prob+0.01))
            {
                shapes.Add(new EvoShape(MinShapePoints, MaxShapePoints));
                NeedRepaint = true;
            }
            //Remove shape
            //TODO Considering minimum shapes variable or deleting first part of if statement
            if (shapes.Count > 1 && Probability.MutationShouldOccur(Probability.prob))
            {
                shapes.Remove(
                    shapes.ElementAt<EvoShape>(
                        Probability.GetRandom(0, shapes.Count)));
                NeedRepaint = true;
            }
        }
        //Draw a drawing
        //TODO add more types???
        public void Draw(Graphics graphic, Color backgroundColor, ShapeType drawingShape)
        {
            graphic.Clear(backgroundColor);
            foreach (var shape in shapes)
            {
                switch (drawingShape)
                {
                    case ShapeType.elipse:
                        graphic.FillClosedCurve(shape.getBrush(), shape.getPoints());
                        break;
                    case ShapeType.polygon:
                        graphic.FillPolygon(shape.getBrush(), shape.getPoints());
                        break;
                }
                
            }
        }

        public byte[] ToColors()
        {
            var templateBitmap = new Bitmap(Probability.MaxWidth, Probability.MaxHeight, PixelFormat.Format24bppRgb);
            Graphics graphic = Graphics.FromImage(templateBitmap);
            Draw(graphic, Color.Black, shape);
            return BitmapConverter.ByteTableFrom(templateBitmap);

        }
    }
}
