using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using TaskManager.Infrastructure;

namespace TaskManager.Application.RequestHandlers.Assignments.Queries.GetAssignmentByDepartment
{
    public class DataAccess : IDataAccess
    {
        private readonly AssignmentDbContext _dbContext;

        public DataAccess(ArfBlocksDependencyProvider depencyProvider)
        {
            _dbContext = depencyProvider.GetInstance<AssignmentDbContext>();
        }
        public async Task<List<Assignment>> GetAssignmentsByDepartment(Department department)
        {
            return await _dbContext.Assignments
                .Include(a=> a.Creator)
                .Include(a => a.Assignee).ThenInclude(a=> a.Department)
                .Where(a => a.Assignee.Department == department)
                .ToListAsync();
        }

        public async Task<Department> GetDepartmentByUserId(int Id)
        {
            return await _dbContext.Assignments
                .Where(a => a.AssigneeId == Id)
                .Select(a => a.Assignee.Department)
                .FirstOrDefaultAsync();
        }
    }
}
