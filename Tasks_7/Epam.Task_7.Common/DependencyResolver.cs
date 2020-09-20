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

        public static IAuthentication Authentication { get; }

        static DependencyResolver()
        {
            Dao = new ObjectDao(@"C:\Users\Данил\source\repos\EPAM\My_Development_at_EPAM\Tasks_7\Epam.Task_7.TestingConsole\bin\Debug");
            Bll = new ObjectBll(Dao);

            Authentication = new Authentication(Bll.Users);
        }
    }
}
