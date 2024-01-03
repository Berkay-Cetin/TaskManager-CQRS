using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core.RequestResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Users.Queries.Login;

public class Handler : IRequestHandler
{
    private readonly DataAccess _dataAccess;
    private readonly JwtService _jwtService;

    public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
    {
        _dataAccess = (DataAccess)dataAccess;
        _jwtService = dependencyProvider.GetInstance<JwtService>();
    }
    public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
    {
        var requestPayload = (RequestModel)payload;
        var mapper = new Mapper();

        var user = await _dataAccess.GetUserByEmail(requestPayload.Username);

        var token = _jwtService.GenerateJwt(user);

        var response = mapper.MapToResponse(token);

        return ArfBlocksResults.Success(response);
    }
}