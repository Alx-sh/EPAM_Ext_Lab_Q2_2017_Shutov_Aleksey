using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class ProductDetails
    {
        public List<Product> products = new List<Product>();
        public int orderID { get; set; }
        public string prodName { get; set; }
        [Required]
        public int quantity = 1;
        [Required]
        public float discount = 0.0f;
        public decimal totals { get; set; }
    }
}
