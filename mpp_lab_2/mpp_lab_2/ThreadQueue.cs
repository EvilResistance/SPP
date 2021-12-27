using System;
using System.Threading;
using System.Collections.Concurrent;

namespace mpp_lab_2
{
    public class ThreadQueue
    {

        public BlockingCollection<object[]> FuncQueue = new BlockingCollection<object[]>(new ConcurrentQueue<object[]>());

        private int queueCount;

        public ThreadQueue(int queueCount)
        {
            this.queueCount = queueCount;
            for (int i = 0; i < queueCount; i++)
            {
                var thread = new Thread(ThreadWork);
                thread.Start();
            }
        }

        public void ThreadWork()
        {
            while (true)
            {
                object[] task = FuncQueue.Take();
                try
                {

                    ((DirectoryWork)task[0]).CopyFile((string)task[1], (string)task[2]);
                }
                catch (ThreadStateException ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ThreadAbortException ex) 
                
                {
                    Thread.ResetAbort();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void EnqueueTask(object directoryWork,
            string file1, string file2)
        {
            this.FuncQueue.Add(new object[] { directoryWork, file1, file2 });
        }
    }
}