
namespace StudentManagement.Core
{
    public interface IAPIVersionRepository
    {
        Task<APIVersionModel> GetAPIVersion();
        Task<APIVersionModel> SetAPIVersion(int APIVersion);
    }
}
