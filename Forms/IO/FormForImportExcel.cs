using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibPlateAnalysis;
using HCSAnalyzer.Classes;
using HCSAnalyzer.Classes.General_Types.Screen;
using HCSAnalyzer.Classes.General_Types;

namespace HCSAnalyzer
{
    public partial class FormForImportExcel : Form
    {
        private bool FirstTime = true;
        public bool IsImportCSV =  false;
        public bool IsAppend;
        public int ModeWell;
        public char Separator = ',';
        

        public cScreening CurrentScreen = null;
        public HCSAnalyzer thisHCSAnalyzer = null;
        //public Dictionary<cPropertyType, int> ListPosPropertyOnGUI = new Dictionary<cPropertyType, int>();
        public Dictionary<string, int> ListPosPropertyOnGUI = new Dictionary<string, int>();

        public FormForImportExcel()
        {
            InitializeComponent();
            ToolTip MytoolTip = new ToolTip();

            //// Set up the ToolTip text for the Button and Checkbox.
            MytoolTip.SetToolTip(this.checkBoxConvertNaNTo0, "If a non decimal value is detected, it will be automatically converted into a null value.");

            foreach (cPropertyType item in cGlobalInfo.CurrentScreening.ListWellPropertyTypes)
            {
                ListPosPropertyOnGUI.Add(item.Name, -1);
            }

            // TODO: "Well Position has to be added in the cListWellProperty
            ListPosPropertyOnGUI.Add("Well Position", -1);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridViewForImport.Rows.Count; i++)
                this.dataGridViewForImport.Rows[i].Cells[1].Value = true;
        }

        public List<string> GetListPlatesToBeExcluded()
        {
            List<string> ToReturn = new List<string>();

           string[] ListToBeIntegrated = this.richTextBoxToBeExcluded.Text.Split('\n');

           for (int i = 0; i < ListToBeIntegrated.Length; i++)
           {
               if(ListToBeIntegrated[i]!="")
               {
                string TmpString  = ListToBeIntegrated[i];
                   string ToBeIntegrated = "";
                for (int k = 0; k < TmpString.Length; k++)
                {
                    if ((TmpString[k] != '\t')&&(TmpString[k] != '\r'))
                        ToBeIntegrated += TmpString[k];
                }

                ToReturn.Add(ToBeIntegrated);
               
               }
                
           }

            return ToReturn;
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridViewForImport.Rows.Count; i++)
                this.dataGridViewForImport.Rows[i].Cells[1].Value = false;
        }

        private void toolStripMenuItem96_Click(object sender, EventArgs e)
        {
            this.numericUpDownColumns.Value = 12;
            this.numericUpDownRows.Value = 8;
        }

        private void toolStripMenuItem384_Click(object sender, EventArgs e)
        {
            this.numericUpDownColumns.Value = 24;
            this.numericUpDownRows.Value = 16;
        }

        private void toolStripMenuItem1536_Click(object sender, EventArgs e)
        {
            this.numericUpDownColumns.Value = 48;
            this.numericUpDownRows.Value = 32;
        }


        public int HeaderSize = 0;

        public bool NoName = false;
        public bool IsParentFolder;
    }
}
