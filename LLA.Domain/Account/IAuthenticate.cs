namespace LLA.Domain.Account;

public interface IAuthenticate
{
    Task<bool> Authenticate(string email, string password);
    Task<bool> RegisterUser(string nome,string email, string password);
    Task Logout();
}
