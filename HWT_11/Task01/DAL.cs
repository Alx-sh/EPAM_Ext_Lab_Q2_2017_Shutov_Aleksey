namespace Task01
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class DAL//todo pn не очень хорошо, что ты не разбил файлы классов по подпапкам. Напрашивается как минимум одна папка "Models".
    {
        private string connectionString;
        public DateTime? dateNULL = null;

        public DAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Показывает список введенных заказов (таблица [Orders]). 
        /// </summary>
        /// <returns>Список заказов.</returns>
        public List<Order> ShowOrders()
        {
            List<Order> orders = new List<Order>();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"SELECT OrderID
                            ,CustomerID
                            ,EmployeeID
                            ,OrderDate
                            ,RequiredDate
                            ,ShippedDate
                            ,ShipVia
                            ,Freight
                            ,ShipName
                            ,ShipAddress
                            ,ShipCity
                            ,ShipRegion
                            ,ShipPostalCode
                            ,ShipCountry
                      FROM Northwind.Orders";
                command.CommandType = CommandType.Text;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int OrderID = reader.GetInt32(0);
                        string CustomerID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        int EmployeeID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        DateTime? OrderDate = reader.IsDBNull(3) ? dateNULL : reader.GetDateTime(3);
                        DateTime? RequiredDate = reader.IsDBNull(4) ? dateNULL : reader.GetDateTime(4);
                        DateTime? ShippedDate = reader.IsDBNull(5) ? dateNULL : reader.GetDateTime(5);
                        int ShipVia = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                        decimal Freight = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7);
                        string ShipName = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        string ShipAddress = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        string ShipCity = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        string ShipRegion = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        string ShipPostalCode = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        string ShipCounty = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);

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
                            ShipCounty
                            );
                        orders.Add(o);
                    }
                }
            }
            return orders;
        }

        /// <summary>
        /// Показывает подробные сведения о конкретном заказе, включая номенклатуру заказа
        /// (таблицы[Orders], [Order Details], и [Products], требуется извлекать как Id, так и название продукта).
        /// </summary>
        /// <param name="OrderID">Номер заказа.</param>
        /// <returns>Список сведений о заказе.</returns>
        public List<OrderDetails> ShowOrderDetails(int OrderID)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"SELECT p.ProductID
                            ,p.ProductName
                            ,p.QuantityPerUnit
                            ,od.UnitPrice
	                        ,od.Quantity
                            ,od.Discount
	                        ,CONVERT(MONEY, ROUND(SUM((od.UnitPrice - od.UnitPrice * od.Discount) * od.Quantity), 2), 1) AS 'Totals'
	                        ,CASE 
			                    WHEN o.OrderDate IS NULL THEN 'New' 
			                    WHEN o.ShippedDate IS NULL THEN 'NotExecuted' 
			                    WHEN o.ShippedDate IS NOT NULL THEN 'Executed' 
	                         END AS Status
                      FROM Northwind.Orders AS o
                      JOIN Northwind.[Order Details] AS od 
                      ON o.OrderID = od.OrderID
                      JOIN Northwind.Products AS p 
                      ON od.ProductID = p.ProductID 
                      WHERE o.OrderID = @OrderID
                      GROUP BY p.ProductID
                      		  ,p.ProductName
                      		  ,p.QuantityPerUnit
                      		  ,od.UnitPrice
                      		  ,od.Quantity
                      		  ,od.Discount
                      		  ,o.OrderDate
                      		  ,o.ShippedDate";

                Parameter(command, "@OrderID", OrderID, DbType.Int32);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ProductID = reader.GetInt32(0);
                        string ProductName = reader.GetString(1);
                        string QuantityPerUnit = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        decimal UnitPrice = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
                        int Quantity = reader.IsDBNull(4) ? 0 : reader.GetInt16(4);
                        float Discount = reader.IsDBNull(5) ? 0 : reader.GetFloat(5);
                        decimal Totals = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6);
                        string Status = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);

                        OrderDetails p = new OrderDetails(
                            ProductID,
                            ProductName,
                            QuantityPerUnit,
                            UnitPrice,
                            Quantity,
                            Discount,
                            Totals,
                            Status
                            );
                        orderDetails.Add(p);
                    }
                }
                return orderDetails;
            }
        }

        /// <summary>
        /// Создает новый заказ.
        /// </summary>
        /// <param name="NewOrder">Добавляемый заказ.</param>
        public void CreateOrder(Order order)
        {
            List<int> ShipsVia = new List<int>();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"INSERT INTO Northwind.Orders(
                                CustomerID
                               ,EmployeeID
                               ,OrderDate
                               ,RequiredDate
                               ,ShippedDate
                               ,ShipVia
                               ,Freight
                               ,ShipName
                               ,ShipAddress
                               ,ShipCity
                               ,ShipRegion
                               ,ShipPostalCode
                               ,ShipCountry)
                        values(
                                @CustomerID
                               ,@EmployeeID
                               ,@OrderDate
                               ,@RequiredDate
                               ,@ShippedDate
                               ,@ShipVia
                               ,@Freight
                               ,@ShipName
                               ,@ShipAddress
                               ,@ShipCity
                               ,@ShipRegion
                               ,@ShipPostalCode
                               ,@ShipCountry)";

                Parameter(command, "@CustomerID", order.CustomerID, DbType.String);
                Parameter(command, "@EmployeeID", order.EmployeeID, DbType.Int32);
                Parameter(command, "@OrderDate", order.OrderDate, DbType.DateTime);
                Parameter(command, "@RequiredDate", order.RequiredDate, DbType.DateTime);
                Parameter(command, "@ShippedDate", order.ShippedDate, DbType.DateTime);
                Parameter(command, "@ShipVia", order.ShipVia, DbType.Int32);
                Parameter(command, "@Freight", order.Freight, DbType.Decimal);
                Parameter(command, "@ShipName", order.ShipName, DbType.String);
                Parameter(command, "@ShipAddress", order.ShipAddress, DbType.String);
                Parameter(command, "@ShipCity", order.ShipCity, DbType.String);
                Parameter(command, "@ShipRegion", order.ShipRegion, DbType.String);
                Parameter(command, "@ShipPostalCode", order.ShipPostalCode, DbType.String);
                Parameter(command, "@ShipCountry", order.ShipCounty, DbType.String);

                int number = command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Передает заказ в работу: устанавливает дату заказа.
        /// </summary>
        /// <param name="date">Новая дата заказа.</param>
        /// <param name="OrderID">Номер заказа.</param>
        public void SetOrderDate(DateTime? date, int OrderID)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"UPDATE Northwind.Orders 
                    SET OrderDate = CONVERT(DATETIME, '" +
                    date +
                    "', 103) WHERE OrderID = @OrderID";

                Parameter(command, "@OrderID", OrderID, DbType.Int32);

                int number = command.ExecuteNonQuery();
            }
        }

        // <summary>
        /// Помечает как выполненный: устанавливает ShippedDate.
        /// </summary>
        /// <param name="date">Новая дата ShippedDate.</param>
        /// <param name="OrderID">Номер заказа.</param>
        public void SetShippedDate(DateTime? date, int OrderID)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"UPDATE Northwind.Orders 
                    SET ShippedDate = CONVERT(DATETIME, '" +
                    date +
                    "', 103) WHERE OrderID = @OrderID AND OrderDate IS NOT NULL";

                Parameter(command, "@OrderID", OrderID, DbType.Int32);

                int number = command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Получать статистику по заказам, используя готовые хранимые процедуры: CustOrderHist
        /// </summary>
        /// <param name="CustomerID">Номер покупателя.</param>
        /// <returns>Список покупок.</returns>
        public List<CustOrderHist> ViewCustOrderHist(string CustomerID)
        {
            List<CustOrderHist> custOrderHist = new List<CustOrderHist>();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "Northwind.CustOrderHist";
                command.CommandType = CommandType.StoredProcedure;

                Parameter(command, "@CustomerID", CustomerID, DbType.String);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ProductName = reader.GetString(0);
                        int Total = reader.GetInt32(1);

                        custOrderHist.Add(new CustOrderHist(ProductName, Total));
                    }
                }
                return custOrderHist;
            }
        }

        /// <summary>
        /// Получать статистику по заказам, используя готовые хранимые процедуры: CustOrdersDetail.
        /// </summary>
        /// <param name="OrderID">Номер заказа.</param>
        /// <returns>Информация по заказу.</returns>
        public List<CustOrdersDetail> ViewCustOrdersDetail(int OrderID)
        {
            List<CustOrdersDetail> custOrdersDetail = new List<CustOrdersDetail>();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "Northwind.CustOrdersDetail";
                command.CommandType = CommandType.StoredProcedure;

                Parameter(command, "@OrderID", OrderID, DbType.Int32);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ProductName = reader.GetString(0);
                        decimal UnitPrice = reader.GetDecimal(1);
                        int Quantity = reader.GetInt16(2);
                        int Discount = reader.GetInt32(3);
                        decimal ExtendedPrice = reader.GetDecimal(4);

                        custOrdersDetail.Add(new CustOrdersDetail(ProductName, UnitPrice, Quantity, Discount, ExtendedPrice));
                    }
                }
                return custOrdersDetail;
            }
        }

        /// <summary>
        /// Удаление добавленных заказов (для unit test).
        /// </summary>
        public void DeleteOrder()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"DELETE FROM Northwind.Orders
                      WHERE OrderID > 11077";

                int number = command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Добавление параметров в команду.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        private void Parameter<T>(IDbCommand command, string name, T value, DbType type)
        {
            IDbDataParameter Param = command.CreateParameter();
            Param.ParameterName = name;
            Param.Value = value;
            Param.DbType = type;
            command.Parameters.Add(Param);
        }
    }
}
