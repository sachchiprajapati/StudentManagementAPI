
namespace StudentManagement.Core
{
    public interface IDashboardRepository
    {
        Task<DashboardModel> GetDashboardData();
    }
}
