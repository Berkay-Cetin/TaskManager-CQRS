using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Errors;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Users.Commands.Register;

public class Validator : IRequestValidator
{
    private readonly DbValidationService _dbValidator;
    public Validator(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dbValidator = dependencyProvider.GetInstance<DbValidationService>();
    }

    public void ValidateRequestModel(IRequestModel payload, CancellationToken cancellationToken)
    {
        // Get Request Payload
        var requestModel = (RequestModel)payload;

        // Request Model Validation
        var validationResult = new RequestModel_Validator().Validate(requestModel);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.ToString("~");
            throw new ArfBlocksValidationException(errors);
        }
    }

    public async Task ValidateDomain(IRequestModel payload, CancellationToken cancellationToken)
    {
        // Get Request Payload
        var requestPayload = (RequestModel)payload;

        //NOP:
        await Task.CompletedTask;
        // Db Validations
        /*await _dbValidator.ValidateStationExist(requestPayload.StationId);
        await _dbValidator.ValidateSerialPortExist(requestPayload.SerialPortId);
        if (requestPayload.TankId.HasValue)
            await _dbValidator.ValidateTankExist(requestPayload.TankId.Value);*/
    }

}

public class RequestModel_Validator : AbstractValidator<RequestModel>
{
    public RequestModel_Validator()
    {
    }
}
