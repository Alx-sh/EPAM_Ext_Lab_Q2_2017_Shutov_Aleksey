using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task01;

namespace MVCProject.Controllers
{
    public class OrdersController : Controller
    {
        DAL dal = new DAL(ConfigurationManager.ConnectionStrings["Conection"].ConnectionString);

        [HttpGet]
        public ActionResult Index()
        {
            return View(dal.ShowOrders());
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
                ModelState.AddModelError("shipName", "Некорректное название");
                ViewBag.Message += "Некорректное название shipName. ";//todo pn в ресурсы
            }

            if (ModelState.IsValid)
            {
                Order o = new Order(custID, int.Parse(empID), int.Parse(shipVia), shipName);
                o.OrderID = dal.CreateOrder(o);
                ViewBag.Message = "Заказ создан!";
                return View("Result");
            }

            ViewBag.Message += "Запрос не прошел валидацию!";//todo pn в ресурсы
			return View("Result");
        }

        [HttpGet]
        public ActionResult DeleteSelected()
        {
            ViewBag.Message = "Заказы удалены!";//todo pn в ресурсы
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
            if (OrderDate < DateTime.Now.Date)//todo pn нужно ещё добавить атрибуты валидации к моделям (MinValue/MaxValue итп)
            {
                ModelState.AddModelError("OrderDate", "Некорректная дата");//todo pn в ресурсы
				ViewBag.Message = "Некорректная дата OrderDate. ";//todo pn в ресурсы
			}

            if (RequiredDate < DateTime.Now.Date)
            {
                ModelState.AddModelError("RequiredDate", "Некорректная дата");//todo pn в ресурсы
				ViewBag.Message = "Некорректная дата RequiredDate. ";//todo pn в ресурсы
			}

            if (ShippedDate < DateTime.Now.Date)
            {
                ModelState.AddModelError("ShippedDate", "Некорректная дата");//todo pn в ресурсы
				ViewBag.Message = "Некорректная дата ShippedDate. ";//todo pn в ресурсы
			}

            if (string.IsNullOrWhiteSpace(ShipName))
            {
                ModelState.AddModelError("ShipName", "Некорректное название");//todo pn в ресурсы
				ViewBag.Message += "Некорректное название ShipName. ";//todo pn в ресурсы
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

                ViewBag.Message = "Заказ обновлен - №" + o.OrderID;//todo pn в ресурсы
				return View("Result");
            }

            ViewBag.Message += "Запрос не прошел валидацию!";//todo pn в ресурсы
			return View("Result");
        }

        [HttpGet]
        public ActionResult EditProducts(int orderID)
        {
            ProductDetails pd = new ProductDetails();
            pd.orderID = orderID;
            pd.products = dal.SelectProducts();
            return PartialView(pd);
        }

        [HttpPost]
        public ActionResult EditProducts(int orderID, string prodID, int quantity, float discount)
        {
            ProductDetails pd = new ProductDetails();
            if (ModelState.IsValid)
            {
                foreach (var i in dal.SelectProducts())
                {
                    if (i.productID == int.Parse(prodID))
                    {
                        pd.products.Add(i);
                    }
                }
                pd.quantity = quantity;
                pd.discount = discount;
                pd.totals = (pd.products.FirstOrDefault().UnitPrice - pd.products.FirstOrDefault().UnitPrice * (decimal)discount) * pd.quantity;

                OrderDetails od = new OrderDetails(
                    pd.products.FirstOrDefault().productID,//todo pn неоптимальный код. ты 6 раза заставляешь linq искать первый элемент
                    pd.products.FirstOrDefault().productName,
                    pd.products.FirstOrDefault().QuantityPerUnit,
                    pd.products.FirstOrDefault().UnitPrice,
                    pd.quantity,
                    pd.discount,
                    pd.totals,
                    "NotExecuted");//todo pn возможно, в enum
				od.OrderID = orderID;
                dal.CreateOrderDetails(od);
                ViewBag.Message = "Заказ обновлен - №" + od.OrderID;//todo pn в ресурсы
				return View("Result");
            }

            ViewBag.Message += "Запрос не прошел валидацию!";//todo pn в ресурсы
			return View("Result");
        }
    }
}