using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Departments.Queries.GetDepartment;

public class Verificator : IRequestVerificator
{
    private readonly AuthorizationService _authorizationService;
    private readonly CurrentUserService _currentUserService;

    public Verificator(ArfBlocksDependencyProvider dependencyProvider)
    {
        //_authorizationService = dependencyProvider.GetInstance<AuthorizationService>();
        //_currentUserService = dependencyProvider.GetInstance<CurrentUserService>();
    }

    public async Task VerificateActor(IRequestModel payload, CancellationToken cancellationToken)
    {
        //await _authorizationService.CheckPermission(DefinitionService.Resources.Users, _currentUserService.GetCurrentUserStationId());
        // NOP:
        await Task.CompletedTask;
    }

    public async Task VerificateDomain(IRequestModel payload, CancellationToken cancellationToken)
    {
        // NOP:
        await Task.CompletedTask;
    }
}
