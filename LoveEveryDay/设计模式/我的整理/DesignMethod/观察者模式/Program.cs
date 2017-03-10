using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignMethod.观察者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            #region 观察者模式

            TenXun tenXun = new TenXunGame("腾讯游戏", "建立了一个腾讯游戏");
            //添加订阅者
            tenXun.AddObserver(new Subscriber("学习硬件"));
            tenXun.AddObserver(new Subscriber("汤姆"));
            tenXun.Update();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("移除汤姆订阅者");
            tenXun.RemoveObserver(new Subscriber("汤姆"));
            tenXun.Update();

            #endregion 观察者模式

            #region 观察者模式使用委托

            //TenXunWt tenXun = new TenXunGameWt("腾讯游戏", "建立了一个腾讯游戏");
            ////添加订阅者
            //SubscriberWt lh = new SubscriberWt("学习硬件");
            //SubscriberWt tom = new SubscriberWt("汤姆");
            //tenXun.AddObserver(new 观察者模式.NotifyEventHandler(lh.ReceiveAndPrint));
            //tenXun.AddObserver(new 观察者模式.NotifyEventHandler(tom.ReceiveAndPrint));
            //tenXun.Update();
            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine("移除汤姆订阅者");
            //tenXun.RemoveObserver(new 观察者模式.NotifyEventHandler(tom.ReceiveAndPrint));
            //tenXun.Update();

            #endregion 观察者模式使用委托

            Console.ReadLine();
        }
    }



    //订阅号抽象类
    public abstract class TenXun
    {
        //保留订阅号列表
        private List<IObserver> observers = new List<IObserver>();

        public TenXun(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        public string Info { get; set; }
        public string Symbol { get; set; }

        #region 新增对订阅号列表的维护操作

        public void AddObserver(IObserver ob)
        {
            observers.Add(ob);
        }

        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);
        }

        #endregion 新增对订阅号列表的维护操作

        public void Update()
        {
            //遍历订阅者列表进行通知
            foreach (IObserver ob in observers)
            {
                if (ob != null)
                {
                    ob.ReceiveAndPrint(this);
                }
            }
        }
    }

    //具体订阅号
    public class TenXunGame : TenXun
    {
        public TenXunGame(string symbol, string info)
            : base(symbol, info)
        { }
    }


    //订阅者接口
    public interface IObserver
    {
        void ReceiveAndPrint(TenXun tenxun);
    }

    //具体订阅类
    public class Subscriber : IObserver
    {
        public Subscriber(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void ReceiveAndPrint(TenXun tenxun)
        {
            Console.WriteLine("通知：{1}的{0}信息是: {2}", Name, tenxun.Symbol, tenxun.Info);
        }
    }







    //委托--------------------------------------------------------------------------------------------------------------------------------------------------
    public delegate void NotifyEventHandler(object sender);

    //腾讯
    public class TenXunWt
    {
        //保留订阅号列表
        public event NotifyEventHandler NotifyEvent;

        public TenXunWt(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        public string Info { get; set; }
        public string Symbol { get; set; }

        #region 新增对订阅号列表的维护操作

        public void AddObserver(NotifyEventHandler ob)
        {
            NotifyEvent += ob;
        }

        public void RemoveObserver(NotifyEventHandler ob)
        {
            NotifyEvent -= ob;
        }

        #endregion 新增对订阅号列表的维护操作

        public void Update()
        {
            if (NotifyEvent != null)
            {
                NotifyEvent(this);
            }
        }
    }


    //腾讯游戏
    public class TenXunGameWt : TenXunWt
    {
        public TenXunGameWt(string symbol, string info)
            : base(symbol, info)
        {
        }
    }

    //委托
    public class SubscriberWt
    {
        public SubscriberWt(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void ReceiveAndPrint(Object ob)
        {
            TenXunWt tenxun = ob as TenXunWt;
            if (tenxun != null)
            {
                Console.WriteLine("通知：{1}的{0}信息是: {2}", Name, tenxun.Symbol, tenxun.Info);
            }
        }
    }



}
