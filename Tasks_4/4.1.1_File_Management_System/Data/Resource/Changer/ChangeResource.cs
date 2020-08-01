using System;
using System.IO;

namespace FileManagementSystem.Data.Resource.Changer
{
    internal class ChangeResource : IChangeResource
    {
        public string PathResource { get; }

        public ChangeResource(string pathFolder)
        {
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
            }
            PathResource = pathFolder;
        }

        public void ChangeAllResource(ResourceEventArgs[] args)
        {
            if (Directory.Exists(PathResource) && args.Length > 0)
            {
                Directory.Delete(PathResource, true);
            }

            foreach (var item in args)
            {
                CreateFile(item);
            }
        }

        protected void CreateFile(ResourceEventArgs arg)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(arg.TypeActionResource == TypeActionResource.Rename ? arg.Paths[1] : arg.Paths[0]))
                     .Create();

            using (BinaryWriter writer = new BinaryWriter(new FileStream(
                arg.TypeActionResource == TypeActionResource.Rename ? arg.Paths[1] : arg.Paths[0],
                FileMode.Create, FileAccess.Write)))
            {
                writer.Write(arg.Value);
            }
        }
    }
}
