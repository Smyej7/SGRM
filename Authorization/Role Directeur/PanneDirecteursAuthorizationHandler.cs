using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using SGRM.Models;

namespace SGRM.Authorization.Role_Directeur
{
    public class PanneDirecteursAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, Panne>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Panne resource)
        {
            
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }
            
            if (requirement.Name != Operations.ListOperationName && 
                requirement.Name != Operations.ReadOperationName)
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
