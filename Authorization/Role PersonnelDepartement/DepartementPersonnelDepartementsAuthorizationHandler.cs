﻿using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using SGRM.Models;

namespace SGRM.Authorization.Role_PersonnelDepartement
{
    public class DepartementPersonnelDepartementsAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, Departement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            Departement resource)
        {
            
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }
            
            return Task.CompletedTask;
        }
    }
}
