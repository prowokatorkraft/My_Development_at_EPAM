using System;
using System.Collections.Generic;

using Epam.Task_7.BLL.Interfaces;
using Epam.Task_7.DAL.Interfaces;
using Epam.Task_7.Common.Entities;

namespace Epam.Task_7.BLL
{
    public class AwardsBll : IAwardsBll
    {
        private readonly IAwardsDao _awardsDao;

        public AwardsBll(IAwardsDao awardsDao)
        {
            _awardsDao = awardsDao;
        }

        public Guid AddAward(Award award)
        {
            if (award.Id == Guid.Empty || string.IsNullOrWhiteSpace(award.Title))
            {
                return Guid.Empty;
            }

            return _awardsDao.AddAward(award);
        }

        public IEnumerable<Award> GetAllAwards()
        {
            foreach (var item in _awardsDao.GetAllAward())
            {
                yield return item;
            }
        }

        /// <exception cref="ArgumentException"></exception>
        public Award GetAward(Guid id)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("Argument id is empty!");
            }

            try
            {
                return _awardsDao.GetAward(id);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid id!");
            }
        }

        public bool IsAward(Guid id)
        {
            if (Guid.Empty == id)
            {
                return false;
            }

            return _awardsDao.IsAward(id);
        }

        public int RemoveAward(Guid id)
        {
            if (Guid.Empty == id)
            {
                return -1;
            }

            if (_awardsDao.RemoveAward(id))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
