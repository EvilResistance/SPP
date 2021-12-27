using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace SPP1
{
    public delegate void TaskDelegate();
    class TaskQueue
    {
        static object locker = new object();
        private BlockingCollection<TaskDelegate> QueueFunc = new BlockingCollection<TaskDelegate>(new ConcurrentQueue<TaskDelegate>()); 
        
        public TaskQueue(int count)
        {
            for(int i = 0; i < count; i++)
            {
                Thread thread = new Thread(Write) { IsBackground = true }; ;
                thread.Start();
            }
        }

        public void Write()
        {
            lock (locker)
            {
                while (true)
                {
                    var task = QueueFunc.Take();
                    try
                    {
                        task();
                    }
                    catch(ThreadStateException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (ThreadAbortException ex)
                    {
                        Thread.ResetAbort();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            this.QueueFunc.Add(task);
        }
    }
}
