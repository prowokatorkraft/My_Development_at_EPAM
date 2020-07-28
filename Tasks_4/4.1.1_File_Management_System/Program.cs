using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

using FileManagementSystem.Data.Resource.Monitor;
using FileManagementSystem.Data.Tracer;
using FileManagementSystem.Data;

namespace FileManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            MonitorResource monitor = new MonitorResource(@".\Test", @"*.txt");

            monitor.DetectActionEvent += Test;

            monitor.MonitorAsync(new CancellationToken());

            Console.ReadKey();
        }

        static void Test<T>(object o, T arg)
        {
        }
    }
}
