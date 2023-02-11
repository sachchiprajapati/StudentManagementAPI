using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.Core;

namespace StudentManagement.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        #region "Declarations"
        private readonly IDashboardRepository _dashboardRepository;
        private readonly ILogger<DashboardController> _logger;
        public DashboardController(IDashboardRepository dashboardRepository, ILogger<DashboardController> logger)
        {
            _dashboardRepository = dashboardRepository;
            _logger = logger;
        }
        #endregion

        #region GetDashboardData
        [Route("GetDashboardData")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardData()
        {
            try
            {
                var response = await _dashboardRepository.GetDashboardData();
                _logger.LogInformation($"GetDashboardData Response : {JsonConvert.SerializeObject(response)}");

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
