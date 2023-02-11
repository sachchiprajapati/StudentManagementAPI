using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.Core;

namespace StudentManagement.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        #region "Declarations"
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger, IWebHostEnvironment hostEnvironment)
        {
            _userRepository = userRepository;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }
        #endregion

        #region AddUser
        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromForm] UserModel userModel)
        {
            try
            {
                //return Ok();
                _logger.LogInformation($"AddUser Request : {JsonConvert.SerializeObject(userModel)}");

                string fileName = userModel.PhotoFile != null ? await UploadImage(userModel.PhotoFile) : null;
                userModel.Photo = fileName;
                var response = await _userRepository.AddUser(userModel);
                _logger.LogInformation($"AddUser Response : {JsonConvert.SerializeObject(response)}");

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UpdateUser
        [Route("UpdateUser")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromForm] UserModel userModel)
        {
            try
            {
                _logger.LogInformation($"UpdateUser Request : {JsonConvert.SerializeObject(userModel)}");
                string fileName = userModel.PhotoFile != null ? await UploadImage(userModel.PhotoFile) : userModel.Photo;
                userModel.Photo = fileName;
                var response = await _userRepository.UpdateUser(userModel);
                _logger.LogInformation($"UpdateUser Response : {JsonConvert.SerializeObject(response)}");

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DeleteUser
        [Route("DeleteUser")]
        [HttpPost]
        public async Task<IActionResult> DeleteUser([FromForm] UserModel userModel)
        {
            try
            {
                _logger.LogInformation($"DeleteUser Request : {JsonConvert.SerializeObject(userModel)}");
                var response = await _userRepository.DeleteUser(userModel);
                _logger.LogInformation($"DeleteUser Response : {JsonConvert.SerializeObject(response)}");

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetUserbyId
        [Route("GetUserbyId")]
        [HttpGet]
        public async Task<IActionResult> GetUserbyId(int Id)
        {
            try
            {
                _logger.LogInformation($"GetUserbyId Request : {Id}");
                var response = await _userRepository.GetUserbyId(Id);
                if (response != null && response.UserData != null)
                    response.UserData.ForEach(_ => _.PhotoPath = Constants.UserPhotos + "/");
                _logger.LogInformation($"GetUserbyId Response : {JsonConvert.SerializeObject(response)}");

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetStudents
        [Route("GetStudents")]
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var response = await _userRepository.GetStudents();
                if (response != null && response.UserData != null)
                    response.UserData.ForEach(_ => _.PhotoPath = Constants.UserPhotos + "/");
                _logger.LogInformation($"GetStudents Response : {JsonConvert.SerializeObject(response)}");

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetTeachers
        [Route("GetTeachers")]
        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            try
            {
                var response = await _userRepository.GetTeachers();
                if (response != null && response.UserData != null)
                    response.UserData.ForEach(_ => _.PhotoPath = Constants.UserPhotos + "/");
                _logger.LogInformation($"GetTeachers Response : {JsonConvert.SerializeObject(response)}");

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Students Count By Standard
        [Route("GetStudentsCountByStandard")]
        [HttpGet]
        public async Task<IActionResult> GetStudentsCountByStandard()
        {
            try
            {
                var response = await _userRepository.GetStudentsCountByStandard();
                _logger.LogInformation($"GetTeachers Response : {JsonConvert.SerializeObject(response)}");

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "Other Methods"

        #region Save Employee Profile Image to StudentPhotos folder
        public async Task<string> UploadImage(IFormFile profileImage)
        {
            string fileName = string.Empty;

            //Save image to wwwroot/StudentPhotos
            if (profileImage != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, Constants.UserPhotos);
                fileName = Guid.NewGuid().ToString() + "_" + profileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await profileImage.CopyToAsync(fileStream);
                }
            }
            return fileName;
        }
        #endregion

        #endregion
    }
}
