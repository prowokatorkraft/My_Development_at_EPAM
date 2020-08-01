using System;

using FileManagementSystem.Data;
using FileManagementSystem.Data.Resource.Changer;
using FileManagementSystem.Data.VersionStore;

namespace FileManagementSystem.Logic.Recovery
{
    internal class Recovery : IRecovery
    {
        protected readonly IChangeResource _resource;
        protected readonly IVersionStore _store;
        
        public Recovery(string pathFolder = @".\Test", string pathStore = @".\Store.dat")
        {
            _resource = new ChangeResource(pathFolder);
            _store = new VersionStore(pathStore);
        }

        public void ReturnVersion(DateTime time)
        {
            ResourceEventArgs[] args = _store.GetVersions(time);

            _resource.ChangeAllResource(args);
        }
    }
}
