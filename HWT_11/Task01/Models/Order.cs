namespace Task01
{
    using System;

    public class Order
    {
        public int OrderID { get; private set; }
        public string CustomerID { get; private set; }
        public int EmployeeID { get; private set; }
        public DateTime? OrderDate { get; private set; }
        public DateTime? RequiredDate { get; private set; }
        public DateTime? ShippedDate { get; private set; }
        public int ShipVia { get; private set; }
        public decimal Freight { get; private set; }
        public string ShipName { get; private set; }
        public string ShipAddress { get; private set; }
        public string ShipCity { get; private set; }
        public string ShipRegion { get; private set; }
        public string ShipPostalCode { get; private set; }
        public string ShipCounty { get; private set; }
        public Status OrderStatus { get; private set; }

        public Order(int OrderID, string CustomerID, int EmployeeID, DateTime? OrderDate, DateTime? RequiredDate, 
            DateTime? ShippedDate, int ShipVia, decimal Freight, string ShipName, string ShipAddress, 
            string ShipCity, string ShipRegion, string ShipPostalCode, string ShipCounty)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.EmployeeID = EmployeeID;
            this.OrderDate = OrderDate;
            this.RequiredDate = RequiredDate;
            this.ShippedDate = ShippedDate;
            this.ShipVia = ShipVia;
            this.Freight = Freight;
            this.ShipName = ShipName;
            this.ShipAddress = ShipAddress;
            this.ShipCity = ShipCity;
            this.ShipRegion = ShipRegion;
            this.ShipPostalCode = ShipPostalCode;
            this.ShipCounty = ShipCounty;

            if (ShippedDate.Equals(null))
            {
                if (OrderDate.Equals(null))
                {
                    OrderStatus = Status.New;
                }
                else
                {
                    OrderStatus = Status.NotExecuted;
                }
            }
            else
            {
                OrderStatus = Status.Executed;
            }
        }
    }
}
