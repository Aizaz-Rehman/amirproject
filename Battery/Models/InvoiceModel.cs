using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battery.Models
{
    public enum status
    {
        Paid = 10,
        UnPaid = 20,
        PartialPaid = 30,
        OverPaid = 40,
    }
    public class InvoiceModel
    {


        public long Id { get; set; }

        public string Name { get; set; } = null;
        public string Address { get; set; }
        public string Item { get; set; }
        public string Phone { get; set; }
        public double Price { get; set; } = 0;
        public double Paid { get; set; } = 0;
       
        public int Quantity { get; set; }
        public double TotalPrice => Price * Quantity;
        public double Debit => TotalPrice - Paid;
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public status Status { get; set; }

    }
}
