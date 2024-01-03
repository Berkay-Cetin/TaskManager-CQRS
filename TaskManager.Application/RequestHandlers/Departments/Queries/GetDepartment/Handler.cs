using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core.RequestResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Departments.Queries.GetDepartment;

public class Handler : IRequestHandler
{
    private readonly DataAccess _dataAccessLayer;
    private readonly CurrentUserService _currentUserService;

    public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
    {
        _dataAccessLayer = (DataAccess)dataAccess;
        _currentUserService = dependencyProvider.GetInstance<CurrentUserService>();
    }

    public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
    {
        var requestPayload = (RequestModel)payload;
        var mapper = new Mapper();

        var departments = await _dataAccessLayer.GetAllDepartments();

        var response = mapper.MapToResponse(departments);
        return ArfBlocksResults.Success(response);
    }
}
