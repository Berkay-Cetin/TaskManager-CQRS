using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Users.Queries.Me
{
    public class Mapper
    {
        public ResponseModel MapToResponse(User user)
        {
            return new ResponseModel()
            {
                UserId = user.UserId,
                Name = user.UserName,
                Email = user.Email,
                Contact = user.Contact,
                DepartmentId = user.DepartmentId,
                Title = user.Title,
            };
        }
    }
}
