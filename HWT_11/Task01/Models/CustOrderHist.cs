namespace Task01
{
    public class CustOrderHist
    {
        public string ProductName { get; private set; }
        public int Total { get; private set; }

        public CustOrderHist(string ProductName, int Total)
        {
            this.ProductName = ProductName;
            this.Total = Total;
        }
    }
}
