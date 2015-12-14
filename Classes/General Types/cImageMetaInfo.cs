using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibPlateAnalysis;

namespace HCSAnalyzer.Classes.General_Types
{
    public class cImageMetaInfo
    {
        public string FileName = "";
        public string Name = "";

        public int NumZ = 1;

        public double ResolutionX = -1;
        public double ResolutionY = -1;
        public double ResolutionZ = -1;
        public double PositionX = -1;
        public double PositionY = -1;
        public double PositionZ = -1;

        public int Field = -1;
        public cWell AssociatedWell = null;


    }
}
