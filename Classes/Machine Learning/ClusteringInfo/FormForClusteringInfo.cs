using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCSAnalyzer.Forms.FormsForOptions.ClassForOptions;
using HCSAnalyzer.Forms.FormsForOptions.ClassForOptions.Children;
using HCSAnalyzer.Classes;

namespace HCSAnalyzer.Forms.FormsForOptions
{
    public partial class FormForClusteringInfo : Form
    {
        cGlobalInfo GlobalInfo;
      
        FormForAllClusteringOptions AllPanelForOptions = new FormForAllClusteringOptions();


        public FormForClusteringInfo(List<string> ListDescriptors, cGlobalInfo GlobalInfo)
        {
            InitializeComponent();
            //this.panelForDisplay.Controls.Add(this.AllPanelForOptions.panelMeanShift); 
            this.GlobalInfo = GlobalInfo;
            this.treeViewForOptions.SelectedNode = this.treeViewForOptions.Nodes[0];
           
        }

        private void treeViewForOptions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.panelForDisplay.Controls.Clear();
            richTextBoxForInfo.Clear();
            string TagName= (string)e.Node.Text;

          //  Panel PanelToDisp = ListClusteringAlgo.GetPanel(TagName);
          //  if (PanelToDisp == null) return;
           // this.panelForDisplay.Controls.Add(PanelToDisp);

            if (TagName == "EM")
            {
                this.AllPanelForOptions.panelEM.Location = new Point(0, 0);
                this.panelForDisplay.Controls.Add(this.AllPanelForOptions.panelEM); 

                richTextBoxForInfo.AppendText("Expectation Maximization (EM)\n------------------------------------------------------\nFor more information, go to: http://en.wikipedia.org/wiki/Expectation_maximization");
            }
            else if (TagName == "K-Means")
            {
                this.AllPanelForOptions.panelKMeans.Location = new Point(0, 0);
                this.panelForDisplay.Controls.Add(this.AllPanelForOptions.panelKMeans); 

                richTextBoxForInfo.AppendText("K-Means\n------------------------------------------------------\nFor more information, go to: http://en.wikipedia.org/wiki/K-means_clustering");
            }
            else if (TagName == "Mean-Shift")
            {
                this.AllPanelForOptions.panelMeanShift.Location = new Point(0, 0);
                this.panelForDisplay.Controls.Add(this.AllPanelForOptions.panelMeanShift); 

                richTextBoxForInfo.AppendText("Mean-Shift\n------------------------------------------------------\nFor more information, go to: http://en.wikipedia.org/wiki/Mean_shift");
            }
            else if (TagName == "Hierarchical")
            {   
                this.AllPanelForOptions.panelHierarchical.Location = new Point(0, 0);
                this.panelForDisplay.Controls.Add(this.AllPanelForOptions.panelHierarchical); 
                
                richTextBoxForInfo.AppendText("Hierarchical Clustering\n------------------------------------------------------\nNote: well suited for large signatures, but computationaly heavy regarding the number of experiments.\nFor more information, go to: http://en.wikipedia.org/wiki/Hierarchical_clustering");
            }
            else if (TagName == "Farthest First")
            {
                this.AllPanelForOptions.panelFarthestFirst.Location = new Point(0, 0);
                this.panelForDisplay.Controls.Add(this.AllPanelForOptions.panelFarthestFirst); 

                richTextBoxForInfo.AppendText("Farthest First Clustering\n------------------------------------------------------\nFor more information:\n Hochbaum, Shmoys (1985).\nA best possible heuristic for the k-center problem.\nMathematics of Operations Research. 10(2):180-184.");
            }
            else if (TagName == "CobWeb")
            {
                this.AllPanelForOptions.panelCobWeb.Location = new Point(0, 0);
                this.panelForDisplay.Controls.Add(this.AllPanelForOptions.panelCobWeb); 
                richTextBoxForInfo.AppendText("CobWeb Clustering\n------------------------------------------------------\nFor more information, go to: http://en.wikipedia.org/wiki/Cobweb_(clustering)");
            }            
            else if (TagName == "Manual")
            {

                richTextBoxForInfo.AppendText("Manual Clustering\n------------------------------------------------------\nIn this mode, classes are defined by a descriptor.\nWarning: the descriptor number of values should be lower than the defined number of distinct cellular phenotypes.");
            }
        }

        public cParamAlgo GetSelectedAlgoAndParameters()
        {
            cParamAlgo ToReturn = new cParamAlgo(treeViewForOptions.SelectedNode.Text);
                ToReturn.AllClusteringOptions = this.AllPanelForOptions;
                ToReturn.PanelToDisplay = this.AllPanelForOptions.panelMeanShift;
         
            return ToReturn;
        }

        private void richTextBoxForInfo_LinkClicked(object sender, LinkClickedEventArgs e)
        {
          cGlobalInfo.WindowHCSAnalyzer.ClickOnLink(e.LinkText);
        }
    }

  

}
