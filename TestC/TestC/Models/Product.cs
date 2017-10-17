namespace TestC.Models
{
    public class Product
    {
        public long? ProductId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }

        public long? StoreId { get; set; }
        public long? ClientId { get; set; }

        public Client Client { get; set; }
        public Store Store { get; set; }

    }
}