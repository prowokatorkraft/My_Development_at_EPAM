using System;
using System.Collections.Generic;

namespace Epam.Task_7.BLL.Interfaces
{
    public interface IBll
    {
        IUsersBll Users { get; }

        IAwardsBll Awards { get; }

        IEnumerable<Guid> GetAllСustomAwardGuids(Guid userId);

        IEnumerable<Guid> GetAllAwardedUserGuids(Guid awardId);

        void AddDependUserAndAwards(Guid userId, Guid awardId);

        void RemoveDependUserAndAwards(Guid userId, Guid awardId);
    }
}
