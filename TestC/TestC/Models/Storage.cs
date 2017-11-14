using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestC.Models
{
    public class Storage
    {
        public long StorageId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long StoreId { get; set; }
        public Store Store { get; set; }
        public decimal Amount { get; set; }
    }
}