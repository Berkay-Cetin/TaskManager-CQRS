using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Users.Queries.UserList;

public class ResponseModel : IResponseModel<Array>
{
    public int UserId { get; set; }
    public string UserName { get; set; }
}
