using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.DeleteAssignment;

public class ResponseModel : IResponseModel
{
    public int Id { get; set; }
}

public class RequestModel : IRequestModel
{
    public int TaskId { get; set; }
}