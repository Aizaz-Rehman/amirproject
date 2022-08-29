using Battery.Models;
using LiteDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battery.Configuration
{
    internal class config
    {
        public static LiteDatabase _liteDB = new LiteDatabase(@"D:\Database\MyData.db");
        private ILiteCollection<InvoiceModel> _invoiceCollection;
        private ILiteCollection<ItemModel> _itemCollection;

        public void LiteDbHelper()
        {
            _liteDB = new LiteDatabase(@"D:\Database\MyData.db");
            
            //_invoiceCollection = _liteDB.GetCollection<InvoiceModel>("invoices");
            //_itemCollection = _liteDB.GetCollection<ItemModel>("items");
        }

        
        public  ICollection GetAllTemplate()
        {
            return _invoiceCollection.Query().OrderByDescending(x => x.Id).ToList();
        }

        //public InvoiceModel GetTemplate(string txt)
        //{
        //    return _tempCollection.FindOne(x => x.Title == txt);
        //}

        //public Template GetTemplate(int id)
        //{
        //    return _tempCollection.FindOne(x => x.Id == id);
        //}

        public bool Remove(int id)
        {
            return _invoiceCollection.Delete(id);
        }

        public bool Update(InvoiceModel inv)
        {
            return _invoiceCollection.Update(inv);
        }

        public int Insert(InvoiceModel inv)
        {
            return _invoiceCollection.Insert(inv);
        }

        //public int InsertNotification(IList<Notification> notifications)
        //{
        //    return _notifCollection.InsertBulk(notifications);
        //}

        public List<ItemModel> GetAllNotification()
        {
            return _itemCollection.Query().ToList();
        }

        //public Notification GetNotification()
        //{
        //    return _notifCollection.Query().FirstOrDefault();
        //}

        public bool Delete(int id)
        {
            return _itemCollection.Delete(id);
        }
    }
}
