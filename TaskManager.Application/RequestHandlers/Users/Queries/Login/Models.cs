using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.RequestHandlers.Users.Queries.Login;

public class ResponseModel : IResponseModel
{
    public string JwtToken { get; set; }
}

public class RequestModel : IRequestModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}