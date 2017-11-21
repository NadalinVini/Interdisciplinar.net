using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestC.Models
{
    public class StorageProduct
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long StorageId { get; set; }
        public Storage Storage { get; set; }

        public int Quantitity { get; set; }
    }
}