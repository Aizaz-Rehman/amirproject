using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battery.Models
{
    internal class ItemModel
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public long Price { get; set; }
        public int ItemQuatity { get; set; }
        public long TotalPrice => Price * ItemQuatity;
        public DateTime itemDate { get; set; }  
        public string itemDetail { get; set; }
    }
}
