using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Base.Security
{
    [HttpService]
    public class LoginService
    {
        public const string USER_DATA_JSON_KEY = "userDataJson";
        private SecurityAuthenticator authenticator;
        private IOptions<SecurityOptions> config;

        public LoginService(SecurityAuthenticator authenticator, IOptions<SecurityOptions> config)
        {
            this.authenticator = authenticator;
            this.config = config;
        }

        public LoginResponse Login(LoginRequest toRequest)
        {
            LoginResponse response = new LoginResponse();

            IUserData userData = authenticator.Authenticate(toRequest);

            if (userData != null)
            {
                var tokenString = GenerateJSONWebToken(userData.LoginName, userData);
                response.Success = true;
                response.Token = tokenString;
            }
            else
            {
                response.Success = false;
            }

            return response;
        }

        private string GenerateJSONWebToken(string username, object userData)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Value.JwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userJsonData = JsonConvert.SerializeObject(userData);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(USER_DATA_JSON_KEY, userJsonData),
                // new Claim(USER_DATA_JSON_FOO, userData.FOO),
                // Parse over the UserData object and assign each property as a Name/Value pair
            };

            var token = new JwtSecurityToken(
                config.Value.JwtIssuer,
                config.Value.JwtIssuer,
                claims,
                expires: DateTime.Now.AddHours((config.Value.JwtExpireHours )), 
                // Convert SdateTime object to miliseconds - Currently iot is converting to seconds.
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}


