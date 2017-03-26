using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecreateMeUtils
{
    public static class Probability
    {
        //Maxumum width of the drawing
        public static int MaxWidth;
        //Maximum height of the drawing
        public static int MaxHeight;
        public static double prob = 0.0066;
        //Random generating object
        private static Random randomGenerator = new Random();
        public static int GetRandom(int min, int max)
        {
            return randomGenerator.Next(min, max);
        }

        //Returns true if mutation should occur based on possibility (from 0 to 1)
        public static bool MutationShouldOccur(double possibility)
        {
            return (randomGenerator.NextDouble() <= possibility);
        }

        public static int GetAverage(int a, int b)
        {
            return (a + b) / 2;
        }
    }
}
