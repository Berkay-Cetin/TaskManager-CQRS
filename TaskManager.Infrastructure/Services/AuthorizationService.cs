using Arfware.ArfBlocks.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Enums;
using TaskManager.Domain.Errors;

namespace TaskManager.Infrastructure.Services
{
    public class AuthorizationService
    {
        private readonly AssignmentDbContext _dbContext;
        private readonly CurrentUserService _currentUserService;

        public AuthorizationService(AssignmentDbContext dbContext, CurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
        }
        public async Task CheckPermission(string resourceKey, Guid? requestedId)
        {
            //var resource = await _dbContext.Resources.FirstOrDefaultAsync(r => r.Key == resourceKey);
            var currentUser = _currentUserService.GetCurrentUser();
            var userTitle = _currentUserService.GetCurrentUser().Title;
            bool isPermitted = false;

            switch (userTitle)
            {
                case "Uzman":
                    isPermitted = true;
                    break;

                default:
                    isPermitted = false;
                    break;
            }

            /*if (isPermitted)
            {
                isPermitted = IsOperationTypePermitted(resource, requestedId);
            }*/

            if (!isPermitted)
                throw new ArfBlocksVerificationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.YourUserHaveNotSufficentPermissionToAccessThisResource));
        }

        /*public bool IsOperationTypePermitted(Resource resource, Guid? requestedId)
        {
            var currentUser = _currentUserService.GetCurrentUser();

            switch (currentUser.UserType)
            {
                case UserTypes.NormalStationUser:
                    if (resource.OperationType == OperationTypes.EmployeeWorks)
                        return true;
                    else if (resource.OperationType == OperationTypes.UserRelated)
                        return requestedId.Value == currentUser.UserId;
                    else
                        return false;

                case UserTypes.PrevilagedStationUser:
                    if (resource.OperationType == OperationTypes.EmployeeWorks)
                        return true;
                    else if (resource.OperationType == OperationTypes.UserRelated)
                        return requestedId.Value == currentUser.UserId;
                    else if (resource.OperationType == OperationTypes.StationRelated)
                        return requestedId.Value == currentUser.StationId;
                    else
                        return false;

                case UserTypes.TechnicalServiceUser:
                    if (resource.OperationType == OperationTypes.EmployeeWorks)
                        return true;
                    else if (resource.OperationType == OperationTypes.UserRelated)
                        return requestedId.Value == currentUser.UserId;
                    else if (resource.OperationType == OperationTypes.StationRelated)
                        return true;
                    else
                        return false;

                case UserTypes.Admin:
                    return true;

                default:
                    return false;
            }
        }*/
    }
}
