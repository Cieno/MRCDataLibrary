using MRCDataLibrary._02_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRCDataLibrary._03_Data
{
    public interface ICodeMasterData
    {
        Task<List<CodeMasterModel>> GetCodeList(string? categoryId);
        Task<CodeMasterModel> GetCodeInfo(string codeId, string categoryId);
        Task<string> CreateCode(CodeMasterModel code);
        Task<int> DeleteCode(CodeMasterModel code);
        Task<int> DeleteCode(string codeId, string categoryId);
        Task<string> UpdateCode(CodeMasterModel code);

    }
}
