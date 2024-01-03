using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core.RequestResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Assignments.Queries.GetAssignmentByDepartment
{
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
            var mapper = new Mapper();
            var user = _currentUserService.GetCurrentUser();
            var dept = await _dataAccessLayer.GetDepartmentByUserId(user.Id);
            var assignments = await _dataAccessLayer.GetAssignmentsByDepartment(dept);

            var response = mapper.MapToResponse(assignments);

            return ArfBlocksResults.Success(response);
        }
    }
}
