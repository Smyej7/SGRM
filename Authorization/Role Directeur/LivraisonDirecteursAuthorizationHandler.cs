using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using SGRM.Models;

namespace SGRM.Authorization.Role_Directeur
{
    public class LivraisonDirecteursAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, Livraison>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Livraison resource)
        {
            
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }
            
            return Task.CompletedTask;
        }
    }
}
