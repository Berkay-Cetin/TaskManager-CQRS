using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.StatusUpdate
{
    public class Mapper
    {
        public ResponseModel MapToResponse(Assignment assignment)
        {
            return new ResponseModel() { Id = assignment.Id };
        }
    }
}
