using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;
using SGRM.Models;

namespace SGRM.Authorization.Role_Directeur
{
    public class DepartementDirecteursAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, Departement>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Departement resource)
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
