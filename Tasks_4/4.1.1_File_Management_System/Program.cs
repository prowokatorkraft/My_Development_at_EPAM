using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Diagnostics;

using FileManagementSystem.Data.Resource.Monitor;
using FileManagementSystem.Data.Tracer;
using FileManagementSystem.Data.VersionStore;
using FileManagementSystem.Data;

namespace FileManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //MonitorResource monitor = new MonitorResource(@".\Test", @"*.txt");
            //monitor.MonitorAsync(new CancellationToken());

            VersionStore store = new VersionStore(@".\Store.dat");

            //store.AddVersion(new ResourceEventArgs
            //(
            //    TypeActionResource.Create,
            //    new string[] { "ffe.txt" },
            //    new string[] { @".\Test\ffe.txt" },
            //    DateTime.Now,
            //    new byte[] { 123, 223, 034, 194 }

            //));
            //store.AddVersions(new ResourceEventArgs[]
            //{   new ResourceEventArgs(
            //                TypeActionResource.Rename,
            //                new string[] { "ffr.txt", "fft.txt" },
            //                new string[] { @".\Test\ffr.txt", @".\Test\fft.txt" },
            //                DateTime.Now,
            //                new byte[] { 123, 223, 034, 194 }),
            //    new ResourceEventArgs(
            //                TypeActionResource.Change,
            //                new string[] { "ggg.txt" },
            //                new string[] { @".\Test\ggg.txt" },
            //                DateTime.Now,
            //                new byte[] { 123, 223, 147, 194 })
            //});


            //ResourceEventArgs[] resources = store.GetVersions(DateTime.Now);
            //ResourceEventArgs[] resources = store.GetVersions(DateTime.Now.AddDays(-1));

            Console.ReadKey();
        }

        
    }
}
