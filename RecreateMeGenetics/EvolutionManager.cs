using System.Linq;
using RecreateMeUtils;
using System;

namespace RecreateMeGenetics
{
    public class EvolutionManager
    {
        public static int Fitness(EvoDrawing drawing, byte[] image)
        {
            int fitness = 0;
            var bytesDrawing = drawing.ToColors();

            for(int i=0; i< bytesDrawing.Count(); i++)
            {
                fitness += (bytesDrawing[i] - image[i]) * (bytesDrawing[i] - image[i]); 
            }
            return fitness;
        }

        public static EvoDrawing Crossover(EvoDrawing firstParent, EvoDrawing secondParent)
        {
            return null;
        }
    }


}
