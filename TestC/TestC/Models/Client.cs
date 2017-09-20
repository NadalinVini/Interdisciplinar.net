using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestC.Models
{
    public class Client
    {
        public long ClientId { get; set; }
        public string Name { get; set; }
        public int Cep { get; set; }
        public long Cpf { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public int Fone { get; set; }
        
    }
}