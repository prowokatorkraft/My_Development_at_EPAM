using System;
using System.Collections.Generic;

namespace Epam.Task_7.Common.Entities
{
    public class Award
    {
        public Guid Id { get; }

        public string Title { get; set; }

        public List<Guid> OwnerList { get; }

        public Award(Guid id, string title)
        {
            Id = id;
            Title = title;
            OwnerList = new List<Guid>();
        }
    }
}
