using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStore.Forms
{
    public partial class About : DevExpress.XtraEditors.XtraForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "http://www.hintstar.blogspot.com");
        }
    }
}