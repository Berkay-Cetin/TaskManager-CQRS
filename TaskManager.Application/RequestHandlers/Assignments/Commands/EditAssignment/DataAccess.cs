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

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.EditAssignment
{
    public class DataAccess : IDataAccess
    {
        private readonly AssignmentDbContext _dbContext;
        public DataAccess(ArfBlocksDependencyProvider depencyProvider)
        {
            _dbContext = depencyProvider.GetInstance<AssignmentDbContext>();
        }

        public async Task Update(Assignment assignment)
        {
            _dbContext.Entry(assignment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Assignment> GetAssignmentById(int id)
        {
            return await _dbContext.Assignments.FindAsync(id);
        }
        public async Task<User> GetUserById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }
    }
}
