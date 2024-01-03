using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Users.Queries.Me;


public class ResponseModel : IResponseModel
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Contact { get; set; }
    public int DepartmentId { get; set; }
    public string Title { get; set; }
    public bool IsActive { get; set; }
}
