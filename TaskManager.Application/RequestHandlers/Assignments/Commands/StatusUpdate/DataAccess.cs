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

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.StatusUpdate
{
    public class DataAccess : IDataAccess
    {
        private readonly AssignmentDbContext _dbContext;
        public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
        {
            _dbContext = dependencyProvider.GetInstance<AssignmentDbContext>();
        }
        public async Task<Assignment> GetAssignmentById(int id)
        {
            return await _dbContext.Assignments.FindAsync(id);
        }
        public async Task Update(Assignment assignment)
        {
            _dbContext.Entry(assignment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
