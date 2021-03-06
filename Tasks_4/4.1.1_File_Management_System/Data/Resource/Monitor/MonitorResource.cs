﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FileManagementSystem.Data.Resource.Monitor
{
    internal class MonitorResource : IMonitorResource
    {
        public event EventHandler<ResourceEventArgs> DetectActionEvent;
        public string PathResource { get; }
        public string FilterResource { get; }

        public MonitorResource(string pathFolder, string filter)
        {
            DetectActionEvent += DetectActionEventNull;

            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
            }
            PathResource = pathFolder;

            if (!Regex.IsMatch(filter, @".+\.[a-z]+$"))
            {
                throw new ArgumentException("Incorrect filter!");
            }
            FilterResource = filter;
        }

        public async Task MonitorAsync(CancellationToken token)
        {
            Task task = new Task(Run, token);
            task.Start();

            await task;
        }

        /// <exception cref="ArgumentException"> Incorrect token. Token must be CancellationToken! </exception>
        protected void Run(object token)
        {
            if (!(token is CancellationToken))
            {
                throw new ArgumentException("Incorrect token. Token must be CancellationToken!");
            }
            CancellationToken _token = (CancellationToken)token;

            using (FileSystemWatcher watcher = new FileSystemWatcher(PathResource, FilterResource))
            {
                watcher.IncludeSubdirectories = true;

                watcher.Changed += ChangedResource;
                watcher.Created += CreatedResource;
                watcher.Deleted += DeletedResource;
                watcher.Renamed += RenamedResource;

                watcher.EnableRaisingEvents = true;

                while (!_token.IsCancellationRequested)
                {

                }
            }
        }

        protected void ChangedResource(object o, FileSystemEventArgs arg)
        {
            InvokeDetectActionEvent(o, new ResourceEventArgs(
                                                             TypeActionResource.Change,
                                                             new string[] { Path.GetFileName(arg.FullPath) },
                                                             new string[] { arg.FullPath },
                                                             DateTime.Now,
                                                             GetFileByte(arg.FullPath)
                                                            ));
        }
        protected void CreatedResource(object o, FileSystemEventArgs arg)
        {
            InvokeDetectActionEvent(o, new ResourceEventArgs(
                                                             TypeActionResource.Create,
                                                             new string[] { Path.GetFileName(arg.FullPath) },
                                                             new string[] { arg.FullPath },
                                                             DateTime.Now,
                                                             GetFileByte(arg.FullPath)
                                                            ));
        }
        protected void DeletedResource(object o, FileSystemEventArgs arg)
        {
            InvokeDetectActionEvent(o, new ResourceEventArgs(
                                                             TypeActionResource.Delete,
                                                             new string[] { Path.GetFileName(arg.FullPath) },
                                                             new string[] { arg.FullPath },
                                                             DateTime.Now,
                                                             GetFileByte(arg.FullPath)
                                                            ));
        }
        protected void RenamedResource(object o, RenamedEventArgs arg)
        {
            InvokeDetectActionEvent(o, new ResourceEventArgs(
                                                             TypeActionResource.Rename,
                                                             new string[] { Path.GetFileName(arg.OldFullPath), Path.GetFileName(arg.FullPath) },
                                                             new string[] { arg.OldFullPath, arg.FullPath },
                                                             DateTime.Now,
                                                             GetFileByte(arg.FullPath)
                                                            ));
        }

        protected void InvokeDetectActionEvent(object o, ResourceEventArgs arg)
        {
            DetectActionEvent.Invoke(this, arg);
        }
        private void DetectActionEventNull<T>(object o, T arg)
        {
        }

        protected byte[] GetFileByte(string path)
        {
            if (File.Exists(path))
            {
                byte[] values;

                try
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)))
                    {
                        values = new byte[reader.BaseStream.Length];

                        reader.Read(values, 0, (int)reader.BaseStream.Length);
                    }

                    return values;
                }
                catch (IOException)
                {
                    return GetFileByte(path);
                }
            }

            return new byte[0];
        }
    }
}
