using System;
using System.Collections.Generic;
using Epam.Task_7.Common.Entities;

namespace Epam.Task_7.BLL.Interfaces
{
    public interface IUsersBll
    {
        Guid AddUser(User user);

        int RemoveUser(Guid id);

        bool IsUser(Guid id);

        User GetUser(Guid id);

        IEnumerable<User> GetAllUsers();
    }
}
