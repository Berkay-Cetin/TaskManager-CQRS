using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Enums;

namespace TaskManager.Infrastructure.Services
{
    public class CurrentUserService
    {
        /*private CurrentUserModel _currentUser;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //public CurrentUserService(IHttpContextAccessor httpContextAccessor, EnvironmentService environmentService, CurrentUserModel identifiedClient)
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, CurrentUserModel identifiedClient)
        {
            _httpContextAccessor = httpContextAccessor;

            if (environmentService.Environment == CustomEnvironments.Test)
            {
                this._currentUser = identifiedClient;
            }
            else
            {
                this._currentUser = this.ParseJwt();
            }
            this._currentUser = this.ParseJwt();
        }


        private CurrentUserModel ParseJwt()
        {
            try
            {
                var auhtorizatioValue = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
                if (auhtorizatioValue != null)
                {
                    // format: [Authorization : Baerer eykjdsfjajfkl230423ujre2r23rnnj]
                    string jwtInput = auhtorizatioValue.Split(' ')[1];

                    var jwtHandler = new JwtSecurityTokenHandler();

                    // Check Token Format
                    if (!jwtHandler.CanReadToken(jwtInput)) throw new Exception("Invalid JWT format.");

                    var token = jwtHandler.ReadJwtToken(jwtInput);

                    // Get Claims
                    var name = token.Claims.FirstOrDefault(c => c.Type == "given_name").Value;
                    var userId = int.Parse(token.Claims.FirstOrDefault(c => c.Type == "nameid").Value);
                    var type = (UserTypes)int.Parse(token.Claims.FirstOrDefault(c => c.Type == "user_type").Value);
                    var stationId = Guid.Parse(token.Claims.FirstOrDefault(c => c.Type == "station_id").Value);
                    var stationLicenseNo = token.Claims.FirstOrDefault(c => c.Type == "station_license_no").Value;
                    var stationSubLicenseNo = token.Claims.FirstOrDefault(c => c.Type == "station_sub_license_no").Value;

                    var _currentUser = new CurrentUserModel()
                    {
                        UserId = userId,
                        Name = name,
                        UserType = type,
                        StationId = stationId,
                        StationLicenseNo = stationLicenseNo,
                        StationSubLicenseNo = stationSubLicenseNo,
                    };

                    return _currentUser;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"CurrentUserService JWT Parsing Error: {exception.Message}");
            }

            return null;
        }
        public CurrentUserModel GetCurrentUser()
        {
            return this._currentUser;
        }


        public class CurrentUserModel
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public UserTypes UserType { get; set; }
            public Guid StationId { get; set; }
            public string StationLicenseNo { get; set; }
            public string StationSubLicenseNo { get; set; }
            public string IdentityNumber { get; set; }
        }*/



        
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public CurrentUserResponse GetCurrentUser()
        {
            var user = new CurrentUserResponse();
            if (_httpContextAccessor.HttpContext != null)
            {
                user = new CurrentUserResponse
                {
                    Id = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)),
                    Name = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name),
                    Email = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email),
                    Title = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role)
                };
            }
            return user;
        }
        public class CurrentUserResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Title { get; set; }
        }
    }
}
