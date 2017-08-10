namespace Task01
{
    public class OrderDetails
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string QuantityPerUnit { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public float Discount { get; private set; }
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
