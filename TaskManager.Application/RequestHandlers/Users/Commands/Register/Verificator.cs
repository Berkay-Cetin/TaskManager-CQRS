using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Users.Commands.Register;

public class Verificator : IRequestVerificator
{
    private readonly AuthorizationService _authorizationService;
    private readonly CurrentUserService _currentUserService;

    public Verificator(ArfBlocksDependencyProvider dependencyProvider)
    {
        //_authorizationService = dependencyProvider.GetInstance<AuthorizationService>();
        _currentUserService = dependencyProvider.GetInstance<CurrentUserService>();
    }

    public async Task VerificateActor(IRequestModel payload, CancellationToken cancellationToken)
    {
        //await _authorizationService.CheckPermission(DefinitionService.Resources.DeviceCommands, _currentUserService.GetCurrentUser().Id);
        // NOP:
        await Task.CompletedTask;
    }

    public async Task VerificateDomain(IRequestModel payload, CancellationToken cancellationToken)
    {
        // NOP:
        await Task.CompletedTask;
    }
}
