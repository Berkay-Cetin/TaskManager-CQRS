using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Users.Commands.SetPassive
{
    public class Verificator : IRequestVerificator
    {
        private readonly AuthorizationService _authorizationService;
        private readonly CurrentUserService _currentUserService;
        private readonly DbVerificationService _dbVerificator;

        public Verificator(ArfBlocksDependencyProvider dependencyProvider)
        {
            _authorizationService = dependencyProvider.GetInstance<AuthorizationService>();
            _currentUserService = dependencyProvider.GetInstance<CurrentUserService>();
            _dbVerificator = dependencyProvider.GetInstance<DbVerificationService>();
        }

        public async Task VerificateActor(IRequestModel payload, CancellationToken cancellationToken)
        {
            //await _authorizationService.CheckPermission(DefinitionService.Resources.DeviceCommands, _currentUserService.GetCurrentUserStationId());
            // NOP:
            await Task.CompletedTask;
        }

        public async Task VerificateDomain(IRequestModel payload, CancellationToken cancellationToken)
        {
            var requestPayload = (RequestModel)payload;
            // NOP:
            await Task.CompletedTask;
        }
    }
}
