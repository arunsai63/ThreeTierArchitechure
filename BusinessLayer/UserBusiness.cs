using DomainLayer.Enums;
using DomainLayer.Models;
using RepositoryLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    internal class UserBusiness : IUserBusiness
    {
        private IUserRepo _userRepo;

        internal UserBusiness()
        {
            _userRepo = RepoFactory.GetUserRepo();
        }

        //takes UserRoleChoiceEnum as input returns the appropriate user details retreived from the data layer
        public List<UserModel> GetUserDetails(UserRoleChoiceEnum role)
        {
            return _userRepo.GetUserDetails(role);
        }
    }
}
