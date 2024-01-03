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

namespace TaskManager.Application.RequestHandlers.Departments.Queries.GetDepartment
{
    public class DataAccess : IDataAccess
    {
        private readonly AssignmentDbContext _dbContext;
        public DataAccess(ArfBlocksDependencyProvider depencyProvider)
        {
            _dbContext = depencyProvider.GetInstance<AssignmentDbContext>();
        }
        public async Task<List<Department>> GetAllDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
        }
        public async Task<Department> GetDepartmentById(int id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }
    }
}
