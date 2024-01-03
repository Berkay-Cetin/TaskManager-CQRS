using Arfware.ArfBlocks.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly ArfBlocksRequestOperator _requestOperator;

        public AssignmentsController(ArfBlocksDependencyProvider dependencyProvider)
        {
            _requestOperator = new ArfBlocksRequestOperator(dependencyProvider);
        }

        // QUERIES

        /// <summary>
        /// Get All Assignments
        /// </summary>
        /// <response code="200">Returns All Assignments in Response.Payload</response>
        [HttpGet("[action]")]
        public async Task<ActionResult<List<Application.RequestHandlers.Assignments.Queries.GetAssignment.ResponseModel>>> All()
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Assignments.Queries.GetAssignment.Handler>(null);
        }

        /// <summary>
        /// Get All Assignments that assigned to Department
        /// </summary>
        /// <response code="200">Returns All Assignments that assigned to Department in Response.Payload</response>
        [HttpGet("[action]")]
        public async Task<ActionResult<List<Application.RequestHandlers.Assignments.Queries.GetAssignmentByDepartment.ResponseModel>>> AssignmentsByDepartment()
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Assignments.Queries.GetAssignmentByDepartment.Handler>(null);
        }

        /// <summary>
        /// Get All Filtered Assignments
        /// </summary>
        /// <response code="200">Returns All Filtered Assignments in Response.Payload</response>
        [HttpPost("[action]"),AllowAnonymous]
        public async Task<ActionResult<List<Application.RequestHandlers.Assignments.Queries.FilterAssignment.ResponseModel>>> FilteredAssignments(Application.RequestHandlers.Assignments.Queries.FilterAssignment.RequestModel payload)
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Assignments.Queries.FilterAssignment.Handler>(payload);
        }

        /// <summary>
        /// Get Detail of an Assignment
        /// </summary>
        /// <response code="200">Returns Detail of an Assignment in Response.Payload</response>
        [HttpPost("[action]")]
        public async Task<ActionResult<Application.RequestHandlers.Assignments.Queries.GetDetail.ResponseModel>> Detail (Application.RequestHandlers.Assignments.Queries.GetDetail.RequestModel payload)
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Assignments.Queries.GetDetail.Handler>(payload);
        }

        // COMMANDS 

        /// <summary>
        /// Delete Assignment
        /// </summary>
        /// <response code="200">Returns Id of Deleted Assignment in Response.Payload</response>
        [HttpDelete("[action]")]
        public async Task<ActionResult<Application.RequestHandlers.Assignments.Commands.DeleteAssignment.ResponseModel>> Delete(Application.RequestHandlers.Assignments.Commands.DeleteAssignment.RequestModel payload)
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Assignments.Commands.DeleteAssignment.Handler>(payload);
        }

        /// <summary>
        /// Edit Assignment
        /// </summary>
        /// <response code="200">Returns Id of Edited Assignment in Response.Payload</response>
        [HttpPut("[action]")]
        public async Task<ActionResult<Application.RequestHandlers.Assignments.Commands.EditAssignment.ResponseModel>> Edit(Application.RequestHandlers.Assignments.Commands.EditAssignment.RequestModel payload)
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Assignments.Commands.EditAssignment.Handler>(payload);
        }

        /// <summary>
        /// Create Assignment
        /// </summary>
        /// <response code="200">Returns Id of Created Assignment in Response.Payload</response>
        [HttpPost("[action]")]
        public async Task<ActionResult<Application.RequestHandlers.Assignments.Commands.NewAssignment.ResponseModel>> Create(Application.RequestHandlers.Assignments.Commands.NewAssignment.RequestModel payload)
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Assignments.Commands.NewAssignment.Handler>(payload);
        }

        /// <summary>
        /// Edit Status of Assignment
        /// </summary>
        /// <response code="200">Returns Id of Edited Assignment in Response.Payload</response>
        [HttpPut("[action]")]
        public async Task<ActionResult<Application.RequestHandlers.Assignments.Commands.StatusUpdate.ResponseModel>> ChangeStatus(Application.RequestHandlers.Assignments.Commands.StatusUpdate.RequestModel payload)
        {
            return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Assignments.Commands.StatusUpdate.Handler>(payload);
        }
    }
}
