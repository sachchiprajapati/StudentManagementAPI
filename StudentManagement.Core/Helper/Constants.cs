using System.Runtime.Serialization;

namespace StudentManagement.Core
{
    public static class Constants
    {
        public const string Success = "Success";
        public const string Error = "Error";
        public const string DataNotFound = "DataNotFound";
        public const string UserTypeStudent = "Student";
        public const string UserPhotos = "UserPhotos";
    }

    public enum UserType
    {
        [EnumMember(Value = "Admin")]
        Admin,
        [EnumMember(Value = "Principal")]
        Principal,
        [EnumMember(Value = "Teacher")]
        Teacher,
        [EnumMember(Value = "Student")]
        Student
    }
}
