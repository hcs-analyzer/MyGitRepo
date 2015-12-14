using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Classes._3D;
using System.Drawing;
using HCSAnalyzer.Forms.FormsForImages;


namespace HCSAnalyzer.Classes.ImageAnalysis.FormsForImages
{
    public class cSelection
    {
        public Color Colour= Color.GreenYellow;
        cImagePanel AssociatedImagePanel = null;
        public Rectangle mRect;

        public cSelection(cImagePanel AssociatedImagePanel)
        {
            this.AssociatedImagePanel = AssociatedImagePanel;
        }

        public Point GetConvertedPosition_Top()
        {
            Point Top = new Point(mRect.Right, mRect.Bottom);
            return this.AssociatedImagePanel.ConvertPanelCoordToImageCoord(Top);
        
        }


        public Point GetConvertedPosition_Bottom()
        {
            Point Bottom = new Point(mRect.Left, mRect.Top);
            return this.AssociatedImagePanel.ConvertPanelCoordToImageCoord(Bottom);
        }

    }
}
