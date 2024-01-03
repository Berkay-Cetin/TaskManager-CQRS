using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core.RequestResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.RequestHandlers.Users.Commands.Register
{
    public class Handler : IRequestHandler
    {
        private readonly DataAccess _dataAccess;
        public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
        {
            _dataAccess = (DataAccess)dataAccess;
        }

        public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
        {
            var request = (RequestModel)payload;
            var mapper = new Mapper();

            var user = mapper.MapToNewEntity(request);
            user.Password = PassHasher.HashPassword(request.Password);
            user.IsActive = true;

            await _dataAccess.AddUser(user);

            var response = mapper.MapToResponse(user);
            return ArfBlocksResults.Success(response);
        }
    }
}
