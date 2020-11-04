using MRCDataLibrary._02_Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRCDataLibrary._03_Data
{
    public interface ICategoryMasterData
    {
        Task<List<CategoryMasterModel>> GetCategoryList(string? categoryId);

        Task<string> CreateCategory(CategoryMasterModel category);

        Task<int> DeleteCategory(string categoryId);

        Task<int> GetDuplicationItemCount(string categoryId);

        Task<string> UpdateCategory(CategoryMasterModel category);
    }
}
