using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;
using NetWorth.Application.Users.Commands.CreateUser;
using NetWorth.Application.Infrastructure;
using NetWorth.Application.Infrastructure.AutoMapper;
using NetWorth.Application.Interfaces;
using NetWorth.Application.Factors.Queries.GetFactor;
using NetWorth.Infrastructure;
using NetWorth.WebAPI.Filters;
using System.Reflection;

namespace NetWorth.WebAPI
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
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            services.AddTransient<INotificationService, NotificationService>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(GetFactorQueryHandler).GetTypeInfo().Assembly);

            services.AddDbContext<NetWorthContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("NetWorthDatabase"),
                x => x.MigrationsAssembly("NetWorth.Persistence")));

            /*services.AddDbContext<NetWorthContext>(opt => 
                opt.UseSqlite("Data Source=NetWorth.db"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);*/

            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
