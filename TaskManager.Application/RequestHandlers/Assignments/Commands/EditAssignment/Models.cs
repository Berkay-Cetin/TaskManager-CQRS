using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.EditAssignment;

public class ResponseModel : IResponseModel
{
    public int Id { get; set; }
}

public class RequestModel : IRequestModel
{
    public int AssigneeId { get; set; }
    public int AssignmentId { get; set; }
    public string Detail { get; set; }
    public string Description { get; set; }
    public AssignmentStatusType NewStatus { get; set; }
}