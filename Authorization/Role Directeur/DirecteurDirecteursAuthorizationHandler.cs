using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using SGRM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace SGRM.Authorization.Role_Directeur
{
    public class DirecteurDirecteursAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, Directeur>
    {
        //UserManager<IdentityUser> _userManager;

        /*public DirecteurDirecteursAuthorizationHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }*/
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Directeur resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If not asking for CRUD permission, return.

            if (requirement.Name != Operations.ListOperationName && 
                requirement.Name != Operations.ReadOperationName &&
                requirement.Name != Operations.UpdateOperationName)
            {
                return Task.CompletedTask;
            }

            /*if (resource.IdentityUserId == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }*/

            return Task.CompletedTask;
        }
    }
}
