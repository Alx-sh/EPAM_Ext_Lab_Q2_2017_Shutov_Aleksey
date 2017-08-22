using System.ComponentModel.DataAnnotations;

namespace Task01
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string QuantityPerUnit { get; private set; }
        [Required]
        public decimal UnitPrice { get; private set; }
        [Required]
        public int Quantity { get; private set; }
        [Required]
        public float Discount { get; private set; }
        [Required]
        public decimal Totals { get; private set; }
        public string Status { get; private set; }

        public OrderDetails(int ProductID, string ProductName, string QuantityPerUnit, decimal UnitPrice, int Quantity,
            float Discount, decimal Totals, string Status)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.QuantityPerUnit = QuantityPerUnit;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
            this.Discount = Discount;
            this.Totals = Totals;
            this.Status = Status;
        }
    }
}
