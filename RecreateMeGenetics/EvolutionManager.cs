using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecreateMeUtils;

namespace RecreateMeGenetics
{
    public static class EvolutionManager
    {
        public static double Fitness(EvoDrawing drawing, byte[] image)
        {
            double fitness = 0;
            byte[] colors = drawing.ToColors();
            for(int i=0; i<colors.Count(); i+=3)
            {
                fitness += Math.Abs(colors[i] - image[i]) 
                    + Math.Abs(colors[i + 1] - image[i + 1]) 
                    + Math.Abs(colors[i + 2] - image[i + 2]);
            }
            return fitness;
        }
    }
}
