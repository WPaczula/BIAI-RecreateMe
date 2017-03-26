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
            red = Probability.GetRandom(0, 255);
            green = Probability.GetRandom(0, 255);
            blue = Probability.GetRandom(0, 255);
            alpha = Probability.GetRandom(0, 255);
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
            if (Probability.MutationShouldOccur(Probability.prob))
            {
                red = Probability.GetRandom(0, 255);
                parent.NeedRepaint = true;
            }
            //Green mutation
            if (Probability.MutationShouldOccur(Probability.prob))
            {
                green = Probability.GetRandom(0, 255);
                parent.NeedRepaint = true;
            }
            //Blue mutation
            if (Probability.MutationShouldOccur(Probability.prob))
            {
                blue = Probability.GetRandom(0, 255);
                parent.NeedRepaint = true;
            }
            //Alpha mutation
            if (Probability.MutationShouldOccur(Probability.prob))
            {
                alpha = Probability.GetRandom(0, 255);
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
