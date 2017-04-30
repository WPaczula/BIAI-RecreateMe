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
            set { x = value; }
        }

        //Y coordinate of the point
        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public EvoPoint()
        {
            //Initiate coordinates of the point on the drawing
            X = Numbers.GetRandom(0, Numbers.MaxWidth);
            Y = Numbers.GetRandom(0, Numbers.MaxHeight);
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
            if (Numbers.MutationShouldOccur(Numbers.prob))
            {
                //TODO add min and max move distance variables
                X = Math.Min(
                    Math.Max(
                        0, X + Numbers.GetRandom(-5, 5)), Numbers.MaxWidth);
                Y = Math.Min(
                    Math.Max
                    (0, Y + Numbers.GetRandom(-5, 5)), Numbers.MaxHeight);
                parent.NeedRepaint = true;
            }

            if (Numbers.MutationShouldOccur(Numbers.prob))
            {
                //TODO add min and max move distance variables
                X = Math.Min(
                    Math.Max(
                        0, X + Numbers.GetRandom(-10, 10)), Numbers.MaxWidth);
                Y = Math.Min(
                    Math.Max
                    (0, Y + Numbers.GetRandom(-10, 10)), Numbers.MaxHeight);
                parent.NeedRepaint = true;
            }
        }


    }
}
