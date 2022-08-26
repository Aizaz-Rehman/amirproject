using Battery.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Battery
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            if (!container.Controls.Contains(AddInvoice.Instance))
            {
                container.Controls.Add(AddInvoice.Instance);
                AddInvoice.Instance.Dock = DockStyle.Fill;
                AddInvoice.Instance.BringToFront();
            }
            AddInvoice.Instance.BringToFront();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!container.Controls.Contains(AddInvoice.Instance))
            {
                container.Controls.Add(AddInvoice.Instance);
                AddInvoice.Instance.Dock = DockStyle.Fill;
                AddInvoice.Instance.BringToFront();
            }
            AddInvoice.Instance.BringToFront();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (!container.Controls.Contains(AddItem.Instance))
            {
                container.Controls.Add(AddItem.Instance);
                AddItem.Instance.Dock = DockStyle.Fill;
                AddItem.Instance.BringToFront();
            }
            AddItem.Instance.BringToFront();
        }
    }
}
