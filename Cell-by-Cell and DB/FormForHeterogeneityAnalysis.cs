using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCSAnalyzer.Forms.FormsForGraphsDisplay;
using MIConvexHull;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using HCSAnalyzer.Classes.Base_Classes.DataAnalysis;
using HCSAnalyzer.Classes.MetaComponents;
using ImageAnalysis;
using HCSAnalyzer.Classes._3D;


namespace HCSAnalyzer.Cell_by_Cell_and_DB
{
    public partial class FormForHeterogeneityAnalysis : Form
    {

        FormForSingleCellsDisplay Parent;

        public FormForHeterogeneityAnalysis(FormForSingleCellsDisplay Parent)
        {
            InitializeComponent();
            this.Parent = Parent;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {

            //cExtendedList ListX = new cExtendedList();
            //cExtendedList ListY = new cExtendedList();
            //cExtendedList ListZ = new cExtendedList();

            cExtendedTable TableForDataToBeAnalyzed = Parent.GetActiveSignatures(false);
            //cExtendedTable PosList = new cExtendedTable();
            //PosList.Add(new cExtendedList("X"));
            //PosList.Add(new cExtendedList("Y"));


            int ImageWidth = 256;// (int)numericUpDownMapWidth.Value;
            int ImageHeight = 256;// (int)numericUpDownMapHeight.Value;
            double MaxX = Parent.chartForPoints.ChartAreas[0].AxisX.Maximum;
            double MinX = Parent.chartForPoints.ChartAreas[0].AxisX.Minimum;

            double MaxY = Parent.chartForPoints.ChartAreas[0].AxisY.Maximum;
            double MinY = Parent.chartForPoints.ChartAreas[0].AxisY.Minimum;
            //   cImage I = new cImage(ImageWidth, ImageHeight, 1,1);

            cExtendedTable Results = new cExtendedTable();
            Results.Add(new cExtendedList("X"));
            Results.Add(new cExtendedList("Y"));

            for (int Iteration = 1; Iteration < 1000; Iteration *= 10)
            {
                double Alpha = 1 / (double)Iteration;
                Results.Add(new cExtendedList("Alpha =" + Alpha));



                // loop over each point
                for (int j = 0; j < TableForDataToBeAnalyzed[0].Count; j++)
                {

                    cPoint3D currentPt = new cPoint3D(TableForDataToBeAnalyzed[Parent.comboBoxAxeX.SelectedIndex][j],
                        TableForDataToBeAnalyzed[Parent.comboBoxAxeY.SelectedIndex][j], 0);
                    if (Iteration == 1)
                    {
                        Results[0].Add(currentPt.X);
                        Results[1].Add(currentPt.Y);
                    }
                    double HeteroValue = 0;

                    for (int k = 0; k < TableForDataToBeAnalyzed[0].Count; k++)
                    {
                        if (j == k) continue;
                        cPoint3D TmpPt = new cPoint3D(TableForDataToBeAnalyzed[Parent.comboBoxAxeX.SelectedIndex][k],
                            TableForDataToBeAnalyzed[Parent.comboBoxAxeY.SelectedIndex][k], 0);

                        double Dist = TmpPt.DistTo(currentPt);
                        Dist = Math.Exp(-Alpha * Dist);
                        HeteroValue += TableForDataToBeAnalyzed[Parent.comboBoxVolume.SelectedIndex][k] * Dist;
                    }

                    //  HeteroValue /= (double)(TableForDataToBeAnalyzed[0].Count - 1);
                    float Delta = (float)Math.Abs(TableForDataToBeAnalyzed[Parent.comboBoxVolume.SelectedIndex][j] - HeteroValue);
                    Results[Results.Count - 1].Add(Delta);

                    // draw the point on the image
                    //int TmpValueX = (int)((ImageWidth * (currentPt.X - MinX)) / (MaxX - MinX));
                    //int TmpValueY = (int)(ImageHeight - (ImageHeight * (currentPt.Y - MinY)) / (MaxY - MinY));

                    //if (TmpValueX >= ImageWidth) TmpValueX = ImageWidth - 1;
                    //if (TmpValueY >= ImageWidth) TmpValueY = ImageHeight - 1;

                    // I.SingleChannelImage[0].Data[TmpValueX + TmpValueY * I.Width] = Delta;

                }
            }
            //cDisplaySingleImage IV = new cDisplaySingleImage();
            //I.Name = "Heterogeneity Maps [" + TableForDataToBeAnalyzed[0].Count + " points]";
            //IV.SetInputData(I);
            //IV.Run();

            cDisplayExtendedTable DET = new cDisplayExtendedTable();
            DET.SetInputData(Results);
            DET.Run();
        }
    }
}
