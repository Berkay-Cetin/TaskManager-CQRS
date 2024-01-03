using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core;

namespace TaskManager.Application.RequestHandlers.Users.Commands.Register
{
    public class Mapper
    {
        public User MapToNewEntity(RequestModel request)
        {
            return new User()
            {
                UserName = request.UserName,
                Email = request.Email,
                Contact = request.Contact,
                DepartmentId = request.DepartmentId,
                Title = request.Title,
            };
        }

        public ResponseModel MapToResponse(User user)
        {
            return new ResponseModel()
            {
                Id = user.UserId
            };
        }
    }
}
