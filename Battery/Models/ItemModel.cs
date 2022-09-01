﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battery.Models
{

    public class ItemModel
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public long Price { get; set; }
        public int ItemQuatity { get; set; }
        public long StockPrice => Price * ItemQuatity;
        public DateTime itemDate { get; set; }  
        public string itemDetail { get; set; }
    }
}
