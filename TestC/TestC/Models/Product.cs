using System.Collections.Generic;

namespace TestC.Models
{
    public class Product
    {
        public long? ProductId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }

        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Storage> Storage { get; set; }

    }
}