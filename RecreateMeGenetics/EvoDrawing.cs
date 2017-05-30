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
        public int Fitness { get; set; }
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
            shapes = new List<EvoShape>();
            foreach (var shape in shapeList)
            {
                shapes.Add(shape.Clone());
            }
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
            foreach (var figure in shapes)
            {
                figure.Mutate(this);
            }

            //Add shape
            if (Numbers.MutationShouldOccur(Numbers.prob * 2))
            {
                shapes.Insert(
                    Numbers.GetRandom(0, shapes.Count),
                        new EvoShape(MinShapePoints, MaxShapePoints));
                NeedRepaint = true;
            }
            //Change layer
            if (shapes.Count > 1 && Numbers.MutationShouldOccur(Numbers.prob * 2))
            {
                int i = Numbers.GetRandom(0, shapes.Count);
                EvoShape p = shapes.ElementAt(i);
                shapes.RemoveAt(i);
                i = Numbers.GetRandom(0, shapes.Count);
                shapes.Insert(i, p);

            }
            //Remove shape
            //TODO Considering minimum shapes variable or deleting first part of if statement
            if (shapes.Count > 1 && Numbers.MutationShouldOccur(Numbers.prob))
            {
                shapes.Remove(
                    shapes.ElementAt(
                        Numbers.GetRandom(0, shapes.Count)));
                NeedRepaint = true;
            }
        }
        //Draw a drawing
        //TODO add more types???
        public void Draw(Graphics graphic, Color backgroundColor, ShapeType drawingShape, double resizeFactor)
        {
            graphic.Clear(backgroundColor);
            foreach (var shape in shapes)
            {
                Point[] scaled = shape.getPoints();

                for (int i = 0; i < scaled.Count(); i++)
                {
                    scaled[i].X = (int)((double)scaled[i].X / resizeFactor);
                    scaled[i].Y = (int)((double)scaled[i].Y / resizeFactor);
                }

                switch (drawingShape)
                {
                    case ShapeType.elipse:
                        graphic.FillClosedCurve(shape.getBrush(), scaled);
                        break;
                    case ShapeType.polygon:
                        graphic.FillPolygon(shape.getBrush(), scaled);
                        break;
                }
            }
        }

        public byte[] ToColors()
        {
            var templateBitmap = new Bitmap(Numbers.MaxWidth, Numbers.MaxHeight, PixelFormat.Format24bppRgb);
            Graphics graphic = Graphics.FromImage(templateBitmap);
            Draw(graphic, Color.Black, shape, 1);
            return BitmapConverter.ByteTableFrom(templateBitmap);
        }
    }
}
