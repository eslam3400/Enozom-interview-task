using Microsoft.EntityFrameworkCore;
using TaskModels;
using TaskModels.Enums;

namespace TaskContext.Seeds
{
    public class UserSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasData(
            //    new User { Name = "Admin", Email = "admin@enozom.com", Type = UserType.ADMIN, UserName = "admin", Password = "admin"},
            //    new User { Name = "User", Email = "user@enozom.com", Type = UserType.USER, UserName = "user", Password = "user"}
            //);
        }
    }
}
