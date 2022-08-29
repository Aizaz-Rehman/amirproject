using Battery.Configuration;
using Battery.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class AddInvoice : UserControl
    {


        private readonly ILiteCollection<InvoiceModel> data;
        private readonly ILiteCollection<ItemModel> itemData;
        List<InvoiceModel> _invoice = new List<InvoiceModel>();
        private dynamic curr;
        public AddInvoice()
        {
            InitializeComponent();
            ResetForm();
            var db = config._liteDB;
            data = db.GetCollection<InvoiceModel>("Invoices");
            itemData = db.GetCollection<ItemModel>("Items");
            gridControl1.DataSource = data.Query().OrderByDescending(x => x.Id).ToList();
            txt_Item.Properties.DataSource = itemData.Query().ToList();
        }
        public void refreshData()
        {
            txt_Item.Properties.DataSource = itemData.Query().ToList();
        }

        internal void show()
        {
            throw new NotImplementedException();
        }

        private void SaveData()
        {

            // Get a collection (or create, if doesn't exist)
            var col = data;
            if (txt_Name.Text == "" || txt_Price.Text == "0" || txt_Item.Text == "--please select item")
            {
                MessageBox.Show("Name, Item and Price cannot be empty!");
            }
            else
            {
                var invoice = new InvoiceModel
                {
                    Name = txt_Name.Text.ToString() ?? "",
                    Address = txt_Address.Text.ToString() ?? "",
                    Phone = txt_Phone.Text,
                    Item = txt_Item.Text.ToString() ?? "",
                    Price = long.Parse(txt_Price.Text),
                    Quantity = int.Parse(txt_Quantity.Text),
                    Paid = long.Parse(txt_Paid.Text),
                    Date = date_Invoice.DateTime,
                    Details = txt_Details.Text.ToString() ?? "",

                };
                var ItemId = int.Parse(txt_Item.EditValue.ToString());

                var item = itemData.FindOne(x => x.Id == ItemId);
                if (item != null) item.ItemQuatity = item.ItemQuatity - int.Parse(txt_Quantity.Text);
                itemData.Update(item);
                statusChange(invoice);
                col.Insert(invoice);
                RefreshData();
                ResetForm();
            }

        }
        private void statusChange(InvoiceModel inv)
        {

            if (inv != null)
            {
                if (inv.Paid > 0 && inv.Paid < inv.TotalPrice)
                {
                    inv.Status = status.PartialPaid;
                }
                else if (inv.Paid == 0)
                {
                    inv.Status = status.UnPaid;
                }
                else if (inv.Paid == inv.TotalPrice)
                {
                    inv.Status = status.Paid;
                }
                else if (inv.Paid > inv.TotalPrice)
                {
                    inv.Status = status.OverPaid;
                }
            }
        }
        public void RefreshData()
        {
            gridControl1.DataSource = data.Query().OrderByDescending(x => x.Id).ToList();
            gridControl1.RefreshDataSource();
        }

        public void ResetForm()
        {
            txt_Name.Text = null;
            txt_Address.Text = null;
            txt_Item.Text = null;
            txt_Details.Text = null;
             txt_Phone.Text = null;
            txt_Price.Text = null;
            txt_Paid.Text = null;
            txt_Quantity.Text = null;
            date_Invoice.DateTime = DateTime.Today;
        }



        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var dlg = YesNo("Are You Sure?", "Delete");
            if (dlg == DialogResult.No) return;
            curr = gridView1.GetFocusedRow();
            long rowId = (long)curr.Id;
            data.Delete(rowId);
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


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          //  new About().ShowDialog();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          //  new Help().ShowDialog();
        }

      

        private void btn_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var dlg = YesNo("Are You Sure?", "Delete");
            if (dlg == DialogResult.No) return;
            curr = gridView1.GetFocusedRow();
            long rowId = (long)curr.Id;
            data.Delete(rowId);
            RefreshData();
        }

     

        private void gridView1_RowCellStyle_1(object sender, RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "Status")
            {
                if (e.Column.AbsoluteIndex == 11)
                {
                    if (e.CellValue.ToString() == "UnPaid")
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (e.CellValue.ToString() == "Paid")
                    {
                        e.Appearance.BackColor = Color.Green;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (e.CellValue.ToString() == "PartialPaid")
                    {
                        e.Appearance.BackColor = Color.Orange;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (e.CellValue.ToString() == "OverPaid")
                    {
                        e.Appearance.BackColor = Color.BlueViolet;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void gridView1_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            curr = gridView1.GetFocusedRow();
            if (curr != null)
            {

                statusChange((InvoiceModel)curr);
                data.Update((InvoiceModel)curr);

            }
        }
    }
}
