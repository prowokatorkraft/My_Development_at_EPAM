using System;
using System.Collections.Generic;
using Epam.Task_7.Common.Entities;

namespace Epam.Task_7.DAL.Interfaces
{
    public interface IAwardsDao
    {
        Guid AddAward(Award award);

        bool ChangeAward(Award newAward);

        bool RemoveAward(Guid id);

        bool IsAward(Guid id);

        Award GetAward(Guid id);

        IEnumerable<Award> GetAllAward();
    }
}
