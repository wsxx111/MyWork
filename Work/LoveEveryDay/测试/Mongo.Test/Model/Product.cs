using MongoDB.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mongo.Test.Model
{
    public class Product
    {
        [MongoId]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryID { get; set; }
        public string Unit { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Remark { get; set; }
    }
}