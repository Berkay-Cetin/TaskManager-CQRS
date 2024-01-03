using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core.RequestResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Assignments.Queries.GetAssignment;

public class Handler : IRequestHandler
{
    private readonly DataAccess _dataAccess;

    public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
    {
        _dataAccess = (DataAccess)dataAccess;
    }

    public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
    {
        var mapper = new Mapper();
        var assignments = await _dataAccess.GetAllAssignments();
        var response = mapper.MapToResponse(assignments);

        return ArfBlocksResults.Success(response);
    }
}
