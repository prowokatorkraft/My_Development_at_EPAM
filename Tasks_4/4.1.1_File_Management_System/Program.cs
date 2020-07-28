using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

using FileManagementSystem.Data.Resource;
using FileManagementSystem.Data.Tracer;

namespace FileManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Tracer tracer = new Tracer("Log.txt");

            tracer.TraceEvent(new ResourceEventArgs(
                TypeActionResource.Create, 
                new string[] { "test.txt" },
                new string[] { @".\test.txt" },
                DateTime.Now));
            tracer.TraceEvent(new ResourceEventArgs(
                TypeActionResource.Delete,
                new string[] { "test.txt" },
                new string[] { @".\test.txt" },
                DateTime.Now));
            tracer.TraceEvent(new ResourceEventArgs(
                TypeActionResource.Change,
                new string[] { "test.txt" },
                new string[] { @".\test.txt" },
                DateTime.Now));
            tracer.TraceEvent(new ResourceEventArgs(
                TypeActionResource.Rename,
                new string[] { "test.txt", "test1.txt" },
                new string[] { @".\test.txt", @".\test1.txt" },
                DateTime.Now));

            tracer.Close();

            Console.ReadKey();
        }
    }
}
