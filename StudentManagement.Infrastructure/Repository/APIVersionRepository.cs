using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentManagement.Core;
using StudentManagement.Infrastructure.DBModels;

namespace StudentManagement.Infrastructure.Repository
{
    public class APIVersionRepository : IAPIVersionRepository
    {
        #region "Declarations"

        private readonly StudentSystemContext _dbContext;
        private readonly ILogger<APIVersionRepository> _logger;
        public APIVersionRepository(StudentSystemContext dbContext, ILogger<APIVersionRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region GetAPIVersion
        public async Task<APIVersionModel> GetAPIVersion()
        {
            APIVersionModel aPIVersionModel = null;
            try
            {
                var versionData = await _dbContext.TblApiversions.FirstOrDefaultAsync();
                aPIVersionModel = new APIVersionModel()
                {
                    Status = true,
                    Message = Constants.Success,
                    APIVersion = versionData != null ? versionData.Apiversion : null,
                    Id = versionData != null ? versionData.Id : null,
                };
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"SetAPIVersion Exception : {ex.ToString()}");
                throw ex;
            }
            return aPIVersionModel;
        }
        #endregion

        #region SetAPIVersion
        public async Task<APIVersionModel> SetAPIVersion(int APIVersion)
        {
            APIVersionModel aPIVersionModel = null;
            try
            {
                var versionData = await _dbContext.TblApiversions.FirstOrDefaultAsync();
                if(versionData == null)
                {
                    //Add
                    var tblapiversion = new TblApiversion()
                    {
                        Apiversion = APIVersion,
                    };
                    _dbContext.Add(tblapiversion);
                    await _dbContext.SaveChangesAsync();

                }
                else
                {
                    //update
                    versionData.Apiversion = APIVersion;
                    await _dbContext.SaveChangesAsync();
                }

                aPIVersionModel = new APIVersionModel()
                {
                    Status = true,
                    Message = Constants.Success,
                    APIVersion = versionData != null ? versionData.Apiversion : null,
                };
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"SetAPIVersion Exception : {ex.ToString()}");
                throw ex;
            }
            return aPIVersionModel;
        }
        #endregion
    }
}
