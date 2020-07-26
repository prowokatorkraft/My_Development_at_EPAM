using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileManagementSystem.Data.Resource
{
    internal abstract class AbstractMonitorResource : AbstractResource
    {
        public abstract event EventHandler<ResourceEventArgs> DetectActionEvent;

        public abstract Task MonitorAsync(CancellationToken token);
    }
}