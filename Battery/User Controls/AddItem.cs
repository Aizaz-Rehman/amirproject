using Battery.Configuration;
using Battery.Models;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Battery.User_Controls
{
    public partial class AddItem : UserControl
    {


        private readonly ILiteCollection<InvoiceModel> invoicedata;
        List<InvoiceModel> _invoice = new List<InvoiceModel>();
        private readonly ILiteCollection<ItemModel> itemData;
        List<InvoiceModel> _item = new List<InvoiceModel>();
        public dynamic curr;
        public AddItem()
        {

            InitializeComponent();
            ResetForm();
           var db = config._liteDB;
            itemData = db.GetCollection<ItemModel>("Items");
            invoicedata = db.GetCollection<InvoiceModel>("Invoices");
            gridControl1.DataSource = itemData.Query().OrderByDescending(x => x.Id).ToList();

        }
        public void refreshData()
        {
            gridControl1.DataSource = itemData.Query().OrderByDescending(x => x.Id).ToList();
        }

        private void SaveData()
        {

            // Get a collection (or create, if doesn't exist)
            var col = itemData;
            if (txt_Item.Text == "" || txt_Price.Text == "0")
            {
                MessageBox.Show("Name and Price cannot be empty!");
            }
            else
            {
                var _item = new ItemModel
                {
                    Item = txt_Item.Text.ToString() ?? "",
                    Price = long.Parse(txt_Price.Text),
                    ItemQuatity = int.Parse(txt_Quantity.Text),
                    itemDate = date_Item.DateTime,
                    itemDetail = rich_ItemDetails.Text.ToString() ?? "",

                };
                statusChange(_item);
                col.Insert(_item);
                RefreshData();
                ResetForm();
            }

        }
        private void statusChange(ItemModel item)
        {

            if (item != null)
            {
                if (item.ItemQuatity > 0)
                {
                    item.Availability = availability.Available;
                }
                else if (item.ItemQuatity <=  0)
                {
                    item.Availability = availability.OutOfStock;
                }
               
            }
        }
        public void RefreshData()
        {
            gridControl1.DataSource = itemData.Query().OrderByDescending(x => x.Id).ToList();
            gridControl1.RefreshDataSource();
        }

        public void ResetForm()
        {
            txt_Item.Text = null;
            txt_Price.Text = null;
            txt_Quantity.Text = null;
            rich_ItemDetails.Text = null;
            date_Item.DateTime = DateTime.Today;
        }



        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var dlg = YesNo("Are You Sure?", "Delete");
            if (dlg == DialogResult.No) return;
            curr = gridView1.GetFocusedRow();
            long rowId = (long)curr.Id;
            itemData.Delete(rowId);
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


        private void gridView1_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            curr = gridView1.GetFocusedRow();
            if (curr != null)
            {

                //statusChange((ItemModel)curr);
                itemData.Update((ItemModel)curr);

            }
        }

        private void btn_Delete_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var dlg = YesNo("Are You Sure?", "Delete");
            if (dlg == DialogResult.No) return;
            curr = gridView1.GetFocusedRow();
            long rowId = (long)curr.Id;
            itemData.Delete(rowId);
            RefreshData();
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "Availability")
            {
                if (e.Column.AbsoluteIndex == 6)
                {
                    if (e.CellValue.ToString() == "OutOfStock")
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (e.CellValue.ToString() == "Available")
                    {
                        e.Appearance.BackColor = Color.Green;
                        e.Appearance.ForeColor = Color.White;
                    }

                }
            }
        }

        private void btn_ItemAdd_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var curr = gridView1.GetFocusedRow() as ItemModel;
            if (curr != null)
            {

                statusChange(curr);
                itemData.Update(curr);

            }
           
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
    }
}
