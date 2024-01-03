using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core.RequestResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Users.Commands.SetPassive
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

            var user = await _dataAccess.GetUserById(request.Id);
            user.IsActive = false;

            await _dataAccess.Update(user);
            var response = mapper.MapToResponse(user);
            return ArfBlocksResults.Success(response);
        }
    }
}
