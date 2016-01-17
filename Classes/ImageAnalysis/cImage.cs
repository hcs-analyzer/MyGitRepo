using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCSAnalyzer.Forms.FormsForImages;
using System.Drawing;
using HCSAnalyzer.Classes;
using HCSAnalyzer.Classes.Base_Classes.DataStructures;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using HCSAnalyzer.Classes.Base_Classes.DataAnalysis;
using HCSAnalyzer.Classes.Base_Classes.Viewers;
using HCSAnalyzer.Classes.Base_Classes.DataProcessing;
using HCSAnalyzer.Classes.MetaComponents;
using HCSAnalyzer;
using Kitware.VTK;
using HCSAnalyzer.Classes.ImageAnalysis._3D_Engine;
using HCSAnalyzer.Classes._3D;
using System.IO;
using System.Net;
using HCSAnalyzer.Classes.ImageAnalysis.FormsForImages;
using HCSAnalyzer.Classes.General_Types;

namespace ImageAnalysis
{
    public partial class cImage : IDisposable
    {

        public cImagePanel AssociatedImagePanel = null;
        public string OriginalPath = "";
        public cListSingleChannelImage SingleChannelImage = new cListSingleChannelImage();
        //  public float[][] Data {get; private set;}
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Depth { get; private set; }


        public void Dispose()
        {
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            SingleChannelImage.Dispose();
            GC.SuppressFinalize(this);
            GC.Collect();
        }




        public int GetNumChannels()
        {
            return this.SingleChannelImage.Count;
        }

        public int SliceSize() { return this.Width * this.Height; }
        public int ImageSize()   { return this.Width*this.Height*this.Depth; }
        public string Name = "New Image";
        public object Tag;
        public cPoint3D Resolution = new cPoint3D(1, 1, 1);

        //public double XResolution = 1;
        //public double YResolution = 1;
        //public double ZResolution = 1;
        public cPoint3D Position = new cPoint3D(0, 0, 0);

        public cExtendedTable GetPropertyTable()
        {
            cExtendedTable ToReturn = new cExtendedTable();
            ToReturn.Name = this.Name + " - Properties";

            cExtendedList Properties = new cExtendedList("Properties");

            ToReturn.Add(Properties);
            ToReturn.ListRowNames = new List<string>();


            ToReturn.ListRowNames.Add("Dimension X");
            Properties.Add(this.Width);
            ToReturn.ListRowNames.Add("Dimension Y");
            Properties.Add(this.Height);
            ToReturn.ListRowNames.Add("Dimension Z");
            Properties.Add(this.Depth);

            ToReturn.ListRowNames.Add("Voxel Size X");
            Properties.Add(this.Resolution.X);
            ToReturn.ListRowNames.Add("Voxel Size Y");
            Properties.Add(this.Resolution.Y);
            ToReturn.ListRowNames.Add("Voxel Size Z");
            Properties.Add(this.Resolution.Z);

            ToReturn.ListRowNames.Add("Position X");
            Properties.Add(this.Position.X);
            ToReturn.ListRowNames.Add("Position Y");
            Properties.Add(this.Position.Y);
            ToReturn.ListRowNames.Add("Position Z");
            Properties.Add(this.Position.Z);


            ToReturn.ListRowNames.Add("Channel Numbers");
            Properties.Add(this.GetNumChannels());

            for (int i = 0; i < this.GetNumChannels(); i++)
            {
                ToReturn.ListRowNames.Add(this.SingleChannelImage[i].Name + " - Wavelenght");
                Properties.Add(i);
            }



            return ToReturn;

        }

        /// <summary>
        /// Build a BITMAP from a cImage
        /// </summary>
        /// <param name="ZoomFactor"></param>
        /// <param name="ListMin">Minimum values for each band (if NULL then automatically computed)</param>
        /// <param name="ListMax">Maximum values for each band (if NULL then automatically computed)</param>
        /// <param name="ListLUTs">use  cLUT ListLUT = new cLUT() to build your LUT</param>
        /// <returns></returns>
        public Bitmap GetBitmap(float ZoomFactor, cImageDisplayProperties ImageDisplayProperties, List<byte[][]> ListLUTs)
        {

            if ((this.Width == 0) || (this.Height == 0)) return null;

            if (ListLUTs == null)
            {
                ListLUTs = new List<byte[][]>();
                cLUT LUT = new cLUT();

                if (this.GetNumChannels() == 1)
                {
                    ListLUTs.Add(LUT.LUT_LINEAR);
                }
                else if (this.GetNumChannels() == 2)
                {
                    ListLUTs.Add(LUT.LUT_LINEAR_RED);
                    ListLUTs.Add(LUT.LUT_LINEAR_GREEN);
                }
                else if (this.GetNumChannels() == 3)
                {
                    ListLUTs.Add(LUT.LUT_LINEAR_RED);
                    ListLUTs.Add(LUT.LUT_LINEAR_GREEN);
                    ListLUTs.Add(LUT.LUT_LINEAR_BLUE);
                }
                else
                {
                    ListLUTs.Add(LUT.LUT_LINEAR_RED);
                    ListLUTs.Add(LUT.LUT_LINEAR_GREEN);
                    ListLUTs.Add(LUT.LUT_LINEAR_BLUE);
                    for (int i = 0; i < this.GetNumChannels() - 3; i++)
                    {
                        ListLUTs.Add(LUT.LUT_LINEAR);
                    }
                }
            }

            List<double> ListMax = new List<double>();
            List<double> ListMin = new List<double>();

            if (ImageDisplayProperties != null)
            {
                if (ImageDisplayProperties.ListMax == null)
                {
                    for (int i = 0; i < this.GetNumChannels(); i++)
                    {
                        this.SingleChannelImage[i].UpDateMax();
                        ListMax.Add(this.SingleChannelImage[i].Max);
                    }
                }
                else
                    ListMax = ImageDisplayProperties.ListMax;

                if (ImageDisplayProperties.ListMin == null)
                {
                    for (int i = 0; i < this.GetNumChannels(); i++)
                    {
                        this.SingleChannelImage[i].UpDateMin();
                        ListMin.Add(this.SingleChannelImage[i].Min);
                    }
                }
                else
                    ListMin = ImageDisplayProperties.ListMin;

            }
            else
            {
                for (int i = 0; i < this.GetNumChannels(); i++)
                {
                    this.SingleChannelImage[i].UpDateMax();
                    ListMax.Add(this.SingleChannelImage[i].Max);
                }

                for (int i = 0; i < this.GetNumChannels(); i++)
                {
                    this.SingleChannelImage[i].UpDateMin();
                    ListMin.Add(this.SingleChannelImage[i].Min);
                }

            }

            List<bool> ListActive = null;

            if ((ImageDisplayProperties == null) || (ImageDisplayProperties.ListActive == null))
            {
                ListActive = new List<bool>();
                for (int i = 0; i < this.GetNumChannels(); i++)
                {
                    ListActive.Add(true);
                }
            }
            else
                ListActive = ImageDisplayProperties.ListActive;

            int NewWidth = (int)(this.Width * ZoomFactor);
            int NewHeight = (int)(this.Height * ZoomFactor);

            Bitmap BMPToBeReturned = new Bitmap(NewWidth, NewHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, NewWidth, NewHeight);
            System.Drawing.Imaging.BitmapData bmpData = BMPToBeReturned.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, BMPToBeReturned.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            int scanline = Math.Abs(bmpData.Stride);

            int bytes = scanline * NewHeight;
            byte[] rgbValues = new byte[bytes];

            byte CurrentRed;
            byte CurrentGreen;
            byte CurrentBlue;

            int RealX;
            int RealY;

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int IdxChannel = 0; IdxChannel < this.GetNumChannels(); IdxChannel++)
            {
                if (!ListActive[IdxChannel]) continue;
                byte[][] CurrentLUT = ListLUTs[IdxChannel];

                for (int FullY = 0; FullY < NewHeight; FullY++)
                {
                    RealY = (int)(FullY / ZoomFactor);
                    if (RealY >= this.Height) RealY = this.Height - 1;

                    for (int FullX = 0; FullX < NewWidth; FullX++)
                    {
                        RealX = (int)(FullX / ZoomFactor);
                        if (RealX >= this.Width) RealX = this.Width - 1;

                        float Value = this.SingleChannelImage[IdxChannel].Data[RealX + RealY * this.Width];

                        int ConvertedValue = (int)((((CurrentLUT[0].Length - 1) * (Value - ListMin[IdxChannel]))
                                                    / (ListMax[IdxChannel] - ListMin[IdxChannel])));

                        if (ConvertedValue < 0) ConvertedValue = 0;
                        if (ConvertedValue >= CurrentLUT[0].Length) ConvertedValue = CurrentLUT[0].Length - 1;

                        CurrentRed = (byte)CurrentLUT[0][ConvertedValue];
                        CurrentGreen = (byte)CurrentLUT[1][ConvertedValue];
                        CurrentBlue = (byte)CurrentLUT[2][ConvertedValue];

                        double NewValue = rgbValues[3 * FullX + FullY * scanline] + CurrentBlue;
                        if (NewValue > 255)
                            rgbValues[3 * FullX + FullY * scanline] = 255;
                        else
                            rgbValues[3 * FullX + FullY * scanline] += CurrentBlue;

                        NewValue = rgbValues[3 * FullX + 1 + FullY * scanline] + CurrentGreen;
                        if (NewValue > 255)
                            rgbValues[3 * FullX + 1 + FullY * scanline] = 255;
                        else
                            rgbValues[3 * FullX + 1 + FullY * scanline] += CurrentGreen;

                        NewValue = rgbValues[3 * FullX + 2 + FullY * scanline] + CurrentRed;
                        if (NewValue > 255)
                            rgbValues[3 * FullX + 2 + FullY * scanline] = 255;
                        else
                            rgbValues[3 * FullX + 2 + FullY * scanline] += CurrentRed;
                    }
                }
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            BMPToBeReturned.UnlockBits(bmpData);

            return BMPToBeReturned;
        }

        #region Constructors
        private cImage()
        {
            //SliceSize = this.Width * this.Height;
            //ImageSize = SliceSize * Depth;
        }

        public cImage(int Width, int Height, int Depth, int NumChannels)
        {
            //this.NumChannels = NumChannels;
            this.Width = Width;
            this.Height = Height;
            this.Depth = Depth;
            //this.SliceSize = this.Height * this.Width;
            //this.ImageSize = SliceSize * Depth;
            this.SingleChannelImage = new cListSingleChannelImage();

            for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
            {
                this.SingleChannelImage.Add(new cSingleChannelImage(Width, Height, Depth, new cPoint3D(this.Resolution)));
                this.SingleChannelImage[this.SingleChannelImage.Count - 1].Name = "Channel " + IdxChannel;
            }
        }

        public cImage(Image<Gray, float> CVImage)
        {
            //this.output = new cImage(this.input);
            this.Width = CVImage.Width;
            this.Height = CVImage.Height;
            //this.SliceSize = this.Height * this.Width;
            //this.ImageSize = SliceSize * Depth;

            this.SingleChannelImage = new cListSingleChannelImage();
            //for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
            this.SingleChannelImage.Add(new cSingleChannelImage(Width, Height, 1, new cPoint3D(1, 1, 1)));

            for (int j = 0; j < CVImage.Height; j++)
                for (int i = 0; i < CVImage.Width; i++)
                    this.SingleChannelImage[0].Data[i + j * this.Width] = CVImage.Data[j, i, 0];

            // this.NumChannels = 1;
        }

        public cImage(Image<Gray, byte> CVImage)
        {
            //this.output = new cImage(this.input);
            this.Width = CVImage.Width;
            this.Height = CVImage.Height;
            //this.SliceSize = this.Height * this.Width;
            //this.ImageSize = SliceSize * Depth;

            this.SingleChannelImage = new cListSingleChannelImage();
            //for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
            this.SingleChannelImage.Add(new cSingleChannelImage(Width, Height, 1, new cPoint3D(1, 1, 1)));

            for (int j = 0; j < CVImage.Height; j++)
                for (int i = 0; i < CVImage.Width; i++)
                    this.SingleChannelImage[0].Data[i + j * this.Width] = CVImage.Data[j, i, 0];

            //this.NumChannels = 1;
        }

        public cImage(cImage Source, bool IsCopyData)
        {
            //Source.GetNumChannels();
            this.Width = Source.Width;
            this.Height = Source.Height;
            this.Depth = Source.Depth;
            //this.SliceSize = this.Height * this.Width;
            //this.ImageSize = SliceSize * Depth;
            this.Resolution = new cPoint3D(Source.Resolution);

            this.SingleChannelImage = new cListSingleChannelImage();
            for (int IdxChannel = 0; IdxChannel < Source.GetNumChannels(); IdxChannel++)
            {
                this.SingleChannelImage.Add(new cSingleChannelImage(Source.Width, Source.Height, Source.Depth, new cPoint3D(Source.Resolution)));
                this.SingleChannelImage[IdxChannel].Name = Source.SingleChannelImage[IdxChannel].Name;
                this.SingleChannelImage[IdxChannel].Data = new float[Source.SingleChannelImage[IdxChannel].Data.Length];

                if (IsCopyData)
                    Array.Copy(Source.SingleChannelImage[IdxChannel].Data, this.SingleChannelImage[IdxChannel].Data, Source.SingleChannelImage[IdxChannel].Data.Length);
            }
        }

        public cImage(cSingleChannelImage Source, bool CopyData)
        {
            // this.NumChannels = 1;
            this.Width = Source.Width;
            this.Height = Source.Height;
            this.Depth = Source.Depth;
            this.Resolution = new cPoint3D(Source.Resolution);

            //this.SliceSize = this.Height * this.Width;
            //this.ImageSize = SliceSize * Depth;

            if (CopyData == true)
            {
                this.SingleChannelImage = new cListSingleChannelImage();

                this.SingleChannelImage.Add(new cSingleChannelImage(Source.Width, Source.Height, Source.Depth, Source.Resolution));
                this.SingleChannelImage[0].Name = Source.Name;
                this.SingleChannelImage[0].Data = new float[Source.Data.Length];

                Array.Copy(Source.Data, this.SingleChannelImage[0].Data, Source.Data.Length);
            }
            else
            {
                this.SingleChannelImage.Add(Source);
            }

            this.Name = Source.Name;
        }

        public cImage(cListExtendedTable ListSources)
        {
            this.BuildFromListTable(ListSources);
        }

        public cImage(cExtendedTable Source)
        {
            this.BuildFromListTable(new cListExtendedTable(Source));
        }

        public cImage(OpenFileDialog DRes)
        {
            List<cImageMetaInfo> ListMetaInfo = new List<cImageMetaInfo>();
            cImageMetaInfo Meta = new cImageMetaInfo();
            Meta.FileName = DRes.FileName;
            ListMetaInfo.Add(Meta);
            LoadFromPath(ListMetaInfo);
        }


        public cImage(string fileName)
        {
            List<cImageMetaInfo> ListMetaInfo = new List<cImageMetaInfo>();
            cImageMetaInfo Meta = new cImageMetaInfo();
            Meta.FileName = fileName;
            ListMetaInfo.Add(Meta);
            LoadFromPath(ListMetaInfo);
        }




        public cImage(List<cImageMetaInfo> ListImageMetaInfo)
        {
            LoadFromPath(ListImageMetaInfo);
        }

        public List<int> GetListChannels()
        {
            List<int> ToBeReturned = new List<int>();

            for (int Band = 0; Band < this.SingleChannelImage.Count; Band++)
                ToBeReturned.Add(Band);

            return ToBeReturned;
        }

        void BuildFromListTable(cListExtendedTable ListSources)
        {
            if (ListSources.Count == 0) return;
            if (ListSources[0].Count == 0) return;
            if (ListSources[0][0].Count == 0) return;

            //this.NumChannels = ListSources.Count;
            this.Width = ListSources[0].Count;
            this.Height = ListSources[0][0].Count;
            this.Depth = 1;
         //   this.SliceSize = this.Height * this.Width;

            this.SingleChannelImage = new cListSingleChannelImage();
            for (int IdxChannel = 0; IdxChannel < ListSources.Count; IdxChannel++)
            {
                this.SingleChannelImage.Add(new cSingleChannelImage(this.Width, this.Height, 1, new cPoint3D(1, 1, 1)));

                for (int i = 0; i < this.Width; i++)
                    for (int j = 0; j < this.Height; j++)
                    {
                        this.SingleChannelImage[IdxChannel].Data[i + j * this.Width] = (float)ListSources[IdxChannel][i][j];
                    }
            }
            this.Name = ListSources.Name;
        }

        public void CopyInto(cImage SubImage, int Dest_PosX, int Dest_PosY, int Dest_PosZ, int Dest_Channel)
        {
            if (SubImage.GetNumChannels() > 1) return;

            for (int Z = 0; Z < SubImage.Depth; Z++)
            {
                int OriginalPosZ = Dest_PosZ + Z;
                if ((OriginalPosZ < 0) || (OriginalPosZ > this.Depth - 1)) continue;

                for (int Y = 0; Y < SubImage.Height; Y++)
                {
                    int OriginalPosY = Dest_PosY + Y;
                    if ((OriginalPosY < 0) || (OriginalPosY > this.Height - 1)) continue;

                    for (int X = 0; X < SubImage.Width; X++)
                    {
                        int OriginalPosX = Dest_PosX + X;
                        if ((OriginalPosX < 0) || (OriginalPosX > this.Width - 1)) continue;

                        this.SingleChannelImage[Dest_Channel].Data[OriginalPosX + OriginalPosY * this.Width + OriginalPosZ * this.SliceSize()] = SubImage.SingleChannelImage[0].Data[X + Y * SubImage.Width + Z * SubImage.SliceSize()];
                    }
                }
            }
        }

        public cImage Crop(cPoint3D StartingPoint, cPoint3D EndingPoint)
        {
            int RealXStartPt = (int)StartingPoint.X;
            if (RealXStartPt < 0) RealXStartPt = 0;
            else if (RealXStartPt >= this.Width) RealXStartPt = this.Width - 1;

            int RealXEndPt = (int)EndingPoint.X;
            if (RealXEndPt < 0) RealXEndPt = 0;
            else if (RealXEndPt >= this.Width) RealXEndPt = this.Width - 1;

            int RealYStartPt = (int)StartingPoint.Y;
            if (RealYStartPt < 0) RealYStartPt = 0;
            else if (RealYStartPt >= this.Height) RealYStartPt = this.Height - 1;

            int RealYEndPt = (int)EndingPoint.Y;
            if (RealYEndPt < 0) RealYEndPt = 0;
            else if (RealYEndPt >= this.Height) RealYEndPt = this.Height - 1;

            int RealZStartPt = (int)StartingPoint.Z;
            if (RealZStartPt < 0) RealZStartPt = 0;
            else if (RealZStartPt >= this.Depth) RealZStartPt = this.Depth - 1;

            int RealZEndPt = (int)EndingPoint.Z;
            if (RealZEndPt < 0) RealZEndPt = 0;
            else if (RealZEndPt >= this.Depth) RealZEndPt = this.Depth - 1;

            cImage CroppedImage = new cImage((int)(RealXEndPt - RealXStartPt + 1),
                                            (int)(RealYEndPt - RealYStartPt + 1),
                                            (int)(EndingPoint.Z - StartingPoint.Z + 1),
                                            this.GetNumChannels());

            CroppedImage.Resolution = new cPoint3D(this.Resolution);

            int RealPosZ;
            int RealPosY;
            int RealPosX;

            for (int Channel = 0; Channel < this.GetNumChannels(); Channel++)
            {
                for (int z = (int)RealZStartPt; z <= (int)RealZEndPt; z++)
                {
                    RealPosZ = (int)(z - RealZStartPt);
                    for (int y = (int)RealYStartPt; y <= (int)RealYEndPt; y++)
                    {
                        RealPosY = (int)(y - RealYStartPt);
                        for (int x = (int)RealXStartPt; x <= (int)RealXEndPt; x++)
                        {
                            RealPosX = (int)(x - RealXStartPt);
                            CroppedImage.SingleChannelImage[Channel].Data[RealPosX + RealPosY * CroppedImage.Width + RealPosZ * CroppedImage.SliceSize()] =
                               this.SingleChannelImage[Channel].Data[x + y * this.Width + z * this.SliceSize()];
                        }
                    }
                }
                CroppedImage.SingleChannelImage[Channel].Resolution = new cPoint3D(this.Resolution);
              //  CroppedImage.SingleChannelImage[Channel].UpDateMin();
              //  CroppedImage.SingleChannelImage[Channel].UpDateMax();
            }
            //   CroppedImage.Resolution = new cPoint3D(this.Resolution);

            CroppedImage.Name = "Crop(" + this.Name + ")";
            
            return CroppedImage;
        }

        public void AddInto(cImage SubImage, int Dest_PosX, int Dest_PosY, int Dest_PosZ, int Dest_Channel)
        {
            if (SubImage.GetNumChannels() > 1) return;

            for (int Z = 0; Z < SubImage.Depth; Z++)
            {
                int OriginalPosZ = Dest_PosZ + Z;
                if ((OriginalPosZ < 0) || (OriginalPosZ > this.Depth - 1)) continue;

                for (int Y = 0; Y < SubImage.Height; Y++)
                {
                    int OriginalPosY = Dest_PosY + Y;
                    if ((OriginalPosY < 0) || (OriginalPosY > this.Height - 1)) continue;

                    for (int X = 0; X < SubImage.Width; X++)
                    {
                        int OriginalPosX = Dest_PosX + X;
                        if ((OriginalPosX < 0) || (OriginalPosX > this.Width - 1)) continue;

                        this.SingleChannelImage[Dest_Channel].Data[OriginalPosX + OriginalPosY * this.Width + OriginalPosZ * this.SliceSize()] += SubImage.SingleChannelImage[0].Data[X + Y * SubImage.Width + Z * SubImage.SliceSize()];
                    }
                }
            }
        }

        void LoadFromPath(/*string Path, string FileName*/List<cImageMetaInfo> ListImageMetaInfo)
        {
            if (ListImageMetaInfo == null) return;
            int ChannelStart = 0;

            for (int IdxName = 0; IdxName < ListImageMetaInfo.Count; IdxName++)
            {
                string CurrentName = ListImageMetaInfo[IdxName].FileName;

                if (CurrentName == "") continue;
                if (CurrentName.Contains("http://"))
                {
                    try
                    {
                        using (WebClient Client = new WebClient())
                        {
                            string[] ListForExt = CurrentName.Split('.');
                            Client.DownloadFile(CurrentName, "Tmp." + ListForExt[ListForExt.Length - 1]);
                            CurrentName = "Tmp." + ListForExt[ListForExt.Length - 1];
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }

                if ((File.Exists(CurrentName) == false)) continue;

                // check if the image is buffered
                string[] ListSplits = CurrentName.Split('.');
                string Extension = ListSplits[ListSplits.Length - 1].ToLower();

                byte[] rgbValues = null;

                int NumBytePerPixel = 0;
                int NumBitsPerPixel = 0;
                int NumChannels = 0;
                object ResMeta = null;

                if (IdxName == 0)
                    this.SingleChannelImage = new cListSingleChannelImage();

                //for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                //{
                //    cSingleChannelImage TmpChannel = new cSingleChannelImage(this.Width, this.Height, this.Depth, new cPoint3D(1, 1, 1));
                //    this.SingleChannelImage.Add(TmpChannel);
                //}



                // first.. check if the image is already in memory
                if ((cGlobalInfo.BufferedImage != null) && (cGlobalInfo.BufferedImage.SingleChannelImage.Count >0) && (cGlobalInfo.BufferedImage.SingleChannelImage[0].Data != null))
                {
                    cImage TmpIm = cGlobalInfo.BufferedImage;

                    if (cGlobalInfo.BufferedImage.OriginalPath == CurrentName)    // the image is here: no need for loading
                    {
                        for (int IdxChannel = 0; IdxChannel < cGlobalInfo.BufferedImage.GetNumChannels(); IdxChannel++)
                        {
                            //cGlobalInfo.BufferedImage.SingleChannelImage
                            this.SingleChannelImage.Add(new cSingleChannelImage(TmpIm.SingleChannelImage[IdxChannel]));
                        }
                        this.Width = TmpIm.Width;
                        this.Height = TmpIm.Height;
                        this.Depth = TmpIm.Depth;
                        this.Resolution = new cPoint3D(TmpIm.Resolution);
                        this.OriginalPath = CurrentName;
                        this.Name = CurrentName;
                        cGlobalInfo.BufferedImage.Dispose();
                        cGlobalInfo.BufferedImage = this;
                        return;
                    }
                }


                this.OriginalPath = CurrentName;


                switch (Extension)
                {
                    #region Cellomics c01 - BioFormats
                    case "c01":
                        loci.formats.@in.CellomicsReader MyCellomicsReader = new loci.formats.@in.CellomicsReader();

                        loci.formats.ChannelFiller a = new loci.formats.ChannelFiller();
                        a.setId(CurrentName);
                    //    a.setId(CurrentName);

                    //    byte[] a = MyCellomicsReader.openBytes(0);
                        MyCellomicsReader.setId(CurrentName);

                        int SerieCurr = -1;
                        int NumSeries =  MyCellomicsReader.getSeriesUsedFiles().Count();
                        for (int IdxSerie = 0; IdxSerie <NumSeries; IdxSerie++)
                        {

                            if (MyCellomicsReader.getSeriesUsedFiles()[IdxSerie] == CurrentName)
                            {
                                SerieCurr = IdxSerie;
                                break;
                            }
                        }

                        MyCellomicsReader.setSeries(SerieCurr);
                        rgbValues = MyCellomicsReader.openBytes(0);
                        //int ImC = MyCellomicsReader.getImageCount();

                        this.Width = MyCellomicsReader.getSizeX();

                        //                     ImageProcessorReader r = new ImageProcessorReader(
                        //new ChannelSeparator(LociPrefs.makeImageReader()));


                        this.Height = MyCellomicsReader.getSizeY();
                        this.Depth = MyCellomicsReader.getSizeZ();
                        NumChannels = MyCellomicsReader.getSizeC();
                        NumBitsPerPixel = MyCellomicsReader.getBitsPerPixel();
                        MyCellomicsReader.close();
                        break;
                    #endregion
                    #region tiff - tif - LibTiff
                    case "tiff" :
                    case "tif":
                        BitMiracle.LibTiff.Classic.Tiff image = BitMiracle.LibTiff.Classic.Tiff.Open(CurrentName, "r");

                        if (image == null) return;
                        
                        this.Depth = image.NumberOfDirectories();

                        BitMiracle.LibTiff.Classic.FieldValue[] value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.IMAGELENGTH);
                        this.Height = value[0].ToInt();

                        value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.IMAGEWIDTH);
                        this.Width = value[0].ToInt();

                        this.Resolution.X = 1;
                        value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.XRESOLUTION);
                        if (value!=null) this.Resolution.X = value[0].ToFloat();
                        this.Resolution.Y = 1;
                        value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.YRESOLUTION);
                        if (value != null) this.Resolution.Y = value[0].ToFloat();

                        this.Resolution.Z = 1;

                        value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.PHOTOMETRIC);
                        NumChannels = 1;

                        #region RGB
                        if (value[0].ToString() == "RGB")
                        {
                            NumChannels = 3;
                            for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                            {
                                cSingleChannelImage TmpChannel = new cSingleChannelImage(this.Width, this.Height, this.Depth, new cPoint3D(1, 1, 1));
                                this.SingleChannelImage.Add(TmpChannel);
                            }

                            int[] raster = new int[this.Height * this.Width];

                            value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.ORIENTATION);

                            if (image.ReadRGBAImage(this.Width, this.Height, raster))
                            {
                                if (value[0].ToString() == "TOPLEFT")
                                {
                                    for (int j = 0; j < this.Height; j++)
                                    {
                                        for (int i = 0; i < this.Width; i++)
                                        {
                                            this.SingleChannelImage[0].Data[i + (this.Height - j - 1) * this.Width] = (raster[i + j * this.Width] & 0x000000FF) >> 00;
                                            this.SingleChannelImage[1].Data[i + (this.Height - j - 1) * this.Width] = (raster[i + j * this.Width] & 0x0000FF00) >> 8;
                                            this.SingleChannelImage[2].Data[i + (this.Height - j - 1) * this.Width] = (raster[i + j * this.Width] & 0x00FF0000) >> 16;
                                        }
                                    }
                                }
                                else
                                {
                                    for (int j = 0; j < this.Height; j++)
                                    {
                                        for (int i = 0; i < this.Width; i++)
                                        {
                                            this.SingleChannelImage[0].Data[i + j * this.Width] = (raster[i + j * this.Width] & 0x000000FF) >> 00;
                                            this.SingleChannelImage[1].Data[i + j * this.Width] = (raster[i + j * this.Width] & 0x0000FF00) >> 8;
                                            this.SingleChannelImage[2].Data[i + j * this.Width] = (raster[i + j * this.Width] & 0x00FF0000) >> 16;
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                        #region Palette
                        else if (value[0].ToString() == "PALETTE")
                        {
                            return;

                            this.Depth = 10;
                         
                               
                          
                            for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                            {
                                cSingleChannelImage TmpChannel = new cSingleChannelImage(this.Width, this.Height, this.Depth, new cPoint3D(1, 1, 1));
                                this.SingleChannelImage.Add(TmpChannel);
                            }

                            value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.BITSPERSAMPLE);
                            int BitPerSample = value[0].ToInt();
                            int BytePerSample = BitPerSample >> 3;
                            int ScanLineSize = image.ScanlineSize();

                            int TagCount = image.GetTagListCount();
                            byte[] buf = new byte[ScanLineSize];
                            value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.ORIENTATION);
                            for (int z = 0; z < 10; z++)
                            {

                                image.ReadDirectory();
                                for (int row = 0; row < this.Height; row++)
                                {
                                    image.ReadScanline(buf, row);
                                    if (BitPerSample == 8)
                                    {
                                        for (int i = 0; i < this.Width; i++)
                                            this.SingleChannelImage[0].Data[z* this.Width* this.Height + i + row * this.Width] = buf[i];
                                    }
                                    else if (BitPerSample == 16)
                                    {
                                        for (int i = 0; i < this.Width; i++)
                                            this.SingleChannelImage[0].Data[i + row * this.Width] = (buf[2 * i]) + (buf[2 * i + 1] << 8);
                                    }
                                }
                            }

                            image.Close(); // or image.Dispose();
                            cGlobalInfo.BufferedImage = this;
                            return;

                            // TODO: TIFF Palette mode not impletemented yet


                            //  value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.IMAGEDEPTH);
                            //  int ImageDepth = 1;
                            //  if (value!=null) 
                            //      ImageDepth = value[0].ToInt();

                            //  Im = new cImage(this.Width, this.Height, 1, 1);// image.StripSize(), 1);
                            //                                                 //   value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.PLANARCONFIG);
                            //                                                 //   BitMiracle.LibTiff.Classic.PlanarConfig config = (BitMiracle.LibTiff.Classic.PlanarConfig)value[0].ToInt();

                            //  value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.BITSPERSAMPLE);

                            //  //  value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.PAGENUMBER);
                            ////  value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.SAMPLESPERPIXEL);

                            ////  value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.COLORMAP);
                            //  int BitPerSample = value[0].ToInt();
                            //  int BytePerSample = BitPerSample >> 3;
                            //  int ScanLineSize = image.ScanlineSize();

                            //  int TagCount = image.GetTagListCount();
                            //  byte[] buf = new byte[ScanLineSize];

                            //  for (int row = 0; row < this.Height; row++)
                            //  {
                            //      image.ReadScanline(buf, row);
                            //      if (BitPerSample == 8)
                            //      {
                            //          for (int i = 0; i < this.Width; i++)
                            //              Im.SingleChannelImage[0].Data[i + row * this.Width] = buf[i];
                            //      }
                            //      else if (BitPerSample == 16)
                            //      {
                            //          for (int i = 0; i < this.Width; i++)
                            //              Im.SingleChannelImage[0].Data[i + row * this.Width] = (buf[2 * i]) + (buf[2 * i + 1] << 8);
                            //      }
                            //  }




                        }
                        #endregion
                        #region regular
                        else
                        {

                            for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                            {
                                cSingleChannelImage TmpChannel = new cSingleChannelImage(this.Width, this.Height, this.Depth, new cPoint3D(1, 1, 1));
                                this.SingleChannelImage.Add(TmpChannel);
                            }


                            value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.BITSPERSAMPLE);
                            int BitPerSample = value[0].ToInt();
                            int BytePerSample = BitPerSample >> 3;
                            int ScanLineSize = image.ScanlineSize();

                            int TagCount = image.GetTagListCount();

                            //value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag);

                            // value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.IMAGEDEPTH);
                            // byte[] buf = new byte[image.StripSize()];
                            // for (int strip = 0; strip < image.NumberOfStrips(); strip++)
                            //     image.ReadEncodedStrip(strip, buf, 0, -1);

                            byte[] buf = new byte[ScanLineSize];

                            value = image.GetField(BitMiracle.LibTiff.Classic.TiffTag.ORIENTATION);

                            if ((value != null) && (value[0].ToString() == "TOPLEFT"))
                            {
                                for (int row = 0; row < this.Height; row++)
                                {
                                    image.ReadScanline(buf, row);
                                    if (BitPerSample == 8)
                                    {
                                        for (int i = 0; i < this.Width; i++)
                                            this.SingleChannelImage[0].Data[i + (this.Height - row - 1) * this.Width] = buf[i];
                                    }
                                    else if (BitPerSample == 16)
                                    {
                                        for (int i = 0; i < this.Width; i++)
                                            this.SingleChannelImage[0].Data[i + (this.Height - row - 1) * this.Width] = (buf[2 * i]) + (buf[2 * i + 1] << 8);
                                    }
                                }

                            }
                            else
                            {
                                for (int row = 0; row < this.Height; row++)
                                {
                                    image.ReadScanline(buf, row);
                                    if (BitPerSample == 8)
                                    {
                                        for (int i = 0; i < this.Width; i++)
                                            this.SingleChannelImage[0].Data[i + row * this.Width] = buf[i];
                                    }
                                    else if (BitPerSample == 16)
                                    {
                                        for (int i = 0; i < this.Width; i++)
                                            this.SingleChannelImage[0].Data[i + row * this.Width] = (buf[2 * i]) + (buf[2 * i + 1] << 8);
                                    }
                                }
                            }

                        }
                        #endregion

                        image.Close(); // or image.Dispose();
                        cGlobalInfo.BufferedImage = this;
                        return;

    
                    #endregion                    #region JPG - FreeImage
                    #region jpeg - libTiff
                    case "jpg":
                    case "jpeg":
                        loci.formats.@in.JPEGReader MyJpeg1Reader = new loci.formats.@in.JPEGReader();
                        MyJpeg1Reader.setId(CurrentName);
                        rgbValues = MyJpeg1Reader.openBytes(0);
                        this.Width = MyJpeg1Reader.getSizeX();
                        this.Height = MyJpeg1Reader.getSizeY();
                        this.Depth = MyJpeg1Reader.getSizeZ();
                        NumChannels = MyJpeg1Reader.getSizeC();
                        NumBitsPerPixel = MyJpeg1Reader.getBitsPerPixel();
                        MyJpeg1Reader.close();
                        break;
                    #endregion
                    #region LSM - BioFormats
                    case "lsm":
                        loci.formats.@in.ZeissLSMReader MyLSMReader = new loci.formats.@in.ZeissLSMReader();
                        MyLSMReader.setId(CurrentName);

                        this.Width = MyLSMReader.getSizeX();
                        this.Height = MyLSMReader.getSizeY();

                        NumChannels = MyLSMReader.getSizeC();
                        this.Depth = MyLSMReader.getSizeZ();

                        this.Name = CurrentName;
                        //this.SliceSize = this.Width * this.Height;
                        //this.ImageSize = SliceSize * Depth;

                        if (IdxName == 0)
                            this.SingleChannelImage = new cListSingleChannelImage();

                        #region GetMetaData
                        ResMeta = MyLSMReader.getSeriesMetadataValue("VoxelSizeX");
                        if (ResMeta == null)
                            this.Resolution.X = 1;
                        else
                            this.Resolution.X = ((java.lang.Double)ResMeta).doubleValue();

                        ResMeta = MyLSMReader.getSeriesMetadataValue("VoxelSizeY");
                        if (ResMeta == null)
                            this.Resolution.X = 1;
                        else
                            this.Resolution.Y = ((java.lang.Double)ResMeta).doubleValue();

                        ResMeta = MyLSMReader.getSeriesMetadataValue("VoxelSizeZ");
                        if (ResMeta == null)
                            this.Resolution.Z = 1;
                        else
                            this.Resolution.Z = ((java.lang.Double)ResMeta).doubleValue();
                        #endregion

                        for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                            this.SingleChannelImage.Add(new cSingleChannelImage(this.Width, this.Height, this.Depth, new cPoint3D(this.Resolution)));


                        float TmpValue = 0;
                        byte[] TmpTable;

                        for (int IdxZ = 0; IdxZ < this.Depth; IdxZ++)
                        {
                            for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                            {
                                TmpTable = MyLSMReader.openBytes(IdxZ * NumChannels + IdxChannel);

                                for (int IdxY = 0; IdxY < this.Height; IdxY++)
                                    for (int IdxX = 0; IdxX < this.Width; IdxX++)
                                    {
                                        TmpValue = TmpTable[IdxX + IdxY * this.Width];

                                        this.SingleChannelImage[IdxChannel + ChannelStart].Data[IdxX + IdxY * this.Width + IdxZ * this.SliceSize()] = TmpValue;
                                    }
                            }
                        }
                        NumBitsPerPixel = MyLSMReader.getBitsPerPixel();

                        // if the meta data are ok, take the name
                        for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                        {
                            ResMeta = MyLSMReader.getSeriesMetadataValue("DataChannel #" + (IdxChannel + 1) + " Name");
                            if (ResMeta != null)
                                this.SingleChannelImage[IdxChannel + ChannelStart].Name = (string)ResMeta;
                        }
                        goto NEXTLOOP;
                    #endregion

                    #region stk - BioFormats
                    case "stk":
                        loci.formats.@in.MetamorphReader MystkReader = new loci.formats.@in.MetamorphReader();
                        MystkReader.setId(CurrentName);
                        rgbValues = MystkReader.openBytes(0);
                        this.Width = MystkReader.getSizeX();
                        this.Height = MystkReader.getSizeY();
                        this.Depth = MystkReader.getSizeZ();
                        int numT = MystkReader.getSizeT();
                        NumChannels = MystkReader.getSizeC();
                        NumBitsPerPixel = MystkReader.getBitsPerPixel();
                        MystkReader.close();
                        break;
                    #endregion
                    #region png - BioFormats
                    case "png":
                        loci.formats.@in.APNGReader MyPNGReader = new loci.formats.@in.APNGReader();
                        MyPNGReader.setId(CurrentName);
                        rgbValues = MyPNGReader.openBytes(0);
                        this.Width = MyPNGReader.getSizeX();
                        this.Height = MyPNGReader.getSizeY();
                        this.Depth = MyPNGReader.getSizeZ();
                        NumChannels = MyPNGReader.getSizeC();
                        NumBitsPerPixel = MyPNGReader.getBitsPerPixel();
                        MyPNGReader.close();
                        break;
                    #endregion
                    #region gif - BioFormats
                    case "gif":
                        loci.formats.@in.GIFReader MyGIFReader = new loci.formats.@in.GIFReader();
                        MyGIFReader.setId(CurrentName);
                        rgbValues = MyGIFReader.openBytes(0);
                        this.Width = MyGIFReader.getSizeX();
                        this.Height = MyGIFReader.getSizeY();
                        this.Depth = MyGIFReader.getSizeZ();
                        NumChannels = MyGIFReader.getSizeC();
                        NumBitsPerPixel = MyGIFReader.getBitsPerPixel();
                        MyGIFReader.close();
                        break;
                    #endregion
                    #region bmp - BioFormats
                    case "bmp":
                        loci.formats.@in.BMPReader MyBMPReader = new loci.formats.@in.BMPReader();
                        MyBMPReader.setId(CurrentName);
                        rgbValues = MyBMPReader.openBytes(0);
                        this.Width = MyBMPReader.getSizeX();
                        this.Height = MyBMPReader.getSizeY();
                        this.Depth = MyBMPReader.getSizeZ();
                        NumChannels = MyBMPReader.getSizeC();
                        NumBitsPerPixel = MyBMPReader.getBitsPerPixel();
                        MyBMPReader.close();
                        break;
                    #endregion
                    default:
                        break;
                }

                if (NumBitsPerPixel == 8)
                {
                    NumBytePerPixel = 1;
                }
                else if (NumBitsPerPixel == 16)
                {
                    NumBytePerPixel = 2;
                }
                else if (NumBitsPerPixel == 24)
                {
                    NumBytePerPixel = 3;
                }
                else if (NumBitsPerPixel == 32)
                {
                    NumBytePerPixel = 4;
                }
                else
                {
                    // format not implemented
                    return;
                }

                //this.Name = Path;
                //FreeImageAPI.FIMULTIBITMAP LoadedMultiPageImage = FreeImage.OpenMultiBitmap(FREE_IMAGE_FORMAT.FIF_TIFF, Path, false, true, true, FREE_IMAGE_LOAD_FLAGS.DEFAULT);
                //FreeImageAPI.FIBITMAP LoadedPage = FreeImage.LockPage(LoadedMultiPageImage,0);
                //FreeImageAPI.FIBITMAP LoadedImage = FreeImage.ConvertToStandardType(LoadedPage, true);
                //if (FileName == "")
                //    this.Name = Path;
                //else
                this.Name = CurrentName;

                //this.SliceSize = this.Width * this.Height;
                //this.ImageSize = SliceSize * Depth;

                //FreeImage.FlipVertical(LoadedImage);
                ////Image CurrentMSImage = (Image)FreeImage.GetBitmap(LoadedImage);
                //FreeImageAPI.FIBITMAP Converted24Im = FreeImage.ConvertToGreyscale(LoadedImage);
                //IntPtr Pt =  FreeImage.GetBits(LoadedImage);

                //int bytes = Width*Height*3;
                //byte[] rgbValues = new byte[bytes];

                //// Copy the RGB values into the array.
                //System.Runtime.InteropServices.Marshal.Copy(Pt, rgbValues, 0,bytes);
                //FormForImageDisplay NewDispl = new FormForImageDisplay();
                //NewDispl.pictureBoxForImage.Image = (Image)FreeImage.GetBitmap(LoadedImage);
                //NewDispl.Show();


                //  this.Data = new float[this.NumChannels][];


                float Value;

                //int GlobalIdx = 0;
                //cSingleChannelImage CI = new cSingleChannelImage(this.Width * this.Height * this.Depth);
                //CI.Data[0] = 10;
                for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                {
                    cSingleChannelImage TmpChannel = new cSingleChannelImage(this.Width, this.Height, this.Depth, new cPoint3D(1, 1, 1));

                    if (IdxChannel < ListImageMetaInfo.Count)
                    {
                        if (ListImageMetaInfo[IdxChannel].Name != "") TmpChannel.Name = ListImageMetaInfo[IdxChannel].Name;
                        if (ListImageMetaInfo[IdxChannel].ResolutionX != 0) this.Resolution.X = ListImageMetaInfo[IdxChannel].ResolutionX;
                        if (ListImageMetaInfo[IdxChannel].ResolutionY != 0) this.Resolution.Y = ListImageMetaInfo[IdxChannel].ResolutionY;
                        if (ListImageMetaInfo[IdxChannel].ResolutionZ != 0) this.Resolution.Z = ListImageMetaInfo[IdxChannel].ResolutionZ;
                    }

                    this.SingleChannelImage.Add(TmpChannel);

                }

                int PixIdx = 0;
                for (int IdxZ = 0; IdxZ < this.Depth; IdxZ++)
                    for (int IdxY = 0; IdxY < this.Height; IdxY++)
                        for (int IdxX = 0; IdxX < this.Width; IdxX++)
                        {
                            for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                            {
                                Value = 0;
                                for (int i = 0; i < NumBytePerPixel; i++)
                                    Value += (rgbValues[NumBytePerPixel * PixIdx + i + IdxChannel * this.SliceSize() * this.Depth] << (i * 8));

                                this.SingleChannelImage[IdxChannel + ChannelStart].Data[PixIdx] = Value;
                            }
                            PixIdx++;
                        }

            NEXTLOOP: ;

                ChannelStart += NumChannels;
            }

           // if (cGlobalInfo.BufferedImage == null)
                cGlobalInfo.BufferedImage = this;


            /*
            for (int IdxY = 0; IdxY < this.Height; IdxY++)
                for (int IdxX = 0; IdxX < this.Width; IdxX++)
                {
                    for (int IdxChannel = 0; IdxChannel < NumChannels; IdxChannel++)
                    {
                        this.Data[IdxChannel].Data[IdxX + IdxY * this.Width] = rgbValues[GlobalIdx++];
                    }
                }
            */
            //if (LoadedImage.IsNull) return;
            // this.NumChannels = this.SingleChannelImage.Count;


        }



        #endregion
    }




}
