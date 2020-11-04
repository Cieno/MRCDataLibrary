using MRCDataLibrary._02_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRCDataLibrary._03_Data
{
    public interface IWorshipData
    {
        Task<string> CreateWorship(WorshipModel worship);
        Task<string> UpdateWorship(WorshipModel worship);
        Task<int> DeleteWorship(string worshipId);
        Task<List<WorshipModel>> GetWorships();
        Task<WorshipModel> GetWorshipById(string worshipId);
    }
}
