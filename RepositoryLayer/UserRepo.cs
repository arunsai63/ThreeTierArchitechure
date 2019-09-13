using DomainLayer;
using DomainLayer.Enums;
using DomainLayer.Models;
using RepositoryLayer.DB;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer
{
    internal class UserRepo : IUserRepo
    {
        //takes UserRoleChoiceEnum as input and returns the appropriate user details
        public List<UserModel> GetUserDetails(UserRoleChoiceEnum role)
        {
            List<Models.UserModel> users = null;
            using(UserDbContext ctx = new UserDbContext())
            {
                switch (role)
                {
                    case UserRoleChoiceEnum.Student:
                        users = ctx.Users.Where(user => user.IsStudent).ToList();
                        break;
                    case UserRoleChoiceEnum.Other:
                        users = ctx.Users.Where(user => !user.IsStudent).ToList();
                        break;
                    case UserRoleChoiceEnum.All:
                        users = ctx.Users.ToList();
                        break;
                }
            }
            return users.ConvertAll(user =>
            {
                UserModel userModel = new UserModel();
                GenericMapper.Map(user, userModel);
                return userModel;
            });
        }
    }
}
