using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestC.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public long Fone { get; set; }
        public int Cep { get; set; }        
        public string Adress { get; set; }
        public long Cnpj { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }

    }
}