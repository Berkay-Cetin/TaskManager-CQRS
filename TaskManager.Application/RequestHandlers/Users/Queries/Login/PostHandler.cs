using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Users.Queries.Login;

public class PostHandler : IPostRequestHandler
{
    private readonly Logger _logger;

    public PostHandler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
    {
        _logger = dependencyProvider.GetInstance<Logger>();
    }

    public async Task Handle(IRequestModel payload, ArfBlocksRequestResult response, CancellationToken cancellationToken)
    {
        var requestPayload = (RequestModel)payload;
        var responsePayload = (ResponseModel)response.Payload;

        if (response.HasError)
            await _logger.Error("Error: {@payload} {1}", requestPayload, response.Error.Message);
        else
            await _logger.Information("'{@payload}' kişi giriş yaptı", requestPayload.Username);
    }
}
