using DomainLayer.Models;
using RepositoryLayer;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer
{
    internal class AuthencationBusiness : IAuthencationBusiness
    {
        private IAuthenticationRepo _authRepo;

        internal AuthencationBusiness()
        {
            _authRepo = RepoFactory.GetAuthenticationRepo();
        }

        //sends login details to data layer for validation
        public bool ValidateLogin(LoginModel loginModel)
        {
            loginModel.Password = GetHash(loginModel.Password);
            return _authRepo.ValidateLogin(loginModel);
        }

        //sends registration details to data layer for registration
        public bool Register(RegistrationModel registrationModel)
        {
            registrationModel.Password = GetHash(registrationModel.Password);
            return _authRepo.Register(registrationModel);
        }

        //hashes the password(SHA256 hashing)
        private string GetHash(string password)
        {
            SHA256 algorithm = SHA256.Create();
            string salt = " S A L T ";
            byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            StringBuilder pwd = new StringBuilder();
            foreach (byte b in hash)
            {
                pwd.Append(b.ToString("X2"));
            }
            return pwd.ToString();
        }
    }
}