using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task01;
using PagedList.Mvc;
using PagedList;
using MVCProject.Properties;

namespace MVCProject.Controllers
{
    public class OrdersController : Controller
    {
        DAL dal = new DAL(ConfigurationManager.ConnectionStrings["Conection"].ConnectionString);

        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(dal.ShowOrders().ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult OrderDetails(int orderID)
        {
            OrderAndOrderDetails ord = new OrderAndOrderDetails();
            ord.o = dal.ShowOrders(orderID).FirstOrDefault();
            ord.od = dal.ShowOrderDetails(orderID);
            return View(ord);
        }

        [HttpGet]
        public ActionResult CreateOrder()
        {
            CustEmpShipViaID list = new CustEmpShipViaID();
            list = dal.SelectCustEmpID();
            list.CustomerListID.Sort();
            list.EmployeeListID.Sort();
            list.ShipViaListID.Sort();
            return PartialView(list);
        }

        [HttpPost]
        public ActionResult CreateOrder(string custID, string empID, string shipVia, string shipName)
        {
            if (string.IsNullOrWhiteSpace(shipName))
            {
                ModelState.AddModelError("shipName", Resources.ErrorShipName);
                ViewBag.Message += Resources.ErrorShipName;
            }

            if (ModelState.IsValid)
            {
                Order o = new Order(custID, int.Parse(empID), int.Parse(shipVia), shipName);
                o.OrderID = dal.CreateOrder(o);
                ViewBag.Message = Resources.OrderIsCreated;
                return View("Result");
            }

            ViewBag.Message += Resources.ErrorValidation;
            return View("Result");
        }

        [HttpGet]
        public ActionResult DeleteSelected()
        {
            ViewBag.Message = Resources.DeleteSelected;
            return View("Result");
        }

        [HttpPost]
        public void DeleteSelected(string[] mas)
        {
            foreach (var orderID in mas)
            {
                dal.DeleteOrder(int.Parse(orderID));
            }
        }

        [HttpGet]
        public ActionResult EditOrder(int orderID)
        {
            Order o = dal.ShowOrders(orderID).FirstOrDefault();
            return PartialView(o);
        }

        [HttpPost]
        public ActionResult EditOrder(int OrderID, string CustomerID, int EmployeeID, DateTime? OrderDate, DateTime? RequiredDate,
            DateTime? ShippedDate, int ShipVia, decimal Freight, string ShipName, string ShipAddress,
            string ShipCity, string ShipRegion, string ShipPostalCode, string ShipCountry)
        {
            if (OrderDate < DateTime.Now.Date)
            {
                ModelState.AddModelError("OrderDate", Resources.ErrorOrderDate);
                ViewBag.Message = Resources.ErrorOrderDate;
            }

            if (RequiredDate < DateTime.Now.Date)
            {
                ModelState.AddModelError("RequiredDate", Resources.ErrorRequiredDate);
                ViewBag.Message = Resources.ErrorRequiredDate;
            }

            if (ShippedDate < DateTime.Now.Date)
            {
                ModelState.AddModelError("ShippedDate", Resources.ErrorShippedDate);
                ViewBag.Message = Resources.ErrorShippedDate;
            }

            if (string.IsNullOrWhiteSpace(ShipName))
            {
                ModelState.AddModelError("ShipName", Resources.ErrorShipName);
                ViewBag.Message += Resources.ErrorShipName;
            }

            if (ModelState.IsValid)
            {
                Order o = new Order(
                            OrderID,
                            CustomerID,
                            EmployeeID,
                            OrderDate,
                            RequiredDate,
                            ShippedDate,
                            ShipVia,
                            Freight,
                            ShipName,
                            ShipAddress,
                            ShipCity,
                            ShipRegion,
                            ShipPostalCode,
                            ShipCountry
                            );

                dal.UpdateOrder(o);

                ViewBag.Message = Resources.UpdateOrder + o.OrderID;
                return View("Result");
            }

            ViewBag.Message += Resources.ErrorValidation;
            return View("Result");
        }

        [HttpGet]
        public ActionResult EditProducts(string orderID)
        {
            ProductDetails pd = new ProductDetails();
            pd.orderID = int.Parse(orderID);
            pd.products = dal.SelectProducts();
            return PartialView(pd);
        }

        [HttpPost]
        public ActionResult EditProducts(int orderID, string prodName, int quantity, float discount)
        {
            ProductDetails pd = new ProductDetails();
            Product prod = new Product();
            if (quantity <= 0)
            {
                ModelState.AddModelError("Quantity", Resources.ErrorQuantity);
                ViewBag.Message += Resources.ErrorQuantity;
            }


            if (discount < 0 || discount > 1)
            {
                ModelState.AddModelError("Discount", Resources.ErrorDiscount);
                ViewBag.Message += Resources.ErrorDiscount;
            }

            if (ModelState.IsValid)
            {
                foreach (var i in dal.SelectProducts())
                {
                    if (i.productName == prodName)
                    {
                        prod = i;
                    }
                }
                pd.quantity = quantity;
                pd.discount = discount;
                pd.totals = (prod.UnitPrice - prod.UnitPrice * (decimal)discount) * pd.quantity;

                OrderDetails od = new OrderDetails(
                    prod.productID,
                    prod.productName,
                    prod.QuantityPerUnit,
                    prod.UnitPrice,
                    pd.quantity,
                    pd.discount,
                    pd.totals,
                    Status.NotExecuted.ToString());
                od.OrderID = orderID;
                dal.CreateOrderDetails(od);
                ViewBag.Message = Resources.UpdateOrder + od.OrderID;
                return View("Result");
            }

            ViewBag.Message += Resources.ErrorValidation;
            return View("Result");
        }
    }
}