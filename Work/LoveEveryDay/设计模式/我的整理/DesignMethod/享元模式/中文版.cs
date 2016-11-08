using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.享元模式
{
   #region  解析
    /*    
     *  外观模式（Facade），为子系统中的一组接口提供一个一致的界面，定义一个高层接口，这个接口使得这一子系统更加容易使用。
     *  引入外观角色之后，用户只需要直接与外观角色交互，用户与子系统之间的复杂关系由外观角色来实现，从而降低了系统的耦合度
     *  外观模式，我们通过外观的包装，使应用程序只能看到外观对象，而不会看到具体的细节对象，这样无疑会降低应用程序的复杂度，并且提高了程序的可维护性。
     * 
     * 
     * */

    #endregion

    //客户端调用
    public class 测试类
    {
        public static void 运行()
        {
           
            Console.ReadKey();
        }
    }

    //----------------------------------------------------------------------------------------



    public class 总开关
    {
    }
}
