using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core.RequestResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.RequestHandlers.Assignments.Queries.FilterAssignment;

public class Handler : IRequestHandler
{
    private readonly DataAccess _dataAccess;
    public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
    {
        _dataAccess = (DataAccess)dataAccess;
    }

    public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
    {
        var requestPayload = (RequestModel)payload;
        var mapper = new Mapper();
        var assignments = await _dataAccess.FilterByAssignedPerson(requestPayload.filterText);
        /*var assignments = new List<Assignment>();

        switch (requestPayload.Filter)
        {
            case AssignmentFilters.AssignedPerson:
                assignments = await _dataAccess.FilterByAssignedPerson(requestPayload.filterText);
                break;
            case AssignmentFilters.AssignedEmail:
                assignments = await _dataAccess.FilterByAssignedEmail(requestPayload.filterText);
                break;
            case AssignmentFilters.AssignedDepartment:
                assignments = await _dataAccess.FilterByAssignedDepartment(requestPayload.filterText);
                break;
            case AssignmentFilters.Description:
                assignments = await _dataAccess.FilterByDescription(requestPayload.filterText);
                break;
            case AssignmentFilters.CreatorPerson:
                assignments = await _dataAccess.FilterByCreator(requestPayload.filterText);
                break;
            default:
                break;
        }*/

        var response = mapper.MapToResponse(assignments);
        return ArfBlocksResults.Success(response);
    }
}
