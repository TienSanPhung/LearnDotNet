namespace ThreadPoolSample;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 1; i <= 10; i++) {
            int capturedI = i;

            MyThreadPool.QueueUserWorkItem(() => {
                Console.WriteLine($"{capturedI} (thread #{Environment.CurrentManagedThreadId})");
            });
        }

        Console.ReadLine();
    }
}