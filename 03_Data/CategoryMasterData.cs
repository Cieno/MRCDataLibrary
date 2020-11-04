using Dapper;
using MRCDataLibrary._01_DB;
using MRCDataLibrary._02_Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MRCDataLibrary._03_Data
{
    public class CategoryMasterData : ICategoryMasterData
    {
        private readonly IDBAccess _dataAccess;
        private readonly ConnectionString _connectionString;

        public CategoryMasterData(IDBAccess dataAccess, ConnectionString connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<string> CreateCategory(CategoryMasterModel category)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@categoryId", category.CATEGORY_ID);
            param.Add("@categoryDescr", category.CATEGORY_DESCR);
            param.Add("@abbreviationCode", category.ABBR_CD);

            await _dataAccess.SaveData("dbo.SP_INSERT_CATEGORY_MST",
                                       param,
                                       _connectionString.sqlConnectionName);
            return param.Get<string>("@categoryId");
        }

        public async Task<int> DeleteCategory(string categoryId)
        {
            return await _dataAccess.SaveData("dbo.SP_DELETE_CATEGORY_MST",
                                              new { categoryId },
                                              _connectionString.sqlConnectionName);
        }

        public async Task<List<CategoryMasterModel>> GetCategoryList(string? categoryId)
        {
            return await _dataAccess.LoadData<CategoryMasterModel, dynamic>("dbo.SP_SEARCH_CATEGORY_MST",
                                                                  new { categoryId },
                                                                  _connectionString.sqlConnectionName);
        }

        public async Task<int> GetDuplicationItemCount(string categoryId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@idValue", categoryId);
            param.Add("@itemCount", 0, DbType.Int32, ParameterDirection.Output, int.MaxValue);
            await _dataAccess.SaveData("dbo.SP_CHECK_DUPLICATE_RECORD",
                                        param,
                                        _connectionString.sqlConnectionName);
            return param.Get<int>("@itemCount"); ;
        }

        public async Task<string> UpdateCategory(CategoryMasterModel category)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@categoryId", category.CATEGORY_ID);
            param.Add("@categoryDescr", category.CATEGORY_DESCR);
            param.Add("@abbreviationCode", category.ABBR_CD);
            param.Add("@activeYn", category.ACTIVE_YN);

            await _dataAccess.SaveData("dbo.SP_UPDATE_CATEGORY_MST",
                                       param,
                                       _connectionString.sqlConnectionName);
            return param.Get<string>("@categoryId");
        }
    }
}
