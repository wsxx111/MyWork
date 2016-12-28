using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WK.Code;

namespace WK.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string key = "2016_fang";
            string unStr = "wangkai_1738&2?3";
            string Str = DESEncrypt.Encrypt(unStr, key);
            string getStr = DESEncrypt.Decrypt(Str, key);

        }
    }
}