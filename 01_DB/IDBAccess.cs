using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRCDataLibrary._01_DB
{
    public interface IDBAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
    }
}
