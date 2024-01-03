using Arfware.ArfBlocks.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ArfBlocksRequestOperator _requestOperator;
        public DepartmentsController(ArfBlocksDependencyProvider dependencyProvider)
        {
            _requestOperator = new ArfBlocksRequestOperator(dependencyProvider);
        }

        // QUERIES

        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <response code="200">Returns All Departments in Response.Payload</response>
        [HttpGet("[action]")]
        public async Task<ActionResult<List<Application.RequestHandlers.Departments.Queries.GetDepartment.ResponseModel>>> All()
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Departments.Queries.GetDepartment.Handler>(null);
        }
    }
}
