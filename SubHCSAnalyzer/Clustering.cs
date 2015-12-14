using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using weka.core;
using System.Data;
using weka.clusterers;
using LibPlateAnalysis;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Windows.Forms;
using weka.classifiers;
using HCSAnalyzer.Classes;
using weka.core.neighboursearch;
using HCSAnalyzer.Forms.ClusteringForms;
using HCSAnalyzer.Forms.IO;

namespace HCSAnalyzer
{
    public partial class HCSAnalyzer
    {
        #region User Interface
        //private void comboBoxClusteringMethod_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    richTextBoxInfoClustering.Clear();

        //    switch (comboBoxClusteringMethod.SelectedIndex)
        //    {
        //        case 0:
        //            richTextBoxInfoClustering.AppendText("K-Means.\nFor more information, go to: http://en.wikipedia.org/wiki/K-means_clustering");
        //            checkBoxAutomatedClusterNumber.Checked = false;
        //            checkBoxAutomatedClusterNumber.Enabled = false;
        //            numericUpDownClusterNumber.ReadOnly = false;
        //            break;
        //        case 1:
        //            richTextBoxInfoClustering.AppendText("EM.\nFor more information, go to: http://en.wikipedia.org/wiki/Expectation_maximization");
        //            checkBoxAutomatedClusterNumber.Enabled = true;
        //            break;
        //        case 2:
        //            richTextBoxInfoClustering.AppendText("Hierarchical Clusterer.\nNote: well suited for large signatures, but computationaly heavy regarding the number of experiments.\nFor more information, go to: http://en.wikipedia.org/wiki/Hierarchical_clustering");
        //            checkBoxAutomatedClusterNumber.Checked = false;
        //            checkBoxAutomatedClusterNumber.Enabled = false;
        //            numericUpDownClusterNumber.ReadOnly = false;
        //            break;

        //    }

        //}

        //private void richTextBoxInfoClustering_LinkClicked(object sender, LinkClickedEventArgs e)
        //{
        //    ClickOnLink(e.LinkText);

        //}

        //private void buttonCluster_Click(object sender, EventArgs e)
        //{
        //    if (CompleteScreening == null) return;

        //    if (!CompleteScreening.IsSelectedDescriptors())
        //    {
        //        MessageBox.Show("You have to check at least one descriptor !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    this.Cursor = Cursors.WaitCursor;
        //    // -------------- K - Means ---------------------------
        //    if (comboBoxClusteringMethod.SelectedIndex == 0)
        //    {
        //        if (radioButtonClusterPlateByPlate.Checked)
        //        {
        //            int NumberOfPlates = CompleteScreening.ListPlatesActive.Count;
        //            // loop on all the plate
        //            for (int PlateIdx = 0; PlateIdx < NumberOfPlates; PlateIdx++)
        //            {
        //                cPlate CurrentPlateToProcess = CompleteScreening.ListPlatesActive.GetPlate(CompleteScreening.ListPlatesActive[PlateIdx].Name);
        //                KMeans((int)numericUpDownClusterNumber.Value, CurrentPlateToProcess);
        //            }
        //            richTextBoxInfoClustering.AppendText("\nPlate by plate clustering done !");
        //        }
        //        else
        //        {
        //            KMeansFullScreen((int)numericUpDownClusterNumber.Value);
        //            richTextBoxInfoClustering.AppendText("\nGlobal clustering done !");
        //        }
        //    }
        //    else if (comboBoxClusteringMethod.SelectedIndex == 1)   // ---------------- EM --------------------------
        //    {
        //        FormForEMInfo WindowEMinfo = new FormForEMInfo();

        //        if (WindowEMinfo.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

        //        if (checkBoxAutomatedClusterNumber.Checked)
        //        {
        //            string feedback = ClusteringEM(radioButtonClusterFullScreen.Checked, -1, WindowEMinfo);
        //            if (feedback != null)
        //            {
        //                FormForCellByCellClusteringResults WindowFormForCellByCellClusteringResults = new FormForCellByCellClusteringResults();
        //                WindowFormForCellByCellClusteringResults.richTextBoxResults.Clear();
        //                WindowFormForCellByCellClusteringResults.richTextBoxResults.AppendText(feedback);
        //                WindowFormForCellByCellClusteringResults.buttonPerformLearning.Text = "Ok";
        //                WindowFormForCellByCellClusteringResults.ShowDialog();
        //            }
        //        }
        //        else
        //        {
        //            string feedback = ClusteringEM(radioButtonClusterFullScreen.Checked, (int)numericUpDownClusterNumber.Value, WindowEMinfo);
        //            if (feedback != null)
        //            {
        //                FormForCellByCellClusteringResults WindowFormForCellByCellClusteringResults = new FormForCellByCellClusteringResults();
        //                WindowFormForCellByCellClusteringResults.richTextBoxResults.Clear();
        //                WindowFormForCellByCellClusteringResults.richTextBoxResults.AppendText(feedback);
        //                WindowFormForCellByCellClusteringResults.buttonPerformLearning.Text = "Ok";
        //                WindowFormForCellByCellClusteringResults.ShowDialog();
        //            }
        //        }
        //    }
        //    else if (comboBoxClusteringMethod.SelectedIndex == 2)   // ---------------- Hierarchical --------------------------
        //    {
        //        if (checkBoxAutomatedClusterNumber.Checked)
        //            ClusteringHierarchical(radioButtonClusterFullScreen.Checked, -1);
        //        else
        //            ClusteringHierarchical(radioButtonClusterFullScreen.Checked, (int)numericUpDownClusterNumber.Value);

        //    }

        //    //CompleteScreening.GetPlate(CompleteScreening.CurrentDisplayPlate).DisplayClasses(CompleteScreening.PanelForPlate);
        //    //   tabControlMain.SelectedTab = tabPageDistribution;
        //    this.Cursor = Cursors.Default;


        //    CompleteScreening.GetCurrentDisplayPlate().DisplayDistribution(CompleteScreening.ListDescriptors.CurrentSelectedDescriptor, false);
        //}

        //private void radioButtonClusterPlateByPlate_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButtonClusterPlateByPlate.Checked)
        //        richTextBoxInfoClustering.AppendText("\nWarning: in such mode the results can be inconsistent from one plate to another.");
        //}

        //private void checkBoxAutomatedClusterNumber_CheckedChanged(object sender, EventArgs e)
        //{
        //    numericUpDownClusterNumber.ReadOnly = checkBoxAutomatedClusterNumber.Checked;
        //    if (checkBoxAutomatedClusterNumber.Checked)
        //        richTextBoxInfoClustering.AppendText("\nWarning: this task can be time consuming.\nIf the number of class is higher than 10, the clustering will not be performed.");
        //}
        #endregion
    }
}
