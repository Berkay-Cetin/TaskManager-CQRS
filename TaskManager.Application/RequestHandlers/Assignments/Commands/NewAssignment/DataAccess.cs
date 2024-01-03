using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure;
using TaskManager.Domain;
using Arfware.ArfBlocks.Core.Abstractions;
using Arfware.ArfBlocks.Core;

namespace TaskManager.Application.RequestHandlers.Assignments.Commands.NewAssignment
{
    public class DataAccess : IDataAccess
    {
        private readonly AssignmentDbContext _dbContext;
        public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
        {
            _dbContext = dependencyProvider.GetInstance<AssignmentDbContext>();
        }

        public async Task AddAssignment(Assignment assignment)
        {
            _dbContext.Assignments.Add(assignment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
