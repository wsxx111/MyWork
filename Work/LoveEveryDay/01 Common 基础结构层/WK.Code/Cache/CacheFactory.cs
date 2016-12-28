using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WK.Code.Cache
{
    public class CacheFactory
    {
        public static ICache Cache()
        {
            return new Cache();
        }
    }
}
