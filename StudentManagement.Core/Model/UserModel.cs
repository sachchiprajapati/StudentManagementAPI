using Microsoft.AspNetCore.Http;

namespace StudentManagement.Core
{
    public class UserModel
    {
        public int Id { get; set; }
        public int UserType { get; set; }
        public string UserTypeName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public int Standard { get; set; }
        public string StandardName { get; set; }
        public string Address { get; set; }
        public IFormFile PhotoFile { get; set; }
        public string Photo { get; set; }
        public string PhotoPath { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherOcuupation { get; set; }
        public string ContactNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class UserResponseModel : BaseResponseModel
    {
        public List<UserModel> UserData { get; set; }
    }


    public class UserCountResponseModel : BaseResponseModel
    {
        public List<UserCount> UserCount { get; set; }
    }

    public class UserCount
    {
        public string Standard { get; set; }
        public int Count { get; set; }
    }
}
