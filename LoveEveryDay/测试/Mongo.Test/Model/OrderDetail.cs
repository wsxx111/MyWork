using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mongo.Test.Model
{
    public class OrderDetail
    {
        public string OrderID { get; set; }
        public string ProductID { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
    }
}