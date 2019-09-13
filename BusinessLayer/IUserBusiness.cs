using DomainLayer.Enums;
using DomainLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IUserBusiness
    {
        List<UserModel> GetUserDetails(UserRoleChoiceEnum role);
    }
}
