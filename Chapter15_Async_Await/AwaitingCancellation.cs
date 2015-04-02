namespace Chapter15_Async_Await
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;

    [Description("Cancellation of Tasks")]
    class AwaitingCancellation
    {
        static void Main()
        {
            var tokenSource = new CancellationTokenSource();
            Task task = DelayFor30Seconds(tokenSource.Token);
            tokenSource.CancelAfter(TimeSpan.FromSeconds(1));

            try
            {
                task.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Caught {0}", e.InnerExceptions[0]);
            }
        }

        static async Task DelayFor30Seconds(CancellationToken token)
        {
            Console.WriteLine("Waiting for 30 seconds ...");
            await Task.Delay(TimeSpan.FromSeconds(30), token);
        }
    }
}