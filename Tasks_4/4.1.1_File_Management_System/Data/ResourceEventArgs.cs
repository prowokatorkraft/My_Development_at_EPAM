using System;

namespace FileManagementSystem.Data
{
    internal class ResourceEventArgs : EventArgs
    {
        public TypeActionResource TypeActionResource { get; }

        public string[] Names { get; }

        public string[] Paths { get; }

        public DateTime Time { get; }

        public byte[] Value { get; }

        public ResourceEventArgs(TypeActionResource typeActionResource, string[] names, string[] paths, DateTime time, byte[] value)
        {
            TypeActionResource = typeActionResource;
            Names = names;
            Paths = paths;
            Time = time;
            Value = value;
        }
    }
}
