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
        /*private byte[] image;
        private EvoDrawing drawing;
        private double fitness;
        public EvoDrawing Drawing
        {
            get { return drawing; }
            private set { drawing = value; }
        }
        public EvolutionManager(byte[] img, ref EvoDrawing drawing)
        {
            image = img;
            Drawing = drawing;
            fitness = Fitness(drawing);
        }*/

        public static double Fitness(EvoDrawing drawing, byte[] image)
        {
            double fitness = 0;
            byte[] colors = drawing.ToColors();
            for(int i=0; i<colors.Count(); i++)
            {
                fitness += Math.Abs(colors[i] - image[i]);
            }
            return fitness;
        }
    }
}
