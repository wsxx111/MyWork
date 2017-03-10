using Mongo.Test.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WK.Data;

namespace Mongo.Test
{
    public partial class InportData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //导入数据
        protected void importDataBtn_Click(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Request.IsLocal == false)
            {
                Response.Write("<script>alert('你不能执行这个操作')</script>");
            }
            else
            {
                using (MongoDB.Mongo m = new MongoDB.Mongo("Server=127.0.0.1"))
                {
                    DBHelper.ConString = ConfigurationManager.AppSettings["SqlConnection"];
                    var db = m.GetDatabase("Northwind");
                    string sql1 = "select * from Customers";
                    List<Category> categoryList = DBHelper.DataTableToList<Category>(DBHelper.GetDataTable(sql1));
                    int dd = categoryList.Count;
                    //string sql2 = "select * from Products";
                    //Dictionary<string, Product> productList = DBHelper.DataTableToList<Product>(DBHelper.GetDataTable(sql2)).ToDictionary(x => x.ProductID.ToString());

                    string sql3 = "select * from Orders";
                    List<OrderItem> ordeList = DBHelper.DataTableToList<OrderItem>(DBHelper.GetDataTable(sql3));
                    

                    string sql4 = "select * from [OrderDetails]";
                    List<OrderDetail> detailList = DBHelper.DataTableToList<OrderDetail>(DBHelper.GetDataTable(sql4));

                    // 补入一些原SqlServer表中没有字段信息
                    Product product = null;
                    foreach (OrderDetail dt in detailList)
                    {
                        //product = productList[dt.ProductID];
                        dt.ProductName = product.ProductName;
                        dt.Unit = product.Unit;
                    }

                    // 然后，清空MongoDB中所有数据。
                    var categories = db.GetCollection<Category>();
                    // categories.Remove(x => true);                

                    var products = db.GetCollection<Product>();
                    //  products.Remove(x => true);

                    var orders = db.GetCollection<OrderItem>("Orders");
                    //  orders.Remove(x => true);

                    //  categoryList.ForEach(x => categories.Insert(x));                    
                    // foreach (var p in productList)
                    //    products.Insert(p.Value);


                    // MongoDB不支持事务，为了能保证订单明细与主记录一起被【同步】保存，所以明细记录不单独保存。
                    //foreach (OrderItem ord in ordeList)
                    //{
                    //    ord.Detail = detailList.Where(x => x.OrderID == ord.OrderID).ToList();
                    //    orders.Insert(ord);
                    //}
                }
            }
        }

    }
}