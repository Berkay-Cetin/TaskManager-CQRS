using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core.RequestResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.EditAssignment;

public class Handler : IRequestHandler
{
    private readonly DataAccess _dataAccess;
    public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
    {
        _dataAccess = (DataAccess)dataAccess;
    }

    public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
    {
        var requestPayload = (RequestModel)payload;
        var mapper = new Mapper();
        var assignment = await _dataAccess.GetAssignmentById(requestPayload.AssignmentId);
        var assignee = await _dataAccess.GetUserById(requestPayload.AssigneeId);
        var newAssignment = mapper.MapToNewEntity(requestPayload);

        assignment.Assignee = assignee;
        assignment.AssigneeId = newAssignment.AssigneeId;
        assignment.Description = newAssignment.Description;
        assignment.Details = newAssignment.Details;
        assignment.Status = newAssignment.Status;

        await _dataAccess.Update(assignment);
        var response = mapper.MapToResponse(assignment);
        return ArfBlocksResults.Success(response);
    }
}
