using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Users.Queries.UserList
{
    public class Mapper
    {
        public List<ResponseModel> MapToResponse(List<User> users)
        {
            return users.Select(user=>new ResponseModel()
            {
                UserId = user.UserId,
                UserName = user.UserName,
            }).ToList();
        }
    }
}
