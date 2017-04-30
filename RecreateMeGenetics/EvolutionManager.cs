using System.Linq;
using RecreateMeUtils;
using System;

namespace RecreateMeGenetics
{
    public class EvolutionManager
    {
        public static double Fitness(EvoDrawing drawing, byte[] image)
        {
            double fitness = 0;
            var fDrawing = BitmapConverter.FloatTableFrom(drawing.ToColors());
            var fImage = BitmapConverter.FloatTableFrom(image);

            for(int i=0; i<fDrawing.Count(); i+=3)
            {
                fitness += Math.Abs(fDrawing[i] - fImage[i])
                    + Math.Abs(fDrawing[i + 1] - fImage[i + 1])
                    + Math.Abs(fDrawing[i + 2] - fImage[i + 2]);
            }
            return fitness;
        }
    }


}
