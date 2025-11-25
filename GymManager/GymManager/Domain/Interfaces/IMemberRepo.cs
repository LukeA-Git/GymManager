using GymManager.Domain.Models;
using System.Collections.Generic;

namespace GymManager.Domain.Interfaces
{
    public interface IMemberRepo
    {
        List<Member> MemberList { get; }

        void AddMember(Member member);
        Member GetMemberByID(int memberId);
        void RemoveMemberByID(int memberId);
    }
}