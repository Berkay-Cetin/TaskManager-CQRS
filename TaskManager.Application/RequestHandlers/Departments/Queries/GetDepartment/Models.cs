using Arfware.ArfBlocks.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.RequestHandlers.Departments.Queries.GetDepartment;

public class ResponseModel : IResponseModel<Array>
{
    public string Name { get; set; }
}

public class RequestModel : IRequestModel
{
    public int id { get; set; }
}