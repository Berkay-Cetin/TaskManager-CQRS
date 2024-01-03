using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.RequestHandlers.Users.Commands.Register;

public class ResponseModel : IResponseModel
{
    public int Id { get; set; }
}

public class RequestModel : IRequestModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Contact { get; set; }
    public int DepartmentId { get; set; }
    public string Title { get; set; }
    public string Password { get; set; }
}