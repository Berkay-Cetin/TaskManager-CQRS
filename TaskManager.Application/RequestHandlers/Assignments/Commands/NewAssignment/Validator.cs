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

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.NewAssignment;

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

        // Db Validations
        //await _dbValidator.ValidateTaskExist(requestPayload.Id);
        //NOP:
        await Task.CompletedTask;
    }
}

public class RequestModel_Validator : AbstractValidator<RequestModel>
{
    public RequestModel_Validator()
    {
        RuleFor(x => x.Description)
                .NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.NameNotValid))
                .NotEmpty().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.NameNotValid));

        RuleFor(x => x.AssigneeId)
                .NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.IdNotValid))
                .NotEmpty().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.IdNotValid));

        RuleFor(x => x.Detail)
                .NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.NameNotValid))
                .NotEmpty().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.NameNotValid));
    }
}
