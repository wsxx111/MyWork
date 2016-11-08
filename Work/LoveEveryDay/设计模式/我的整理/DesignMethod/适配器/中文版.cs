using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.适配器
{
    #region  解析
    /*    
     *  适配器模式将一个接口转换成客户希望的另外一个接口。它使得原来由于接口不兼容而不能在一起工作的那些类可以一起工作。
     * 
     * 共有两类适配器模式：
     * 对象适配器模式
     * -- 在这种适配器模式中，适配器容纳一个它包裹的类的实例。在这种情况下，适配器调用被包裹对象的物理实体。
     * 类适配器模式
     * -- 这种适配器模式下，适配器继承自已实现的类（一般多重继承）。
     * 
     * 适配器模式的三个特点：
     * 1 适配器对象实现原有接口 
     * 2 适配器对象组合一个实现新接口的对象（这个对象也可以不实现一个接口，只是一个单纯的对象） 
     * 3 对适配器原有接口方法的调用被委托给新接口的实例的特定方法 
     * 
     * */

    #endregion

    //客户端调用
    public class 测试类
    {
        public static void 运行()
        {
            中标接口 zh = new 中国插座();           
            适配器 ad = new 适配器(zh);
            德国宾馆 hotel = new 德国宾馆();
            hotel.设为德标(ad);
            hotel.充电();          

            Console.ReadKey();
        }
    }

    //----------------------------------------------------------------------------------------

   // 德国接口的插座通过 适配器 变成中国接口的中国插座

    public abstract class 德标接口
    {
        public abstract void 两孔德国插座();
    }


    public class 德国插座 : 德标接口
    {
        public override void 两孔德国插座()
        {
            Console.WriteLine("现在是德国两孔插座");
        }
    }


    public class 德国宾馆
    {
        private 德标接口 symbol;

        public 德国宾馆()
        {
        }

        public 德国宾馆(德标接口 symbolIn)
        {
            this.symbol = symbolIn;
        }

        public void 设为德标(德标接口 symbolIn)
        {
            this.symbol = symbolIn;
        }

        public void 充电()
        {
            symbol.两孔德国插座();
        }
    }


    public abstract class 中标接口
    {
        public abstract void 两孔中国插座();
    }

    public class 中国插座 : 中标接口
    {
        public override void 两孔中国插座()
        {
            Console.WriteLine("现在是中国两孔插座");
        }
    }

    public class 适配器 : 德标接口
    {
        private 中标接口 gbsymbol;

        public 适配器(中标接口 gbsymbolIn)
        {
            this.gbsymbol = gbsymbolIn;
        }

        public override void 两孔德国插座()
        {
            gbsymbol.两孔中国插座();
        }

    }

}
