using CakeManagement.Endpoints.Services;
using CakeShop.Data;
using CakeShop.Logic;
using CakeShop.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeManagement.Endpoints
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IBakerRepository, BakerRepository>();
            //services.AddTransient<IBakerLogic, BakerLogic>();

            services.AddTransient<ICakeRepository, CakeRepository>();
            services.AddTransient<IDeliveryRepository, DeliveryRepository>();


            services.AddTransient<IAdminManagement, AdminManagement>();
            services.AddTransient<IStaffManagement, StaffManagement>();
            services.AddTransient<IOrderManagement, OrderManagement>();
            services.AddTransient<CakeDbContext, CakeDbContext>();

            services.AddSignalR();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("https://localhost:7043"));


            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
