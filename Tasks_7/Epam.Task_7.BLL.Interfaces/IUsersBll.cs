using System;
using System.Collections.Generic;
using Epam.Task_7.Common.Entities;

namespace Epam.Task_7.BLL.Interfaces
{
    public interface IUsersBll
    {
        Guid AddUser(User user);

        int ChangeUser(User user);

        int ChangeUser(User user, IBll objectBll);

        int RemoveUser(Guid id);

        int RemoveUser(Guid id, IBll objectBll);

        bool IsUser(Guid id);

        User GetUser(Guid id);

        IEnumerable<User> GetAllUsers();
    }
}
