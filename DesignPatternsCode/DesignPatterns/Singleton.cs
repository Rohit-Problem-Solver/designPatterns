using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public sealed class Singleton
    {
        private static int counter = 0;
        private static Singleton instance = null;
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                {
                    //lock ()
                        {

                            if (instance == null)
                                instance = new Singleton();
                            return instance;
                        } 
                }
                return instance;
            }
        }

        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }

        public void PrintDetails(string message)
        {
            for (int i = 2; i < 1000; i = i + 2)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }

    public class ExecutionClass
    {
        public void Execute()
        {

            //Singleton fromTeachaer = Singleton.GetInstance;
            //fromTeachaer.PrintDetails("From Teacher");
            //Singleton fromStudent = Singleton.GetInstance;
            //fromStudent.PrintDetails("From Student");

            Singleton fromTeachaer = Singleton.GetInstance;
            //Thread t1 = new Thread(() => fromTeachaer.PrintDetails("From Teacher"));

            Singleton fromStudent = Singleton.GetInstance;
            //Thread t2 = new Thread(() => fromStudent.PrintDetails("From Student"));

            //t1.Start();
            //t2.Start();


            Task task1 = Task.Factory.StartNew(() => fromTeachaer.PrintDetails("From Teacher"));
            Task task2 = Task.Factory.StartNew(() => fromTeachaer.PrintDetails("From Student"));
            Task.WaitAll(task1, task2);

            Console.ReadLine();
        }
    }
}
