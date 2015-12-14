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
    public partial class cZeroCrossings : c2DImageFilter
    {

        public cZeroCrossings()
        {
            this.Title = "Zero Crossings";
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

            for (int IdxChannel = 0; IdxChannel < base.ListChannelsToBeProcessed.Count; IdxChannel++)
            {
                int CurrentChannel = base.ListChannelsToBeProcessed[IdxChannel];

                for (int j = 1; j < Input.Height - 1; j++)
                    for (int i = 1; i < Input.Width - 1; i++)
                    {
                        float CurrentValue = Input.SingleChannelImage[CurrentChannel].Data[i + j * Input.Width];
                      
                        if (CurrentValue * Input.SingleChannelImage[CurrentChannel].Data[i - 1 + (j - 1) * Input.Width] < 0)
                        {
                            base.Output.SingleChannelImage[CurrentChannel].Data[i + j * Input.Width] = 1;
                            continue;
                        }
                        else if (CurrentValue * Input.SingleChannelImage[CurrentChannel].Data[i - 1 + j * Input.Width] < 0)
                        {
                            base.Output.SingleChannelImage[CurrentChannel].Data[i + j * Input.Width] = 1;
                            continue;
                        }
                        else if (CurrentValue * Input.SingleChannelImage[CurrentChannel].Data[i - 1 + (j+1) * Input.Width] < 0)
                        {
                            base.Output.SingleChannelImage[CurrentChannel].Data[i + j * Input.Width] = 1;
                            continue;
                        }
                        else if (CurrentValue * Input.SingleChannelImage[CurrentChannel].Data[i + (j + 1) * Input.Width] < 0)
                        {
                            base.Output.SingleChannelImage[CurrentChannel].Data[i + j * Input.Width] = 1;
                            continue;
                        }
                        else if (CurrentValue * Input.SingleChannelImage[CurrentChannel].Data[i+1 + (j + 1) * Input.Width] < 0)
                        {
                            base.Output.SingleChannelImage[CurrentChannel].Data[i + j * Input.Width] = 1;
                            continue;
                        }
                        else if (CurrentValue * Input.SingleChannelImage[CurrentChannel].Data[i + 1 + j * Input.Width] < 0)
                        {
                            base.Output.SingleChannelImage[CurrentChannel].Data[i + j * Input.Width] = 1;
                            continue;
                        }
                        else if (CurrentValue * Input.SingleChannelImage[CurrentChannel].Data[i + 1 + (j-1) * Input.Width] < 0)
                        {
                            base.Output.SingleChannelImage[CurrentChannel].Data[i + j * Input.Width] = 1;
                            continue;
                        }
                        else if (CurrentValue * Input.SingleChannelImage[CurrentChannel].Data[i + (j - 1) * Input.Width] < 0)
                        {
                            base.Output.SingleChannelImage[CurrentChannel].Data[i + j * Input.Width] = 1;
                            continue;
                        }

                    }
            }



            base.End();

            return FeedBackMessage;
        }
    }
}
