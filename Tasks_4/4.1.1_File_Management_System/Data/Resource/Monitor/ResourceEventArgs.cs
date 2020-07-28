using System;

namespace FileManagementSystem.Data.Resource.Monitor
{
    internal class ResourceEventArgs : EventArgs
    {
        public TypeActionResource TypeActionResource { get; }

        public string[] Names { get; }

        public string[] Paths { get; }

        public DateTime Time { get; }

        public ResourceEventArgs(TypeActionResource typeActionResource, string[] names, string[] paths, DateTime time)
        {
            TypeActionResource = typeActionResource;
            Names = names;
            Paths = paths;
            Time = time;
        }
    }
}
