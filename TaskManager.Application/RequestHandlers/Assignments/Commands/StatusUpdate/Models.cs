using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.StatusUpdate;

public class ResponseModel : IResponseModel
{
    public int Id { get; set; }
}

public class RequestModel : IRequestModel
{
    public int AssignmentId { get; set; }
    public AssignmentStatusType NewStatus { get; set; }
}