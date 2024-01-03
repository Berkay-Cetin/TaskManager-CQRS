using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core.RequestResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.DeleteAssignment;

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

        var assignment = await _dataAccess.GetAssignmentById(requestPayload.TaskId);
        await _dataAccess.Delete(assignment);
        /*if (assignment != null && assignment.CreatorId == payload.UserId)
        {
            await _dataAccess.Delete(assignment);
        }*/
        var response = mapper.MapToResponse(assignment);
        return ArfBlocksResults.Success(response);
    }
}
