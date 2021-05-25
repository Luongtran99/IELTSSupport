using Microsoft.AspNetCore.Identity;
using SupportingIELTSWriting.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.SeedDatas
{
    public static class DefaultUsers
    {
        public static async Task SeedBasicUserAsync(UserManager<User> userManager, RoleManager<Roles> roleManager)
        {
            var defaultUser = new User
            {
                UserName = "basic@gmail.com",
                Email = "basic@gmail.com",
                EmailConfirmed = true
            };

            if(userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Role.Customer.ToString());
                }
            }
        }

        public static async Task SeedAdminAsync(UserManager<User> userManager, RoleManager<Roles> roleManager)
        {
            var defaultUser = new User
            {
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Role.Adminstrator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Role.Customer.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Role.Member.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Role.Manager.ToString());
                }
                await roleManager.SeedClaimsForAdminstrator();
            }
        }

        private async static Task SeedClaimsForAdminstrator(this RoleManager<Roles> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Adminstrator");
            await roleManager.AddPermissionClaim(adminRole, "Users");

        }

        private async static Task AddPermissionClaim(this RoleManager<Roles>  roleManager, Roles role, string module)
        {
            var AllClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(module);
            foreach(var p in allPermissions)
            {
                if(!AllClaims.Any(a => a.Type == "Permission" && a.Value == p))
                {
                    await roleManager.AddClaimAsync(role, new System.Security.Claims.Claim("Permission", p));
                }
            }
        }
    }
}
