using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecreateMeUtils
{
    public class Numbers
    {
        //min alfa value
        private static int minAlfa = 30;
        public static int MinAlfa
        {
            get { return minAlfa; }
            set
            {
                if (value <= maxAlfa)
                    minAlfa = value;
            }
        }
        //max alfa value
        private static int maxAlfa = 60;
        public static int MaxAlfa
        {
            get { return maxAlfa; }
            set
            {
                if (value >= minAlfa)
                    maxAlfa = value;
            }
        }
        //min points for a shape
        private static int minPointsPerShape = 3;
        public static int MinPointsPerShape
        {
            get { return minPointsPerShape; }
            set
            {
                if (value <= maxPointsPerShape)
                    minPointsPerShape = value;
            }
        }
        //max points for a shape
        private static int maxPointsPerShape = 10;
        public static int MaxPointsPerShape
        {
            get { return maxPointsPerShape; }
            set
            {
                if (minPointsPerShape <= value)
                    maxPointsPerShape = value;
            }
        }
        //1st move range
        private static int firstRange = 5;
        public static int FirstRange
        {
            get { return firstRange; }
            set { firstRange = value; }
        }
        //2nd move range
        private static int secondRange = 10;
        public static int SecondRange
        {
            get { return secondRange; }
            set { secondRange = value; }
        }
        //Maxumum width of the drawing
        private static int maxWidth = 10;
        public static int MaxWidth
        {
            get { return maxWidth; }
            set { maxWidth = value; }
        }
        //Maximum height of the drawing
        public static int maxHeight = 10;
        public static int MaxHeight
        {
            get { return maxHeight; }
            set { maxHeight = value; }
        }
        //Probability of mutation;
        private static double mutationProbability = 0.005f;
        public static double MutationProbability
        {
            get { return mutationProbability; }
            set { mutationProbability = value; }
        }
        //Probability of adding a point
        private static double addPointmutationProbability = 0.01f;
        public static double AddPointMutationProbability
        {
            get { return addPointmutationProbability; }
            set { addPointmutationProbability = value; }
        }
        //Probability of removing a point
        private static double removePointmutationProbability = 0.005f;
        public static double RemovePointmutationProbability
        {
            get { return removePointmutationProbability; }
            set { removePointmutationProbability = value; }
        }
        //Probability of adding a shape
        private static double addShapemutationProbability = 0.01f;
        public static double AddShapemutationProbability
        {
            get { return addShapemutationProbability; }
            set { addShapemutationProbability = value; }
        }
        //Probability of removing a shape
        private static double removeShapemutationProbability = 0.005f;
        public static double RemoveShapemutationProbability
        {
            get { return removeShapemutationProbability; }
            set { removeShapemutationProbability = value; }
        }
        //Probability of removing a shape
        private static double changeLayerOfShapemutationProbability = 0.01f;
        public static double ChangeLayerOfShapemutationProbability
        {
            get { return changeLayerOfShapemutationProbability; }
            set { changeLayerOfShapemutationProbability = value; }
        }
        //Probability of color mutation;
        private static double colorMutationProbability = 0.005f;
        public static double ColorMutationProbability
        {
            get { return colorMutationProbability; }
            set { colorMutationProbability = value; }
        }
        //Probability of moving a point
        private static double pointMoveMutationProbability = 0.01f;
        public static double PointMoveMutationProbability
        {
            get { return pointMoveMutationProbability; }
            set { pointMoveMutationProbability = value; }
        }
        //Probability of crossover to take place
        private static double crossoverProbability = 0f;
        public static double CrossoverProbability
        {
            get { return crossoverProbability; }

            set { crossoverProbability = value; }
        }
        //Ratio for Uniform Crossover
        private static double uniformCrossoverRatio = 1f;
        public static double UniformCrossoverRatio
        {
            get { return uniformCrossoverRatio; }
            set { uniformCrossoverRatio = value; }
        }
        //Random generating object
        private static Random randomGenerator = new Random();
        //Number of children
        private static int generationQuantity = 5;
        public static int GenerationQuantity
        {
            get { return generationQuantity; }
            set { generationQuantity = value; }
        }
        private static int startingShapesNumber = 10;
        public static int StartingShapesNumber
        {
            get { return startingShapesNumber; }
            set { startingShapesNumber = value; }
        }

        public static int GetRandom(int min, int max)
        {
            return randomGenerator.Next(min, max);
        }

        //Returns true if mutation should occur based on possibility (from 0 to 1)
        public static bool ProbabilityFulfilled(double possibility)
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
