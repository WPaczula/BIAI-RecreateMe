namespace RecreateMe
{
    partial class RecreateMe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geneticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.originalPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numberOfShapesLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.polygonRadio = new System.Windows.Forms.RadioButton();
            this.elipseRadio = new System.Windows.Forms.RadioButton();
            this.childrenNumberLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.generationLabel = new System.Windows.Forms.Label();
            this.generationHeaderLabel = new System.Windows.Forms.Label();
            this.fitnessLabel = new System.Windows.Forms.Label();
            this.fitnessHeaderLabel = new System.Windows.Forms.Label();
            this.redrawGenerator = new System.Windows.Forms.Timer(this.components);
            this.drawing = new Drawing();
            this.resetButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startButton.Enabled = false;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startButton.Location = new System.Drawing.Point(13, 358);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(125, 33);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.geneticsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(960, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // geneticsToolStripMenuItem
            // 
            this.geneticsToolStripMenuItem.Name = "geneticsToolStripMenuItem";
            this.geneticsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.geneticsToolStripMenuItem.Text = "Genetics";
            this.geneticsToolStripMenuItem.Click += new System.EventHandler(this.geneticsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // originalPictureBox
            // 
            this.originalPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.originalPictureBox.Location = new System.Drawing.Point(143, 32);
            this.originalPictureBox.Name = "originalPictureBox";
            this.originalPictureBox.Size = new System.Drawing.Size(400, 400);
            this.originalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalPictureBox.TabIndex = 2;
            this.originalPictureBox.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colorButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numberOfShapesLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.polygonRadio);
            this.groupBox1.Controls.Add(this.elipseRadio);
            this.groupBox1.Controls.Add(this.childrenNumberLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.generationLabel);
            this.groupBox1.Controls.Add(this.generationHeaderLabel);
            this.groupBox1.Controls.Add(this.fitnessLabel);
            this.groupBox1.Controls.Add(this.fitnessHeaderLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(125, 324);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "data";
            // 
            // numberOfShapesLabel
            // 
            this.numberOfShapesLabel.AutoSize = true;
            this.numberOfShapesLabel.Location = new System.Drawing.Point(6, 171);
            this.numberOfShapesLabel.Name = "numberOfShapesLabel";
            this.numberOfShapesLabel.Size = new System.Drawing.Size(53, 13);
            this.numberOfShapesLabel.TabIndex = 10;
            this.numberOfShapesLabel.Text = "Unknown";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(5, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Number of shapes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(6, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Shape type";
            // 
            // polygonRadio
            // 
            this.polygonRadio.AutoSize = true;
            this.polygonRadio.Location = new System.Drawing.Point(6, 249);
            this.polygonRadio.Name = "polygonRadio";
            this.polygonRadio.Size = new System.Drawing.Size(62, 17);
            this.polygonRadio.TabIndex = 7;
            this.polygonRadio.TabStop = true;
            this.polygonRadio.Text = "polygon";
            this.polygonRadio.UseVisualStyleBackColor = true;
            // 
            // elipseRadio
            // 
            this.elipseRadio.AutoSize = true;
            this.elipseRadio.Location = new System.Drawing.Point(6, 225);
            this.elipseRadio.Name = "elipseRadio";
            this.elipseRadio.Size = new System.Drawing.Size(52, 17);
            this.elipseRadio.TabIndex = 6;
            this.elipseRadio.TabStop = true;
            this.elipseRadio.Text = "elipse";
            this.elipseRadio.UseVisualStyleBackColor = true;
            this.elipseRadio.CheckedChanged += new System.EventHandler(this.elipseRadio_CheckedChanged);
            // 
            // childrenNumberLabel
            // 
            this.childrenNumberLabel.AutoSize = true;
            this.childrenNumberLabel.Location = new System.Drawing.Point(7, 127);
            this.childrenNumberLabel.Name = "childrenNumberLabel";
            this.childrenNumberLabel.Size = new System.Drawing.Size(53, 13);
            this.childrenNumberLabel.TabIndex = 5;
            this.childrenNumberLabel.Text = "Unknown";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(7, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Picked children:";
            // 
            // generationLabel
            // 
            this.generationLabel.AutoSize = true;
            this.generationLabel.Location = new System.Drawing.Point(6, 81);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.Size = new System.Drawing.Size(53, 13);
            this.generationLabel.TabIndex = 3;
            this.generationLabel.Text = "Unknown";
            // 
            // generationHeaderLabel
            // 
            this.generationHeaderLabel.AutoSize = true;
            this.generationHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.generationHeaderLabel.Location = new System.Drawing.Point(6, 68);
            this.generationHeaderLabel.Name = "generationHeaderLabel";
            this.generationHeaderLabel.Size = new System.Drawing.Size(73, 13);
            this.generationHeaderLabel.TabIndex = 2;
            this.generationHeaderLabel.Text = "Generation:";
            // 
            // fitnessLabel
            // 
            this.fitnessLabel.AutoSize = true;
            this.fitnessLabel.Location = new System.Drawing.Point(7, 33);
            this.fitnessLabel.Name = "fitnessLabel";
            this.fitnessLabel.Size = new System.Drawing.Size(53, 13);
            this.fitnessLabel.TabIndex = 1;
            this.fitnessLabel.Text = "Unknown";
            // 
            // fitnessHeaderLabel
            // 
            this.fitnessHeaderLabel.AutoSize = true;
            this.fitnessHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fitnessHeaderLabel.Location = new System.Drawing.Point(7, 20);
            this.fitnessHeaderLabel.Name = "fitnessHeaderLabel";
            this.fitnessHeaderLabel.Size = new System.Drawing.Size(51, 13);
            this.fitnessHeaderLabel.TabIndex = 0;
            this.fitnessHeaderLabel.Text = "Fitness:";
            // 
            // redrawGenerator
            // 
            this.redrawGenerator.Interval = 10;
            this.redrawGenerator.Tick += new System.EventHandler(this.redrawImpulse);
            // 
            // drawing
            // 
            this.drawing.Location = new System.Drawing.Point(548, 32);
            this.drawing.Name = "drawing";
            this.drawing.Size = new System.Drawing.Size(400, 400);
            this.drawing.TabIndex = 4;
            this.drawing.Text = "Drawing";
            this.drawing.Paint += new System.Windows.Forms.PaintEventHandler(this.drawing_Paint);
            // 
            // resetButton
            // 
            this.resetButton.Enabled = false;
            this.resetButton.Location = new System.Drawing.Point(13, 397);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(124, 35);
            this.resetButton.TabIndex = 5;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(7, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Background color";
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.Color.Black;
            this.colorButton.Location = new System.Drawing.Point(8, 297);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(111, 23);
            this.colorButton.TabIndex = 12;
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // RecreateMe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 444);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.drawing);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.originalPictureBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(363, 299);
            this.Name = "RecreateMe";
            this.Text = "BIAI";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox originalPictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private Drawing drawing;
        private System.Windows.Forms.Label generationLabel;
        private System.Windows.Forms.Label generationHeaderLabel;
        private System.Windows.Forms.Label fitnessLabel;
        private System.Windows.Forms.Label fitnessHeaderLabel;
        private System.Windows.Forms.Timer redrawGenerator;
        private System.Windows.Forms.Label childrenNumberLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem geneticsToolStripMenuItem;
        private System.Windows.Forms.Label numberOfShapesLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton polygonRadio;
        private System.Windows.Forms.RadioButton elipseRadio;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Label label4;
    }
}

