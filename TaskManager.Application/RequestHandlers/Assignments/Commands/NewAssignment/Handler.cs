using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core.RequestResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.NewAssignment;

public class Handler : IRequestHandler
{
    private readonly DataAccess _dataAccessLayer;
    private readonly CurrentUserService _currentUserService;
    public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
    {
        _dataAccessLayer = (DataAccess)dataAccess;
        _currentUserService = dependencyProvider.GetInstance<CurrentUserService>();
    }
    public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
    {
        var requestPayload = (RequestModel)payload;
        var mapper = new Mapper();
        var currentUser = _currentUserService.GetCurrentUser();

        var assignment = mapper.MapToCreateAssignment(requestPayload);
        assignment.CreatorId = currentUser.Id;
        await _dataAccessLayer.AddAssignment(assignment);

        var response = mapper.MapToResponse(assignment);
        return ArfBlocksResults.Success(response);
    }
}
