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
    public partial class cImageGeometricTranslate : c2DImageFilter
    {


        public cImageGeometricTranslate()
        {
            this.Title = "Translation ";

            cProperty Prop1 = new cProperty(new cPropertyType("X", eDataType.DOUBLE), null);
            Prop1.Info = "X Translation";
            Prop1.SetNewValue((double)0);
            base.ListProperties.Add(Prop1);

            Prop1 = new cProperty(new cPropertyType("Y", eDataType.DOUBLE), null);
            Prop1.Info = "Y Translation";
            Prop1.SetNewValue((double)0);
            base.ListProperties.Add(Prop1);

        }

        public cFeedBackMessage Run()
        {
            if (base.Start() == false)
            {
                base.FeedBackMessage.IsSucceed = false;
                return base.FeedBackMessage;
            }

            object _firstValue = base.ListProperties.FindByName("X");
            double XTrans = 0;
            if (_firstValue == null)
            {
                base.GenerateError("-X- not found !");
                return base.FeedBackMessage;
            }
            try
            {
                cProperty TmpProp = (cProperty)_firstValue;
                XTrans = (double)TmpProp.GetValue();
            }
            catch (Exception)
            {
                base.GenerateError("-X- cast didn't work");
                return base.FeedBackMessage;
            }
            _firstValue = base.ListProperties.FindByName("Y");
            double YTrans = 0;
            if (_firstValue == null)
            {
                base.GenerateError("-Y- not found !");
                return base.FeedBackMessage;
            }
            try
            {
                cProperty TmpProp = (cProperty)_firstValue;
                YTrans = (double)TmpProp.GetValue();
            }
            catch (Exception)
            {
                base.GenerateError("-Y- cast didn't work");
                return base.FeedBackMessage;
            }

            int i, j, k, cpt;
            float[] inData;
            float[] outData;

            base.Output = new cImage(base.Input, false);

            for (int band = 0; band < base.Input.GetNumChannels(); band++)
            {
                inData = base.Input.SingleChannelImage[band].Data;
                outData = base.Output.SingleChannelImage[band].Data;
                cpt = 0;

                for (k = 0; k < base.Output.Depth; k++)

                    for (j = 0; j < base.Output.Height; j++)
                    {
                        int newj = (int)(j - YTrans);
                        if (newj < 0) newj = 0;
                        else if (newj > base.Output.Height) newj = base.Output.Height - 1;

                        for (i = 0; i < base.Output.Width; i++, cpt++)
                        {
                            int newi = (int)(i - XTrans);
                            if (newi < 0) newi = 0;
                            else if (newi > base.Output.Width) newi = base.Output.Width - 1;

                            outData[cpt] = inData[newi + newj * base.Input.Width + k * base.Input.SliceSize()];
                        }
                    }

            }


            base.End();
            return FeedBackMessage;
        }

    }
}
