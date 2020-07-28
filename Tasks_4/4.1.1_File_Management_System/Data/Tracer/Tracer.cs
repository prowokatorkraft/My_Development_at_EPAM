using System;
using System.IO;
using System.Diagnostics;

using FileManagementSystem.Data.Resource;

namespace FileManagementSystem.Data.Tracer
{
    internal class Tracer : AbstractTrace
    {
        TraceListener[] listeners;

        public Tracer(string fileName)
        {
            Trace.AutoFlush = true;

            listeners = new TraceListener[]
            {
                new TextWriterTraceListener(Console.Out),
                new TextWriterTraceListener(File.AppendText(fileName))
            };
            foreach (var item in listeners)
            {
                Trace.Listeners.Add(item);
            }

            Trace.WriteLine($"Trace Started: {DateTime.Now}");
            Trace.Indent();
        }

        public override void Close()
        {
            Trace.Unindent();
            Trace.WriteLine($"Trace Finished: {DateTime.Now}");

            foreach (var item in listeners)
            {
                Trace.Listeners.Remove(item);
            }
        }

        /// <exception cref="Exception"> Undefined TypeActionResource in ResourceEventArgs </exception>
        public override void TraceEvent(ResourceEventArgs arg)
        {
            switch (arg.TypeActionResource)
            {
                case TypeActionResource.Create:
                    Trace.WriteLine($"{arg.Time}  Created {arg.Paths[0]}");
                    break;
                case TypeActionResource.Delete:
                    Trace.WriteLine($"{arg.Time}  Deleted {arg.Paths[0]}");
                    break;
                case TypeActionResource.Change:
                    Trace.WriteLine($"{arg.Time}  Changed {arg.Paths[0]}");
                    break;
                case TypeActionResource.Rename:
                    Trace.WriteLine($"{arg.Time}  Renamed {arg.Paths[0]} to {arg.Names[1]}");
                    break;
                default:
                    throw new Exception("Undefined TypeActionResource in ResourceEventArgs");
            }
        }
    }
}
