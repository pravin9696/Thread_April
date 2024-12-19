using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Thread_April
{
    class MyClass
    {
        public void PrintSeries()
        {
            lock (this)
            {
                Console.WriteLine();
                for (int i = 1; i <= 50; i++)
                {
                    Console.Write(" " + i);
                    Thread.Sleep(100);
                }
           
            //Thread.Sleep(1000);
           
                Console.WriteLine();
                for (int i = 51; i <= 100; i++)
                {
                    Console.Write(" " + i);
                    Thread.Sleep(100);
                }
            }
        }
        public void method1()
        {
            Thread t = Thread.CurrentThread;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"##{t.Name} Method1 i:" + i);
                Thread.Sleep(100);
            }
        }
        public void method2()
        {
            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"**{Thread.CurrentThread.Name} Method2 i:" + i);
                Thread.Sleep(100);
            }
        }
    }
    internal class Program
    {
      
        static void Main(string[] args)
        {
            MyClass mobj = new MyClass();

            // Total Threads  1: Main   2: t1   3: t2
            //Thread t1 = new Thread(mobj.method1);//thread create
            //Thread t2= new Thread(mobj.method2);
            //t1.Name = "T1";
            //t2.Name = "T2";
            //t1.Start();
            //t2.Start();

            Thread t1 = new Thread(mobj.PrintSeries);
            Thread t2 = new Thread(mobj.PrintSeries);
            t1.Start();
            t2.Start();
            Console.WriteLine("Done....");
            Console.ReadKey();
        }
    }
}
