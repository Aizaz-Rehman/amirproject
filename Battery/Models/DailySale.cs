using System;
namespace Battery.Models
{
    public class DailySale
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Sale { get; set; }
        public string Details { get; set; }

    }
}
