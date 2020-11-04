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
    public class AttendanceData : IAttendanceData
    {
        private readonly IDBAccess _dataAccess;
        private readonly ConnectionString _connectionString;

        public AttendanceData(IDBAccess dataAccess, ConnectionString connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<string> CreateAttendance(AttendanceModel attendance)
        {
            var param = new DynamicParameters();
            param.Add("@memberId", attendance.MemberId);
            param.Add("@worshipId", attendance.WorshipId, DbType.String, direction: ParameterDirection.InputOutput, size: int.MaxValue);
            param.Add("@attendanceType", attendance.AttendanceType);
            param.Add("@estimatedArrival", attendance.EstimatedArrival);
            param.Add("@signAgreement", attendance.SignAgreement);
            param.Add("@initial", attendance.Initial);
            param.Add("@descr", attendance.Descr);

            await _dataAccess.SaveData("dbo.SP_INSERT_ATTENDANCE_INFO", param, _connectionString.sqlConnectionName);
            return param.Get<string>("@worshipId");
        }

        public async Task<string> DeleteAttendance(string worshipId, string memberId)
        {
            var param = new DynamicParameters();
            param.Add("@worshipId", worshipId);
            param.Add("@memberId", memberId);
            await _dataAccess.SaveData("dbo.SP_DELETE_ATTENDANCE_INFO",
                                       param,
                                       _connectionString.sqlConnectionName);
            return param.Get<string>("@worshipId");
        }

        public async Task<List<AttendanceModel>> GetAttendanceByWorship(string worshipId)
        {
            return await _dataAccess.LoadData<AttendanceModel, dynamic>("dbo.SP_SEARCH_ATTENDANCE_MEMBER_LIST",
                                                                            new { @worshipId = worshipId},
                                                                            _connectionString.sqlConnectionName);
        }

        public async Task<AttendanceModel> GetAttendanceByWorshipMember(string worshipId, string userId)
        {
            var result = await _dataAccess.LoadData<AttendanceModel, dynamic>("dbo.SP_SEARCH_ATTENDANCE_MEMBER",
                                                                            new { worshipId = worshipId, id = userId },
                                                                            _connectionString.sqlConnectionName);
            return result.FirstOrDefault();
        }

        public async Task<string> UpdateAttendance(AttendanceModel attendance)
        {
            var param = new DynamicParameters();
            param.Add("@memberId", attendance.MemberId);
            param.Add("@worshipId", attendance.WorshipId, DbType.String, direction: ParameterDirection.InputOutput);
            param.Add("@attendanceType", attendance.AttendanceType);
            param.Add("@estimatedArrival", attendance.EstimatedArrival);
            param.Add("@signAgreement", attendance.SignAgreement);
            param.Add("@initial", attendance.Initial == "n/a" ? "" : attendance.Initial);
            param.Add("@descr", attendance.Descr);

            await _dataAccess.SaveData("dbo.SP_UPDATE_ATTENDANCE_INFO", param, _connectionString.sqlConnectionName);
            return param.Get<string>("@worshipId");
        }
    }
}
