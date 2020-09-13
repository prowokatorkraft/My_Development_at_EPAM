using Epam.Task_7.DAL.Json;
using Epam.Task_7.DAL.Interfaces;
using Epam.Task_7.BLL;
using Epam.Task_7.BLL.Interfaces;

namespace Epam.Task_7.Common
{
    public static class DependencyResolver
    {
        public static IDao Dao { get; }

        public static IBll Bll { get; }

        static DependencyResolver()
        {
            Dao = new ObjectDao(@".\");
            Bll = new ObjectBll(Dao);
        }
    }
}
