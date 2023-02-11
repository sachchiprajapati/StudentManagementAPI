using StudentManagement.Core;

namespace StudentManagement.Hubs
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(APIVersionModel aPIVersionModel);
    }
}
