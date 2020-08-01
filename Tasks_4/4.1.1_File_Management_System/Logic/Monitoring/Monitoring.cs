using System;
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

        public Monitoring(string pathFolder = @".\Test", string filterFile = @"*.txt", string nameLog = "Log.txt", string pathStore = @".\Store.dat")
        {
            _resource = new MonitorResource(pathFolder, filterFile);
            _resource.DetectActionEvent += CatchEvent;
            _cancellation = new CancellationTokenSource();

            _tracer = new Tracer(nameLog);
            _store = new VersionStore(pathStore);
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
