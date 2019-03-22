namespace DiplV1
{
    partial class MainUI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openItem = new System.Windows.Forms.ToolStripMenuItem();
            this.examplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectionForGeyscaleImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalDeletebineryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackPropagationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patternMatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Start = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.recomendLabel = new System.Windows.Forms.Label();
            this.GeneText = new System.Windows.Forms.TextBox();
            this.OpenList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OpenList2 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.arbIn2 = new System.Windows.Forms.CheckBox();
            this.arbIn1 = new System.Windows.Forms.CheckBox();
            this.nOfIteration = new System.Windows.Forms.TextBox();
            this.rBGreyScale = new System.Windows.Forms.RadioButton();
            this.rBBinOut = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBArbBound = new System.Windows.Forms.RadioButton();
            this.rBFlux = new System.Windows.Forms.RadioButton();
            this.arbBound = new System.Windows.Forms.TextBox();
            this.Boundary = new System.Windows.Forms.GroupBox();
            this.logicalNotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Boundary.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.examplesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(340, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.souborToolStripMenuItem.Text = "File";
            // 
            // openItem
            // 
            this.openItem.Name = "openItem";
            this.openItem.Size = new System.Drawing.Size(103, 22);
            this.openItem.Text = "Open";
            this.openItem.Click += new System.EventHandler(this.OpenItem_Click);
            // 
            // examplesToolStripMenuItem
            // 
            this.examplesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edgeDetectionForGeyscaleImageToolStripMenuItem,
            this.verticalDeletebineryToolStripMenuItem,
            this.blackPropagationToolStripMenuItem,
            this.patternMatchToolStripMenuItem,
            this.averageToolStripMenuItem,
            this.logicalNotToolStripMenuItem});
            this.examplesToolStripMenuItem.Name = "examplesToolStripMenuItem";
            this.examplesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.examplesToolStripMenuItem.Text = "Examples";
            // 
            // edgeDetectionForGeyscaleImageToolStripMenuItem
            // 
            this.edgeDetectionForGeyscaleImageToolStripMenuItem.Name = "edgeDetectionForGeyscaleImageToolStripMenuItem";
            this.edgeDetectionForGeyscaleImageToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.edgeDetectionForGeyscaleImageToolStripMenuItem.Text = "Edge detection (greyscale)";
            this.edgeDetectionForGeyscaleImageToolStripMenuItem.Click += new System.EventHandler(this.EdgeDetectionForGeyscaleImageToolStripMenuItem_Click);
            // 
            // verticalDeletebineryToolStripMenuItem
            // 
            this.verticalDeletebineryToolStripMenuItem.Name = "verticalDeletebineryToolStripMenuItem";
            this.verticalDeletebineryToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.verticalDeletebineryToolStripMenuItem.Text = "Vertical delete (binary)";
            this.verticalDeletebineryToolStripMenuItem.Click += new System.EventHandler(this.VerticalDeletebineryToolStripMenuItem_Click);
            // 
            // blackPropagationToolStripMenuItem
            // 
            this.blackPropagationToolStripMenuItem.Name = "blackPropagationToolStripMenuItem";
            this.blackPropagationToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.blackPropagationToolStripMenuItem.Text = "Black propagation";
            this.blackPropagationToolStripMenuItem.Click += new System.EventHandler(this.BlackPropagationToolStripMenuItem_Click);
            // 
            // patternMatchToolStripMenuItem
            // 
            this.patternMatchToolStripMenuItem.Name = "patternMatchToolStripMenuItem";
            this.patternMatchToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.patternMatchToolStripMenuItem.Text = "Pattern match";
            this.patternMatchToolStripMenuItem.Click += new System.EventHandler(this.PatternMatchToolStripMenuItem_Click);
            // 
            // averageToolStripMenuItem
            // 
            this.averageToolStripMenuItem.Name = "averageToolStripMenuItem";
            this.averageToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.averageToolStripMenuItem.Text = "Average";
            this.averageToolStripMenuItem.Click += new System.EventHandler(this.AverageToolStripMenuItem_Click);
            // 
            // Start
            // 
            this.Start.Enabled = false;
            this.Start.Location = new System.Drawing.Point(279, 291);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(50, 23);
            this.Start.TabIndex = 25;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Input 1:";
            // 
            // recomendLabel
            // 
            this.recomendLabel.AutoSize = true;
            this.recomendLabel.ForeColor = System.Drawing.Color.Blue;
            this.recomendLabel.Location = new System.Drawing.Point(127, 9);
            this.recomendLabel.Name = "recomendLabel";
            this.recomendLabel.Size = new System.Drawing.Size(0, 13);
            this.recomendLabel.TabIndex = 34;
            // 
            // GeneText
            // 
            this.GeneText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneText.Location = new System.Drawing.Point(12, 40);
            this.GeneText.Name = "GeneText";
            this.GeneText.Size = new System.Drawing.Size(317, 26);
            this.GeneText.TabIndex = 25;
            this.GeneText.TabStop = false;
            this.GeneText.Text = "-0.5;0;0;0;0;2;0;0;0;0;-1;-1;-1;-1;8;-1;-1;-1;-1";
            // 
            // OpenList
            // 
            this.OpenList.FormattingEnabled = true;
            this.OpenList.Location = new System.Drawing.Point(12, 100);
            this.OpenList.Name = "OpenList";
            this.OpenList.Size = new System.Drawing.Size(317, 43);
            this.OpenList.TabIndex = 37;
            this.OpenList.SelectedValueChanged += new System.EventHandler(this.OpenList_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Gene:";
            // 
            // OpenList2
            // 
            this.OpenList2.Enabled = false;
            this.OpenList2.FormattingEnabled = true;
            this.OpenList2.Location = new System.Drawing.Point(12, 172);
            this.OpenList2.Name = "OpenList2";
            this.OpenList2.Size = new System.Drawing.Size(317, 43);
            this.OpenList2.TabIndex = 40;
            this.OpenList2.SelectedValueChanged += new System.EventHandler(this.OpenList_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Input 2:";
            // 
            // arbIn2
            // 
            this.arbIn2.AutoSize = true;
            this.arbIn2.Checked = true;
            this.arbIn2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.arbIn2.Location = new System.Drawing.Point(57, 149);
            this.arbIn2.Name = "arbIn2";
            this.arbIn2.Size = new System.Drawing.Size(64, 17);
            this.arbIn2.TabIndex = 41;
            this.arbIn2.Text = "Arbitrary";
            this.arbIn2.UseVisualStyleBackColor = true;
            this.arbIn2.CheckedChanged += new System.EventHandler(this.ArbIn2_CheckedChanged);
            // 
            // arbIn1
            // 
            this.arbIn1.AutoSize = true;
            this.arbIn1.Location = new System.Drawing.Point(57, 76);
            this.arbIn1.Name = "arbIn1";
            this.arbIn1.Size = new System.Drawing.Size(64, 17);
            this.arbIn1.TabIndex = 42;
            this.arbIn1.Text = "Arbitrary";
            this.arbIn1.UseVisualStyleBackColor = true;
            this.arbIn1.CheckedChanged += new System.EventHandler(this.ArbIn1_CheckedChanged);
            // 
            // nOfIteration
            // 
            this.nOfIteration.Location = new System.Drawing.Point(223, 291);
            this.nOfIteration.Name = "nOfIteration";
            this.nOfIteration.Size = new System.Drawing.Size(50, 20);
            this.nOfIteration.TabIndex = 26;
            this.nOfIteration.Text = "1";
            // 
            // rBGreyScale
            // 
            this.rBGreyScale.AutoSize = true;
            this.rBGreyScale.Location = new System.Drawing.Point(6, 42);
            this.rBGreyScale.Name = "rBGreyScale";
            this.rBGreyScale.Size = new System.Drawing.Size(75, 17);
            this.rBGreyScale.TabIndex = 7;
            this.rBGreyScale.Text = "Grey scale";
            this.rBGreyScale.UseVisualStyleBackColor = true;
            // 
            // rBBinOut
            // 
            this.rBBinOut.AutoSize = true;
            this.rBBinOut.Checked = true;
            this.rBBinOut.Location = new System.Drawing.Point(6, 19);
            this.rBBinOut.Name = "rBBinOut";
            this.rBBinOut.Size = new System.Drawing.Size(54, 17);
            this.rBBinOut.TabIndex = 6;
            this.rBBinOut.TabStop = true;
            this.rBBinOut.Text = "Binary";
            this.rBBinOut.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBBinOut);
            this.groupBox1.Controls.Add(this.rBGreyScale);
            this.groupBox1.Location = new System.Drawing.Point(193, 221);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 64);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // rBArbBound
            // 
            this.rBArbBound.AutoSize = true;
            this.rBArbBound.Location = new System.Drawing.Point(6, 18);
            this.rBArbBound.Name = "rBArbBound";
            this.rBArbBound.Size = new System.Drawing.Size(63, 17);
            this.rBArbBound.TabIndex = 1;
            this.rBArbBound.Text = "Arbitrary";
            this.rBArbBound.UseVisualStyleBackColor = true;
            this.rBArbBound.CheckedChanged += new System.EventHandler(this.RBArbBound_CheckedChanged);
            // 
            // rBFlux
            // 
            this.rBFlux.AutoSize = true;
            this.rBFlux.Checked = true;
            this.rBFlux.Location = new System.Drawing.Point(6, 41);
            this.rBFlux.Name = "rBFlux";
            this.rBFlux.Size = new System.Drawing.Size(44, 17);
            this.rBFlux.TabIndex = 0;
            this.rBFlux.TabStop = true;
            this.rBFlux.Text = "Flux";
            this.rBFlux.UseVisualStyleBackColor = true;
            this.rBFlux.CheckedChanged += new System.EventHandler(this.RBFlux_CheckedChanged);
            // 
            // arbBound
            // 
            this.arbBound.Enabled = false;
            this.arbBound.Location = new System.Drawing.Point(75, 18);
            this.arbBound.Name = "arbBound";
            this.arbBound.Size = new System.Drawing.Size(50, 20);
            this.arbBound.TabIndex = 25;
            this.arbBound.Text = "0";
            // 
            // Boundary
            // 
            this.Boundary.Controls.Add(this.arbBound);
            this.Boundary.Controls.Add(this.rBFlux);
            this.Boundary.Controls.Add(this.rBArbBound);
            this.Boundary.Location = new System.Drawing.Point(12, 221);
            this.Boundary.Name = "Boundary";
            this.Boundary.Size = new System.Drawing.Size(136, 91);
            this.Boundary.TabIndex = 33;
            this.Boundary.TabStop = false;
            this.Boundary.Text = "Boundary";
            // 
            // logicalNotToolStripMenuItem
            // 
            this.logicalNotToolStripMenuItem.Name = "logicalNotToolStripMenuItem";
            this.logicalNotToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.logicalNotToolStripMenuItem.Text = "Logical not";
            this.logicalNotToolStripMenuItem.Click += new System.EventHandler(this.logicalNotToolStripMenuItem_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 327);
            this.Controls.Add(this.nOfIteration);
            this.Controls.Add(this.arbIn1);
            this.Controls.Add(this.arbIn2);
            this.Controls.Add(this.OpenList2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OpenList);
            this.Controls.Add(this.GeneText);
            this.Controls.Add(this.recomendLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Boundary);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CNN Sim";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Boundary.ResumeLayout(false);
            this.Boundary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openItem;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem examplesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectionForGeyscaleImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalDeletebineryToolStripMenuItem;
        private System.Windows.Forms.Label recomendLabel;
        private System.Windows.Forms.TextBox GeneText;
        private System.Windows.Forms.ListBox OpenList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox OpenList2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox arbIn2;
        private System.Windows.Forms.CheckBox arbIn1;
        private System.Windows.Forms.TextBox nOfIteration;
        private System.Windows.Forms.RadioButton rBGreyScale;
        private System.Windows.Forms.RadioButton rBBinOut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBArbBound;
        private System.Windows.Forms.RadioButton rBFlux;
        private System.Windows.Forms.TextBox arbBound;
        private System.Windows.Forms.GroupBox Boundary;
        private System.Windows.Forms.ToolStripMenuItem blackPropagationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patternMatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logicalNotToolStripMenuItem;
    }
}

