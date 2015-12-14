using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Forms.FormsForImages;
using System.Drawing;
using ImageAnalysis;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Runtime.InteropServices;
using Emgu.CV.Structure;
using HCSAnalyzer.Classes;
using HCSAnalyzer.Classes.General_Types;
using HCSAnalyzer.Classes.Base_Classes;

namespace ImageAnalysisFiltering
{

    public enum eGradType
    {
        VERTICAL, HORIZONTAL, MAX
    }


    public partial class cImageGradient : c2DImageFilter
    {
        eGradType GradType = eGradType.HORIZONTAL;
        //  public double StdDev = 3.0;

        public cImageGradient(eGradType GradType)
        {
            this.GradType = GradType;
            switch (GradType)
            {
                case eGradType.VERTICAL:
                    this.Title = "2D Y gradient";
                    break;
                case eGradType.HORIZONTAL:
                    this.Title = "2D X gradient";
                    break;
                case eGradType.MAX:
                    this.Title = "2D maximum gradient";
                    break;
                default:
                    this.Title = "gradient type not defined";
                    break;
            }



            //cPropertyType PT = new cPropertyType("Kernel Size", eDataType.INTEGER);
            //PT.IntType = eIntegerType.ODD;
            //cProperty Prop1 = new cProperty(PT, null);
            //Prop1.Info = "Gaussian kernel size";
            //Prop1.SetNewValue((int)3);
            //base.ListProperties.Add(Prop1);
        }

        public cFeedBackMessage Run()
        {
            if (base.Start() == false)
            {
                base.FeedBackMessage.IsSucceed = false;
                return base.FeedBackMessage;
            }

            //object _firstValue = base.ListProperties.FindByName("Kernel Size");
            //int KernelSize = 0;
            //if (_firstValue == null)
            //{
            //    base.GenerateError("Kernel Size not found !");
            //    return base.FeedBackMessage;
            //}
            //try
            //{
            //    cProperty TmpProp = (cProperty)_firstValue;
            //    KernelSize = (int)TmpProp.GetValue();
            //}
            //catch (Exception)
            //{
            //    base.GenerateError("Kernel Size cast didn't work");
            //    return base.FeedBackMessage;
            //}
            base.Output = new cImage(base.Input, false);

            switch (GradType)
            {
                case eGradType.VERTICAL:
                    for (int IdxChannel = 0; IdxChannel < base.ListChannelsToBeProcessed.Count; IdxChannel++)
                    {
                        int CurrentChannel = base.ListChannelsToBeProcessed[IdxChannel];

                        for (int j = 1; j < Input.Height - 1; j++)
                            for (int i = 1; i < Input.Width - 1; i++)
                            {
                                base.Output.SingleChannelImage[CurrentChannel].Data[i + j * this.Input.Width] =
                                    (Input.SingleChannelImage[CurrentChannel].Data[i + (j+1) * Input.Width] - Input.SingleChannelImage[CurrentChannel].Data[i + (j-1) * Input.Width]) / 2.0f;
                            }
                    }
                    break;
                case eGradType.HORIZONTAL:
                    for (int IdxChannel = 0; IdxChannel < base.ListChannelsToBeProcessed.Count; IdxChannel++)
                    {
                        int CurrentChannel = base.ListChannelsToBeProcessed[IdxChannel];

                        for (int j = 1; j < Input.Height - 1; j++)
                            for (int i = 1; i < Input.Width - 1; i++)
                            {
                                base.Output.SingleChannelImage[CurrentChannel].Data[i + j * this.Input.Width] =
                                    (Input.SingleChannelImage[CurrentChannel].Data[i + 1 + j * Input.Width] - Input.SingleChannelImage[CurrentChannel].Data[i - 1 + j * Input.Width]) / 2.0f;
                            }
                    }
                    break;
                case eGradType.MAX:
                    for (int IdxChannel = 0; IdxChannel < base.ListChannelsToBeProcessed.Count; IdxChannel++)
                    {
                        int CurrentChannel = base.ListChannelsToBeProcessed[IdxChannel];

                        for (int j = 1; j < Input.Height - 1; j++)
                            for (int i = 1; i < Input.Width - 1; i++)
                            {
                                float Value = (Input.SingleChannelImage[CurrentChannel].Data[i + 1 + j * Input.Width] - Input.SingleChannelImage[CurrentChannel].Data[i - 1 + j * Input.Width]) / 2.0f;
                                float NewValue = (Input.SingleChannelImage[CurrentChannel].Data[i + (j+1) * Input.Width] - Input.SingleChannelImage[CurrentChannel].Data[i + (j-1) * Input.Width]) / 2.0f;
                                if (NewValue > Value)
                                    base.Output.SingleChannelImage[CurrentChannel].Data[i + j * this.Input.Width] = NewValue;
                                else
                                    base.Output.SingleChannelImage[CurrentChannel].Data[i + j * this.Input.Width] = Value;
                            }
                    }
                    break;
                default:
                    break;
            }



            base.End();

            return FeedBackMessage;
        }
    }
}
