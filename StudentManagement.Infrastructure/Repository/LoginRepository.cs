using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentManagement.Core;
using StudentManagement.Infrastructure.DBModels;

namespace StudentManagement.Infrastructure
{
    public class LoginRepository : ILoginRepository
    {
        #region "Declarations"

        private readonly StudentSystemContext _dbContext;
        private readonly ILogger<LoginRepository> _logger;
        public LoginRepository(StudentSystemContext dbContext, ILogger<LoginRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region ValidateLogin
        public async Task<LoginResponseModel> ValidateLogin(LoginRequestModel loginRequestModel)
        {
            try
            {
                LoginResponseModel loginResponseModel = null;
                var userData = await _dbContext.TblUsers.Include(_ => _.UserTypeNavigation).FirstOrDefaultAsync(_ => _.Email.ToLower() == loginRequestModel.Email.ToLower() && _.Password == loginRequestModel.Password);
                if (userData != null)
                {
                    loginResponseModel = new LoginResponseModel()
                    {
                        Status = true,
                        Message = Constants.Success,
                        UserTypeId = userData.UserType ?? 0,
                        UserType = userData.UserTypeNavigation.UserType,
                        FirstName = userData.FirstName,
                        LastName = userData.LastName,
                        Email = userData.Email,
                        Id = userData.Id,
                        Photo = Constants.UserPhotos + "/" + userData.Photo
                    };
                }
                else
                {
                    loginResponseModel = new LoginResponseModel()
                    {
                        Status = false,
                        Message = Constants.Error,
                    };
                }
                return loginResponseModel;
            }
            catch (Exception ex)
            {
                _logger.LogError($"ValidateLogin Error : {ex.ToString()}");
                throw ex;
            }
        }
        #endregion
    }
}
