using TaskModels;
using TaskModels.DTOs.User;

namespace TaskRepositories.Interfaces
{
    public interface IUserRepository
    {
        public void Add(User user);
        public User Get(string username);
        public void Save();
    }
}
