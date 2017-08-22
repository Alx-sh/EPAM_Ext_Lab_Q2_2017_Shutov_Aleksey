namespace Task01
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        [Required]
        public DateTime? OrderDate { get; private set; }
        [Required]
        public DateTime? RequiredDate { get; private set; }
        [Required]
        public DateTime? ShippedDate { get; private set; }
        public int ShipVia { get; private set; }
        public decimal Freight { get; private set; }
        [Required]
        public string ShipName { get; private set; }
        public string ShipAddress { get; private set; }
        public string ShipCity { get; private set; }
        public string ShipRegion { get; private set; }
        public string ShipPostalCode { get; private set; }
        public string ShipCountry { get; private set; }
        public Status OrderStatus { get; private set; }

        public Order()
        {
            OrderStatus = Status.New;
        }

        public Order(string CustomerID, int EmployeeID, int ShipVia, string ShipName)
        {
            this.CustomerID = CustomerID;
            this.EmployeeID = EmployeeID;
            OrderDate = DateTime.Now.Date;
            RequiredDate = DateTime.Now.Date;
            ShippedDate = DateTime.Now.Date;
            this.ShipVia = ShipVia;
            Freight = 0;
            this.ShipName = ShipName;
            ShipAddress = string.Empty;
            ShipCity = string.Empty;
            ShipRegion = string.Empty;
            ShipPostalCode = string.Empty;
            ShipCountry = string.Empty;
            OrderStatus = Status.New;
        }

        public Order(int OrderID, string CustomerID, int EmployeeID, DateTime? OrderDate, DateTime? RequiredDate, 
            DateTime? ShippedDate, int ShipVia, decimal Freight, string ShipName, string ShipAddress, 
            string ShipCity, string ShipRegion, string ShipPostalCode, string ShipCountry)
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
            this.ShipCountry = ShipCountry;

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
