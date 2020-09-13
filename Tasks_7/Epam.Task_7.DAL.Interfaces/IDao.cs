using System;
using System.Collections.Generic;

namespace Epam.Task_7.DAL.Interfaces
{
    public interface IDao
    {
        IUsersDao Users { get; }

        IAwardsDao Awards { get; }

        IEnumerable<Guid> GetAllСustomAwardGuids(Guid userId);

        IEnumerable<Guid> GetAllAwardedUserGuids(Guid awardId);

        void AddDependUserAndAwards(Guid userId, Guid awardId);

        void RemoveDependUserAndAwards(Guid userId, Guid awardId);
    }
}
