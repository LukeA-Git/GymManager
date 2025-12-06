using System.Collections.Generic;
using System.Linq;
using GymManager.Domain.Interfaces;
using GymManager.Domain.Models;

namespace GymManager.Infrastructure.Repositories
{
    public class UserRepo : IRepository<GymUser>
    {
        private readonly List<GymUser> _users = new();

        public void Add(GymUser user)
        {
            _users.Add(user);
        }

        public void Remove(GymUser user)
        {
            _users.Remove(user);
        }

        public void Update(GymUser user)
        {
            var existing = FindById(user.UserID);
            if (existing != null)
            {
                _users.Remove(existing);
                _users.Add(user);
            }
        }

        public GymUser? FindById(int id)
        {
            return _users.FirstOrDefault(u => u.UserID == id);
        }

        public List<GymUser> GetAll()
        {
            return _users;
        }

        public void Clear()
        {
            _users.Clear();
        }

        // LOGIN METHOD
        public GymUser? Authenticate(int id, string password)
        {
            return _users.FirstOrDefault(u =>
                u.UserID == id &&
                u.UserPassword == password
            );
        }
    }
}