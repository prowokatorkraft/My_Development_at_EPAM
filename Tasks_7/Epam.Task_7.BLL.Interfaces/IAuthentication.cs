namespace Epam.Task_7.BLL.Interfaces
{
    public interface IAuthentication
    {
        bool CheckAuthentication(string login, string password);

        bool IsLogin(string login);
    }
}
