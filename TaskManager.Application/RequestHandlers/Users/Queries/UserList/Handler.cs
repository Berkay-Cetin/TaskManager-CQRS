using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core.RequestResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.RequestHandlers.Users.Queries.UserList;

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
        var users = await _dataAccess.GetAllUsers();
        var response = mapper.MapToResponse(users);
        return ArfBlocksResults.Success(response);
    }
}
