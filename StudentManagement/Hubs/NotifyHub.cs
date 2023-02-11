using Microsoft.AspNetCore.SignalR;
using StudentManagement.Core;

namespace StudentManagement.Hubs
{
    public class NotifyHub : Hub<ITypedHubClient>
    {
        //public async Task BroadcastMessage(APIVersionModel aPIVersionModel)
        //{
        //    await Clients.All.BroadcastMessage(aPIVersionModel);
        //}
    }
}
