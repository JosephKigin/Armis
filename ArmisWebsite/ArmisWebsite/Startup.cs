using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmisWebsite.DataAccess;
using ArmisWebsite.DataAccess.Customer;
using ArmisWebsite.DataAccess.Customer.Interfaces;
using ArmisWebsite.DataAccess.Employee;
using ArmisWebsite.DataAccess.Employee.Interfaces;
using ArmisWebsite.DataAccess.Part;
using ArmisWebsite.DataAccess.Part.Interfaces;
using ArmisWebsite.DataAccess.Quality;
using ArmisWebsite.DataAccess.Quality.Inspection;
using ArmisWebsite.DataAccess.Quality.Inspection.Interfaces;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using ArmisWebsite.DataAccess.Quality.Specification;
using ArmisWebsite.DataAccess.Quality.Specification.Interfaces;
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

            //QUALITY
            //Inspection
            services.AddScoped<ITestTypeDataAccess, TestTypeDataAccess>();
            services.AddScoped<ISamplePlanDataAccess, SamplePlanDataAccess>();

            //Process
            services.AddScoped<IStepDataAccess, StepDataAccess>();
            services.AddScoped<IProcessDataAccess, ProcessDataAccess>();
            services.AddScoped<IOperationDataAccess, OperationDataAccess>();

            //Specification
            services.AddScoped<ISpecDataAccess, SpecDataAccess>();
            services.AddScoped<ISpecProcessAssignDataAccess, SpecProcessAssignDataAccess>();

            //CUSTOMER
            services.AddScoped<ICustomerDataAccess, CustomerDataAccess>();

            //EMPLOYEE
            services.AddScoped<IEmployeeDataAccess, EmployeeDataAccess>();

            //PART
            services.AddScoped<IHardnessDataAccess, HardnessDataAccess>();
            services.AddScoped<IMaterialAlloyDataAccess, MaterialAlloyDataAccess>();
            services.AddScoped<IMaterialSeriesDataAccess, MaterialSeriesDataAccess>();

            services.AddScoped<IPdfGenerator, PdfGenerator>(); //TODO: Is this really needed???
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
