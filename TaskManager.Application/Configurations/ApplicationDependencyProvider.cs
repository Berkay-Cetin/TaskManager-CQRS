using Arfware.ArfBlocks.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Infrastructure;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Application.Configurations
{
    public class ApplicationDependencyProvider : ArfBlocksDependencyProvider
    {
        public ApplicationDependencyProvider(IHttpContextAccessor httpContextAccessor, ProjectConfigurations projectConfiguration)
        {
            base.Add<ArfBlocksDependencyProvider>(this);            

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<AssignmentDbContext>();
            dbContextOptionsBuilder.UseSqlServer(projectConfiguration.RelationalDbConfiguration.ConnectionString);
            var dbContext = new AssignmentDbContext(dbContextOptionsBuilder.Options);
            base.Add<AssignmentDbContext>(dbContext);
            base.Add<IHttpContextAccessor>(httpContextAccessor);
            base.Add<CurrentUserService.CurrentUserResponse>();

            base.Add<DbVerificationService>();
            base.Add<DbValidationService>();
            base.Add<JwtService>();
            base.Add<AuthorizationService>();
            base.Add<CurrentUserService>();
            base.Add<Logger>();
            //base.Add<EnvironmentService>();
        }
    }
}
