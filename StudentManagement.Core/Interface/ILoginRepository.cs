
namespace StudentManagement.Core
{
    public interface ILoginRepository
    {
        Task<LoginResponseModel> ValidateLogin(LoginRequestModel loginRequestModel);
    }
}
