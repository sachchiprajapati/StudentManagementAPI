using IdentityModel.Client;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.Core;

namespace StudentManagement.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        #region "Declarations"
        private readonly ILoginRepository _loginRepository;
        private readonly ILogger<LoginController> _logger;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClientFactory;
        public LoginController(ILoginRepository loginRepository, ILogger<LoginController> logger, IConfiguration configuration, HttpClient httpClientFactory)
        {
            _loginRepository = loginRepository;
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        #endregion

        #region login

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> login([FromBody] LoginRequestModel loginRequestModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"login Request : {JsonConvert.SerializeObject(loginRequestModel)}");
                    var response = await _loginRepository.ValidateLogin(loginRequestModel);
                    _logger.LogInformation($"login Response : {JsonConvert.SerializeObject(response)}");
                    return Ok(response);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Token Genertion
        [HttpPost("token/create")]
        public async Task<IActionResult> CreateToken([FromBody] TokenLoginModel login)
        {
            //var client = _httpClientFactory.CreateClient("token_client");


            //        var response = await client.RequestTokenAsync(new TokenRequest
            //        {
            //            Address = "https://localhost:7007/connect/token",
            //            GrantType = "custom",

            //            ClientId = "client",
            //            ClientSecret = "secret",

            //            Parameters =
            //{
            //    { "custom_parameter", "custom value"},
            //    { "scope", "api1" }
            //}
            //        });

            var client = new HttpClient();
            PasswordTokenRequest tokenRequest = new PasswordTokenRequest()
            {
                Address = "https://localhost:7007/connect/token",
                ClientId = "studentsystem",
                ClientSecret = "student#@123",
                UserName = login.Username,
                Password = login.Password,
            };

            var response = client.RequestPasswordTokenAsync(tokenRequest).Result;
            if (!response.IsError)
            {
                //
            }
            else
            {
                throw new Exception("Invalid username or password");
            }

            var data = new PasswordTokenRequest
            {
                Address = "https://localhost:7007/connect/token", //$"{_configuration["AuthConfiguration:ClientUrl"]}/connect/token",
                GrantType = "password",
                ClientId = _configuration["IdentityAuth:ClientId"],
                ClientSecret = _configuration["IdentityAuth:ClientSecrets"],
                Scope = $"{IdentityServerConstants.StandardScopes.OpenId} {IdentityServerConstants.StandardScopes.Profile} assapi offline_access",

                UserName = login.Username,
                Password = login.Password
            };

            var tokenResponse = await client.RequestPasswordTokenAsync(data).ConfigureAwait(false);

            if (tokenResponse.IsError)
            {
                return BadRequest(tokenResponse.ErrorDescription);
            }

            return Ok(new
            {
                AccessToken = tokenResponse.AccessToken,
                RefreshToken = tokenResponse.RefreshToken,
                ExpiresIn = tokenResponse.ExpiresIn,
                ExpiresAtUtc = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn)
            });
        }
        #endregion
    }
}
