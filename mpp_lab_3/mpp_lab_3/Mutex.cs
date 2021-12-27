using System.Threading;

namespace mpp_lab_3
{
    public class Mutex
    {
        private int currentId = -1;
        public void Lock()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            while (Interlocked.CompareExchange(ref this.currentId, id, -1) != -1)                                                                 
            {
            }
        }

        public void Unlock()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            Interlocked.CompareExchange(ref this.currentId, -1, id);
        }
    }
}