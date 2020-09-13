using System;
using System.Collections.Generic;

using Epam.Task_7.BLL.Interfaces;
using Epam.Task_7.DAL.Interfaces;

namespace Epam.Task_7.BLL
{
    public class ObjectBll : IBll
    {
        public IUsersBll Users { get; }
        public IAwardsBll Awards { get; }
        private readonly IDao _objectDao;

        public ObjectBll(IDao objectDao)
        {
            _objectDao = objectDao;

            Users = new UsersBll(_objectDao.Users);

            Awards = new AwardsBll(_objectDao.Awards);
        }

        public void AddDependUserAndAwards(Guid userId, Guid awardId)
        {
            if (!Users.IsUser(userId))
            {
                throw new ArgumentException("Incorrect argument userId!");
            }
            else if (!Awards.IsAward(awardId))
            {
                throw new ArgumentException("Incorrect argument awardId!");
            }
            else
            {
                _objectDao.AddDependUserAndAwards(userId, awardId);
            }

        }

        public IEnumerable<Guid> GetAllAwardedUserGuids(Guid awardId)
        {
            if (!_objectDao.Awards.IsAward(awardId))
            {
                throw new ArgumentException("Incorrect argument awardId!");
            }

            foreach (var item in _objectDao.GetAllAwardedUserGuids(awardId))
            {
                yield return item;
            }
        }

        public IEnumerable<Guid> GetAllСustomAwardGuids(Guid userId)
        {
            if (!_objectDao.Users.IsUser(userId))
            {
                throw new ArgumentException("Incorrect argument userId!");
            }

            foreach (var item in _objectDao.GetAllСustomAwardGuids(userId))
            {
                yield return item;
            }
        }

        public void RemoveDependUserAndAwards(Guid userId, Guid awardId)
        {
            if (!Users.IsUser(userId))
            {
                throw new ArgumentException("Incorrect argument userId!");
            }
            else if (!Awards.IsAward(awardId))
            {
                throw new ArgumentException("Incorrect argument awardId!");
            }
            else
            {
                _objectDao.RemoveDependUserAndAwards(userId, awardId);
            }
        }
    }
}
