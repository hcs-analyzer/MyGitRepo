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

    public enum e2ndDerivativeType
    {
        VERTICAL, HORIZONTAL, CROSSED
    }


    public partial class cImage2ndDerivative : c2DImageFilter
    {
        e2ndDerivativeType GradType = e2ndDerivativeType.HORIZONTAL;

        public cImage2ndDerivative(e2ndDerivativeType GradType)
        {
            this.GradType = GradType;
            switch (GradType)
            {
                case e2ndDerivativeType.VERTICAL:
                    this.Title = "2D Y 2nd derivative";
                    break;
                case e2ndDerivativeType.HORIZONTAL:
                    this.Title = "2D X 2nd derivative";
                    break;
                case e2ndDerivativeType.CROSSED:
                    this.Title = "2D crossed 2nd derivative";
                    break;
                default:
                    this.Title = "type not defined";
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
                case e2ndDerivativeType.VERTICAL:
                    for (int IdxChannel = 0; IdxChannel < base.ListChannelsToBeProcessed.Count; IdxChannel++)
                    {
                        int CurrentChannel = base.ListChannelsToBeProcessed[IdxChannel];

                        for (int j = 1; j < Input.Height - 1; j++)
                            for (int i = 1; i < Input.Width - 1; i++)
                            {
                                base.Output.SingleChannelImage[CurrentChannel].Data[i + j * this.Input.Width] =
                                    (Input.SingleChannelImage[CurrentChannel].Data[i + (j+1) * Input.Width] + Input.SingleChannelImage[CurrentChannel].Data[i + (j-1) * Input.Width]
                                    -2*Input.SingleChannelImage[CurrentChannel].Data[i + j * Input.Width] ) / 4.0f;
                            }
                    }
                    break;
                case e2ndDerivativeType.HORIZONTAL:
                    for (int IdxChannel = 0; IdxChannel < base.ListChannelsToBeProcessed.Count; IdxChannel++)
                    {
                        int CurrentChannel = base.ListChannelsToBeProcessed[IdxChannel];

                        for (int j = 1; j < Input.Height - 1; j++)
                            for (int i = 1; i < Input.Width - 1; i++)
                            {
                                base.Output.SingleChannelImage[CurrentChannel].Data[i + j * this.Input.Width] =
                                    (Input.SingleChannelImage[CurrentChannel].Data[i + 1 + j * Input.Width] + Input.SingleChannelImage[CurrentChannel].Data[i - 1 + j * Input.Width]
                                    - 2 * Input.SingleChannelImage[CurrentChannel].Data[i + j * Input.Width]) / 4.0f;
                            }
                    }
                    break;
                case e2ndDerivativeType.CROSSED:
                    for (int IdxChannel = 0; IdxChannel < base.ListChannelsToBeProcessed.Count; IdxChannel++)
                    {
                        int CurrentChannel = base.ListChannelsToBeProcessed[IdxChannel];

                        for (int j = 1; j < Input.Height - 1; j++)
                            for (int i = 1; i < Input.Width - 1; i++)
                            {
                                base.Output.SingleChannelImage[CurrentChannel].Data[i + j * this.Input.Width] =
                                    (Input.SingleChannelImage[CurrentChannel].Data[i + 1 + j * Input.Width] + Input.SingleChannelImage[CurrentChannel].Data[i - 1 + j * Input.Width]
                                    + Input.SingleChannelImage[CurrentChannel].Data[i +  (j+1) * Input.Width] + Input.SingleChannelImage[CurrentChannel].Data[i + (j-1) * Input.Width]
                                    - 4 * Input.SingleChannelImage[CurrentChannel].Data[i + j * Input.Width]) / 4.0f;
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
