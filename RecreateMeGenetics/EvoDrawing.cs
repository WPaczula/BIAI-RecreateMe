using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecreateMeUtils;

namespace RecreateMeGenetics
{
    //TODO: comments and the rest of drawing
    public class EvoDrawing
    {
        //List containing figures on the drawing
        private List<EvoShape> shapes;
        //Variable showing if repaint of the drawing is needed
        private bool needRepaint;
        public void NeedRepaint()
        {
            needRepaint = true;
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

        public EvoDrawing(int minShapePoints, int maxShapePoints)
        {
            shapes = new List<EvoShape>();
            needRepaint = false;
            MinShapePoints = minShapePoints;
            MaxShapePoints = maxShapePoints;
        }

        //TODO change mutation rates to variables
        public void Mutate(EvoDrawing parent)
        {
            //Mutate shape
            if (Utils.MutationShouldOccur(0.5))
            {
                foreach (var figure in shapes)
                {
                    figure.Mutate(this);
                }
            }
            //Add shape
            if (Utils.MutationShouldOccur(0.5))
            {
                shapes.Add(new EvoShape(MinShapePoints, MaxShapePoints));
            }
            //Remove shape
            //TODO Considering minimum shapes variable or deleting first part of if statement
            if (shapes.Count > 1 && Utils.MutationShouldOccur(0.5))
            {
                shapes.Remove(
                    shapes.ElementAt<EvoShape>(
                        Utils.GetRandom(0, shapes.Count)));
            }
        }
    }
}
