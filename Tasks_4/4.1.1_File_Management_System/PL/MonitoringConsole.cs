using System;

using FileManagementSystem.Logic.Monitoring;

namespace FileManagementSystem.PL
{
    internal class MonitoringConsole : IConsole
    {
        protected readonly IMonitoring monitoring;

        public MonitoringConsole(IMonitoring monitoring)
        {
            this.monitoring = monitoring;

            Start();
        }

        public void Start()
        {
            int enter = -1;

            while (enter != 0)
            {
                monitoring.Start();

                int.TryParse(Console.ReadLine(), out enter);
            }

            monitoring.Stop();
            (monitoring as IDisposable)?.Dispose();
        }
    }
}
