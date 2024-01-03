using Arfware.ArfBlocks.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly ArfBlocksRequestOperator _requestOperator;

        public UsersController(ArfBlocksDependencyProvider dependencyProvider)
        {
            _requestOperator = new ArfBlocksRequestOperator(dependencyProvider);
        }

        // QUERIES

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <response code="200">Returns All Users in Response.Payload</response>
        [HttpGet("[action]")]
        public async Task<ActionResult<List<Application.RequestHandlers.Users.Queries.UserList.ResponseModel>>> All()
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Users.Queries.UserList.Handler>(null);
        }

        /// <summary>
        /// Get Current Users
        /// </summary>
        /// <response code="200">Returns Current User in Response.Payload</response>
        [HttpGet("[action]")]
        public async Task<ActionResult<List<Application.RequestHandlers.Users.Queries.Me.ResponseModel>>> Me()
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Users.Queries.Me.Handler>(null);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <response code="200">Returns User Jwt in Response.Payload</response>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<Application.RequestHandlers.Users.Queries.Login.ResponseModel>> Login(Application.RequestHandlers.Users.Queries.Login.RequestModel payload)
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Users.Queries.Login.Handler>(payload);            
        }

        // COMMANDS 

        /// <summary>
        /// Register
        /// </summary>
        /// <response code="200">Returns Registered User in Response.Payload</response>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<Application.RequestHandlers.Users.Commands.Register.ResponseModel>> Register(Application.RequestHandlers.Users.Commands.Register.RequestModel payload)
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Users.Commands.Register.Handler>(payload);
        }

        /// <summary>
        /// SetPassive
        /// </summary>
        /// <response code="200">Returns Id of a User which is set to passive in Response.Payload</response>
        [HttpPut("[action]")]
        public async Task<ActionResult<Application.RequestHandlers.Users.Commands.SetPassive.ResponseModel>> SetPassive(Application.RequestHandlers.Users.Commands.SetPassive.RequestModel payload)
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Users.Commands.SetPassive.Handler>(payload);
        }
    }
}
