using Azure.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.EditAssignment
{
    public class Mapper
    {
        public Assignment MapToNewEntity(RequestModel requestPayload)
        {
            return new Assignment()
            {
                AssigneeId = requestPayload.AssigneeId,
                Description = requestPayload.Description,
                Details = requestPayload.Detail,
                Status = requestPayload.NewStatus
            };
        }

        public ResponseModel MapToResponse(Assignment assignment)
        {
            return new ResponseModel()
            {
                Id = assignment.Id,
            };
        }
    }
}
