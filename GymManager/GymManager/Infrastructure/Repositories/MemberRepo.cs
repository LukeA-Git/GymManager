using GymManager.Domain.Interfaces;
using GymManager.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace GymManager.Infrastructure.Repositories
{
    public class MemberRepo : IMemberRepo
    {
        public List<Member> MemberList { get; } = new();

        public void AddMember(Member member)
        {
            MemberList.Add(member);
        }

        public Member GetMemberByID(int memberId)
        {
            return MemberList.FirstOrDefault(m => m.Id == memberId);
        }

        public void RemoveMemberByID(int memberId)
        {
            var member = GetMemberByID(memberId);
            if (member != null)
                MemberList.Remove(member);
        }

        public void SetMemberName(Member member, string name)
        {
            member.Name = name;
        }
    }
}