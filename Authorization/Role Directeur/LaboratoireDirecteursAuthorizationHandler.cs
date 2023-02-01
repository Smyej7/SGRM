using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using SGRM.Models;

namespace SGRM.Authorization.Role_Directeur
{
    public class LaboratoireDirecteursAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, Laboratoire>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Laboratoire resource)
        {
            
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }
            
            if (requirement.Name != Operations.ListOperationName && 
                requirement.Name != Operations.ReadOperationName &&
                requirement.Name != Operations.CreateOperationName &&
                requirement.Name != Operations.UpdateOperationName &&
                requirement.Name != Operations.DeleteOperationName)
            {
                return Task.CompletedTask;
            }

            // Directeur can Read
            if (context.User.IsInRole(Roles.DirecteurRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
