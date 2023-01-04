﻿using SGRM.Authorization;
using SGRM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// dotnet aspnet-codegenerator razorpage -m Contact -dc ApplicationDbContext -outDir Pages\Contacts --referenceScriptLibraries
namespace SGRM.Data
{
    public static class SeedData
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        #region snippet_Initialize
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, testUserPw, "responsable@fake.com");
                await EnsureRole(serviceProvider, adminID, Constants.ResponsableRole);

                // allowed user can create and edit contacts that they create
                var managerID = await EnsureUser(serviceProvider, testUserPw, "directeur@fake.com");
                await EnsureRole(serviceProvider, managerID, Constants.DirecteurRole);

                SeedDB(context);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            //if (userManager == null)
            //{
            //    throw new Exception("userManager is null");
            //}

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
        #endregion

        public static void Initialize2(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                SeedDB(context);
            }
        }
        public static void SeedDB(ApplicationDbContext context)
        {
            if (context.Enseignants.Any())
            {
                context.Enseignants.ToList().ForEach(Console.WriteLine);
            }
            if (context.Directeurs.Any())
            {
                context.Directeurs.ToList().ForEach(Console.WriteLine);
            }
            /*
            context.Directeurs.AddRange(
                new Directeur
                {
                    Name = "DIR samir",
                    //IdentityUserId = "8a4a005f-e271-4f5c-bd03-352ef288c655"
                }
            );
            context.SaveChanges();

            context.Enseignants.AddRange(
                new Enseignant
                {
                    Name = "PROF karim",
                    //IdentityUserId = "8a4a005f-e271-4f5c-bd03-352ef288c655"
                }
            );
            context.SaveChanges();
            */
        }
    }
}
#pragma warning restore CS8602 // Dereference of a possibly null reference.
