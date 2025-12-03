using System.Collections.Generic;
using System.Linq;
using GymManager.Domain.Interfaces;

namespace GymManager.Infrastructure.Repositories
{
    public class UserRepo : IRepository<IUser>
    {
        private readonly List<IUser> _users = new();

        //  ADD
        public void Add(IUser user)
        {
            _users.Add(user);
        }

        //  REMOVE
        public void Remove(IUser user)
        {
            _users.Remove(user);
        }

        //  UPDATE
        public void Update(IUser user)
        {
            var existing = FindById(user.UserID);
            if (existing != null)
            {
                _users.Remove(existing);
                _users.Add(user);
            }
        }

        //  FIND BY ID
        public IUser? FindById(int id)
        {
            return _users.FirstOrDefault(u => u.UserID == id);
        }

        //  GET ALL
        public List<IUser> GetAll()
        {
            return _users;
        }

        //  CLEAR (THIS FIXES YOUR ERROR)
        public void Clear()
        {
            _users.Clear();
        }

        //  LOGIN (CUSTOM METHOD)
        public IUser? Authenticate(int id, string password)
        {
            return _users.FirstOrDefault(u =>
                u.UserID == id &&
                u.UserPassword == password
            );
        }
    }
}