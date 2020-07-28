﻿using FileManagementSystem.Data.Resource;

namespace FileManagementSystem.Data.Tracer
{
    internal abstract class AbstractTrace
    {
        public abstract void TraceEvent(ResourceEventArgs arg);

        public abstract void Close();
    }
}
