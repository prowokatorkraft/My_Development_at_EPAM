using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

using Epam.Task_7.Common.Entities;
using Epam.Task_7.DAL.Interfaces;

namespace Epam.Task_7.DAL.Json
{
    public class AwardsDao : IAwardsDao
    {
        private readonly string _folderName;
        private readonly string _fileExtension;
        private readonly string _folderPath;

        public AwardsDao(string folderPath, string folderName = "Awards_Json", string fileExtension = ".Json")
        {
            _folderPath = folderPath;
            _folderName = folderName;
            _fileExtension = fileExtension;

            CreateDirectory();
        }

        public Guid AddAward(Award award)
        {
            using (var writer = AddJsonFile(award.Id))
            {
                writer.Write(JsonConvert.SerializeObject(award));
            }

            return award.Id;
        }

        public bool ChangeAward(Award newAward)
        {
            using (var writer = ChangeJsonFile(newAward.Id))
            {
                writer.Write(JsonConvert.SerializeObject(newAward));
            }

            return true;
        }

        public IEnumerable<Award> GetAllAward()
        {
            string path = Path.Combine(_folderPath, _folderName);
            string templateExtention = "*" + _fileExtension;

            foreach (var item in Directory.EnumerateFiles(path, templateExtention))
            {
                yield return GetAward(Guid.Parse(Path.GetFileNameWithoutExtension(item)));
            }
        }

        public Award GetAward(Guid id)
        {
            string jsonStr;

            using (var stream = GetJsonFileForReader(id))
            {
                jsonStr = stream.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<Award>(jsonStr);
        }

        public bool IsAward(Guid id)
        {
            return IsJsonFile(id);
        }

        public bool RemoveAward(Guid id)
        {
            RemoveJsonFile(id);

            return true;
        }

        #region Internal implementation

        private bool IsJsonFile(Guid id)
        {
            return File.Exists(GetFilePath(id));
        }

        private TextReader GetJsonFileForReader(Guid id)
        {
            try
            {
                var stream = File.Open(
                                GetFilePath(id),
                                FileMode.Open,
                                FileAccess.Read
                            );

                return new StreamReader(stream);
            }
            catch (FileNotFoundException e)
            {
                throw new IOException("Data retrieval error!", e);
            }
        }

        private TextWriter GetJsonFileForWrite(Guid id)
        {
            try
            {
                var stream = File.Open(
                                GetFilePath(id),
                                FileMode.Open,
                                FileAccess.Write
                            );

                return new StreamWriter(stream);
            }
            catch (FileNotFoundException e)
            {
                throw new IOException("Data retrieval error!", e);
            }
        }

        private TextWriter AddJsonFile(Guid id)
        {
            try
            {
                var stream = File.Open(
                                GetFilePath(id),
                                FileMode.CreateNew,
                                FileAccess.Write
                            );

                return new StreamWriter(stream);
            }
            catch (IOException e)
            {
                throw new IOException("The Json file has already been created!", e);
            }
        }

        private TextWriter ChangeJsonFile(Guid id)
        {
            try
            {
                if (!IsJsonFile(id))
                {
                    throw new FileNotFoundException("The Json file was not found!");
                }

                var stream = File.Open(
                                GetFilePath(id),
                                FileMode.Create,
                                FileAccess.Write
                            );

                return new StreamWriter(stream);
            }
            catch (FileNotFoundException e)
            {
                throw new IOException("The Json file was not found!", e);
            }
        }

        private void RemoveJsonFile(Guid id)
        {
            try
            {
                File.Delete(GetFilePath(id));
            }
            catch (IOException e)
            {
                throw new IOException("Failed to delete file!", e);
            }
        }

        private string GetFilePath(Guid id)
        {
            return Path.Combine(_folderPath, _folderName, id.ToString() + _fileExtension);
        }

        private void CreateDirectory()
        {
            try
            {
                Directory.CreateDirectory(Path.Combine(_folderPath, _folderName));
            }
            catch (IOException e)
            {
                throw new IOException("Storage " + _folderName + " is damaged!", e);
            }
        }

        #endregion
    }
}
