namespace FileManagementSystem.Data.Tracer
{
    internal interface ITrace
    {
        void TraceEvent(ResourceEventArgs arg);
        void Close();
    }
}
