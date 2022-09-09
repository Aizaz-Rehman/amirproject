using Battery.Configuration;
using Battery.Models;
using DevExpress.XtraEditors;
using LiteDB;
using System;
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
        public void RefreshData()
        {
            gridControl1.DataSource = saleData.Query().OrderByDescending(x => x.ID).ToList();
            gridControl1.RefreshDataSource();
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var dlg = YesNo("Are You Sure?", "Delete");
            if (dlg == DialogResult.No) return;
            var curr = gridView1.GetFocusedRow() as DailySaleModel;
            long rowId = (long)curr.ID;
            saleData.Delete(rowId);
            RefreshData();
        }








        public static DialogResult YesNo(string msg, string title = null)
        {
            if (title == null)
            {
                title = "Confirmation";
            }

            return XtraMessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
