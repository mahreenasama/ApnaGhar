using ApnaGharV2.Models.Classes;

namespace ApnaGharV2.Models.Interfaces
{
    public interface IUserRepository
    {
        public User AddUser(User user, IFormFile profileImage, int adderId);    //id of person(admin/user) who is adding this user
        public bool LoginUser(User user);
        public bool UserAlreadyExist(User user);

        public User SearchUser(int id);
        public bool UpdateUser(User newData, IFormFile ProfileImage, int id, int changerId);

        public List<User> GetAllUsers();

    }
}
