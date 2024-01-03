using Arfware.ArfBlocks.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Errors;

namespace TaskManager.Infrastructure.Services
{
    public class DbValidationService
    {
        private readonly AssignmentDbContext _dbContext;
        public DbValidationService(AssignmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ValidateTaskExist(int TaskId)
        {
            var taskExist = await _dbContext.Assignments.AnyAsync(a => a.Id == TaskId);

            // Check
            if (!taskExist)
                throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.IdNotValid));
        }

        public async Task ValidateUserIsActive(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);

            // Check
            if (!user.IsActive||user==null)
                throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.IdNotValid));
        }
    }
}
