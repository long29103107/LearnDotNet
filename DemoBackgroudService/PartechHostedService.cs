namespace DemoBackgroudService
{
    public class PartechHostedService : IHostedService
    {
        private Timer _timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(HelloWorld, null, 0, 10000);
            return Task.CompletedTask;
        }

        void HelloWorld(object state)
        {
            Console.WriteLine(DateTime.Now.ToString() + " Welcome to Partech World");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
