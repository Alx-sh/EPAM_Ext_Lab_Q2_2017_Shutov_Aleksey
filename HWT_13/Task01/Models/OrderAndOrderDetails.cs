using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task01
{
    public class OrderAndOrderDetails
    {
        public Order o { get; set; }
        public List<OrderDetails> od { get; set; }
    }
}