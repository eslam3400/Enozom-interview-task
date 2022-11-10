using TaskContext;
using TaskModels;
using TaskRepositories.Interfaces;

namespace TaskRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        public UserRepository(DataContext context) { this.context = context; }
        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public User Get(string username)
        {
            return context.Users.Where(filter => filter.UserName == username).SingleOrDefault();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
