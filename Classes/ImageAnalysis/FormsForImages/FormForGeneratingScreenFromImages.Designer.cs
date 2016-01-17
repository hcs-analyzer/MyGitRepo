namespace HCSAnalyzer.Classes.ImageAnalysis.FormsForImages
{
    partial class FormForGeneratingScreenFromImages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForGeneratingScreenFromImages));
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.labelPlatform = new System.Windows.Forms.Label();
            this.textBoxPlateForm = new System.Windows.Forms.TextBox();
            this.numericUpDownChannelNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownFieldNumber = new System.Windows.Forms.NumericUpDown();
            this.treeViewForScreenInspection = new System.Windows.Forms.TreeView();
            this.buttonInspect = new System.Windows.Forms.Button();
            this.richTextBoxReport = new System.Windows.Forms.RichTextBox();
            this.tabControlForInfo = new System.Windows.Forms.TabControl();
            this.tabPageImageProp = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonChangeImagePlatform = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChannelNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFieldNumber)).BeginInit();
            this.tabControlForInfo.SuspendLayout();
            this.tabPageImageProp.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGenerate.Location = new System.Drawing.Point(733, 305);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(98, 23);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Start";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // labelPlatform
            // 
            this.labelPlatform.AutoSize = true;
            this.labelPlatform.Location = new System.Drawing.Point(12, 15);
            this.labelPlatform.Name = "labelPlatform";
            this.labelPlatform.Size = new System.Drawing.Size(45, 13);
            this.labelPlatform.TabIndex = 3;
            this.labelPlatform.Text = "Platform";
            this.labelPlatform.DoubleClick += new System.EventHandler(this.labelPlatform_DoubleClick);
            // 
            // textBoxPlateForm
            // 
            this.textBoxPlateForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPlateForm.Location = new System.Drawing.Point(80, 12);
            this.textBoxPlateForm.Name = "textBoxPlateForm";
            this.textBoxPlateForm.ReadOnly = true;
            this.textBoxPlateForm.Size = new System.Drawing.Size(720, 20);
            this.textBoxPlateForm.TabIndex = 4;
            // 
            // numericUpDownChannelNumber
            // 
            this.numericUpDownChannelNumber.Location = new System.Drawing.Point(56, 29);
            this.numericUpDownChannelNumber.Name = "numericUpDownChannelNumber";
            this.numericUpDownChannelNumber.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownChannelNumber.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Channel Number(s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Field Number(s)";
            // 
            // numericUpDownFieldNumber
            // 
            this.numericUpDownFieldNumber.Location = new System.Drawing.Point(56, 94);
            this.numericUpDownFieldNumber.Name = "numericUpDownFieldNumber";
            this.numericUpDownFieldNumber.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownFieldNumber.TabIndex = 7;
            // 
            // treeViewForScreenInspection
            // 
            this.treeViewForScreenInspection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewForScreenInspection.CheckBoxes = true;
            this.treeViewForScreenInspection.Location = new System.Drawing.Point(115, 38);
            this.treeViewForScreenInspection.Name = "treeViewForScreenInspection";
            this.treeViewForScreenInspection.Size = new System.Drawing.Size(213, 290);
            this.treeViewForScreenInspection.TabIndex = 9;
            this.treeViewForScreenInspection.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewForScreenInspection_AfterCheck);
            this.treeViewForScreenInspection.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewForScreenInspection_NodeMouseClick);
            this.treeViewForScreenInspection.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewForScreenInspection_NodeMouseDoubleClick);
            // 
            // buttonInspect
            // 
            this.buttonInspect.Location = new System.Drawing.Point(15, 38);
            this.buttonInspect.Name = "buttonInspect";
            this.buttonInspect.Size = new System.Drawing.Size(94, 23);
            this.buttonInspect.TabIndex = 10;
            this.buttonInspect.Text = "Parse Root";
            this.buttonInspect.UseVisualStyleBackColor = true;
            this.buttonInspect.Click += new System.EventHandler(this.buttonInspect_Click);
            // 
            // richTextBoxReport
            // 
            this.richTextBoxReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxReport.Location = new System.Drawing.Point(334, 38);
            this.richTextBoxReport.Name = "richTextBoxReport";
            this.richTextBoxReport.Size = new System.Drawing.Size(320, 290);
            this.richTextBoxReport.TabIndex = 11;
            this.richTextBoxReport.Text = "";
            // 
            // tabControlForInfo
            // 
            this.tabControlForInfo.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControlForInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlForInfo.Controls.Add(this.tabPageImageProp);
            this.tabControlForInfo.Controls.Add(this.tabPage2);
            this.tabControlForInfo.Location = new System.Drawing.Point(660, 38);
            this.tabControlForInfo.Multiline = true;
            this.tabControlForInfo.Name = "tabControlForInfo";
            this.tabControlForInfo.SelectedIndex = 0;
            this.tabControlForInfo.Size = new System.Drawing.Size(171, 261);
            this.tabControlForInfo.TabIndex = 13;
            // 
            // tabPageImageProp
            // 
            this.tabPageImageProp.Controls.Add(this.label3);
            this.tabPageImageProp.Controls.Add(this.numericUpDownChannelNumber);
            this.tabPageImageProp.Controls.Add(this.label4);
            this.tabPageImageProp.Controls.Add(this.numericUpDownFieldNumber);
            this.tabPageImageProp.Location = new System.Drawing.Point(4, 4);
            this.tabPageImageProp.Name = "tabPageImageProp";
            this.tabPageImageProp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImageProp.Size = new System.Drawing.Size(144, 253);
            this.tabPageImageProp.TabIndex = 0;
            this.tabPageImageProp.Text = "Images";
            this.tabPageImageProp.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(144, 223);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plate";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonChangeImagePlatform
            // 
            this.buttonChangeImagePlatform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeImagePlatform.Location = new System.Drawing.Point(806, 10);
            this.buttonChangeImagePlatform.Name = "buttonChangeImagePlatform";
            this.buttonChangeImagePlatform.Size = new System.Drawing.Size(25, 23);
            this.buttonChangeImagePlatform.TabIndex = 14;
            this.buttonChangeImagePlatform.Text = "...";
            this.buttonChangeImagePlatform.UseVisualStyleBackColor = true;
            this.buttonChangeImagePlatform.Click += new System.EventHandler(this.buttonChangeImagePlatform_Click);
            // 
            // FormForGeneratingScreenFromImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 334);
            this.Controls.Add(this.buttonChangeImagePlatform);
            this.Controls.Add(this.tabControlForInfo);
            this.Controls.Add(this.richTextBoxReport);
            this.Controls.Add(this.buttonInspect);
            this.Controls.Add(this.treeViewForScreenInspection);
            this.Controls.Add(this.textBoxPlateForm);
            this.Controls.Add(this.labelPlatform);
            this.Controls.Add(this.buttonGenerate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(718, 235);
            this.Name = "FormForGeneratingScreenFromImages";
            this.Text = "Generate Screen From Images";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChannelNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFieldNumber)).EndInit();
            this.tabControlForInfo.ResumeLayout(false);
            this.tabPageImageProp.ResumeLayout(false);
            this.tabPageImageProp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Label labelPlatform;
        private System.Windows.Forms.TextBox textBoxPlateForm;
        private System.Windows.Forms.NumericUpDown numericUpDownChannelNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownFieldNumber;
        private System.Windows.Forms.TreeView treeViewForScreenInspection;
        private System.Windows.Forms.Button buttonInspect;
        private System.Windows.Forms.RichTextBox richTextBoxReport;
        private System.Windows.Forms.TabControl tabControlForInfo;
        private System.Windows.Forms.TabPage tabPageImageProp;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonChangeImagePlatform;
    }
}