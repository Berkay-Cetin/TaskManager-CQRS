using Arfware.ArfBlocks.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Enums;
using TaskManager.Domain.Errors;

namespace TaskManager.Infrastructure.Services;

public class DbVerificationService
{
    private readonly AssignmentDbContext _dbContext;
    public DbVerificationService(AssignmentDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task VerifyThatTaskCanBeDeleted(int taskId)
    {
        var taskCount = await _dbContext.Assignments.Where(n => n.Id == taskId).CountAsync();

        if (taskCount > 0)
            throw new ArfBlocksVerificationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.PumpErrors.ToDeleteThisPumpRemoveTheConnectedFillingPoints));
    }

    public async Task VerifyPasswordCorrect(string username, string password)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == username);

        if (!PassHasher.VerifyPassword(password, user.Password))
        {
            throw new ArfBlocksVerificationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.IdentityNumberOrPasswordIncorrect));
        }
    }
}
