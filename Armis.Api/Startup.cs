using Armis.Data.DatabaseContext;
using Armis.DataLogic.Services.ARServices;
using Armis.DataLogic.Services.ARServices.Interfaces;
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
using Armis.DataLogic.Services.ShopFloorServices;
using Armis.DataLogic.Services.ShopFloorServices.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

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
                    builder.WithOrigins(Configuration.GetSection("SectionCORS:AllowedSites").Value)
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyHeader();
                });

                //options.AddPolicy("CorsAllowSpecific",
                //    p => p.WithHeaders("Content-Type", "Accept", "Auth-Token")
                //        .WithMethods("POST"));
            });

            //Setting up dependency injection
            //AR
            services.AddScoped<ICertificationChargeService, CertificationChargeService>();

            //Coop
            services.AddScoped<IEmployeeService, EmployeeService>();

            //Customer
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBillToService, BillToService>();
            services.AddScoped<IContactService, ContactService>();
            
            //Inspection
            services.AddScoped<ISamplePlanService, SamplePlanService>();
            services.AddScoped<IInspectTestTypeService, InspectTestTypeService>();

            //Order Entry
            services.AddScoped<IOrderHeadService, OrderHeadService>();

            //Part
            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IHardnessService, HardnessService>();
            services.AddScoped<IMaterialSeriesService, MaterialSeriesService>();
            services.AddScoped<IMaterialAlloyService, MaterialAlloyService>();
            services.AddScoped<IUnitOfMeasureService, UnitOfMeasureService>();

            //Process
            services.AddScoped<IStepService, StepService>();
            services.AddScoped<IProcessService, ProcessService>();
            services.AddScoped<IOperationService, OperationService>();

            //Shipping
            services.AddScoped<IShipToService, ShipToService>();
            services.AddScoped<IShipViaCodeService, ShipViaCodeService>();
            services.AddScoped<IPackageCodeService, PackageCodeService>();
            services.AddScoped<IContainerService, ContainerService>();
            services.AddScoped<ICommentCodeService, CommentCodeService>();
            services.AddScoped<IOrderReceivedService, OrderReceivedService>();

            //Shop Floor
            services.AddScoped<IDepartmentService, DepartmentService>();

            //Specification
            services.AddScoped<ISpecService, SpecService>();
            services.AddScoped<ISpecProcessAssignService, SpecProcessAssignService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();

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
