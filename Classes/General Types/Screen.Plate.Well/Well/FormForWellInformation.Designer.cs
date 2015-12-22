namespace HCSAnalyzer.Forms
{
    partial class FormForWellInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForWellInformation));
            this.chartForFormWell = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonUpdateAndClose = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageDescriptors = new System.Windows.Forms.TabPage();
            this.panelForDescValues = new System.Windows.Forms.Panel();
            this.tabPageDesc = new System.Windows.Forms.TabPage();
            this.panelForProperties = new System.Windows.Forms.Panel();
            this.tabPageHisto = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.chartForFormWell)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPageDescriptors.SuspendLayout();
            this.tabPageDesc.SuspendLayout();
            this.tabPageHisto.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartForFormWell
            // 
            this.chartForFormWell.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartForFormWell.Location = new System.Drawing.Point(6, 6);
            this.chartForFormWell.Name = "chartForFormWell";
            this.chartForFormWell.Size = new System.Drawing.Size(508, 445);
            this.chartForFormWell.TabIndex = 1;
            this.chartForFormWell.Text = "chart1";
            // 
            // buttonUpdateAndClose
            // 
            this.buttonUpdateAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateAndClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonUpdateAndClose.Location = new System.Drawing.Point(382, 401);
            this.buttonUpdateAndClose.Name = "buttonUpdateAndClose";
            this.buttonUpdateAndClose.Size = new System.Drawing.Size(132, 50);
            this.buttonUpdateAndClose.TabIndex = 4;
            this.buttonUpdateAndClose.Text = "Update";
            this.buttonUpdateAndClose.UseVisualStyleBackColor = true;
            this.buttonUpdateAndClose.Click += new System.EventHandler(this.buttonUpdateAndClose_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageDescriptors);
            this.tabControlMain.Controls.Add(this.tabPageDesc);
            this.tabControlMain.Controls.Add(this.tabPageHisto);
            this.tabControlMain.Location = new System.Drawing.Point(12, 10);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(528, 483);
            this.tabControlMain.TabIndex = 9;
            // 
            // tabPageDescriptors
            // 
            this.tabPageDescriptors.Controls.Add(this.panelForDescValues);
            this.tabPageDescriptors.Location = new System.Drawing.Point(4, 22);
            this.tabPageDescriptors.Name = "tabPageDescriptors";
            this.tabPageDescriptors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDescriptors.Size = new System.Drawing.Size(520, 457);
            this.tabPageDescriptors.TabIndex = 3;
            this.tabPageDescriptors.Text = "Descriptors";
            this.tabPageDescriptors.UseVisualStyleBackColor = true;
            // 
            // panelForDescValues
            // 
            this.panelForDescValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForDescValues.Location = new System.Drawing.Point(3, 6);
            this.panelForDescValues.Name = "panelForDescValues";
            this.panelForDescValues.Size = new System.Drawing.Size(514, 448);
            this.panelForDescValues.TabIndex = 0;
            // 
            // tabPageDesc
            // 
            this.tabPageDesc.Controls.Add(this.panelForProperties);
            this.tabPageDesc.Controls.Add(this.buttonUpdateAndClose);
            this.tabPageDesc.Location = new System.Drawing.Point(4, 22);
            this.tabPageDesc.Name = "tabPageDesc";
            this.tabPageDesc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDesc.Size = new System.Drawing.Size(520, 457);
            this.tabPageDesc.TabIndex = 1;
            this.tabPageDesc.Text = "Properties";
            this.tabPageDesc.UseVisualStyleBackColor = true;
            // 
            // panelForProperties
            // 
            this.panelForProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForProperties.AutoScroll = true;
            this.panelForProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForProperties.Location = new System.Drawing.Point(6, 8);
            this.panelForProperties.Name = "panelForProperties";
            this.panelForProperties.Size = new System.Drawing.Size(508, 387);
            this.panelForProperties.TabIndex = 1;
            // 
            // tabPageHisto
            // 
            this.tabPageHisto.Controls.Add(this.chartForFormWell);
            this.tabPageHisto.Location = new System.Drawing.Point(4, 22);
            this.tabPageHisto.Name = "tabPageHisto";
            this.tabPageHisto.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHisto.Size = new System.Drawing.Size(520, 457);
            this.tabPageHisto.TabIndex = 0;
            this.tabPageHisto.Text = "Histogram";
            this.tabPageHisto.UseVisualStyleBackColor = true;
            // 
            // FormForWellInformation
            // 
            this.AcceptButton = this.buttonUpdateAndClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 505);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(330, 279);
            this.Name = "FormForWellInformation";
            this.Text = "Info";
            ((System.ComponentModel.ISupportInitialize)(this.chartForFormWell)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageDescriptors.ResumeLayout(false);
            this.tabPageDesc.ResumeLayout(false);
            this.tabPageHisto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chartForFormWell;
        private System.Windows.Forms.Button buttonUpdateAndClose;
        public System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageHisto;
        private System.Windows.Forms.TabPage tabPageDesc;
        private System.Windows.Forms.TabPage tabPageDescriptors;
        public System.Windows.Forms.Panel panelForDescValues;
        public System.Windows.Forms.Panel panelForProperties;
    }
}