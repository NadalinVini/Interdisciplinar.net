using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestC.Models
{
    public class Buy
    {
        public long BuyId { get; set; }
        public long Amount { get; set; }
        public DateTime Date_buy { get; set; }
        public decimal Price { get; set; }
        public int Form_Payment { get; set; }
        public int Invoice { get; set; }
        public long ClientId { get; set; }
        public long StorageId  { get; set; }

        public Storage Storage { get; set; }

        public Client Client { get; set; }


    }
}