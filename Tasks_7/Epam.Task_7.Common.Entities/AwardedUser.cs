using System;
using System.Collections.Generic;

namespace Epam.Task_7.Common.Entities
{
    public class AwardedUser
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Award> AwardList { get; }

        public AwardedUser(Guid id, string name, DateTime dateOfBirth, string login, string password, string role)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            AwardList = new List<Award>();
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
