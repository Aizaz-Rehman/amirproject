using Battery.Configuration;
using Battery.Models;
using LiteDB;
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
    public partial class DailySale : UserControl
    {
        private readonly ILiteCollection<DailySaleModel> saleData;
        public DailySale()
        {
            InitializeComponent();
            var db = config._liteDB;
            saleData = db.GetCollection<DailySaleModel>("DailySale");
            gridControl1.DataSource = saleData.Query().OrderByDescending(x => x.Date).ToList();
        }
        public void refreshData()
        {
            gridControl1.DataSource = saleData.Query().OrderByDescending(x => x.Date).ToList();
        }
    }
}
