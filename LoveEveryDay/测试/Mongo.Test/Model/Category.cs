using MongoDB.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mongo.Test.Model
{
    public class Category
    {
        [MongoId]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}