using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Departments.Queries.GetDepartment;

public class Mapper
{
    public List<ResponseModel> MapToResponse(List<Department> departments)
    {
        return departments.Select(department => new ResponseModel
        {
            Name = department.Name,
        }).ToList();
    }
}
