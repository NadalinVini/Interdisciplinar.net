using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestC.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string VideoCard { get; set; }
        public string MotherBoard { get; set; }
        public string HardDisk { get; set; }
        public string Cabinet { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Source { get; set; }
    }
}