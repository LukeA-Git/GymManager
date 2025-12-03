using GymManager.Domain.Interfaces;

namespace GymManager.Infrastructure.Repositories
{
    public class UserRepo
    {
        private readonly List<IUser> _users = new();

        // ADD USER
        public void AddUser(IUser user)
        {
            _users.Add(user);
        }

        // REMOVE USER BY ID
        public void RemoveUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserID == id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        // UPDATE USER
        public void UpdateUser(IUser updatedUser)
        {
            int index = _users.FindIndex(u => u.UserID == updatedUser.UserID);
            if (index != -1)
            {
                _users[index] = updatedUser;
            }
        }

        // GET USER BY ID
        public IUser GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.UserID == id);
        }

        // GET ALL USERS
        public List<IUser> GetAllUsers()
        {
            return _users;
        }

        // LOGIN METHOD (ID + PASSWORD)
        public IUser Authenticate(int id, string password)
        {
            return _users.FirstOrDefault(u =>
                u.UserID == id &&
                u.UserPassword == password
            );
        }
    }
}