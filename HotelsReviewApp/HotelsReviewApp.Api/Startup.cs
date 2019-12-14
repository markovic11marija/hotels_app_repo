using System;
using Autofac;
using HotelsReviewApp.Domain.Service;
using HotelsReviewApp.Infrastructure.Autofac;
using HotelsReviewApp.Infrastructure.Data.Ef;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace HotelsReviewApp.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "HotelsReviewApp.Api", Version = "v1" }); });

            services.AddCors(); //Cross-Origin Resource Sharing sa kojih domena mogu requesti na moj api
            services.AddDbContext<HotelsReviewDbContext>();

            services.AddMediatR(
                typeof(CommandResult<>).Assembly
            );
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelsReviewApp.Api");
                c.RoutePrefix = String.Empty;
            });


            app.UseMvc();
        }
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<EntityFrameworkModule>();
        }
    }
}
