using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Users.Commands.SetPassive
{
    public class Mapper
    {
        public ResponseModel MapToResponse(User user)
        {
            return new ResponseModel()
            {
                Id = user.UserId,
            };
        }
    }
}
