using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.RequestHandlers.Assignments.Queries.GetAssignmentByDepartment;

public class ResponseModel : IResponseModel<Array>
{
    public DateTime CreatedAt { get; set; }
    public string CreatorName { get; set; }
    public string Description { get; set; }
    public string AssigneeName { get; set; }
    public string DepartmentName { get; set; }
    public AssignmentStatusType Status { get; set; }
}
