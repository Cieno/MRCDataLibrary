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
    public class CodeMasterData : ICodeMasterData
    {
        private readonly IDBAccess _dataAccess;
        private readonly ConnectionString _connectionString;

        public CodeMasterData(IDBAccess dataAccess, ConnectionString connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<string> CreateCode(CodeMasterModel code)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@codeId", "", DbType.String, direction: ParameterDirection.Output, size:int.MaxValue);
            param.Add("@categoryId", code.CATEGORY_ID);
            param.Add("@codeDescr", code.CODE_DESCR);
            param.Add("@sortOrder", code.SORT_ORDER);

            await _dataAccess.SaveData("dbo.SP_INSERT_CODE_MST",
                                       param,
                                       _connectionString.sqlConnectionName);
            return param.Get<string>("@codeId");
        }

        public async Task<List<CodeMasterModel>> GetCodeList(string? categoryId)
        {
            return await _dataAccess.LoadData<CodeMasterModel, dynamic>("dbo.SP_SEARCH_CODE_MST",
                                                                  new { categoryId },
                                                                  _connectionString.sqlConnectionName);
        }

        public async Task<CodeMasterModel> GetCodeInfo(string codeId, string categoryId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@codeId", codeId);
            param.Add("@categoryId", categoryId);

            var recs = await _dataAccess.LoadData<CodeMasterModel, dynamic>("dbo.SP_SEARCH_CODE_INFO",
                                                                  param,
                                                                  _connectionString.sqlConnectionName);
            return recs.FirstOrDefault();
        }

        public async Task<string> UpdateCode(CodeMasterModel code)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@codeId", code.CODE_ID);
            param.Add("@categoryId", code.CATEGORY_ID);
            param.Add("@codeDescr", code.CODE_DESCR);
            param.Add("@sortOrder", code.SORT_ORDER);
            param.Add("@activeYn", code.ACTIVE_YN);

            await _dataAccess.SaveData("dbo.SP_UPDATE_CODE_MST",
                                       param,
                                       _connectionString.sqlConnectionName);
            return param.Get<string>("@codeId");
        }

        public async Task<int> DeleteCode(CodeMasterModel code)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@codeId", code.CODE_ID);
            param.Add("@categoryId", code.CATEGORY_ID);

            return await _dataAccess.SaveData("dbo.SP_DELETE_CODE_MST",
                                              param,
                                              _connectionString.sqlConnectionName);
        }

        public async Task<int> DeleteCode(string codeId, string categoryId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@codeId", codeId);
            param.Add("@categoryId", categoryId);

            return await _dataAccess.SaveData("dbo.SP_DELETE_CODE_MST",
                                              param,
                                              _connectionString.sqlConnectionName);
        }
    }
}
