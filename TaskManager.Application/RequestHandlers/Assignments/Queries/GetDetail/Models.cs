using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.RequestHandlers.Assignments.Queries.GetDetail;

public class ResponseModel : IResponseModel
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Details { get; set; }
    public assigneeResponse Assignee { get; set; }
    public string Creator { get; set; }
    public AssignmentStatusType Status { get; set; }
}

public class RequestModel : IRequestModel
{
    public int AssignmentId { get; set; }
}

public class assigneeResponse
{
    public string Name { get; set; }
    public string Email {  get; set; }
    public int departmentId { get; set; }
}
