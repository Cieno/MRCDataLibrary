using MRCDataLibrary._02_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRCDataLibrary._03_Data
{
    public interface IAttendanceData
    {
        Task<string> CreateAttendance(AttendanceModel attendance);
        Task<string> DeleteAttendance(string worshipId, string memberId);
        Task<List<AttendanceModel>> GetAttendanceByWorship(string worshipId);
        Task<AttendanceModel> GetAttendanceByWorshipMember(string worshipId, string memberId);

        Task<string> UpdateAttendance(AttendanceModel attendance);
    }
}
