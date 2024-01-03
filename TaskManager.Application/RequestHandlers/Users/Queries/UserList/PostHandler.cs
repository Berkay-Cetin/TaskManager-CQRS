using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Users.Queries.UserList;

public class PostHandler : IPostRequestHandler
{
    private readonly Logger _logger;
    private readonly CurrentUserService _currentUserService;

    public PostHandler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
    {
        _logger = dependencyProvider.GetInstance<Logger>();
        _currentUserService = dependencyProvider.GetInstance<CurrentUserService>();
    }

    public async Task Handle(IRequestModel payload, ArfBlocksRequestResult response, CancellationToken cancellationToken)
    {
        if (response.HasError)
            await _logger.Error("Error: {@payload} {1}", _currentUserService.GetCurrentUser().Name, response.Error.Message);
        else
            await _logger.Debug("'{@payload}' kullanıcı listesini çağırdı.", _currentUserService.GetCurrentUser().Name);
    }
}
