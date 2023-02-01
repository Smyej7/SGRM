using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SGRM.Authorization;

namespace SGRM.Data
{
    public class UserManipulation
    {
        IServiceProvider _serviceProvider;

        public UserManipulation(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private static async Task<string> EnsureUser(
            IServiceProvider serviceProvider, 
            string UserName, 
            string Pwd)
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
                await userManager.CreateAsync(user, Pwd);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(
            IServiceProvider serviceProvider, 
            string userId, 
            string role)
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

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);
            
            return IR;
        }

        public async Task CreateUser(string userName, string pwd, string role)
        {
            using (var context = new ApplicationDbContext(
                _serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var userID = await EnsureUser(_serviceProvider, userName, pwd);
                await EnsureRole(_serviceProvider, userID, role);
            }
        }
    }
}