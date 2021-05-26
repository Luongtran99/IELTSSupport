using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SupportingIELTSWriting.Data;
using SupportingIELTSWriting.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.SeedDatas
{
    public class SeedData
    {
        public static async void EnsurePopulatedAsync(IApplicationBuilder app)
        {
            using(var serviceScopte = app.ApplicationServices.CreateScope())
            {
                // register serviceScopur
                var services = serviceScopte.ServiceProvider;
                DictionaryDbContext context = serviceScopte.ServiceProvider.GetRequiredService<DictionaryDbContext>();
                await context.Database.MigrateAsync();

                try
                {
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<Roles>>();
                    await DefaultRoles.SeedAsync(userManager, roleManager);
                    await DefaultUsers.SeedBasicUserAsync(userManager, roleManager);
                    await DefaultUsers.SeedAdminAsync(userManager, roleManager);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            

        } 
    }
}
