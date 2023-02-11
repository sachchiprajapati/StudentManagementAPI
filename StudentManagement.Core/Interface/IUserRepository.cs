
namespace StudentManagement.Core
{
    public interface IUserRepository
    {
        Task<UserResponseModel> AddUser(UserModel userModel);
        Task<UserResponseModel> UpdateUser(UserModel userModel);
        Task<UserResponseModel> DeleteUser(UserModel userModel);
        Task<UserResponseModel> GetUserbyId(int Id);
        Task<UserResponseModel> GetStudents();
        Task<UserResponseModel> GetTeachers();
        Task<UserCountResponseModel> GetStudentsCountByStandard();
    }
}
