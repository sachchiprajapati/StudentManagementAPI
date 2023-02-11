using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentManagement.Core;
using StudentManagement.Infrastructure.DBModels;

namespace StudentManagement.Infrastructure.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        #region "Declarations"

        private readonly StudentSystemContext _dbContext;
        private readonly ILogger<DashboardRepository> _logger;
        public DashboardRepository(StudentSystemContext dbContext, ILogger<DashboardRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region GetDashboardData
        public async Task<DashboardModel> GetDashboardData()
        {
            DashboardModel dashboardModel = null;
            try
            {
                int activeTeacherCount = await _dbContext.TblUsers.Where(_ => _.UserTypeNavigation.UserType.ToLower() == UserType.Teacher.ToString().ToLower()
                && _.IsDeleted == false).CountAsync();

                int deleteTeacherCount = await _dbContext.TblUsers.Where(_ => _.UserTypeNavigation.UserType.ToLower() == UserType.Teacher.ToString().ToLower()
               && _.IsDeleted == true).CountAsync();

                int activeStudentCount = await _dbContext.TblUsers.Where(_ => _.UserTypeNavigation.UserType.ToLower() == UserType.Student.ToString().ToLower()
               && _.IsDeleted == false).CountAsync();

                int deleteStudentCount = await _dbContext.TblUsers.Where(_ => _.UserTypeNavigation.UserType.ToLower() == UserType.Student.ToString().ToLower()
               && _.IsDeleted == true).CountAsync();

                dashboardModel = new DashboardModel()
                {
                    Status = true,
                    Message = Constants.Success,
                    ActiveTecherCount = activeTeacherCount,
                    DeleteTecherCount = deleteTeacherCount,
                    ActiveStudentCount = activeStudentCount,
                    DeleteStudentCount = deleteStudentCount
                };
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetDashboardData Exception : {ex.ToString()}");
                throw ex;
            }
            return dashboardModel;
        }
        #endregion
    }
}
