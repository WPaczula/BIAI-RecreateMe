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
            //Move points
            if (Utils.MutationShouldOccur(0.5))
            {
                foreach (var point in shapePoints)
                {
                    point.Mutate(parent);
                }
                parent.NeedRepaint = true;
            }
            //Add point to shape
            if (shapePoints.Count < MaxPoints && Utils.MutationShouldOccur(0.5))
            {
                parent.NeedRepaint = true;
                shapePoints.Add(new EvoPoint());
            }
            //Delete point
            if(shapePoints.Count > MinPoints && Utils.MutationShouldOccur(0.5))
            {
                parent.NeedRepaint = true;
                shapePoints.Remove(
                    shapePoints.ElementAt<EvoPoint>(
                        Utils.GetRandom(0, shapePoints.Count)));
            }
        }
    }
}
