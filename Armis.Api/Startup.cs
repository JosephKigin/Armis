using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.Services.CustomerServices;
using Armis.DataLogic.Services.CustomerServices.Interfaces;
using Armis.DataLogic.Services.OrderEntryServices;
using Armis.DataLogic.Services.OrderEntryServices.Interfaces;
using Armis.DataLogic.Services.PartServices;
using Armis.DataLogic.Services.PartServices.Interfaces;
using Armis.DataLogic.Services.QualityServices;
using Armis.DataLogic.Services.QualityServices.Inspection;
using Armis.DataLogic.Services.QualityServices.Inspection.Interfaces;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Armis.DataLogic.Services.ShippingService;
using Armis.DataLogic.Services.ShippingService.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Armis.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ARMISContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:ARMISDb"]));

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(Configuration.GetSection("SectionCORS:AllowedSites").Value);
                });
            });

            //Setting up dependency injection
            //Process
            services.AddScoped<IStepService, StepService>();
            services.AddScoped<IProcessService, ProcessService>();
            services.AddScoped<IOperationService, OperationService>();

            //Specification
            services.AddScoped<ISpecService, SpecService>();
            services.AddScoped<ISpecProcessAssignService, SpecProcessAssignService>();

            //Inspection
            services.AddScoped<ISamplePlanService, SamplePlanService>();
            services.AddScoped<IInspectTestTypeService, InspectTestTypeService>();
            services.AddScoped<IQualityStandardService, QualityStandardService>();

            //Part
            services.AddScoped<IHardnessService, HardnessService>();
            services.AddScoped<IMaterialSeriesService, MaterialSeriesService>();
            services.AddScoped<IMaterialAlloyService, MaterialAlloyService>();

            //Customer
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBillToService, BillToService>();

            //Shipping
            services.AddScoped<IShipToService, ShipToService>();
            services.AddScoped<IShipViaService, ShipViaService>();
            services.AddScoped<IPackagCodeService, PackageCodeService>();
            services.AddScoped<IContainerService, ContainerService>();
            services.AddScoped<ICommentCodeService, CommentCodeService>();

            //Coop
            services.AddScoped<IEmployeeService, EmployeeService>();
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

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
