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

        public  config()
        {
           // _liteDB = new LiteDatabase(@"D:\Database\MyData.db");
            
            //_invoiceCollection = _liteDB.GetCollection<InvoiceModel>("invoices");
            //_itemCollection = _liteDB.GetCollection<ItemModel>("items");
        }

    }
}
