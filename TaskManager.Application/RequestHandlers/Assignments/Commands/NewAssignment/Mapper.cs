using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TaskManager.Application.RequestHandlers.Assignments.Commands.NewAssignment;
using TaskManager.Infrastructure;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.NewAssignment;

public class Mapper
{
    public Assignment MapToCreateAssignment(RequestModel request)
    {
        return new Assignment
        {
            Description = request.Description,
            Details = request.Detail,
            //CreatorId = request.CreatorId,
            AssigneeId = request.AssigneeId,
            CreatedAt = DateTime.Now,
            Status = Domain.Enums.AssignmentStatusType.Created
        };

    }

    public ResponseModel MapToResponse(Assignment assignment)
    {
        return new ResponseModel()
        {
            AssignmentId = assignment.Id,
        };
    }
}
