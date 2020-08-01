using System;

using FileManagementSystem.Logic.Monitoring;
using FileManagementSystem.Logic.Recovery;

namespace FileManagementSystem.PL
{
    internal class PresentationConsole
    {
        private IConsole console;

        public PresentationConsole()
        {
            Start();
        }

        private IConsole InitializeConsole(int enter)
        {
            switch (enter)
            {
                case 1:
                    return new MonitoringConsole(new Monitoring());
                case 2:
                    return new RecoveryConsole(new Recovery());
                case 0:
                default:
                    return null;
            }
        }

        private void Start()
        {
            int enter = -1;

            while (enter != 0)
            {
                Console.WriteLine("Select the operating mode:\n" +
                                  "1. Monitoring\n" +
                                  "2. Rollback\n" +
                                  "0. Exit"
                                  );

                int.TryParse(Console.ReadLine(), out enter);

                Console.Clear();
                Console.WriteLine("Press any key to exit ...");

                if ((console = InitializeConsole(enter)) != null)
                {
                    console.Start();
                    break;
                }
            }
        }
    }
}
