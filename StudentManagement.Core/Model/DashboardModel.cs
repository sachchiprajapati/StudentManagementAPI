
namespace StudentManagement.Core
{
    public class DashboardModel : BaseResponseModel
    {
        public int ActiveTecherCount { get; set; }
        public int DeleteTecherCount { get; set; }
        public int ActiveStudentCount { get; set; }
        public int DeleteStudentCount { get; set; }
    }
}
