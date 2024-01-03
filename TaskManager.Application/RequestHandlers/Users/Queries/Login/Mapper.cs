using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Users.Queries.Login
{
    public class Mapper
    {
        public RequestModel MapToRequest(RequestModel request)
        {
            return new RequestModel
            {
                Username = request.Username,
                Password = request.Password,
            };
        }
        public ResponseModel MapToResponse(string jwtToken)
        {
            return new ResponseModel
            {
                JwtToken = jwtToken,
            };
        }
    }
}
