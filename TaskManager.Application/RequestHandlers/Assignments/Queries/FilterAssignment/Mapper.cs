using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Assignments.Queries.FilterAssignment
{
    public class Mapper
    {
        public List<ResponseModel> MapToResponse(List<Assignment> assignments)
        {
            var mappedProducts = new List<ResponseModel>();

            assignments.ForEach(assignment =>
            {
                mappedProducts.Add(
                    new ResponseModel()
                    {
                        CreatorName = assignment.Creator.UserName,
                        AssigneeName = assignment.Assignee.UserName,
                        AssigneeMail = assignment.Assignee.Email,
                        AssigneeDepartment = assignment.Assignee.Department.Name,
                        Description = assignment.Description,
                        Status = assignment.Status,
                    });
            });
            return mappedProducts;
        }
    }
}
