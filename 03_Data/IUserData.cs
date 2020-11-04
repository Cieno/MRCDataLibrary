
using Microsoft.AspNetCore.Identity;
using MRCDataLibrary._02_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRCDataLibrary._03_Data
{
    public interface IUserData
    {
        Task<string> UpdateUser(UserModel user);
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUser(string id);
        Task<int> DeleteUser(string id);

        Task<List<IdentityRole>> GetRoles();
    }
}
