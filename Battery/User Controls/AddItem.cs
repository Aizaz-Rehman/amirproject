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

namespace Battery.User_Controls
{
    public partial class AddItem : DevExpress.XtraEditors.XtraUserControl
    {
        private static AddItem _instance;
        public static AddItem Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new AddItem();
                return _instance;
            }
            
        }
        public AddItem()
        {
            InitializeComponent();
        }
    }
}
