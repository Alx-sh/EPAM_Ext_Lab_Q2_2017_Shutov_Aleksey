namespace Task01
{
    public class CustOrdersDetail
    {
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public int Discount { get; private set; }
        public decimal ExtendedPrice { get; private set; }

        public CustOrdersDetail(string ProductName, decimal UnitPrice, int Quantity, int Discount, decimal ExtendedPrice)
        {
            this.ProductName = ProductName;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
            this.Discount = Discount;
            this.ExtendedPrice = ExtendedPrice;
        }
    }
}
