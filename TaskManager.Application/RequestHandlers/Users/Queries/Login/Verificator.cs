using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Users.Queries.Login;

public class Verificator : IRequestVerificator
{
    private readonly DbVerificationService _dbVerificator;
    public Verificator(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dbVerificator = dependencyProvider.GetInstance<DbVerificationService>();
    }

    public async Task VerificateActor(IRequestModel payload, CancellationToken cancellationToken)
    {
        // NOP:
        await Task.CompletedTask;
    }

    public async Task VerificateDomain(IRequestModel payload, CancellationToken cancellationToken)
    {
        // Get Request Payload
        var requestPayload = (RequestModel)payload;

        // DB Validations
        await _dbVerificator.VerifyPasswordCorrect(requestPayload.Username, requestPayload.Password);
    }
}
