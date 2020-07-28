using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileManagementSystem.Data.Resource.Monitor
{
    internal interface IMonitorResource
    {
        event EventHandler<ResourceEventArgs> DetectActionEvent;

        Task MonitorAsync(CancellationToken token);
    }
}