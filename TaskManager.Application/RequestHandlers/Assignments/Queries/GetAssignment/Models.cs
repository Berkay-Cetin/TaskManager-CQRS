using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.RequestHandlers.Assignments.Queries.GetAssignment;

public class ResponseModel : IResponseModel<Array>
{
    public string Creator { get; set; }
    public assigneeResponse Assignee { get; set; }
    public string Description { get; set; }
    public AssignmentStatusType Status { get; set; }

}
public class assigneeResponse
{
    public string name { get; set; }
    public string email { get; set; }
    public int DepartmentId { get; set; }
}