using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.NewAssignment;

public class ResponseModel : IResponseModel
{
    public int AssignmentId { get; set; }
}

public class RequestModel : IRequestModel
{
    public string Description { get; set; }
    public string Detail { get; set; }
    public int AssigneeId { get; set; }
    //public int CreatorId { get; set; }
}