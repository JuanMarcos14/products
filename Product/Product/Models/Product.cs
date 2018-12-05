using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public DateTime? deleted { get; set; }
    }
}
