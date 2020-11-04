
using Dapper;
using Microsoft.AspNetCore.Identity;
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
    public class UserData : IUserData
    {
        private readonly IDBAccess _dBAccess;
        private readonly ConnectionString _connection;

        public UserData(IDBAccess dBAccess, ConnectionString connection)
        {
            _dBAccess = dBAccess;
            _connection = connection;
        }

        public async Task<int> DeleteUser(string id)
        {
            return await _dBAccess.SaveData("dbo.SP_DELETE_USER_INFO",
                                        new { id },
                                        _connection.sqlConnectionName);
        }

        public async Task<UserModel> GetUser(string id)
        {
            var recs = await _dBAccess.LoadData<UserModel, dynamic>("dbo.SP_SEARCH_USER_INFO",
                                                          new { id },
                                                          _connection.sqlConnectionName);
            return recs.FirstOrDefault();
        }

        public async Task<List<UserModel>> GetUsers()
        {
            return await _dBAccess.LoadData<UserModel, dynamic>("dbo.SP_SEARCH_USER_LIST",
                                                          new { },
                                                          _connection.sqlConnectionName);
        }

        public async Task<string> UpdateUser(UserModel user)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", user.Id, DbType.String, direction: ParameterDirection.InputOutput, int.MaxValue);
            param.Add("@firstName", user.FirstName);
            param.Add("@lastName", user.LastName);
            param.Add("@email", user.Email);
            param.Add("@phoneNumber", user.PhoneNumber);
            param.Add("@roleId", user.RoleId);
            //param.Add("@roleName", user.RoleName);

            await _dBAccess.SaveData("dbo.SP_UPDATE_USER_INFO", param, _connection.sqlConnectionName);
            return param.Get<string>("@id");
        }

        //필요없음.
        public async Task<List<IdentityRole>> GetRoles()
        {
            return await _dBAccess.LoadData<IdentityRole, dynamic>("dbo.SP_SEARCH_ROLE_LIST",
                                                          new { },
                                                          _connection.sqlConnectionName);
        }
    }
}
