using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.RequestHandlers.Assignments.Queries.FilterAssignment;

public class ResponseModel : IResponseModel<Array>
{
    public string CreatorName { get; set; }
    public string AssigneeName { get; set; }
    public string AssigneeMail { get; set; }
    public string AssigneeDepartment { get; set; }
    public string Description { get; set; }
    public AssignmentStatusType Status { get; set; }

}

public class RequestModel : IRequestModel
{
    public AssignmentFilters Filter { get; set; }
    public string filterText {  get; set; }
}