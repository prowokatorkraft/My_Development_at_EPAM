using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

using FileManagementSystem.Data;
using FileManagementSystem.Data.Resource.Monitor;
using FileManagementSystem.Data.Tracer;
using FileManagementSystem.Data.VersionStore;


namespace FileManagementSystem.Logic.Monitoring
{
    internal class Monitoring : IMonitoring, IDisposable
    {
        protected readonly IMonitorResource _resource;
        protected readonly ITrace _tracer;
        protected readonly IVersionStore _store;

        protected CancellationTokenSource _cancellation;

        public Monitoring(string pathDictionary = @".\Test", string filterFile = @"*.txt")
        {
            _resource = new MonitorResource(pathDictionary, filterFile);
            _resource.DetectActionEvent += CatchEvent;
            _cancellation = new CancellationTokenSource();

            _tracer = new Tracer("Log.txt");
            _store = new VersionStore(@".\Store.dat");
        }
        public void Dispose()
        {
            Stop();
            _tracer.Close();
        }

        public async void Start()
        {
            await _resource.MonitorAsync(_cancellation.Token);

            _cancellation = new CancellationTokenSource();
        }
        public void Stop()
        {
            _cancellation.Cancel();
        }

        protected void CatchEvent(object o, ResourceEventArgs args)
        {
            _tracer.TraceEvent(args);
            _store.AddVersion(args);
        }
    }
}
