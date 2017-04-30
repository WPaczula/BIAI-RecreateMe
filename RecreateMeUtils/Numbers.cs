using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecreateMeUtils
{
    public class Numbers
    {
        //Maxumum width of the drawing
        public static int MaxWidth=10;
        //Maximum height of the drawing
        public static int MaxHeight=10;
        public static double prob = 0.005f;
        //Random generating object
        private static Random randomGenerator = new Random();
        public static int GetRandom(int min, int max)
        {
            return randomGenerator.Next(min, max);
        }

        //Returns true if mutation should occur based on possibility (from 0 to 1)
        public static bool MutationShouldOccur(double possibility)
        {
            double random = randomGenerator.NextDouble();
            return (random <= possibility);
        }

        public static int GetAverage(int a, int b)
        {
            return (a + b) / 2;
        }
    }
}
