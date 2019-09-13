using DomainLayer;
using DomainLayer.Models;
using RepositoryLayer.DB;
using System.Linq;

namespace RepositoryLayer
{
    internal class AuthenticationRepo : IAuthenticationRepo
    {
        //validates the login credentials
        public bool ValidateLogin(LoginModel loginModel)
        {
            using(UserDbContext ctx = new UserDbContext())
            {
                return ctx.Users.Any(user => user.Email == loginModel.Email && user.Password == loginModel.Password);
            }
        }

        //registers the user in the database
        public bool Register(RegistrationModel registrationModel)
        {
            if(UserExists(registrationModel.Email))
            {
                return false;
            }
            Models.UserModel userModel = new Models.UserModel();
            GenericMapper.Map(registrationModel, userModel);
            using(UserDbContext ctx = new UserDbContext())
            {
                userModel.UserID = ctx.Users.Max(user => user.UserID) + 10; //generates new UserID
                ctx.Users.Add(userModel);
                try
                {
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        //check if user exists in the database
        public bool UserExists(string email)
        {
            using(UserDbContext ctx = new UserDbContext())
            {
                return ctx.Users.Any(user => user.Email == email);
            }
        }
    }
}
