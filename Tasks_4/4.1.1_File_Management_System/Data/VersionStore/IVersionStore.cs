using System;

namespace FileManagementSystem.Data.VersionStore
{
    internal interface IVersionStore
    {
        ResourceEventArgs[] GetVersions(DateTime time);
        void AddVersion(ResourceEventArgs args);
        void AddVersions(ResourceEventArgs[] args);
    }
}
