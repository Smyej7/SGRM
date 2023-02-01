using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using SGRM.Models;

namespace SGRM.Authorization.Role_Directeur
{
    public class FournisseurDirecteursAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, Fournisseur>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Fournisseur resource)
        {
            
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }
            
            return Task.CompletedTask;
        }
    }
}