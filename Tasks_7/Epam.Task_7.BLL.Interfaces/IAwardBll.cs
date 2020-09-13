using System;
using System.Collections.Generic;
using Epam.Task_7.Common.Entities;

namespace Epam.Task_7.BLL.Interfaces
{
    public interface IAwardsBll
    {
        Guid AddAward(Award award);

        int RemoveAward(Guid id);

        bool IsAward(Guid id);

        Award GetAward(Guid id);

        IEnumerable<Award> GetAllAwards();
    }
}
