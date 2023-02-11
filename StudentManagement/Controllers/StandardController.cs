using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.Core;

namespace StudentManagement.Controllers
{
    [Authorize]
    public class StandardController : Controller
    {
        #region "Declarations"
        private readonly IStandardRepository _standardRepository;
        private readonly ILogger<StandardController> _logger;
        public StandardController(IStandardRepository standardRepository, ILogger<StandardController> logger)
        {
            _standardRepository = standardRepository;
            _logger = logger;
        }
        #endregion

        #region GetStandards
        [Route("GetStandards")]
        [HttpGet]
        public async Task<IActionResult> GetStandards()
        {
            try
            {
                var response = await _standardRepository.GetStandards();
                _logger.LogInformation($"GetStandards Response : {JsonConvert.SerializeObject(response)}");

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
