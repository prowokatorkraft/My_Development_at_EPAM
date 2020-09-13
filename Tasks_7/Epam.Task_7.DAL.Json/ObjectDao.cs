using System;
using System.Collections.Generic;
using System.IO;

using Epam.Task_7.Common.Entities;
using Epam.Task_7.DAL.Interfaces;

namespace Epam.Task_7.DAL.Json
{
    public class ObjectDao : IDao
    {
        public IUsersDao Users { get; }
        public IAwardsDao Awards { get; }

        private readonly string _storagePath;

        public ObjectDao(string storagePath, string storageName = "StorageJson")
        {
            _storagePath = Path.Combine(storagePath, storageName);
            CreateDirectory(_storagePath);

            Users = new UsersDao(_storagePath);
            Awards = new AwardsDao(_storagePath);
        }

        public void AddDependUserAndAwards(Guid userId, Guid awardId)
        {
            User user = Users.GetUser(userId);
            Award award = Awards.GetAward(awardId);

            user.AwardList.Add(awardId);
            award.OwnerList.Add(userId);

            Users.ChangeUser(user);
            Awards.ChangeAward(award);
        }

        public IEnumerable<Guid> GetAllAwardedUserGuids(Guid awardId)
        {
            Award award = Awards.GetAward(awardId);

            foreach (var item in award.OwnerList)
            {
                yield return item;
            }
        }

        public IEnumerable<Guid> GetAllСustomAwardGuids(Guid userId)
        {
            User user = Users.GetUser(userId);

            foreach (var item in user.AwardList)
            {
                yield return item;
            }
        }

        public void RemoveDependUserAndAwards(Guid userId, Guid awardId)
        {
            User user = Users.GetUser(userId);
            Award award = Awards.GetAward(awardId);

            user.AwardList.Remove(awardId);
            award.OwnerList.Remove(userId);

            Users.ChangeUser(user);
            Awards.ChangeAward(award);
        }

        private void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
