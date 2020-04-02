using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmisWebsite.DataAccess;
using ArmisWebsite.DataAccess.Customer;
using ArmisWebsite.DataAccess.Customer.Interfaces;
using ArmisWebsite.DataAccess.Employee;
using ArmisWebsite.DataAccess.Employee.Interfaces;
using ArmisWebsite.DataAccess.Process;
using ArmisWebsite.DataAccess.Process.Interfaces;
using ArmisWebsite.Utility;
using ArmisWebsite.Utility.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ArmisWebsite
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


            services.AddRazorPages();
            services.AddScoped<IStepDataAccess, StepDataAccess>();
            services.AddScoped<IProcessDataAccess, ProcessDataAccess>();
            services.AddScoped<ICustomerDataAccess, CustomerDataAccess>();
            services.AddScoped<IOperationDataAccess, OperationDataAccess>();
            services.AddScoped<IEmployeeDataAccess, EmployeeDataAccess>();
            services.AddScoped<ISpecDataAccess, SpecDataAccess>();
            services.AddScoped<IPdfGenerator, PdfGenerator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
