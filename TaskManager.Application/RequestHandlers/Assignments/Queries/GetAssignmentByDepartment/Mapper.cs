using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Assignments.Queries.GetAssignmentByDepartment
{
    public class Mapper
    {
        public List<ResponseModel> MapToResponse(List<Assignment> assignments)
        {
            return assignments.Select(assignment => new ResponseModel
            {
                CreatedAt = assignment.CreatedAt,
                CreatorName = assignment.Creator.UserName,
                AssigneeName = assignment.Assignee.UserName,
                Description = assignment.Description,
                DepartmentName = assignment.Assignee.Department.Name,
                Status = assignment.Status,
            }).ToList();
        }
    }
}
