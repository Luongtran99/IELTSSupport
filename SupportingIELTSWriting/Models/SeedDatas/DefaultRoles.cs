using Microsoft.AspNetCore.Identity;
using SupportingIELTSWriting.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.SeedDatas
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<User> userManager, RoleManager<Roles> roleManager)
        {
            await roleManager.CreateAsync(new Roles { Name = Roles.Role.Adminstrator.ToString()});
            await roleManager.CreateAsync(new Roles { Name = Roles.Role.Customer.ToString() });
            await roleManager.CreateAsync(new Roles { Name = Roles.Role.Manager.ToString() });
            await roleManager.CreateAsync(new Roles { Name = Roles.Role.Member.ToString() });
        }
    }
}
