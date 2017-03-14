using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecreateMeUtils;

namespace RecreateMeGenetics
{
    class EvoShape
    {
        //Points for the shape
        private List<EvoPoint> shapePoints;
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
            shapePoints = new List<EvoPoint>();
            MinPoints = minPoints;
            for(int i=0; i<MinPoints; i++)
            {
                shapePoints.Add(new EvoPoint());
            }
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
                parent.NeedRepaint();
            }

            //Add point to shape
            if (shapePoints.Count < MaxPoints && Utils.MutationShouldOccur(0.5))
            {
                parent.NeedRepaint();
                shapePoints.Add(new EvoPoint());
            }

            //Delete point
            if(shapePoints.Count > MinPoints && Utils.MutationShouldOccur(0.5))
            {
                parent.NeedRepaint();
                shapePoints.Remove(
                    shapePoints.ElementAt<EvoPoint>(
                        Utils.GetRandom(0, shapePoints.Count)));
            }
        }
    }
}
