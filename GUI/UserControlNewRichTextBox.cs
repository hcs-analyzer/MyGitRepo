using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HCSAnalyzer.GUI
{
    public partial class UserControlNewRichTextBox : UserControl
    {
        public UserControlNewRichTextBox()
        {
            InitializeComponent();
        }

        private void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            this.richTextBox.Clear();
        }
    }
}
