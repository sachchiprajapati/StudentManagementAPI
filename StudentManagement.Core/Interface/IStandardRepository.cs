
namespace StudentManagement.Core
{
    public interface IStandardRepository
    {
        Task<List<StandardModel>> GetStandards();
    }
}
