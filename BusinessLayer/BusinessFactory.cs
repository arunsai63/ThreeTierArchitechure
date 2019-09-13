namespace BusinessLayer
{
    public class BusinessFactory
    {
        public static IAuthencationBusiness GetAuthencationBusiness()
        {
            return new AuthencationBusiness();
        }

        public static IUserBusiness GetUserBusiness()
        {
            return new UserBusiness();
        }
    }
}
