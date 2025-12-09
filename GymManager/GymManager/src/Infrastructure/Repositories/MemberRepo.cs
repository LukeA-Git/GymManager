using GymManager.Domain.Interfaces;
using GymManager.Domain.Models;

namespace GymManager.Infrastructure.Repositories
{
    public class MemberRepo : IRepository<Member>
    {
        private readonly List<Member> _members = new();

        public void Add(Member member)
        {
            _members.Add(member);
        }

        public List<Member> GetAll()
        {
            return _members;
        }

        public void Clear()
        {
            _members.Clear();
        }

        public void Remove(Member member)
        {
            _members.Remove(member);
        }
        
        public void Update(Member updatedMember)
        {
            var existing = FindById(updatedMember.Id);
            if (existing != null)
            {
                _members.Remove(existing);
                _members.Add(updatedMember);
            }
        }
        
        public Member? FindById(int id)
        {
            return _members.FirstOrDefault(m => m.Id == id);
        }
        
        public List<Member> FindByName(string name)
        {
            return _members
                .Where(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}