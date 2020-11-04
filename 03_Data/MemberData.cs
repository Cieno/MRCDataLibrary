using Dapper;
using MRCDataLibrary._01_DB;
using MRCDataLibrary._02_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRCDataLibrary._03_Data
{
    public class MemberData : IMemberData
    {
        private readonly IDBAccess _dataAccess;
        private readonly ConnectionString _connectionString;

        public MemberData(IDBAccess dataAccess, ConnectionString connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<string> CreateMember(MemberModel member)
        {
            DynamicParameters param = new DynamicParameters();
            //param.Add("@memberId", member.MEMBER_ID);
            param.Add("@memberId", "", DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
            param.Add("@firstName", member.FirstName);
            param.Add("@lastName", member.LastName);
            param.Add("@emailAddress", member.EmailAddr);
            param.Add("@birthDate", member.BirthDate);
            param.Add("@phoneNumber", member.PhoneNum);
            //param.Add("@photoImage", member.PHOTO_IMG);
            //param.Add("@signImage", member.SIGN_IMG);
            param.Add("@familyId", member.FamilyId);
            param.Add("@groupCode", member.GroupCd);
            param.Add("@teamCode", member.TeamCd);

            await _dataAccess.SaveData("dbo.SP_INSERT_MEMBER_INFO", param, _connectionString.sqlConnectionName);
            return param.Get<string>("@memberId");
        }

        public async Task<int> DeleteMember(string memberId)
        {
            return await _dataAccess.SaveData("dbo.SP_DELETE_MEMBER_INFO",
                                              new { @memberId = memberId },
                                              _connectionString.sqlConnectionName);
        }

        public async Task<MemberModel> GetMemberById(string memberId)
        {
            var recs = await _dataAccess.LoadData<MemberModel, dynamic>("dbo.SP_SEARCH_MEMBER_INFO",
                                                                    new { @memberId = memberId },
                                                                    _connectionString.sqlConnectionName);
            return recs.FirstOrDefault();
        }

        public async Task<List<MemberModel>> GetMembers()
        {
            return await _dataAccess.LoadData<MemberModel, dynamic>("dbo.SP_SEARCH_MEMBER_LIST",
                                                                    new { },
                                                                    _connectionString.sqlConnectionName);
        }

        public async Task<List<MemberModel>> GetMembersToAdd(string worshipId)
        {
            return await _dataAccess.LoadData<MemberModel, dynamic>("dbo.SP_SEARCH_MEMBER_LIST_TO_ADD",
                                                                    new { worshipId },
                                                                    _connectionString.sqlConnectionName);
        }

        public async Task<string> UpdateMember(MemberModel member)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@memberId", member.MemberId, DbType.String, direction: ParameterDirection.InputOutput, size: int.MaxValue);
            param.Add("@firstName", member.FirstName);
            param.Add("@lastName", member.LastName);
            param.Add("@emailAddress", member.EmailAddr);
            param.Add("@birthDate", member.BirthDate);
            param.Add("@phoneNumber", member.PhoneNum);
            //param.Add("@photoImage", member.PHOTO_IMG);
            //param.Add("@signImage", member.SIGN_IMG);
            param.Add("@familyId", member.FamilyId);
            param.Add("@groupCode", member.GroupCd);
            param.Add("@teamCode", member.TeamCd);

            await _dataAccess.SaveData("dbo.SP_UPDATE_MEMBER_INFO", param, _connectionString.sqlConnectionName);
            return param.Get<string>("@memberId");
        }
    }
}
