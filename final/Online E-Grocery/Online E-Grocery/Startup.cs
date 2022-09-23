using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Online_E_Grocery.Core.Class;
using Online_E_Grocery.Core.Interface;
using Online_E_Grocery.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_E_Grocery
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
            services.AddControllers();
            services.AddControllers();
            services.AddScoped<IUser, user>();
            services.AddScoped<IItems, items>();
            services.AddScoped<IItemRating, itemRating>();
            services.AddScoped<IOrderItem, orderItem>();
            services.AddCors(cors => cors.AddPolicy("MyPolicy", builder =>
             {
                 builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
             }));
            services.AddDbContext<GroceryDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("path")));
            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Online E-Grocery",
                    Version = "v1.0"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("MyPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(i =>
            {
                i.SwaggerEndpoint("/Swagger/v1.0/swagger.json", "Online E-Grocery");
            });


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
