using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Spango_Kitchen.DatabaseContext;
using Spango_Kitchen.Services;
using Spango_Kitchen.ServicesImplementations;
using System;


namespace Spango_Kitchen
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
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                services.AddDbContext<Spago_Context>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnectionProd")));
            }
            else
            {
                services.AddDbContext<Spago_Context>(options =>
                     options.UseSqlServer(
                         Configuration.GetConnectionString("SpangoContext")));
            }
            services.BuildServiceProvider().GetService<Spago_Context>().Database.Migrate();

            
            services.AddScoped<ICategory, Category>();
            services.AddScoped<ICookingTime, CookingTime>();
            services.AddScoped<ICousine, Cousine>();
            services.AddScoped<IDish, Dish>();
            services.AddScoped<IIngredient, Ingredient>();
            
            services.AddMvcCore().AddApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Spango Kitchen Api", Version = "v1" });
            });
            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
