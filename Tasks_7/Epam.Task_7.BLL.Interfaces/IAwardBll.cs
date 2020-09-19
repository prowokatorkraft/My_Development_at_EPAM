using System;
using System.Collections.Generic;
using Epam.Task_7.Common.Entities;

namespace Epam.Task_7.BLL.Interfaces
{
    public interface IAwardsBll
    {
        Guid AddAward(Award award);

        int ChangeAward(Award award);

        int ChangeAward(Award award, IBll objectBll);

        int RemoveAward(Guid id);

        int RemoveAward(Guid id, IBll objectBll);

        bool IsAward(Guid id);

        Award GetAward(Guid id);

        IEnumerable<Award> GetAllAwards();
    }
}
