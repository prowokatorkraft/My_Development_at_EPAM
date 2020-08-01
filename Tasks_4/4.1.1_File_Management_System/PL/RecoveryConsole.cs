using System;

using FileManagementSystem.Logic.Recovery;

namespace FileManagementSystem.PL
{
    internal class RecoveryConsole : IConsole
    {
        protected readonly IRecovery _recovery;

        public RecoveryConsole(IRecovery recovery)
        {
            _recovery = recovery;
        }

        public void Start()
        {
            DateTime time = DateTime.Now;

            Console.WriteLine("Enter the date for recovery (dd/MM/yyyy HH:mm:ss):");

            if (DateTime.TryParse(Console.ReadLine(), out time))
            {
                _recovery.ReturnVersion(time);
            }
        }
    }
}
