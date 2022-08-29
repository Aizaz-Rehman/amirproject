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
            addItem1.Hide();
           
        }
 
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addItem1.Hide();
            addInvoice1.Show();
            addInvoice1.Dock = DockStyle.Fill;
            addInvoice1.BringToFront();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addInvoice1.Hide();
            addItem1.Show();
            addItem1.Dock = DockStyle.Fill;
            addItem1.BringToFront();
        }

       
    }
}
