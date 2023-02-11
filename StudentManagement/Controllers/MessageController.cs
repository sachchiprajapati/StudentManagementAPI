using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StudentManagement.Core;
using StudentManagement.Hubs;

namespace StudentManagement.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        #region "Declarations"
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        private readonly IAPIVersionRepository _aPIVersionRepository;
        public MessageController(IHubContext<NotifyHub, ITypedHubClient> hubContext, IAPIVersionRepository aPIVersionRepository)
        {
            _hubContext = hubContext;
            _aPIVersionRepository = aPIVersionRepository;
        }
        #endregion

        #region GetSignalRAPIVersion
        [HttpGet]
        [Route("GetSignalRAPIVersion")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _aPIVersionRepository.GetAPIVersion();
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SetSignalRAPIVersion
        [HttpPost]
        [Route("SetSignalRAPIVersion")]
        public async Task<IActionResult> Post(int version)
        {
            try
            {
                var response = await _aPIVersionRepository.SetAPIVersion(version);
                await _hubContext.Clients.All.BroadcastMessage(response);
                return Ok(new { Message = "Request Completed" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}