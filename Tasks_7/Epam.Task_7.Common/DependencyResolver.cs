using Epam.Task_7.DAL.DataBase;
using Epam.Task_7.DAL.Interfaces;
using Epam.Task_7.BLL;
using Epam.Task_7.BLL.Interfaces;

namespace Epam.Task_7.Common
{
    public static class DependencyResolver
    {
        public static IDao Dao { get; }

        public static IBll Bll { get; }

        public static IAuthentication Authentication { get; }

        static DependencyResolver()
        {
            Dao = new ObjectDao();
            Bll = new ObjectBll(Dao);

            Authentication = new Authentication(Bll.Users);
        }
    }
}
