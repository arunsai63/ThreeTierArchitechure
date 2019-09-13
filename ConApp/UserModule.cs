using BusinessLayer;
using DomainLayer.Enums;
using DomainLayer.Models;
using System;
using System.Collections.Generic;

namespace ConApp
{
    public class UserModule
    {
        private IUserBusiness _userBusiness;
        public UserModule()
        {
            _userBusiness = BusinessFactory.GetUserBusiness();
        }

        //takes UserRoleChoiceEnum as input and shows the appropriate user details
        internal void GetUserDetails(UserRoleChoiceEnum role)
        {
            List<UserModel> userModel = _userBusiness.GetUserDetails(role);
            foreach(UserModel user in userModel)
            {
                Console.WriteLine("\n" + user.FirstName + " " + user.LastName + " " + user.Email);
            }
        }
    }
}
