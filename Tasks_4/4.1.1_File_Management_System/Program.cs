using System;
using System.IO;
using System.Threading;

using FileManagementSystem.Data.Resource;

namespace FileManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.ReadKey();
        }



        static void Method(object o, ResourceEventArgs arg)
        {
            switch (arg.TypeActionResource)
            {
                case TypeActionResource.Create:
                    Console.WriteLine($"Created: {arg.Paths[0]}, {arg.Time}");
                    break;
                case TypeActionResource.Delete:
                    Console.WriteLine($"Deleted: {arg.Paths[0]}, {arg.Time}");
                    break;
                case TypeActionResource.Change:
                    Console.WriteLine($"Change: {arg.Paths[0]}, {arg.Time}");
                    break;
                case TypeActionResource.Rename:
                    Console.WriteLine($"Rename: {arg.Paths[0]} in {arg.Paths[1]}, {arg.Time}");
                    break;
                default:
                    break;
            }
        }
    }
}
