using System;
using System.Collections.Generic;

namespace Epam.Task_7.Common.Entities
{
    public class User
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Guid> AwardList { get; }

        public User(Guid id, string name, DateTime dateOfBirth, string login, string password, string role)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            AwardList = new List<Guid>();
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
