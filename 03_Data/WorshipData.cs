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
    public class WorshipData : IWorshipData
    {
        private readonly IDBAccess _dataAccess;
        private readonly ConnectionString _connectionString;

        public WorshipData(IDBAccess dataAccess, ConnectionString connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<string> CreateWorship(WorshipModel worship)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@worshipId", "", DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
            param.Add("@worshipDate", worship.WorshipDate);
            param.Add("@worshipType", worship.WorshipType);
            param.Add("@worshipLocation", worship.Location);
            param.Add("@description", worship.Description);

            await _dataAccess.SaveData("dbo.SP_INSERT_WORSHIP_INFO", param, _connectionString.sqlConnectionName);
            return param.Get<string>("@worshipId");
        }

        public async Task<int> DeleteWorship(string worshipId)
        {
            return await _dataAccess.SaveData("dbo.SP_DELETE_WORSHIP_INFO",
                                        new { @worshipId = worshipId },
                                        _connectionString.sqlConnectionName);
        }

        public async Task<WorshipModel> GetWorshipById(string worshipId)
        {
            var recs = await _dataAccess.LoadData<WorshipModel, dynamic>("dbo.SP_SEARCH_WORSHIP_INFO",
                                                                        new { @worshipId = worshipId },
                                                                        _connectionString.sqlConnectionName);
            return recs.FirstOrDefault();
        }

        public async Task<List<WorshipModel>> GetWorships()
        {
            return await _dataAccess.LoadData<WorshipModel, dynamic>("dbo.SP_SEARCH_WORSHIP_LIST",
                                                                     new { },
                                                                     _connectionString.sqlConnectionName);
        }

        public async Task<string> UpdateWorship(WorshipModel worship)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@worshipId", worship.WorshipId, DbType.String, direction: ParameterDirection.InputOutput, size: int.MaxValue);
            param.Add("@worshipDate", worship.WorshipDate);
            param.Add("@worshipType", worship.WorshipType);
            param.Add("@worshipLocation", worship.Location);
            param.Add("@description", worship.Description);

            await _dataAccess.SaveData("dbo.SP_UPDATE_WORSHIP_INFO", param, _connectionString.sqlConnectionName);
            return param.Get<string>("@worshipId");
        }
    }
}
