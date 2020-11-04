using MRCDataLibrary._02_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRCDataLibrary._03_Data
{
    public interface IMemberData
    {
        Task<string> CreateMember(MemberModel member);
        Task<string> UpdateMember(MemberModel member);
        Task<int> DeleteMember(string memberId);
        Task<List<MemberModel>> GetMembers();
        Task<List<MemberModel>> GetMembersToAdd(string worshipId);
        Task<MemberModel> GetMemberById(string memberId);
    }
}
