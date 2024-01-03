using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using TaskManager.Domain.Enums;
using TaskManager.Infrastructure;

namespace TaskManager.Application.RequestHandlers.Assignments.Queries.FilterAssignment
{
    public class DataAccess : IDataAccess
    {
        private readonly AssignmentDbContext _dbContext;
        public DataAccess(ArfBlocksDependencyProvider depencyProvider)
        {
            _dbContext = depencyProvider.GetInstance<AssignmentDbContext>();
        }

        public async Task<List<Assignment>> FilterByCreator(string filterText)
        {
            return await _dbContext.Assignments.Include(a => a.Creator).Include(a => a.Assignee).ThenInclude(a => a.Department).Where(a => a.Creator.UserName.Contains(filterText)).ToListAsync();
            //return await _dbContext.Assignments.Include(a=>a.Creator).Include(a=>a.Assignee).ThenInclude(a=>a.Department).Where(a=>EF.Functions.Like(a.Creator.UserName,filterText)).ToListAsync();
        }
        public async Task<List<Assignment>> FilterByAssignedPerson(string filterText)
        {
            return await _dbContext.Assignments.Include(a => a.Creator).Include(a => a.Assignee).ThenInclude(a => a.Department).Where(a => EF.Functions.Like(a.Assignee.UserName, filterText)).ToListAsync();
        }
        public async Task<List<Assignment>> FilterByAssignedEmail(string filterText)
        {
            return await _dbContext.Assignments.Include(a => a.Creator).Include(a => a.Assignee).ThenInclude(a => a.Department).Where(a => EF.Functions.Like(a.Assignee.Email, filterText)).ToListAsync();
        }
        public async Task<List<Assignment>> FilterByAssignedDepartment(string filterText)
        {
            return await _dbContext.Assignments.Include(a => a.Creator).Include(a => a.Assignee).ThenInclude(a => a.Department).Where(a => EF.Functions.Like(a.Assignee.Department.Name, filterText)).ToListAsync();
        }
        public async Task<List<Assignment>> FilterByDescription(string filterText)
        {
            return await _dbContext.Assignments.Include(a => a.Creator).Include(a => a.Assignee).ThenInclude(a => a.Department).Where(a => EF.Functions.Like(a.Description, filterText)).ToListAsync();
        }
        /*public async Task<List<Assignment>> FilterByStatus(AssignmentStatusType filterText)
        {
            return await _context.Assignments.Where(a => a.Status == filterText).ToListAsync();
        }*/
    }
}
