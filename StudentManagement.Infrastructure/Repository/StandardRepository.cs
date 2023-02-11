using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentManagement.Core;
using StudentManagement.Infrastructure.DBModels;

namespace StudentManagement.Infrastructure
{
    public class StandardRepository : IStandardRepository
    {
        #region "Declarations"

        private readonly StudentSystemContext _dbContext;
        private readonly ILogger<StandardRepository> _logger;
        public StandardRepository(StudentSystemContext dbContext, ILogger<StandardRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region
        public async Task<List<StandardModel>> GetStandards()
        {
            try
            {
                var standardData = await _dbContext.TblStandards.Select(_ => new StandardModel
                {
                  Id = _.Id,
                  Standard = _.Standard
                }).ToListAsync();

                return standardData;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetStandards Exception : {ex.ToString()}");
                throw ex;
            }
        }
        #endregion
    }
}
