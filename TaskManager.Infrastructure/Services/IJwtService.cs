using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Infrastructure.Services
{
    public interface IJwtService
    {
        string GenerateJwt(User user);
        int GetExpirationDayCount();
    }
}
