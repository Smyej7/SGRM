﻿using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using SGRM.Models;

namespace SGRM.Authorization.Role_Responsable
{
    public class LaboratoireResopnsablesAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, Laboratoire>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            Laboratoire resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // Responsables can do anything.
            if (context.User.IsInRole(Roles.ResponsableRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
