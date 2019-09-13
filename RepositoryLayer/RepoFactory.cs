namespace RepositoryLayer
{
    public class RepoFactory
    {
        public static IAuthenticationRepo GetAuthenticationRepo()
        {
            return new AuthenticationRepo();
        }

        public static IUserRepo GetUserRepo()
        {
            return new UserRepo();
        }
    }
}
