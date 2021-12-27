using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace SPP1
{
    class Program
    {
        static int stack = 0;
        static int x = 0;
        static int y = 1;
        static object locker = new object();
        static void counter()
        {
            lock (locker)
            {
                x = 1;
                for(int i = 1; i <= stack; i++)
                {
                    Console.WriteLine("Поток #{0}: {1}", y, x);
                    x++;
                    Thread.Sleep(100);
                }
                y++;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество потоков:");
            String line = Console.ReadLine();
            Char[] temp = line.ToCharArray();
            Regex regex = new Regex("[1-9]");
            line = "";
            for (int i = 0; i < temp.Length; i++)
            {
                MatchCollection matches = regex.Matches(temp[i].ToString());
                if(matches.Count > 0)
                {
                    line += temp[i];
                }
            }
            int count = Int32.Parse(line);
            stack = count;
            TaskQueue taskQueue = new TaskQueue(count);
            for(int i = 0; i < count; i++)
            {
                taskQueue.EnqueueTask(counter);
            }
            Console.ReadKey();
        }

    }
}
