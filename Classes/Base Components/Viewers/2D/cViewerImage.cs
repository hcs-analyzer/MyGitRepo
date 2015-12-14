using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageAnalysis;
using HCSAnalyzer.Forms.FormsForImages;
using System.Windows.Forms;
using HCSAnalyzer.Classes.ImageAnalysis.FormsForImages;
using System.Drawing;

namespace HCSAnalyzer.Classes.Base_Classes.Viewers._2D
{
    public class cViewerImage : cDataDisplay
    {
        public cViewerImage()
        {
            Title = "Image Viewer";
        }

        cImage InputData = null;
        public cImagePanel ImagePanel;
        public bool IsDisplayScale = false;
        public bool IsUseSavedDefaultDisplayProperties = false;
        public int DefaultZoom = 0;  // 0 <=> automated
        public List<Color> ListLinearMaxColor = null; // if this list not null, the LUT will based on these colors as maximum values

        public void SetInputData(cImage Input)
        {
            this.InputData = Input;
        }

        public cFeedBackMessage Run()
        {
            base.CurrentPanel = new DataStructures.cExtendedControl();

            ImagePanel = new cImagePanel();
            // IP.Unsafe_SetAssociatedImage(this.InputData);

            this.InputData.AssociatedImagePanel = ImagePanel;

            ImagePanel.Unsafe_SetAssociatedImage(this.InputData);

            if (this.DefaultZoom != 0)
                ImagePanel.DefaultZoom = this.DefaultZoom;

            cImage Image = this.InputData;
            ImagePanel.Text = Image + " - [" + Image.Width + "x" + Image.Height + "x" + Image.Depth + "]" + " - " + Image.GetNumChannels() + " channels"; ;
            ImagePanel.LUTManager = new FormForLUTManager(ImagePanel);
            ImagePanel.ZNavigator = new Classes.ImageAnalysis.FormsForImages.FormForNavigator(ImagePanel);

            //List<byte[][]> ListLUTs = new List<byte[][]>();
            //   cLUT LUT = new cLUT();

            //   if (Image.GetNumChannels() == 1)
            //   {
            //       ListLUTs.Add(LUT.LUT_LINEAR);
            //   }
            //   else if (Image.GetNumChannels() == 2)
            //   {
            //       ListLUTs.Add(LUT.LUT_LINEAR_RED);
            //       ListLUTs.Add(LUT.LUT_LINEAR_GREEN);
            //   }
            //   else if (Image.GetNumChannels() == 3)
            //   {
            //       ListLUTs.Add(LUT.LUT_LINEAR_RED);
            //       ListLUTs.Add(LUT.LUT_LINEAR_GREEN);
            //       ListLUTs.Add(LUT.LUT_LINEAR_BLUE);
            //   }
            //   else
            //   {
            //       ListLUTs.Add(LUT.LUT_LINEAR_RED);
            //       ListLUTs.Add(LUT.LUT_LINEAR_GREEN);
            //       ListLUTs.Add(LUT.LUT_LINEAR_BLUE);
            //       for (int i = 0; i < Image.GetNumChannels() - 3; i++)
            //       {
            //           ListLUTs.Add(LUT.LUT_LINEAR);
            //       }
            //   }

            for (int IdxLUT = 0; IdxLUT < Image.GetNumChannels(); IdxLUT++)
            {
                if (Image.SingleChannelImage[IdxLUT].Name == "Single Channel Image")
                    Image.SingleChannelImage[IdxLUT].Name = "Channel " + IdxLUT;
                UserControlSingleLUT SingleLUT = new UserControlSingleLUT(ImagePanel, Image.SingleChannelImage[IdxLUT], IdxLUT);
                SingleLUT.textBoxForName.Text = Image.SingleChannelImage[IdxLUT].Name;
                SingleLUT.Location = new System.Drawing.Point(0, IdxLUT * SingleLUT.Height);

                if((this.ListLinearMaxColor!=null)&&(this.ListLinearMaxColor.Count>IdxLUT))
                   SingleLUT.CreateAndUpDateLinearLUT(this.ListLinearMaxColor[IdxLUT]);

                ImagePanel.LUTManager.panelForLUTS.Controls.Add(SingleLUT);
            }

            if ((cGlobalInfo.TmpImageDisplayProperties != null) && (cGlobalInfo.TmpImageDisplayProperties.ListLUTNames.Count == Image.GetNumChannels())
                && this.IsUseSavedDefaultDisplayProperties)
            {
                ImagePanel.LUTManager.PastFromClipBoard();
            }

            ImagePanel.Width = ImagePanel.Height = 0;
            base.CurrentPanel.Controls.Add(ImagePanel);
            base.CurrentPanel.Width = base.CurrentPanel.Height = 0;
            base.CurrentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
            base.CurrentPanel.Width = base.CurrentPanel.Height = 0;

            base.CurrentPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(ImagePanel.panelForImage_MouseWheel);
            //base.CurrentPanel.Paint +=new PaintEventHandler(IP.panelForImage_Paint);
            //this.CurrentPanel.Paint += new System.Windows.Forms.PaintEventHandler(IP.panelForImage_Paint);
            //this.CurrentPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(IP.panelForImage_MouseDoubleClick);
            //this.CurrentPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(IP.panelForImage_MouseDown);
            //this.CurrentPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(IP.panelForImage_MouseMove);
            //  this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panelForImage_MouseWheel);
            // this.CurrentPanel.Resize += new EventHandler(IP.panelForImage_Resize);
            this.CurrentPanel.Disposed += new EventHandler(ImagePanel.FormForImageDisplay_Disposed);

          //  this.CurrentPanel.MouseDown += new MouseEventHandler(CurrentPanel_MouseDown);
            this.CurrentPanel.DragDrop += new DragEventHandler(ImagePanel.CurrentPanel_DragDrop);
            this.CurrentPanel.DragEnter += new DragEventHandler(ImagePanel.CurrentPanel_DragEnter);
            this.CurrentPanel.AllowDrop = true;
        
            ImagePanel._ToolStripMenuItemDisplayScale.Checked = IsDisplayScale;
           // ImagePanel.ZoomToFit(2);
          //  ImagePanel.Width = ImagePanel.Height = 100;

            return base.FeedBackMessage;
        }

        //void CurrentPanel_MouseDown(object sender, MouseEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}



    }
}
