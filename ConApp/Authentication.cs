using BusinessLayer;
using DomainLayer.Models;

namespace ConApp
{
    public class Authentication
    {
        private IAuthencationBusiness _authencationBusiness;
        public Authentication()
        {
            _authencationBusiness = BusinessFactory.GetAuthencationBusiness();
        }

        //takes email and password, creates login model and sends it to business layer for authentication
        internal bool Login(string emailID, string password)
        {
            LoginModel loginModel = new LoginModel
            {
                Email = emailID,
                Password = password
            };
            return _authencationBusiness.ValidateLogin(loginModel);
        }

        //takes all parameters, creates a regitration model and sends it to businesslayer for registration
        internal bool Register(string emailID, string password,string firstName, string lastName, bool isStudent)
        {
            RegistrationModel registrationModel = new RegistrationModel
            {
                Email = emailID,
                Password = password,
                ConfirmPassword = password,
                FirstName = firstName,
                LastName = lastName,
                IsStudent = isStudent
            };
            return _authencationBusiness.Register(registrationModel);
        }
    }
}
