using GymManager.Domain.Interfaces;
using GymManager.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace GymManager.Infrastructure.Repositories
{
    public class MemberRepo<Member> : IRepository<Member>
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
    }
}