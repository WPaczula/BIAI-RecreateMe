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
            X = Utils.GetRandom(0, Utils.MaxWidth);
            Y = Utils.GetRandom(0, Utils.MaxHeight);
        }

        //TODO add mutation rates and min/max move values
        public void Mutate(EvoDrawing parent)
        {
            //TODO add probability variable
            
            //TODO add more move if statements???
            //move the point by random change between set values
            if (Utils.MutationShouldOccur(0.5))
            {
                //TODO add min and max move distance variables
                X = Math.Min(
                    Math.Max(
                        0, X + Utils.GetRandom(-2, 2)), Utils.MaxWidth);
                Y = Math.Min(
                    Math.Max
                    (0, X + Utils.GetRandom(-2, 2)), Utils.MaxHeight);
                parent.NeedRepaint = true;
            }
        }


    }
}
