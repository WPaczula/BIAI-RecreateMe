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

        //Constructor of a random color
        public EvoColor()
        {
            red = Utils.GetRandom(0, 255);
            green = Utils.GetRandom(0, 255);
            blue = Utils.GetRandom(0, 255);
            alpha = Utils.GetRandom(0, 255);
        }

        //Mutation of a color
        //TODO add variables of mutation probability
        public void Mutate(EvoDrawing parent)
        {
            //Red mutation
            if (Utils.MutationShouldOccur(0.5))
            {
                red = Utils.GetRandom(0, 255);
                parent.NeedRepaint = true;
            }
            //Green mutation
            if (Utils.MutationShouldOccur(0.5))
            {
                green = Utils.GetRandom(0, 255);
                parent.NeedRepaint = true;
            }
            //Blue mutation
            if (Utils.MutationShouldOccur(0.5))
            {
                blue = Utils.GetRandom(0, 255);
                parent.NeedRepaint = true;
            }
            //Alpha mutation
            if (Utils.MutationShouldOccur(0.5))
            {
                alpha = Utils.GetRandom(0, 255);
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
