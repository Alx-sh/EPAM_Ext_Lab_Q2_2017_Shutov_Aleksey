namespace Task01.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Task01Tests
    {
        string connectionString = @"Data Source=(local);Initial Catalog=Northwind;Integrated Security=True";

        [TestMethod]
        public void ShowOrdersTest()
        {
            DAL dal = new DAL(connectionString);
            List<Order> orders = dal.ShowOrders();

            foreach (var order in orders)
            {
                Assert.IsNotNull(order);
            }
        }

        [TestMethod]
        public void ShowOrderDetails()
        {
            DAL dal = new DAL(connectionString);
            List<Order> orders = dal.ShowOrders();
            List<OrderDetails> orderDetails = new List<OrderDetails>();

            foreach (var order in orders)
            {
                orderDetails = dal.ShowOrderDetails(order.OrderID);
            }

            foreach (var orderDet in orderDetails)
            {
                Assert.IsNotNull(orderDet);
            }
        }

        [TestMethod]
        public void CreateOrderTest()
        {
            DAL dal = new DAL(connectionString);
            List<Order> orders = dal.ShowOrders();
            Order order = new Order(
                1,
                "VINET",
                1,
                new DateTime(1900, 01, 01),
                new DateTime(1900, 01, 01),
                new DateTime(1900, 01, 01),
                1,
                0,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty);

            dal.CreateOrder(order);

            Assert.IsTrue(orders.Count < dal.ShowOrders().Count);

            //Удаление всех созданных заказов для теста.
            dal.DeleteOrder();
        }

        [TestMethod]
        public void SetOrderDateTest()
        {
            DAL dal = new DAL(connectionString);
            //Создание заказа для теста.
            CreateOrderTest();

            List<Order> orders = dal.ShowOrders();
            DateTime? date = DateTime.Now.Date;
            dal.SetOrderDate(date, orders[orders.Count - 1].OrderID);
            DateTime? date2 = orders[orders.Count - 1].OrderDate;
            Assert.AreEqual(date, date2);

            //Удаление всех созданных заказов для теста.
            dal.DeleteOrder();
        }

        [TestMethod]
        public void SetShippedDateTest()
        {
            DAL dal = new DAL(connectionString);
            //Создание заказа для теста.
            CreateOrderTest();

            List<Order> orders = dal.ShowOrders();
            DateTime? date = DateTime.Now.Date;
            dal.SetShippedDate(date, orders[orders.Count - 1].OrderID);
            DateTime? date2 = orders[orders.Count - 1].ShippedDate;
            Assert.AreEqual(date, date2);

            //Удаление всех созданных заказов для теста.
            dal.DeleteOrder();
        }

        [TestMethod]
        public void ViewCustOrderHistTest()
        {
            DAL dal = new DAL(connectionString);
            List<CustOrderHist> custOrderHist = dal.ViewCustOrderHist("VINET");
            Assert.IsTrue(custOrderHist.Count > 0);
        }

        [TestMethod]
        public void ViewCustOrdersDetailTest()
        {
            DAL dal = new DAL(connectionString);
            List<CustOrdersDetail> custOrdersDetail = dal.ViewCustOrdersDetail(10248);
            Assert.IsTrue(custOrdersDetail.Count > 0);
        }
    }
}
