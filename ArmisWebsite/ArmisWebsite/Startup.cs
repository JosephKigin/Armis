using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmisWebsite.DataAccess;
using ArmisWebsite.DataAccess.Customer;
using ArmisWebsite.DataAccess.Customer.Interfaces;
using ArmisWebsite.DataAccess.Employee;
using ArmisWebsite.DataAccess.Employee.Interfaces;
using ArmisWebsite.DataAccess.OrderEntry;
using ArmisWebsite.DataAccess.OrderEntry.Interfaces;
using ArmisWebsite.DataAccess.Part;
using ArmisWebsite.DataAccess.Part.Interfaces;
using ArmisWebsite.DataAccess.Quality;
using ArmisWebsite.DataAccess.Quality.Inspection;
using ArmisWebsite.DataAccess.Quality.Inspection.Interfaces;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using ArmisWebsite.DataAccess.Quality.Specification;
using ArmisWebsite.DataAccess.Quality.Specification.Interfaces;
using ArmisWebsite.DataAccess.Shipping;
using ArmisWebsite.DataAccess.Shipping.Interfaces;
using ArmisWebsite.DataAccess.ShopFloor;
using ArmisWebsite.DataAccess.ShopFloor.Department;
using ArmisWebsite.DataAccess.ShopFloor.Department.Interfaces;
using ArmisWebsite.Utility;
using ArmisWebsite.Utility.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Serilog;

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

            //*HTTPContext*
            services.AddHttpContextAccessor();

            //*CUSTOMER*
            services.AddScoped<ICustomerDataAccess, CustomerDataAccess>();
            services.AddScoped<IBillToDataAccess, BillToDataAccess>();


            //*EMPLOYEE*
            services.AddScoped<IEmployeeDataAccess, EmployeeDataAccess>();


            //*ORDER_ENTRY*
            services.AddScoped<IOrderHeadDataAccess, OrderHeadDataAccess>();


            //*PART*
            services.AddScoped<IPartDataAccess, PartDataAccess>();
            services.AddScoped<IHardnessDataAccess, HardnessDataAccess>();
            services.AddScoped<IMaterialAlloyDataAccess, MaterialAlloyDataAccess>();
            services.AddScoped<IMaterialSeriesDataAccess, MaterialSeriesDataAccess>();
            services.AddScoped<IUoMDataAccess, UoMDataAccess>();


            //*QUALITY*
            //Inspection
            services.AddScoped<ITestTypeDataAccess, TestTypeDataAccess>();
            services.AddScoped<ISamplePlanDataAccess, SamplePlanDataAccess>();
            services.AddScoped<IQualityStandardDataAccess, QualityStandardDataAccess>();

            //Process
            services.AddScoped<IStepDataAccess, StepDataAccess>();
            services.AddScoped<IProcessDataAccess, ProcessDataAccess>();
            services.AddScoped<IOperationDataAccess, OperationDataAccess>();

            //Specification
            services.AddScoped<ISpecDataAccess, SpecDataAccess>();
            services.AddScoped<ISpecProcessAssignDataAccess, SpecProcessAssignDataAccess>();


            //*SHIPPING*
            services.AddScoped<IShipViaCodeDataAccess, ShipViaCodeDataAccess>();
            services.AddScoped<IPackageCodeDataAccess, PackageCodeDataAccess>();
            services.AddScoped<IContainerTypeDataAccess, ContainerTypeDataAccess>();

            //*SHOP_FLOOR*
            services.AddScoped<IDepartmentDataAccess, DepartmentDataAccess>();

            //*TOOLS*
            services.AddScoped<IPdfGenerator, PdfGenerator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            //}

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
