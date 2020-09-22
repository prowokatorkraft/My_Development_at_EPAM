using System;
using System.Collections.Generic;

using Epam.Task_7.BLL.Interfaces;
using Epam.Task_7.DAL.Interfaces;
using Epam.Task_7.Common.Entities;

namespace Epam.Task_7.BLL
{
    public class UsersBll : IUsersBll
    {
        private readonly IUsersDao _usersDao;

        public UsersBll(IUsersDao usersDao)
        {
            _usersDao = usersDao;
        }

        public Guid AddUser(User user)
        {
            if (user.Id == Guid.Empty)
            {
                return Guid.Empty;
            }

            return _usersDao.AddUser(user);
        }

        public int ChangeUser(User user)
        {
            if (_usersDao.ChangeUser(user))
            {
                return 0;
            }

            return 1;
        }

        public int ChangeUser(User user, IBll objectBll)
        {
            var oldUser = objectBll.Users.GetUser(user.Id);

            foreach (var item in oldUser.AwardList)
            {
                objectBll.RemoveDependUserAndAwards(user.Id, item);
            }

            ChangeUser(user);

            foreach (var item in user.AwardList)
            {
                var award = objectBll.Awards.GetAward(item);
                award.OwnerList.Add(user.Id);
                objectBll.Awards.ChangeAward(award);
                objectBll.AddDependUserAndAwards(user.Id, item);
            }

            return 1;
        }

        public IEnumerable<User> GetAllUsers()
        {
            foreach (var item in _usersDao.GetAllUsers())
            {
                yield return item;
            }
        }

        /// <exception cref="ArgumentException"></exception>
        public User GetUser(Guid id)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("Argument id is empty!");
            }

            try
            {
                return _usersDao.GetUser(id);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid id!");
            }
        }

        public bool IsUser(Guid id)
        {
            if (Guid.Empty == id)
            {
                return false;
            }

            return _usersDao.IsUser(id);
        }

        public int RemoveUser(Guid id)
        {
            if (Guid.Empty == id)
            {
                return -1;
            }

            if (_usersDao.RemoveUser(id))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public int RemoveUser(Guid id, IBll objectBll)
        {
            if (Guid.Empty == id || objectBll == null)
            {
                return -1;
            }

            foreach (var awardId in _usersDao.GetUser(id).AwardList)
            {
                objectBll.RemoveDependUserAndAwards(id, awardId);
            }

            if (_usersDao.RemoveUser(id))
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
