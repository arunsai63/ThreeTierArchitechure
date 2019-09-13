using RepositoryLayer.Migrations;
using RepositoryLayer.Models;
using System.Data.Entity;

namespace RepositoryLayer.DB
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() : base("name=EmployeeDataBase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserDbContext, Configuration>());
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
