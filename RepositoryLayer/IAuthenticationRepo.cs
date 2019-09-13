using DomainLayer.Models;

namespace RepositoryLayer
{
    public interface IAuthenticationRepo
    {
        bool ValidateLogin(LoginModel loginModel);

        bool Register(RegistrationModel registrationModel);

        bool UserExists(string email);
    }
}
