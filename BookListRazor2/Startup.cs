using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookListRazor2
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
            services.AddRazorPages().AddRazorRuntimeCompilation();

            //HelloWorld services
            //services.AddTransient<HelloWorldService>(); //Create a new instance everytime asked
            //services.AddScoped<HelloWorldService>(); //Create one single instance for every web request
            services.AddSingleton<HelloWorldService>(); //Create one single instance for entire application run
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Middleware
            // app.Use(async (context, next) =>
            // {
            //     context.Response.ContentType = "text/html";
            //     await context
            //         .Response
            //          .WriteAsync("<html><h1>Handled by middleware! Changed in runtime!</h1></html>");
            // });
            
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Primitive handler
                endpoints.MapGet("/hi/{name}", async (context) =>
                {
                    var name = context.Request.RouteValues["name"];
                    await context.Response.WriteAsync($"Hello, {name}!");
                });

                //Map to files inside Pages directory
                endpoints.MapRazorPages();
                
                //Controller
                
            });
        }
    }
}