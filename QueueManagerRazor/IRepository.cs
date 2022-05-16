namespace QueueManagerRazor
{
    public interface IRepository
    {
        int DequeueFromQueue();
        Queue<int> EnqueueToQueue();
        Queue<int> ShowQueue();

    }
}
