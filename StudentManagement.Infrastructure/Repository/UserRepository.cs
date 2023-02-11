using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentManagement.Core;
using StudentManagement.Infrastructure.DBModels;

namespace StudentManagement.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        #region "Declarations"

        private readonly StudentSystemContext _dbContext;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(StudentSystemContext dbContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region AddUser
        public async Task<UserResponseModel> AddUser(UserModel userModel)
        {
            UserResponseModel userResponseModel = null;
            try
            {
                int userType = _dbContext.TblUserTypes.FirstOrDefault(_ => _.UserType.ToLower() == userModel.UserTypeName.ToLower()).Id;
                var tblUser = new TblUser()
                {
                    FirstName = userModel.FirstName,
                    MiddleName = userModel.MiddleName,
                    LastName = userModel.LastName,
                    Standard = userModel.Standard,
                    BirthDate = Convert.ToDateTime(Convert.ToDateTime(userModel.BirthDate).ToShortDateString()),
                    Gender = userModel.Gender,
                    Address = userModel.Address,
                    Photo = userModel.Photo,
                    FatherOccupation = userModel.FatherOccupation,
                    MotherOcuupation = userModel.MotherOcuupation,
                    ContactNo = userModel.ContactNo,
                    Email = userModel.Email,
                    Password = userModel.Password,
                    UserType = userType,
                    CreatedBy = userModel.CreatedBy,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                };

                _dbContext.Add(tblUser);
                await _dbContext.SaveChangesAsync();
                userResponseModel = new UserResponseModel()
                {
                    Status = true,
                    Message = Constants.Success
                };
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"AddUser Exception : {ex.ToString()}");
                throw ex;
            }
            return userResponseModel;
        }
        #endregion

        #region UpdateUser
        public async Task<UserResponseModel> UpdateUser(UserModel userModel)
        {
            UserResponseModel userResponseModel = null;
            try
            {
                var student = await _dbContext.TblUsers.FirstOrDefaultAsync(_ => _.Id == userModel.Id);
                if (student != null)
                {
                    student.FirstName = userModel.FirstName;
                    student.MiddleName = userModel.MiddleName;
                    student.LastName = userModel.LastName;
                    student.Standard = userModel.Standard;
                    student.BirthDate = Convert.ToDateTime(Convert.ToDateTime(userModel.BirthDate).ToShortDateString());
                    student.Gender = userModel.Gender;
                    student.Address = userModel.Address;
                    student.Photo = userModel.Photo;
                    student.FatherOccupation = userModel.FatherOccupation;
                    student.MotherOcuupation = userModel.MotherOcuupation;
                    student.ContactNo = userModel.ContactNo;
                    student.Email = userModel.Email;
                    student.Password = userModel.Password;
                    student.UpdatedBy = userModel.UpdatedBy;
                    student.UpdatedDate = DateTime.Now;

                    await _dbContext.SaveChangesAsync();
                    userResponseModel = new UserResponseModel()
                    {
                        Status = true,
                        Message = Constants.Success
                    };
                }
                else
                {
                    userResponseModel = new UserResponseModel()
                    {
                        Status = false,
                        Message = Constants.Error
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"UpdateUser Exception : {ex.ToString()}");
                throw ex;
            }
            return userResponseModel;
        }
        #endregion

        #region DeleteUser
        public async Task<UserResponseModel> DeleteUser(UserModel userModel)
        {
            UserResponseModel userResponseModel = null;
            try
            {
                var user = await _dbContext.TblUsers.FirstOrDefaultAsync(_ => _.Id == userModel.Id);
                if (user != null)
                {
                    user.IsDeleted = true;
                    user.UpdatedBy = userModel.UpdatedBy;
                    user.UpdatedDate = DateTime.Now;

                    await _dbContext.SaveChangesAsync();
                    userResponseModel = new UserResponseModel()
                    {
                        Status = true,
                        Message = Constants.Success
                    };
                }
                else
                {
                    userResponseModel = new UserResponseModel()
                    {
                        Status = false,
                        Message = Constants.Error
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"DeleteUser Exception : {ex.ToString()}");
                throw ex;
            }
            return userResponseModel;
        }
        #endregion

        #region GetUserbyId
        public async Task<UserResponseModel> GetUserbyId(int Id)
        {
            UserResponseModel userResponseModel = null;
            try
            {
                var user = await _dbContext.TblUsers.Include(_ => _.UserTypeNavigation).FirstOrDefaultAsync(_ => _.Id == Id);
                if (user != null)
                {
                    var studentData = new UserModel()
                    {
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName,
                        LastName = user.LastName,
                        Standard = user.Standard ?? 0,
                        BirthDate = Convert.ToDateTime(user.BirthDate).ToShortDateString(),
                        Gender = user.Gender,
                        Address = user.Address,
                        Photo = user.Photo,
                        FatherOccupation = user.FatherOccupation,
                        MotherOcuupation = user.MotherOcuupation,
                        ContactNo = user.ContactNo,
                        Id = user.Id,
                        UserType = user.UserType ?? 0,
                        UserTypeName = user.UserTypeNavigation.UserType,
                        Email = user.Email,
                        Password = user.Password
                    };

                    List<UserModel> usertList = new List<UserModel>();
                    usertList.Add(studentData);

                    userResponseModel = new UserResponseModel()
                    {
                        Status = true,
                        Message = Constants.Success,
                        UserData = usertList
                    };
                }
                else
                {
                    userResponseModel = new UserResponseModel()
                    {
                        Status = true,
                        Message = Constants.DataNotFound
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetUserbyId Exception : {ex.ToString()}");
                throw ex;
            }
            return userResponseModel;
        }
        #endregion

        #region GetStudents
        public async Task<UserResponseModel> GetStudents()
        {
            UserResponseModel userResponseModel = null;
            try
            {
                var userData = await _dbContext.TblUsers.Where(_ => _.UserTypeNavigation.UserType.ToLower() == UserType.Student.ToString().ToLower()
                && _.IsDeleted == false).Select(_ => new UserModel
                {
                    FirstName = _.FirstName,
                    MiddleName = _.MiddleName,
                    LastName = _.LastName,
                    Standard = _.Standard ?? 0,
                    StandardName = _.StandardNavigation.Standard,
                    BirthDate = Convert.ToDateTime(_.BirthDate).ToShortDateString(),
                    Gender = _.Gender,
                    Address = _.Address,
                    Photo = _.Photo,
                    FatherOccupation = _.FatherOccupation,
                    MotherOcuupation = _.MotherOcuupation,
                    ContactNo = _.ContactNo,
                    Id = _.Id,
                    UserType = _.UserType ?? 0,
                    UserTypeName = _.UserTypeNavigation.UserType
                }).ToListAsync();

                userResponseModel = new UserResponseModel()
                {
                    Status = true,
                    Message = Constants.Success,
                    UserData = userData != null && userData.Count() == 0 ? null : userData
                };
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetStudents Exception : {ex.ToString()}");
                throw ex;
            }
            return userResponseModel;
        }
        #endregion

        #region GetTeachers
        public async Task<UserResponseModel> GetTeachers()
        {
            UserResponseModel userResponseModel = null;
            try
            {
                var userData = await _dbContext.TblUsers.Where(_ => _.UserTypeNavigation.UserType.ToLower() == UserType.Teacher.ToString().ToLower()
                && _.IsDeleted == false).Select(_ => new UserModel
                {
                    FirstName = _.FirstName,
                    MiddleName = _.MiddleName,
                    LastName = _.LastName,
                    Standard = _.Standard ?? 0,
                    StandardName = _.StandardNavigation.Standard,
                    BirthDate = Convert.ToDateTime(_.BirthDate).ToShortDateString(),
                    Gender = _.Gender,
                    Address = _.Address,
                    Photo = _.Photo,
                    FatherOccupation = _.FatherOccupation,
                    MotherOcuupation = _.MotherOcuupation,
                    ContactNo = _.ContactNo,
                    Id = _.Id,
                    UserType = _.UserType ?? 0,
                    UserTypeName = _.UserTypeNavigation.UserType,
                    Email = _.Email,
                    Password = _.Password
                }).ToListAsync();

                userResponseModel = new UserResponseModel()
                {
                    Status = true,
                    Message = Constants.Success,
                    UserData = userData != null && userData.Count() == 0 ? null : userData
                };
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetTeachers Exception : {ex.ToString()}");
                throw ex;
            }
            return userResponseModel;
        }
        #endregion

        #region GetStudents Count By Standard
        public async Task<UserCountResponseModel> GetStudentsCountByStandard()
        {
            UserCountResponseModel userCountResponse = null;
            try
            {
                var studentCount = await _dbContext.TblStandards.
                GroupJoin(
                    _dbContext.TblUsers.Where(_ => _.UserTypeNavigation.UserType.ToLower() == UserType.Student.ToString().ToLower()
                                    && _.IsDeleted == false),
                    dept => dept.Id,
                    emp => emp.Standard,
                    //User Defined names in Result Selector
                    (dept, emp) => new UserCount
                    {
                        Standard = dept.Standard,
                        Count = emp.Count()
                    }
                ).ToListAsync();

                userCountResponse = new UserCountResponseModel()
                {
                    Status = true,
                    Message = Constants.Success,
                    UserCount = studentCount != null && studentCount.Count() == 0 ? null : studentCount
                };
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetStudentsCountByStandard Exception : {ex.ToString()}");
                throw ex;
            }
            return userCountResponse;
        }
        #endregion
    }
}
