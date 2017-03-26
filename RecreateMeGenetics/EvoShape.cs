using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecreateMeUtils;
using System.Drawing;

namespace RecreateMeGenetics
{
    //Class of a single shape of the drawing
    class EvoShape
    {
        //Points for the shape
        private List<EvoPoint> shapePoints;
        //Color of the shape
        private EvoColor color;
        public EvoColor Color
        {
            get { return color; }
            private set { color = value; }
        }
        //Minimum points required for a shape
        private int minPoints;
        public int MinPoints
        {
            get { return minPoints; }
            private set { minPoints = value; }
        }
        //Maximum points required for a shape
        private int maxPoints;
        public int MaxPoints
        {
            get { return maxPoints; }
            private set { maxPoints = value; }
        }

        //Constructor creating a shape in memory
        public EvoShape(int minPoints, int maxPoints)
        {
            MinPoints = minPoints;
            MaxPoints = maxPoints;

            color = new EvoColor();

            shapePoints = new List<EvoPoint>();
            for (int i=0; i<MinPoints; i++)
            {
                shapePoints.Add(new EvoPoint());
            }            
        }

        public EvoShape Clone()
        {
            var list = new List<EvoPoint>();
            foreach (var point in shapePoints)
            {
                list.Add(point.Clone());
            }
            return new EvoShape(list, Color, MinPoints, MaxPoints);
        }

        private EvoShape(List<EvoPoint> points, EvoColor color, int minPoints, int maxPoints)
        {
            shapePoints = points;
            Color = color;
            MinPoints = minPoints;
            MaxPoints = maxPoints;
        }

        //Gets brush which is needed to paint 
        public SolidBrush getBrush()
        {
            return color.ToBrush();
        }

        //Gets points in form used by 
        public Point[] getPoints()
        {
            Point[] points = new Point[shapePoints.Count];
            int i = 0;

            foreach (var evoPoint in shapePoints)
            {
                points[i++] = new Point(evoPoint.X, evoPoint.Y);
            }
            return points;
        }

        //Mutating shape by changing number of points or changing their position
        //TODO change mutation rates to variables
        public void Mutate(EvoDrawing parent)
        {
            foreach (var point in shapePoints)
            {
                point.Mutate(parent);
            }

            //Add point to shape
            if (shapePoints.Count < MaxPoints && Probability.MutationShouldOccur(Probability.prob))
            {
                parent.NeedRepaint = true;

                EvoPoint additionalPoint = new EvoPoint();
                int i = Probability.GetRandom(1, shapePoints.Count - 1);
                additionalPoint.X = Probability.GetAverage(shapePoints[i - 1].X, shapePoints[i + 1].X);
                additionalPoint.Y = Probability.GetAverage(shapePoints[i - 1].Y, shapePoints[i + 1].Y);
                shapePoints.Insert(i, additionalPoint);
            }
            //Delete point
            if(shapePoints.Count > MinPoints && Probability.MutationShouldOccur(Probability.prob))
            {
                parent.NeedRepaint = true;
                shapePoints.Remove(
                    shapePoints.ElementAt<EvoPoint>(
                        Probability.GetRandom(0, shapePoints.Count)));
            }

            color.Mutate(parent);
        }
    }
}
