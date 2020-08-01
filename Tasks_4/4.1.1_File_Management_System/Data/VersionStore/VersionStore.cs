using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FileManagementSystem.Data.VersionStore
{
    internal class VersionStore : IVersionStore
    {
        protected readonly string _storePath;

        public VersionStore(string storePath)
        {
            _storePath = storePath;
        }

        public void AddVersion(ResourceEventArgs args)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(_storePath, FileMode.Append, FileAccess.Write)))
            {
                StringBuilder builder = new StringBuilder();
                foreach (var item in args.Value)
                {
                    builder.Append(item + ",");
                }

                if (args.TypeActionResource == TypeActionResource.Rename)
                {
                    writer.WriteLine($"{args.Time}|{args.TypeActionResource}|{args.Names[0]},{args.Names[1]}|{args.Paths[0]},{args.Paths[1]}|{builder.ToString()}");
                }
                else
                {
                    writer.WriteLine($"{args.Time}|{args.TypeActionResource}|{args.Names[0]}|{args.Paths[0]}|{builder.ToString()}");
                }
            }
        }
        public void AddVersions(ResourceEventArgs[] args)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(_storePath, FileMode.Append, FileAccess.Write)))
            {
                foreach (var arg in args)
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (var item in arg.Value)
                    {
                        builder.Append(item + ",");
                    }

                    if (arg.TypeActionResource == TypeActionResource.Rename)
                    {
                        writer.WriteLine($"{arg.Time}|{arg.TypeActionResource}|{arg.Names[0]},{arg.Names[1]}|{arg.Paths[0]},{arg.Paths[1]}|{builder.ToString()}");
                    }
                    else
                    {
                        writer.WriteLine($"{arg.Time}|{arg.TypeActionResource}|{arg.Names[0]}|{arg.Paths[0]}|{builder.ToString()}");
                    }
                }
            }
        }

        /// <exception cref="IOException"> The file is damaged!</exception>
        public ResourceEventArgs[] GetVersions(DateTime time)
        {
            Dictionary<string, ResourceEventArgs> ResourceDictionary = new Dictionary<string, ResourceEventArgs>();

            try
            {
                foreach (var item in RunVersoins(time))
                {
                    if (ResourceDictionary.Keys.Any(key => key.Equals(item.Paths[0])))
                    {
                        switch (item.TypeActionResource)
                        {
                            case TypeActionResource.Delete:
                                ResourceDictionary.Remove(item.Paths[0]);
                                break;
                            case TypeActionResource.Rename:
                                ResourceDictionary.Remove(item.Paths[0]);
                                ResourceDictionary.Add(item.Paths[1], item);
                                break;
                            case TypeActionResource.Change:
                                ResourceDictionary[item.Paths[0]] = item;
                                break;
                            case TypeActionResource.Create:
                                throw new IOException("An attempt to repeat the data.");
                            default:
                                throw new IOException("Unknown type TypeActionResource!");
                        }
                    }
                    else
                    {
                        switch (item.TypeActionResource)
                        {
                            case TypeActionResource.Create:
                                ResourceDictionary[item.Paths[0]] = item;
                                break;
                            default:
                                throw new IOException("An attempt was made to work with non-existent data.");
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                throw new IOException($"The file \"{Path.GetFileName(_storePath)}\" is damaged!", ex);
            }

            return ResourceDictionary.Values.ToArray();
        }
        /// <exception cref="IOException"> Trying to read data. </exception>
        protected IEnumerable<ResourceEventArgs> RunVersoins(DateTime time)
        {
            using (StreamReader reader = new StreamReader(new FileStream(_storePath, FileMode.Open, FileAccess.Read)))
            {
                Regex regex = new Regex(@"(?<data>\d{1,2}\/\d{1,2}\/\d{2,4} \d{1,2}:\d{1,2}:\d{1,2})\|(?<type>\b\w+\b)\|(?<names>[A-Za-zА-Яа-яЁё0-9. ]+|[A-Za-zА-Яа-яЁё0-9. ]+,[A-Za-zА-Яа-яЁё0-9. ]+)\|(?<paths>[A-Za-zА-Яа-яЁё0-9. \\]+|[A-Za-zА-Яа-яЁё0-9. \\]+,[A-Za-zА-Яа-яЁё0-9. \\]+)\|(?<value>[0-9,]+)?");

                TypeActionResource resourceType;
                DateTime resourceDate;
                string[] tempStringValue;
                byte[] resourceValue;
                GroupCollection group;

                foreach (Match match in regex.Matches(reader.ReadToEnd()))
                {
                    group = match.Groups;
                    tempStringValue = group[5].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    resourceValue = new byte[tempStringValue.Length];

                    for (int i = 0; i < resourceValue.Length; i++)
                    {
                        if (!byte.TryParse(tempStringValue[i], out resourceValue[i]))
                        {
                            throw new IOException("Trying to read bytes.");
                        }
                    }

                    if (Enum.TryParse(group[2].ToString(), out resourceType) &&
                        DateTime.TryParse(group[1].ToString(), out resourceDate))
                    {
                        if (resourceDate <= time)
                        {
                            yield return new ResourceEventArgs
                                                    (
                                                        resourceType,
                                                        group[3].ToString().Split(','),
                                                        group[4].ToString().Split(','),
                                                        resourceDate,
                                                        resourceValue
                                                    );
                        }
                    }
                    else
                    {
                        throw new IOException("Trying to read data.");
                    }
                }
            }

            yield break;
        }
    }
}
