using System;
using System.Threading;

/*Создать класс на языке C#, который: 
- называется Mutex и реализует двоичный семафор
с помощью атомарной операции Interlocked.CompareExchange. 
- обеспечивает блокировку и разблокировку двоичного
семафора с помощью public-методов Lock и Unlock.
*/
namespace mpp_lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 10;
            Mutex mutex = new Mutex();
            for (int i = 0; i < N; i++)  
            {
                new Thread(() =>
                {
                    mutex.Lock();
                    Console.WriteLine("current Thread id: " + Thread.CurrentThread.ManagedThreadId + " lock Thread");
                    Thread.Sleep(400);
                    Console.WriteLine("current Thread id: " + Thread.CurrentThread.ManagedThreadId + " unlock Thread");
                    mutex.Unlock();
                }
                ).Start();
            }
            Console.ReadKey();
        }
    }
}