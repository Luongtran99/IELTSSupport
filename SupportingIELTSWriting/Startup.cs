using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SupportingIELTSWriting.Data;
using SupportingIELTSWriting.Infrastructure.TernarySearchTree;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Services;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using SupportingIELTSWriting.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using SupportingIELTSWriting.Models.Entities;

namespace SupportingIELTSWriting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddScoped<ITernarySearchTreeRepository, TernarySearchTree>(); // Register Ternary Search Tree

            services.AddScoped<IConvertorServices, ConvertorServices>();

            services.AddScoped<IUserServices, UserServices>();

            services.AddScoped<IHistoryServices, HistoryServices>();

            services.AddScoped<IEssayServices, EssayServices>();

            services.AddScoped<IIdentityServices, IdentityServices>();

            services.AddScoped<IWordServices, WordServices>();

            services.AddDbContext<DictionaryDbContext>(options =>
            {
                options.UseSqlServer(Configuration["Data:Dictionary:ConnectionString"]);
            });

            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<DictionaryDbContext>();

            var jwtOptions = new JwtOptions();

            Configuration.Bind(key: nameof(jwtOptions), jwtOptions);

            services.AddSingleton(jwtOptions);

            services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true

                    };
                });


            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = "JwtBearer";
            //    options.DefaultChallengeScheme = "JwtBearer";
            //});


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddMvcOptions(options => 
            {
                
            });

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "SupportIELTSWriting",
                        Version = "v1"
                    });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[0] }
                };

                setup.AddSecurityDefinition(name: "Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT authorization header using bearer scheme \r\n\r Enter 'Bearer' [space]",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header
                });

                setup.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            

            app.UseHttpsRedirection();

            app.UseAuthentication();

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(swaggerOptions)).Bind(swaggerOptions);


            app.UseSwagger(options => options.RouteTemplate = swaggerOptions.JsonRoute);
            app.UseSwaggerUI(x => 
            {
                x.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);

            });

            app.UseMvc();

            // seed data
            // SeedData.EnsurePopulatedAsync(app);
        }
    }
}
