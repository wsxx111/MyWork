using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WK.Code
{
    public static class Json
    {
        //把json字符串转为json对象
        public static object ToJson(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject(Json);
        }

        /*
         * 但是如果对象中存在日期类型属性时，序列化后格式是    {"UserId":1,"UserName":"李 刚","CreateDate":"\/Date(353521211984)\/"}  
         * 其中日期会被转换成Date(353521211984)，其中Date代表的是日期，353521211984是毫秒
         * 上面的格式看起来非常不方便，所以我们应该转换成普通的日期格式如：2013-01-15 12:13:14
         * Newtonsoft.Json里面有一个类IsoDateTimeConverter可以转换日期
         * 利用IsoDateTimeConverter转换后结果  new IsoDateTimeConverter().DateTimeFormat = "yyyy-MM-dd HH:mm:ss";  
         * {"UserId":1,"UserName":"李 刚","CreateDate":"2013-01-15 12:13:14"}
         * */

        //序列化对象成json字符串
        public static string ToJson(this object obj)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }

        //转换对象有时间转换指定格式
        public static string ToJson(this object obj, string datetimeformats)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = datetimeformats };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }


        //扩展
        public static T ToObject<T>(this string Json)
        {
            return Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json);
        }


        public static List<T> ToList<T>(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<List<T>>(Json);
        }


        public static DataTable ToTable(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<DataTable>(Json);
        }


        public static JObject ToJObject(this string Json)
        {
            return Json == null ? JObject.Parse("{}") : JObject.Parse(Json.Replace("&nbsp;", ""));
        }

    }
}
