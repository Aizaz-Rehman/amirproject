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

namespace Battery
{
    public partial class AddInvoice : DevExpress.XtraEditors.XtraUserControl
    {
        private static AddInvoice _instance;
        public static AddInvoice Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AddInvoice();
                return _instance;
            }

        }
        public AddInvoice()
        {
            InitializeComponent();
        }
    }
}
