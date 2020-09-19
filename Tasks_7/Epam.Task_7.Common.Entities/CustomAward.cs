using System;
using System.Collections.Generic;

namespace Epam.Task_7.Common.Entities
{
    public class CustomAward
    {
        public Guid Id { get; }

        public string Title { get; set; }

        public List<User> OwnerList { get; }

        public CustomAward(Guid id, string title)
        {
            Id = id;
            Title = title;
            OwnerList = new List<User>();
        }
    }
}
