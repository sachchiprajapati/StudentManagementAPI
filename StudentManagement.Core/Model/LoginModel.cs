using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Core
{
    public class LoginRequestModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class LoginResponseModel : BaseResponseModel
    {
        public int Id { get;set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
    }

    public class TokenLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
