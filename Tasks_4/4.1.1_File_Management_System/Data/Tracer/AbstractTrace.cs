using FileManagementSystem.Data.Resource.Monitor;

namespace FileManagementSystem.Data.Tracer
{
    internal abstract class AbstractTrace
    {
        public abstract void TraceEvent(ResourceEventArgs arg);

        public abstract void Close();
    }
}
