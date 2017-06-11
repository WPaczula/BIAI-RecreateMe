using System;
using System.Windows.Forms;
using RecreateMeUtils;

namespace RecreateMe
{
    public partial class GeneticsForm : Form
    {
        public GeneticsForm()
        {
            InitializeComponent();
            addPointProbabilityBar.Value = (int)(Numbers.AddPointMutationProbability * 1000f);
            addShapeProbabilityBar.Value = (int)(Numbers.AddShapemutationProbability * 1000f);
            moveShapeProbabilityBar.Value = (int)(Numbers.ChangeLayerOfShapemutationProbability * 1000f);
            colorChangeProbabilityBar.Value = (int)(Numbers.ColorMutationProbability * 1000f);
            crossoverProbabilityBar.Value = (int)(Numbers.CrossoverProbability * 1000f);
            crossoverRatioBar.Value = (int)(Numbers.UniformCrossoverRatio * 1000f);
            firstMoveDistanceBar.Value = Numbers.FirstRange;
            generationQuantityBar.Value = Numbers.GenerationQuantity;
            maxPointsBar.Value = Numbers.MaxPointsPerShape;
            minPointsBar.Value = Numbers.MinPointsPerShape;
            pointMoveProbabilityBar.Value = (int)(Numbers.PointMoveMutationProbability * 1000f);
            removePointProbabilityBar.Value = (int)(Numbers.RemovePointmutationProbability * 1000f);
            removeShapeProbabilityBar.Value = (int)(Numbers.RemoveShapemutationProbability * 1000f);
            secondMoveDistanceBar.Value = Numbers.SecondRange;
            startingShapeNumberBar.Value = Numbers.StartingShapesNumber;
            crossoverProbabilityBar_Scroll(null, null);
            crossoverRatioBar_Scroll(null, null);
            pointMoveProbabilityBar_Scroll(null, null);
            firstMoveDistanceBar_Scroll(null, null);
            secondMoveDistanceBar_Scroll(null, null);
            addPointProbabilityBar_Scroll(null, null);
            removePointProbabilityBar_Scroll(null, null);
            minPointsBar_Scroll(null, null);
            maxPointsBar_Scroll(null, null);
            generationQuantityBar_Scroll(null, null);
            colorChangeProbabilityBar_Scroll(null, null);
            addShapeProbabilityBar_Scroll(null, null);
            removeShapeProbabilityBar_Scroll(null, null);
            moveShapeProbabilityBar_Scroll(null, null);
            startingShapeNumberBar_Scroll(null, null);
        }

        private void crossoverProbabilityBar_Scroll(object sender, EventArgs e)
        {
            crossoverProbabilityLabel.Text = crossoverProbabilityBar.Value.ToString();
        }

        private void crossoverRatioBar_Scroll(object sender, EventArgs e)
        {
            crossoverRatioLabel.Text = crossoverRatioBar.Value.ToString();
        }

        private void pointMoveProbabilityBar_Scroll(object sender, EventArgs e)
        {
            pointMoveProbabilityLabel.Text = pointMoveProbabilityBar.Value.ToString();
        }

        private void firstMoveDistanceBar_Scroll(object sender, EventArgs e)
        {
            firstMoveDistanceLabel.Text = firstMoveDistanceBar.Value.ToString();
        }

        private void secondMoveDistanceBar_Scroll(object sender, EventArgs e)
        {
            secondMoveDistanceLabel.Text = secondMoveDistanceBar.Value.ToString();
        }

        private void addPointProbabilityBar_Scroll(object sender, EventArgs e)
        {
            addPointProbabilityLabel.Text = addPointProbabilityBar.Value.ToString();
        }

        private void removePointProbabilityBar_Scroll(object sender, EventArgs e)
        {
            removePointProbabilityLabel.Text = removePointProbabilityBar.Value.ToString();
        }

        private void minPointsBar_Scroll(object sender, EventArgs e)
        {
            minPointsLabel.Text = minPointsBar.Value.ToString();
        }

        private void maxPointsBar_Scroll(object sender, EventArgs e)
        {
            maxPointsLabel.Text = maxPointsBar.Value.ToString();
        }

        private void generationQuantityBar_Scroll(object sender, EventArgs e)
        {
            generationQuantityLabel.Text = generationQuantityBar.Value.ToString();
        }

        private void colorChangeProbabilityBar_Scroll(object sender, EventArgs e)
        {
            colorChangeProbabilityLabel.Text = colorChangeProbabilityBar.Value.ToString();
        }

        private void addShapeProbabilityBar_Scroll(object sender, EventArgs e)
        {
            addShapeProbabilityLabel.Text = addShapeProbabilityBar.Value.ToString();
        }

        private void removeShapeProbabilityBar_Scroll(object sender, EventArgs e)
        {
            removeShapeProbabilityLabel.Text = removeShapeProbabilityBar.Value.ToString();
        }

        private void moveShapeProbabilityBar_Scroll(object sender, EventArgs e)
        {
            moveShapeProbabilityLabel.Text = moveShapeProbabilityBar.Value.ToString();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            Numbers.AddPointMutationProbability = addPointProbabilityBar.Value / 1000f;
            Numbers.AddShapemutationProbability = addShapeProbabilityBar.Value / 1000f;
            Numbers.ChangeLayerOfShapemutationProbability = moveShapeProbabilityBar.Value / 1000f;
            Numbers.ColorMutationProbability = colorChangeProbabilityBar.Value / 1000f;
            Numbers.CrossoverProbability = crossoverProbabilityBar.Value / 1000f;
            Numbers.UniformCrossoverRatio = crossoverRatioBar.Value / 1000f;
            Numbers.FirstRange = firstMoveDistanceBar.Value;
            Numbers.GenerationQuantity = generationQuantityBar.Value;
            Numbers.MaxPointsPerShape = maxPointsBar.Value;
            Numbers.MinPointsPerShape = minPointsBar.Value;
            Numbers.PointMoveMutationProbability = pointMoveProbabilityBar.Value / 1000f;
            Numbers.RemovePointmutationProbability = removePointProbabilityBar.Value / 1000f;
            Numbers.RemoveShapemutationProbability = removeShapeProbabilityBar.Value / 1000f;
            Numbers.SecondRange = secondMoveDistanceBar.Value;
            Numbers.StartingShapesNumber = startingShapeNumberBar.Value;
            Close();
        }

        private void startingShapeNumberBar_Scroll(object sender, EventArgs e)
        {
            startingShapeNumberLabel.Text = startingShapeNumberBar.Value.ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
