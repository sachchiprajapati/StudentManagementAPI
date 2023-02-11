using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace StudentManagement
{
    public static class ConfigurationHelper
    {
        public static IConfiguration _configuration;
        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope> {
            new ApiScope(_configuration["IdentityAuth:Scope"], "Student System")
        };

        public static IEnumerable<Client> Clients => new List<Client> {
            new Client {
                    ClientId = _configuration["IdentityAuth:ClientId"],
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = {
                        new Secret(_configuration["IdentityAuth:ClientSecrets"].Sha256())
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        _configuration["IdentityAuth:Scope"],
                        IdentityServerConstants.StandardScopes.OfflineAccess
                    },
                    AllowOfflineAccess  = true,     //This feature refresh token
                    RefreshTokenUsage = TokenUsage.ReUse,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    AccessTokenLifetime = 1200,     //Access token life time is 1200 seconds (20 min)
                    IdentityTokenLifetime = 1200    //Identity token life time is 1200 seconds (20 min)
            }
        };

        public static IEnumerable<TestUser> TestUsers()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "admin@gmail.com",
                    Password = "admin",
                    Claims = new List<Claim>{new Claim(ClaimTypes.Email, "admin@gmail.com") }
                }
            };
        }
    }
}
