using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class ProductDetails
    {
        public List<Product> products = new List<Product>();
        public int orderID { get; set; }
        public string prodID { get; set; }
        public int quantity { get; set; }
        public float discount { get; set; }
        public decimal totals { get; set; }
    }
}
