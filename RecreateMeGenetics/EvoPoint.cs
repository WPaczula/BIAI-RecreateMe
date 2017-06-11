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

            if (Numbers.ProbabilityFulfilled(Numbers.PointMoveMutationProbability))
            {
                X = Math.Min(
                   Math.Max(
                       0, X + Numbers.GetRandom(-Numbers.FirstRange, Numbers.FirstRange)), Numbers.MaxWidth);
                Y = Math.Min(
                    Math.Max
                    (0, Y + Numbers.GetRandom(-Numbers.FirstRange, Numbers.FirstRange)), Numbers.MaxHeight);
                parent.NeedRepaint = true;
            }


            if (Numbers.ProbabilityFulfilled(Numbers.PointMoveMutationProbability))
            {
                X = Math.Min(
                   Math.Max(
                       0, X + Numbers.GetRandom(-Numbers.SecondRange, Numbers.SecondRange)), Numbers.MaxWidth);
                Y = Math.Min(
                    Math.Max
                    (0, Y + Numbers.GetRandom(-Numbers.SecondRange, Numbers.SecondRange)), Numbers.MaxHeight);
                parent.NeedRepaint = true;
            }

            if (Numbers.ProbabilityFulfilled(Numbers.PointMoveMutationProbability))
            {
                X =  Numbers.GetRandom(1, Numbers.MaxWidth);
                Y = Numbers.GetRandom(1, Numbers.MaxHeight);
                parent.NeedRepaint = true;
            }
        }


    }
}
