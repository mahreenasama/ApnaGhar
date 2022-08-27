namespace ApnaGharV2.Models.Interfaces
{
    public interface IUserRepository
    {
        public bool AddUser(User user);
        public bool LoginUser(User user);
        public bool UserAlreadyExist(User user);
        public List<User> GetAllUsers();

    }
}
