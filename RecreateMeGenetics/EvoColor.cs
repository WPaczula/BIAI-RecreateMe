using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecreateMeUtils;
using System.Drawing;

namespace RecreateMeGenetics
{
    //Class describing color of a shape
    class EvoColor
    {
        //RGBA color set
        private int red;
        private int green;
        private int blue;
        private int alpha;

        public EvoColor Clone()
        {
            return new EvoColor(red, green, blue, alpha);
        }

        //Constructor of a random color
        public EvoColor()
        {
            red = Numbers.GetRandom(0, 255);
            green = Numbers.GetRandom(0, 255);
            blue = Numbers.GetRandom(0, 255);
            alpha = Numbers.GetRandom(20, 40);
        }

        private EvoColor(int r, int g, int b, int a)
        {
            red = r;
            green = g;
            blue = b;
            alpha = a;
        }

        //Mutation of a color
        //TODO add variables of mutation probability
        public void Mutate(EvoDrawing parent)
        {
            //Red mutation
            if (Numbers.MutationShouldOccur(Numbers.prob))
            {
                red = Numbers.GetRandom(0, 255);
                parent.NeedRepaint = true;
            }
            //Green mutation
            if (Numbers.MutationShouldOccur(Numbers.prob))
            {
                green = Numbers.GetRandom(0, 255);
                parent.NeedRepaint = true;
            }
            //Blue mutation
            if (Numbers.MutationShouldOccur(Numbers.prob))
            {
                blue = Numbers.GetRandom(0, 255);
                parent.NeedRepaint = true;
            }
            //Alpha mutation
            if (Numbers.MutationShouldOccur(Numbers.prob))
            {
                alpha = Numbers.GetRandom(30, 60);
                parent.NeedRepaint = true;
            }
        }
        //Convert to a SolidBrush object used to paint
        public SolidBrush ToBrush()
        {
            return new SolidBrush(Color.FromArgb(alpha, red, green, blue));
        }
    }
}
