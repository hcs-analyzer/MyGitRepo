namespace HCSAnalyzer.Forms.FormsForOptions
{
    partial class FormForAllClusteringOptions
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
            this.panelMeanShift = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownMeanShiftBandWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMeanShiftKernel = new System.Windows.Forms.ComboBox();
            this.panelEM = new System.Windows.Forms.Panel();
            this.numericUpDownEMMinStdev = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEMSeedNumber = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEMMaxIterations = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxAutomatedEMClassNum = new System.Windows.Forms.CheckBox();
            this.numericUpDownEMNumClasses = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.panelFarthestFirst = new System.Windows.Forms.Panel();
            this.numericUpDownFarthestFirstSeed = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownFarthestFirstClasses = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.panelCobWeb = new System.Windows.Forms.Panel();
            this.numericUpDownCobWebCutOff = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownCobWebAcuity = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCobWebSeedNumber = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panelHierarchical = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxHierarchicalNormalize = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxHierarchicalDistance = new System.Windows.Forms.ComboBox();
            this.comboBoxHierarchicalLinkType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDownHierarchicalNumClasses = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.panelKMeans = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxKMeansIsNormalized = new System.Windows.Forms.CheckBox();
            this.comboBoxKMeansDistType = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDownKMeansSeedNumber = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownKMeansMaxIterations = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDownKMeansClasses = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDownMeanShiftMaxIter = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.panelMeanShift.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMeanShiftBandWidth)).BeginInit();
            this.panelEM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEMMinStdev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEMSeedNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEMMaxIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEMNumClasses)).BeginInit();
            this.panelFarthestFirst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFarthestFirstSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFarthestFirstClasses)).BeginInit();
            this.panelCobWeb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCobWebCutOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCobWebAcuity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCobWebSeedNumber)).BeginInit();
            this.panelHierarchical.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHierarchicalNumClasses)).BeginInit();
            this.panelKMeans.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKMeansSeedNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKMeansMaxIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKMeansClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMeanShiftMaxIter)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMeanShift
            // 
            this.panelMeanShift.Controls.Add(this.numericUpDownMeanShiftMaxIter);
            this.panelMeanShift.Controls.Add(this.label19);
            this.panelMeanShift.Controls.Add(this.comboBoxMeanShiftKernel);
            this.panelMeanShift.Controls.Add(this.label2);
            this.panelMeanShift.Controls.Add(this.numericUpDownMeanShiftBandWidth);
            this.panelMeanShift.Controls.Add(this.label1);
            this.panelMeanShift.Location = new System.Drawing.Point(9, 10);
            this.panelMeanShift.Name = "panelMeanShift";
            this.panelMeanShift.Size = new System.Drawing.Size(236, 120);
            this.panelMeanShift.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bandwith";
            // 
            // numericUpDownMeanShiftBandWidth
            // 
            this.numericUpDownMeanShiftBandWidth.DecimalPlaces = 2;
            this.numericUpDownMeanShiftBandWidth.Location = new System.Drawing.Point(81, 12);
            this.numericUpDownMeanShiftBandWidth.Name = "numericUpDownMeanShiftBandWidth";
            this.numericUpDownMeanShiftBandWidth.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownMeanShiftBandWidth.TabIndex = 1;
            this.numericUpDownMeanShiftBandWidth.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kernel";
            // 
            // comboBoxMeanShiftKernel
            // 
            this.comboBoxMeanShiftKernel.FormattingEnabled = true;
            this.comboBoxMeanShiftKernel.Items.AddRange(new object[] {
            "Epanechnikov",
            "Gaussian",
            "Uniform"});
            this.comboBoxMeanShiftKernel.Location = new System.Drawing.Point(81, 49);
            this.comboBoxMeanShiftKernel.Name = "comboBoxMeanShiftKernel";
            this.comboBoxMeanShiftKernel.Size = new System.Drawing.Size(119, 21);
            this.comboBoxMeanShiftKernel.TabIndex = 3;
            this.comboBoxMeanShiftKernel.Text = "Epanechnikov";
            // 
            // panelEM
            // 
            this.panelEM.Controls.Add(this.numericUpDownEMMinStdev);
            this.panelEM.Controls.Add(this.numericUpDownEMSeedNumber);
            this.panelEM.Controls.Add(this.numericUpDownEMMaxIterations);
            this.panelEM.Controls.Add(this.label3);
            this.panelEM.Controls.Add(this.label4);
            this.panelEM.Controls.Add(this.label5);
            this.panelEM.Controls.Add(this.checkBoxAutomatedEMClassNum);
            this.panelEM.Controls.Add(this.numericUpDownEMNumClasses);
            this.panelEM.Controls.Add(this.label6);
            this.panelEM.Location = new System.Drawing.Point(251, 10);
            this.panelEM.Name = "panelEM";
            this.panelEM.Size = new System.Drawing.Size(236, 159);
            this.panelEM.TabIndex = 1;
            // 
            // numericUpDownEMMinStdev
            // 
            this.numericUpDownEMMinStdev.DecimalPlaces = 7;
            this.numericUpDownEMMinStdev.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.numericUpDownEMMinStdev.Location = new System.Drawing.Point(81, 92);
            this.numericUpDownEMMinStdev.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numericUpDownEMMinStdev.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            458752});
            this.numericUpDownEMMinStdev.Name = "numericUpDownEMMinStdev";
            this.numericUpDownEMMinStdev.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownEMMinStdev.TabIndex = 8;
            this.numericUpDownEMMinStdev.Value = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            // 
            // numericUpDownEMSeedNumber
            // 
            this.numericUpDownEMSeedNumber.Location = new System.Drawing.Point(81, 123);
            this.numericUpDownEMSeedNumber.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numericUpDownEMSeedNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownEMSeedNumber.Name = "numericUpDownEMSeedNumber";
            this.numericUpDownEMSeedNumber.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownEMSeedNumber.TabIndex = 9;
            this.numericUpDownEMSeedNumber.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownEMMaxIterations
            // 
            this.numericUpDownEMMaxIterations.Location = new System.Drawing.Point(81, 62);
            this.numericUpDownEMMaxIterations.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numericUpDownEMMaxIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownEMMaxIterations.Name = "numericUpDownEMMaxIterations";
            this.numericUpDownEMMaxIterations.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownEMMaxIterations.TabIndex = 10;
            this.numericUpDownEMMaxIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Seed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Min. Stdv";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Max It.";
            // 
            // checkBoxAutomatedEMClassNum
            // 
            this.checkBoxAutomatedEMClassNum.AutoSize = true;
            this.checkBoxAutomatedEMClassNum.Location = new System.Drawing.Point(170, 19);
            this.checkBoxAutomatedEMClassNum.Name = "checkBoxAutomatedEMClassNum";
            this.checkBoxAutomatedEMClassNum.Size = new System.Drawing.Size(48, 17);
            this.checkBoxAutomatedEMClassNum.TabIndex = 4;
            this.checkBoxAutomatedEMClassNum.Text = "Auto";
            this.checkBoxAutomatedEMClassNum.UseVisualStyleBackColor = true;
            // 
            // numericUpDownEMNumClasses
            // 
            this.numericUpDownEMNumClasses.Location = new System.Drawing.Point(81, 17);
            this.numericUpDownEMNumClasses.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownEMNumClasses.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownEMNumClasses.Name = "numericUpDownEMNumClasses";
            this.numericUpDownEMNumClasses.Size = new System.Drawing.Size(79, 20);
            this.numericUpDownEMNumClasses.TabIndex = 3;
            this.numericUpDownEMNumClasses.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Classes";
            // 
            // panelFarthestFirst
            // 
            this.panelFarthestFirst.Controls.Add(this.numericUpDownFarthestFirstSeed);
            this.panelFarthestFirst.Controls.Add(this.label7);
            this.panelFarthestFirst.Controls.Add(this.numericUpDownFarthestFirstClasses);
            this.panelFarthestFirst.Controls.Add(this.label10);
            this.panelFarthestFirst.Location = new System.Drawing.Point(251, 175);
            this.panelFarthestFirst.Name = "panelFarthestFirst";
            this.panelFarthestFirst.Size = new System.Drawing.Size(236, 79);
            this.panelFarthestFirst.TabIndex = 2;
            // 
            // numericUpDownFarthestFirstSeed
            // 
            this.numericUpDownFarthestFirstSeed.Location = new System.Drawing.Point(81, 46);
            this.numericUpDownFarthestFirstSeed.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numericUpDownFarthestFirstSeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFarthestFirstSeed.Name = "numericUpDownFarthestFirstSeed";
            this.numericUpDownFarthestFirstSeed.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownFarthestFirstSeed.TabIndex = 9;
            this.numericUpDownFarthestFirstSeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Seed";
            // 
            // numericUpDownFarthestFirstClasses
            // 
            this.numericUpDownFarthestFirstClasses.Location = new System.Drawing.Point(81, 17);
            this.numericUpDownFarthestFirstClasses.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownFarthestFirstClasses.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFarthestFirstClasses.Name = "numericUpDownFarthestFirstClasses";
            this.numericUpDownFarthestFirstClasses.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownFarthestFirstClasses.TabIndex = 3;
            this.numericUpDownFarthestFirstClasses.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Classes";
            // 
            // panelCobWeb
            // 
            this.panelCobWeb.Controls.Add(this.numericUpDownCobWebCutOff);
            this.panelCobWeb.Controls.Add(this.label8);
            this.panelCobWeb.Controls.Add(this.numericUpDownCobWebAcuity);
            this.panelCobWeb.Controls.Add(this.numericUpDownCobWebSeedNumber);
            this.panelCobWeb.Controls.Add(this.label9);
            this.panelCobWeb.Controls.Add(this.label11);
            this.panelCobWeb.Location = new System.Drawing.Point(251, 260);
            this.panelCobWeb.Name = "panelCobWeb";
            this.panelCobWeb.Size = new System.Drawing.Size(236, 115);
            this.panelCobWeb.TabIndex = 3;
            // 
            // numericUpDownCobWebCutOff
            // 
            this.numericUpDownCobWebCutOff.DecimalPlaces = 12;
            this.numericUpDownCobWebCutOff.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.numericUpDownCobWebCutOff.Location = new System.Drawing.Point(81, 48);
            this.numericUpDownCobWebCutOff.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numericUpDownCobWebCutOff.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            458752});
            this.numericUpDownCobWebCutOff.Name = "numericUpDownCobWebCutOff";
            this.numericUpDownCobWebCutOff.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownCobWebCutOff.TabIndex = 11;
            this.numericUpDownCobWebCutOff.Value = new decimal(new int[] {
            833273639,
            6568031,
            0,
            1245184});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "CutOff";
            // 
            // numericUpDownCobWebAcuity
            // 
            this.numericUpDownCobWebAcuity.DecimalPlaces = 1;
            this.numericUpDownCobWebAcuity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.numericUpDownCobWebAcuity.Location = new System.Drawing.Point(81, 18);
            this.numericUpDownCobWebAcuity.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numericUpDownCobWebAcuity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            458752});
            this.numericUpDownCobWebAcuity.Name = "numericUpDownCobWebAcuity";
            this.numericUpDownCobWebAcuity.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownCobWebAcuity.TabIndex = 8;
            this.numericUpDownCobWebAcuity.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // numericUpDownCobWebSeedNumber
            // 
            this.numericUpDownCobWebSeedNumber.Location = new System.Drawing.Point(81, 79);
            this.numericUpDownCobWebSeedNumber.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numericUpDownCobWebSeedNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCobWebSeedNumber.Name = "numericUpDownCobWebSeedNumber";
            this.numericUpDownCobWebSeedNumber.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownCobWebSeedNumber.TabIndex = 9;
            this.numericUpDownCobWebSeedNumber.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Seed";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Acuity";
            // 
            // panelHierarchical
            // 
            this.panelHierarchical.Controls.Add(this.groupBox1);
            this.panelHierarchical.Controls.Add(this.comboBoxHierarchicalLinkType);
            this.panelHierarchical.Controls.Add(this.label18);
            this.panelHierarchical.Controls.Add(this.numericUpDownHierarchicalNumClasses);
            this.panelHierarchical.Controls.Add(this.label13);
            this.panelHierarchical.Location = new System.Drawing.Point(9, 163);
            this.panelHierarchical.Name = "panelHierarchical";
            this.panelHierarchical.Size = new System.Drawing.Size(236, 180);
            this.panelHierarchical.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxHierarchicalNormalize);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.comboBoxHierarchicalDistance);
            this.groupBox1.Location = new System.Drawing.Point(4, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 86);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Distance";
            // 
            // checkBoxHierarchicalNormalize
            // 
            this.checkBoxHierarchicalNormalize.AutoSize = true;
            this.checkBoxHierarchicalNormalize.Checked = true;
            this.checkBoxHierarchicalNormalize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHierarchicalNormalize.Location = new System.Drawing.Point(16, 56);
            this.checkBoxHierarchicalNormalize.Name = "checkBoxHierarchicalNormalize";
            this.checkBoxHierarchicalNormalize.Size = new System.Drawing.Size(72, 17);
            this.checkBoxHierarchicalNormalize.TabIndex = 19;
            this.checkBoxHierarchicalNormalize.Text = "Normalize";
            this.checkBoxHierarchicalNormalize.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Type";
            // 
            // comboBoxHierarchicalDistance
            // 
            this.comboBoxHierarchicalDistance.FormattingEnabled = true;
            this.comboBoxHierarchicalDistance.Items.AddRange(new object[] {
            "Euclidean",
            "Manhattan",
            "Chebyshev"});
            this.comboBoxHierarchicalDistance.Location = new System.Drawing.Point(77, 24);
            this.comboBoxHierarchicalDistance.Name = "comboBoxHierarchicalDistance";
            this.comboBoxHierarchicalDistance.Size = new System.Drawing.Size(119, 21);
            this.comboBoxHierarchicalDistance.TabIndex = 3;
            this.comboBoxHierarchicalDistance.Text = "Euclidean";
            // 
            // comboBoxHierarchicalLinkType
            // 
            this.comboBoxHierarchicalLinkType.FormattingEnabled = true;
            this.comboBoxHierarchicalLinkType.Items.AddRange(new object[] {
            "SINGLE",
            "COMPLETE",
            "AVERAGE",
            "MEAN",
            "CENTROID",
            "WARD",
            "ADJCOMLPETE"});
            this.comboBoxHierarchicalLinkType.Location = new System.Drawing.Point(81, 143);
            this.comboBoxHierarchicalLinkType.Name = "comboBoxHierarchicalLinkType";
            this.comboBoxHierarchicalLinkType.Size = new System.Drawing.Size(119, 21);
            this.comboBoxHierarchicalLinkType.TabIndex = 5;
            this.comboBoxHierarchicalLinkType.Text = "SINGLE";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 146);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "Link type";
            // 
            // numericUpDownHierarchicalNumClasses
            // 
            this.numericUpDownHierarchicalNumClasses.Location = new System.Drawing.Point(81, 17);
            this.numericUpDownHierarchicalNumClasses.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownHierarchicalNumClasses.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHierarchicalNumClasses.Name = "numericUpDownHierarchicalNumClasses";
            this.numericUpDownHierarchicalNumClasses.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownHierarchicalNumClasses.TabIndex = 1;
            this.numericUpDownHierarchicalNumClasses.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Classes";
            // 
            // panelKMeans
            // 
            this.panelKMeans.Controls.Add(this.groupBox2);
            this.panelKMeans.Controls.Add(this.numericUpDownKMeansSeedNumber);
            this.panelKMeans.Controls.Add(this.numericUpDownKMeansMaxIterations);
            this.panelKMeans.Controls.Add(this.label14);
            this.panelKMeans.Controls.Add(this.label15);
            this.panelKMeans.Controls.Add(this.numericUpDownKMeansClasses);
            this.panelKMeans.Controls.Add(this.label16);
            this.panelKMeans.Location = new System.Drawing.Point(9, 349);
            this.panelKMeans.Name = "panelKMeans";
            this.panelKMeans.Size = new System.Drawing.Size(236, 206);
            this.panelKMeans.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxKMeansIsNormalized);
            this.groupBox2.Controls.Add(this.comboBoxKMeansDistType);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Location = new System.Drawing.Point(4, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 86);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Distance";
            // 
            // checkBoxKMeansIsNormalized
            // 
            this.checkBoxKMeansIsNormalized.AutoSize = true;
            this.checkBoxKMeansIsNormalized.Checked = true;
            this.checkBoxKMeansIsNormalized.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKMeansIsNormalized.Location = new System.Drawing.Point(13, 56);
            this.checkBoxKMeansIsNormalized.Name = "checkBoxKMeansIsNormalized";
            this.checkBoxKMeansIsNormalized.Size = new System.Drawing.Size(72, 17);
            this.checkBoxKMeansIsNormalized.TabIndex = 19;
            this.checkBoxKMeansIsNormalized.Text = "Normalize";
            this.checkBoxKMeansIsNormalized.UseVisualStyleBackColor = true;
            // 
            // comboBoxKMeansDistType
            // 
            this.comboBoxKMeansDistType.FormattingEnabled = true;
            this.comboBoxKMeansDistType.Items.AddRange(new object[] {
            "Euclidean",
            "Manhattan"});
            this.comboBoxKMeansDistType.Location = new System.Drawing.Point(77, 24);
            this.comboBoxKMeansDistType.Name = "comboBoxKMeansDistType";
            this.comboBoxKMeansDistType.Size = new System.Drawing.Size(119, 21);
            this.comboBoxKMeansDistType.TabIndex = 18;
            this.comboBoxKMeansDistType.Text = "Euclidean";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Type";
            // 
            // numericUpDownKMeansSeedNumber
            // 
            this.numericUpDownKMeansSeedNumber.Location = new System.Drawing.Point(81, 79);
            this.numericUpDownKMeansSeedNumber.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numericUpDownKMeansSeedNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownKMeansSeedNumber.Name = "numericUpDownKMeansSeedNumber";
            this.numericUpDownKMeansSeedNumber.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownKMeansSeedNumber.TabIndex = 15;
            this.numericUpDownKMeansSeedNumber.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownKMeansMaxIterations
            // 
            this.numericUpDownKMeansMaxIterations.Location = new System.Drawing.Point(81, 50);
            this.numericUpDownKMeansMaxIterations.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numericUpDownKMeansMaxIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownKMeansMaxIterations.Name = "numericUpDownKMeansMaxIterations";
            this.numericUpDownKMeansMaxIterations.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownKMeansMaxIterations.TabIndex = 16;
            this.numericUpDownKMeansMaxIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Seed";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Max It.";
            // 
            // numericUpDownKMeansClasses
            // 
            this.numericUpDownKMeansClasses.Location = new System.Drawing.Point(81, 17);
            this.numericUpDownKMeansClasses.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownKMeansClasses.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownKMeansClasses.Name = "numericUpDownKMeansClasses";
            this.numericUpDownKMeansClasses.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownKMeansClasses.TabIndex = 12;
            this.numericUpDownKMeansClasses.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Classes";
            // 
            // numericUpDownMeanShiftMaxIter
            // 
            this.numericUpDownMeanShiftMaxIter.Location = new System.Drawing.Point(81, 86);
            this.numericUpDownMeanShiftMaxIter.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numericUpDownMeanShiftMaxIter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMeanShiftMaxIter.Name = "numericUpDownMeanShiftMaxIter";
            this.numericUpDownMeanShiftMaxIter.Size = new System.Drawing.Size(119, 20);
            this.numericUpDownMeanShiftMaxIter.TabIndex = 18;
            this.numericUpDownMeanShiftMaxIter.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 88);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 13);
            this.label19.TabIndex = 17;
            this.label19.Text = "Max It.";
            // 
            // FormForAllClusteringOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 679);
            this.Controls.Add(this.panelKMeans);
            this.Controls.Add(this.panelHierarchical);
            this.Controls.Add(this.panelCobWeb);
            this.Controls.Add(this.panelFarthestFirst);
            this.Controls.Add(this.panelEM);
            this.Controls.Add(this.panelMeanShift);
            this.Name = "FormForAllClusteringOptions";
            this.Text = "FormForAllClusteringOptions";
            this.panelMeanShift.ResumeLayout(false);
            this.panelMeanShift.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMeanShiftBandWidth)).EndInit();
            this.panelEM.ResumeLayout(false);
            this.panelEM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEMMinStdev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEMSeedNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEMMaxIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEMNumClasses)).EndInit();
            this.panelFarthestFirst.ResumeLayout(false);
            this.panelFarthestFirst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFarthestFirstSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFarthestFirstClasses)).EndInit();
            this.panelCobWeb.ResumeLayout(false);
            this.panelCobWeb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCobWebCutOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCobWebAcuity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCobWebSeedNumber)).EndInit();
            this.panelHierarchical.ResumeLayout(false);
            this.panelHierarchical.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHierarchicalNumClasses)).EndInit();
            this.panelKMeans.ResumeLayout(false);
            this.panelKMeans.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKMeansSeedNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKMeansMaxIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKMeansClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMeanShiftMaxIter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelMeanShift;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numericUpDownMeanShiftBandWidth;
        public System.Windows.Forms.ComboBox comboBoxMeanShiftKernel;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panelEM;
        public System.Windows.Forms.NumericUpDown numericUpDownEMMinStdev;
        public System.Windows.Forms.NumericUpDown numericUpDownEMSeedNumber;
        public System.Windows.Forms.NumericUpDown numericUpDownEMMaxIterations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown numericUpDownEMNumClasses;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox checkBoxAutomatedEMClassNum;
        public System.Windows.Forms.Panel panelFarthestFirst;
        public System.Windows.Forms.NumericUpDown numericUpDownFarthestFirstSeed;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown numericUpDownFarthestFirstClasses;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Panel panelCobWeb;
        public System.Windows.Forms.NumericUpDown numericUpDownCobWebCutOff;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.NumericUpDown numericUpDownCobWebAcuity;
        public System.Windows.Forms.NumericUpDown numericUpDownCobWebSeedNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Panel panelHierarchical;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox comboBoxHierarchicalDistance;
        public System.Windows.Forms.ComboBox comboBoxHierarchicalLinkType;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.NumericUpDown numericUpDownHierarchicalNumClasses;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Panel panelKMeans;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox comboBoxKMeansDistType;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.NumericUpDown numericUpDownKMeansSeedNumber;
        public System.Windows.Forms.NumericUpDown numericUpDownKMeansMaxIterations;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.NumericUpDown numericUpDownKMeansClasses;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.CheckBox checkBoxHierarchicalNormalize;
        public System.Windows.Forms.CheckBox checkBoxKMeansIsNormalized;
        public System.Windows.Forms.NumericUpDown numericUpDownMeanShiftMaxIter;
        private System.Windows.Forms.Label label19;
    }
}