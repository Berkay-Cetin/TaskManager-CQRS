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

namespace TaskManager.Application.RequestHandlers.Users.Commands.Register;

public class DataAccess : IDataAccess
{
    private readonly AssignmentDbContext _context;
    public DataAccess(ArfBlocksDependencyProvider depencyProvider)
    {
        _context = depencyProvider.GetInstance<AssignmentDbContext>();
    }
    public async Task AddUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

}
