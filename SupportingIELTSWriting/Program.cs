using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SupportingIELTSWriting.Data;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Models.Entities;

namespace SupportingIELTSWriting
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using(var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<DictionaryDbContext>();
                await dbContext.Database.MigrateAsync();
                try
                {
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<Roles>>();
                    await Models.SeedDatas.DefaultRoles.SeedAsync(userManager, roleManager);
                    await Models.SeedDatas.DefaultUsers.SeedBasicUserAsync(userManager, roleManager);
                    await Models.SeedDatas.DefaultUsers.SeedAdminAsync(userManager, roleManager);
                }
                catch(Exception ex)
                {
                    throw new Exception("Error!");
                }
            }
            await host.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //.UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .UseStartup<Startup>();
    }
}
