using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Assignments.Queries.GetAssignment;

public class Mapper
{
    public List<ResponseModel> MapToResponse(List<Assignment> assignments)
    {
        return assignments.Select(assignment=> new ResponseModel
        {
            Creator = assignment.Creator.UserName,
            Assignee = new assigneeResponse
            {
                name = assignment.Assignee.UserName,
                email = assignment.Assignee.Email,
                DepartmentId = assignment.Assignee.DepartmentId,
            },
            Description = assignment.Description,
            Status = assignment.Status,
        }).ToList();

        /*
        var mappedAssignments = new List<ResponseModel>();
        assignments?.ForEach(assignment =>
        {
            mappedAssignments.Add(new ResponseModel()
            {
                Creator = assignment.Creator.UserName,
                Assignee = new ResponseModel.assigneeResponse
                {
                    name = assignment.Assignee.UserName,
                    email = assignment.Assignee.Email,
                    DepartmentId = assignment.Assignee.DepartmentId,
                },
                Description = assignment.Description,
                Status = assignment.Status,
            });
        });
        return mappedAssignments;*/
    }
}
