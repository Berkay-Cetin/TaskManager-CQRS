using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Assignments.Queries.GetDetail
{
    public class Mapper
    {
        public ResponseModel MapToResponse(Assignment assignment)
        {
            return new ResponseModel()
            {
                Id = assignment.Id,
                Assignee = new assigneeResponse
                {
                    Name = assignment.Assignee.UserName,
                    Email = assignment.Assignee.Email,
                    departmentId = assignment.Assignee.DepartmentId,
                },
                Creator = assignment.Creator.UserName,
                Description = assignment.Description,
                Details = assignment.Details,
                Status = assignment.Status,
            };
        }
    }
}
