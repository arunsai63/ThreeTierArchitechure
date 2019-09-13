using DomainLayer.Models;

namespace BusinessLayer
{
    public interface IAuthencationBusiness
    {
        bool ValidateLogin(LoginModel loginModel);

        bool Register(RegistrationModel registrationModel);
    }
}
