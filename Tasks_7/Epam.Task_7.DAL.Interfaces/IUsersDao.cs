using System;
using System.Collections.Generic;
using Epam.Task_7.Common.Entities;

namespace Epam.Task_7.DAL.Interfaces
{
    public interface IUsersDao
    {
        Guid AddUser(User user);

        bool ChangeUser(User newUser);

        bool RemoveUser(Guid id);

        bool IsUser(Guid id);

        User GetUser(Guid id);

        IEnumerable<User> GetAllUsers();
    }
}
