using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecreateMeUtils;

namespace RecreateMeGenetics
{
    //class of the point on the drawing, which position is affected by genetics algorythm
    public class EvoPoint
    {
        //X coordinate of the point
        private int x;
        public int X
        {
            get { return x; }
            private set { x = value; }
        }

        //Y coordinate of the point
        private int y;
        public int Y
        {
            get { return y; }
            private set { y = value; }
        }

        public EvoPoint()
        {
            //Initiate coordinates of the point on the drawing
            X = Probability.GetRandom(0, Probability.MaxWidth);
            Y = Probability.GetRandom(0, Probability.MaxHeight);
        }

        private EvoPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
        public EvoPoint Clone()
        {
            return new EvoPoint(X, Y);
        }

        //TODO add mutation rates and min/max move values
        public void Mutate(EvoDrawing parent)
        {
            //TODO add probability variable
            
            //TODO add more move if statements???
            //move the point by random change between set values
            if (Probability.MutationShouldOccur(Probability.prob))
            {
                //TODO add min and max move distance variables
                X = Math.Min(
                    Math.Max(
                        0, X + Probability.GetRandom(-2, 2)), Probability.MaxWidth);
                Y = Math.Min(
                    Math.Max
                    (0, X + Probability.GetRandom(-2, 2)), Probability.MaxHeight);
                parent.NeedRepaint = true;
            }
        }


    }
}
