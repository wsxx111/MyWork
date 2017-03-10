using MongoDB.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Mongo.Test.Model
{
    public class OrderItem
    {
        [MongoId]		// 这个成员将映射到 "_id"
        public string OrderID { get; set; }
        [ScriptIgnore]
        public string CustomerID { get; set; }
        [ScriptIgnore]	// 在JSON序列化时，忽略这个成员
        public DateTime OrderDate { get; set; }

        public double SumMoney { get; set; }

        public string Comment { get; set; }

        public bool Finished { get; set; }

        [MongoIgnore]	// 在保存到MongoDB时，忽略这个成员
        public string CustomerName { get; set; }

        public List<OrderDetail> Detail;
    }
}