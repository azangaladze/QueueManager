using Microsoft.AspNetCore.Mvc;

namespace QueueManagerRazor
{
    public class Repository : IRepository
    {
        private Queue<int> queue;

        private int LastServed;

        public Repository()
        {
            queue = new Queue<int>();
        }
        public Queue<int> ShowQueue()
        {
            return queue;
        }

        public int DequeueFromQueue()
        {
            var dequeued = queue.Dequeue();
            if (queue.Count == 0)
            {
                LastServed = dequeued;
            }

            return dequeued;
        }

        public Queue<int> EnqueueToQueue()
        {

            int lastTokenNumber = queue.LastOrDefault();
            if (lastTokenNumber == 0) 
            {
                lastTokenNumber = LastServed;
            }
            int nextTokenNumber = lastTokenNumber + 1;
            queue.Enqueue(nextTokenNumber);
            return queue;
        }
    }
}
