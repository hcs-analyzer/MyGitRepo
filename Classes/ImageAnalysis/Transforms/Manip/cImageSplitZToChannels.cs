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
using HCSAnalyzer.Classes.General_Types;
using HCSAnalyzer.Classes.Base_Classes;

namespace ImageAnalysisFiltering
{
    public partial class cImageSplitZToChannels : c2DImageFilter
    {
        public cImageSplitZToChannels()
        {
            this.Title = "Split Z To Channels";

            cProperty Prop1 = new cProperty(new cPropertyType("Number of Channels", eDataType.INTEGER), null);
            Prop1.Info = "Number of Channels for the destination?";
            Prop1.SetNewValue((int)3);
            base.ListProperties.Add(Prop1);
        }

        public cFeedBackMessage Run()
        {
            if (base.Start() == false)
            {
                base.FeedBackMessage.IsSucceed = false;
                return base.FeedBackMessage;
            }

            if (base.Input.GetNumChannels() > 1)
            {
                base.GenerateError("This process works only on grey level images");
                return base.FeedBackMessage;
            }

            object _firstValue = base.ListProperties.FindByName("Number of Channels");
            int ChannelNumber = 3;
            if (_firstValue == null)
            {
                base.GenerateError("-Number of Channels- not found !");
                return base.FeedBackMessage;
            }
            try
            {
                cProperty TmpProp = (cProperty)_firstValue;
                ChannelNumber = (int)TmpProp.GetValue();
            }
            catch (Exception)
            {
                base.GenerateError("-Number of Channels- cast didn't work");
                return base.FeedBackMessage;
            }


            float[] inData;
            float[] outData;

            int NewZSize = base.Input.Depth / ChannelNumber;


            base.Output = new cImage(base.Input.Width, base.Input.Height, NewZSize, ChannelNumber);

            for (int band = 0; band < ChannelNumber; band++)
            {
                inData = base.Input.SingleChannelImage[0].Data;
                outData = base.Output.SingleChannelImage[band].Data;

                int SliceSize = base.Output.Width * base.Output.Height;

                for (int Z = 0; Z < NewZSize; Z++)
                {
                //    for (int i = 0; i < SliceSize ; i++)
                //{

                //    base.Output.SingleChannelImage[band].Data[+i] = base.Input.SingleChannelImage[0].Data[+i];
                //} 
                    Array.Copy(base.Input.SingleChannelImage[0].Data, (Z * ChannelNumber + band) * SliceSize,
                               base.Output.SingleChannelImage[band].Data, Z * SliceSize,
                               SliceSize);
                }










            }


            base.End();
            return FeedBackMessage;
        }

    }
}
