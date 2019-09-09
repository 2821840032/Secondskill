using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test001
{
    class Program
    {
        /// <summary>
        /// 消息队列
        /// </summary>
        static Queue<string> AQueue = new Queue<string>();

        static void Main(string[] args)
        {
            InitQueue();

            Parallel.For(0, 20, (id) =>
            {
                Consumption(id);
            });



            Console.Read();
        }
        /// <summary>
        /// 消费消息
        /// </summary>
        static void Consumption(long ID)
        {

            if (AQueue.Count > 0)
            {
                string prodeName = AQueue.Dequeue();
                Console.WriteLine("哈，我抢到了"+ prodeName+":"+ID);
            }
            else
            {
                Console.WriteLine("我没有抢到" + ID);
            }

        }

        /// <summary>
        /// 开启线程发布消息
        /// </summary>
        static void InitQueue()
        {
            AQueue.Enqueue("电脑");
            AQueue.Enqueue("手机");
            AQueue.Enqueue("笔记本");
            AQueue.Enqueue("书包");
            AQueue.Enqueue("女朋友");
            AQueue.Enqueue("电饭煲");
        }
    }
}
