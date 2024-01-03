using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using TaskManager.Infrastructure.Services;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.RequestResults;

namespace TaskManager.Application.RequestHandlers.Users.Queries.Me
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

        public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload,CancellationToken cancellationToken)
        {
            var mapper = new Mapper();
            var userTemp = _currentUserService.GetCurrentUser();
            var user = await _dataAccessLayer.GetUserById(userTemp.Id);
            var response = mapper.MapToResponse(user);
            return ArfBlocksResults.Success(response);
        }
    }
}
