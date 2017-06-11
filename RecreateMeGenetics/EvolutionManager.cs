using System.Linq;
using RecreateMeUtils;
using System;
using System.Collections.Generic;

namespace RecreateMeGenetics
{
    public class EvolutionManager
    {
        public static float Fitness(EvoDrawing drawing, float[] image)
        {
            float fitness = 0;
            var bytesDrawing = BitmapConverter.getFloats(drawing.ToColors());

            for(int i=0; i< bytesDrawing.Count(); i++)
            {
                fitness += (bytesDrawing[i] - image[i]) * (bytesDrawing[i] - image[i]); 
            }
            return fitness;
        }

        public static List<EvoDrawing> Crossover(int numberOfChildren, EvoDrawing firstParent, EvoDrawing secondParent)
        {
            
            var drawings = new List<EvoDrawing>();
            for(int i=0; i<numberOfChildren; i++)
            {
                if (Numbers.ProbabilityFulfilled(Numbers.CrossoverProbability))
                {
                    drawings.Add(firstParent.Crossover(secondParent));
                }
                else
                {
                    drawings.Add(firstParent.Clone()); 
                }
            }
            return drawings;
        }
    }


}
