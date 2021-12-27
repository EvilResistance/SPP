using System;
using System.Threading;

/*
Создать на языке C# статический метод класса Parallel.WaitAll, который: 
- принимает в параметрах массив делегатов;
- выполняет все указанные делегаты параллельно с помощью пула потоков;
- дожидается окончания выполнения всех делегатов.
Реализовать простейший пример использования метода Parallel.WaitAll.
*/

namespace SPPLab7
{
    class Program
    {
        public delegate void Task(object done);
        public static void WaitAll(Task[] task)
        {
            ManualResetEvent[] doneEvents = new ManualResetEvent[task.Length];
            for (int i = 0; i < task.Length; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);//ManualResetEvent помогает понять, когда заканчивается
                ThreadPool.QueueUserWorkItem(new WaitCallback(task[i]),
                doneEvents[i]);
            }
            
            WaitHandle.WaitAll(doneEvents); 
            Console.WriteLine("All tasks are complete."); 
        }

        public static void WriteText(object obj)
        {
            ManualResetEvent doneEvent = (ManualResetEvent)obj;
            Thread.Sleep(200);
            Console.WriteLine($"Task id: {Thread.CurrentThread.ManagedThreadId}");
            doneEvent.Set();
        }

        static void Main(string[] args)
        {
            Task[] tasks = new Task[30];
            for (int i = 0; i < tasks.Length; i++)
                tasks[i] = WriteText;
            WaitAll(tasks);
            Console.ReadKey();
        }
    }
}
