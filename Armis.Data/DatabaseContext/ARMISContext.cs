using System;
using Armis.Data.DatabaseContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Armis.Data.DatabaseContext
{
    public partial class ARMISContext : DbContext
    {
        public ARMISContext()
        {
        }

        public ARMISContext(DbContextOptions<ARMISContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdjustReason> AdjustReason { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<AreaRemark> AreaRemark { get; set; }
        public virtual DbSet<BakeResult> BakeResult { get; set; }
        public virtual DbSet<Carrier> Carrier { get; set; }
        public virtual DbSet<Certification> Certification { get; set; }
        public virtual DbSet<CommentCode> CommentCode { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactTitle> ContactTitle { get; set; }
        public virtual DbSet<Container> Container { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DeptArea> DeptArea { get; set; }
        public virtual DbSet<DeptOperations> DeptOperations { get; set; }
        public virtual DbSet<DeptSpecs> DeptSpecs { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<HandlingCharge> HandlingCharge { get; set; }
        public virtual DbSet<Hardness> Hardness { get; set; }
        public virtual DbSet<LoadType> LoadType { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<MaterialAlloy> MaterialAlloy { get; set; }
        public virtual DbSet<MaterialSeries> MaterialSeries { get; set; }
        public virtual DbSet<Memo> Memo { get; set; }
        public virtual DbSet<MiscCharge> MiscCharge { get; set; }
        public virtual DbSet<NotifyContact> NotifyContact { get; set; }
        public virtual DbSet<NotifyEvent> NotifyEvent { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<OperationGroup> OperationGroup { get; set; }
        public virtual DbSet<OprLoadPrice> OprLoadPrice { get; set; }
        public virtual DbSet<OprMaterialPrice> OprMaterialPrice { get; set; }
        public virtual DbSet<OprThickPrice> OprThickPrice { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderExpedite> OrderExpedite { get; set; }
        public virtual DbSet<OrderHead> OrderHead { get; set; }
        public virtual DbSet<OrderLocation> OrderLocation { get; set; }
        public virtual DbSet<Oven> Oven { get; set; }
        public virtual DbSet<PackageCode> PackageCode { get; set; }
        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<PartHist> PartHist { get; set; }
        public virtual DbSet<PartRev> PartRev { get; set; }
        public virtual DbSet<PlateResult> PlateResult { get; set; }
        public virtual DbSet<PriceCode> PriceCode { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<ProcessLoad> ProcessLoad { get; set; }
        public virtual DbSet<ProcessRevision> ProcessRevision { get; set; }
        public virtual DbSet<ProcessSubOprList> ProcessSubOprList { get; set; }
        public virtual DbSet<ProcessVarOverride> ProcessVarOverride { get; set; }
        public virtual DbSet<QualityStandard> QualityStandard { get; set; }
        public virtual DbSet<Rack> Rack { get; set; }
        public virtual DbSet<RemarkCode> RemarkCode { get; set; }
        public virtual DbSet<ReworkCode> ReworkCode { get; set; }
        public virtual DbSet<SamplePlan> SamplePlan { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<ShipAccount> ShipAccount { get; set; }
        public virtual DbSet<ShipCharge> ShipCharge { get; set; }
        public virtual DbSet<ShipTo> ShipTo { get; set; }
        public virtual DbSet<ShipVia> ShipVia { get; set; }
        public virtual DbSet<SpecialHandling> SpecialHandling { get; set; }
        public virtual DbSet<Specification> Specification { get; set; }
        public virtual DbSet<Stamp> Stamp { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Step> Step { get; set; }
        public virtual DbSet<StepCategory> StepCategory { get; set; }
        public virtual DbSet<StepVarList> StepVarList { get; set; }
        public virtual DbSet<StepVariable> StepVariable { get; set; }
        public virtual DbSet<SubOpRevision> SubOpRevision { get; set; }
        public virtual DbSet<SubOpStepList> SubOpStepList { get; set; }
        public virtual DbSet<SubOperation> SubOperation { get; set; }
        public virtual DbSet<TaxAuthority> TaxAuthority { get; set; }
        public virtual DbSet<TaxJurisdiction> TaxJurisdiction { get; set; }
        public virtual DbSet<Terms> Terms { get; set; }
        public virtual DbSet<TestHead> TestHead { get; set; }
        public virtual DbSet<Uomcode> Uomcode { get; set; }

        private IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//TODO: This warning should be fixed.  Check up on this later.  (12/2/2019)
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ARMISContextOnConfiguring"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdjustReason>(entity =>
            {
                entity.HasKey(e => e.AdjustReasonCd)
                    .HasName("PK_AdjustReason_AdjustReasonCd");

                entity.Property(e => e.AdjustReasonCd)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.AreaId)
                    .HasColumnName("AreaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.DefaultLocationNavigation)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.DefaultLocation)
                    .HasConstraintName("FK_Area_DefaultLocation_Location_LocationID");
            });

            modelBuilder.Entity<AreaRemark>(entity =>
            {
                entity.HasKey(e => new { e.AreaId, e.RemarkId })
                    .HasName("PK_AreaRemark_AreaID_RemarkID");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.RemarkId).HasColumnName("RemarkID");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.AreaRemark)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AreaRemark_AreaID_Area_AreaID");
            });

            modelBuilder.Entity<BakeResult>(entity =>
            {
                entity.Property(e => e.BakeResultId).HasColumnName("BakeResultID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OvenName)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.OvenTemp).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.PlatedTime).HasColumnType("time(0)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.StartTime).HasColumnType("time(0)");

                entity.Property(e => e.Status)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.StopDate).HasColumnType("date");

                entity.Property(e => e.StopTime).HasColumnType("time(0)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.BakeResult)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_BakeResult_OrderID_OrderHead_OrderID");

                entity.HasOne(d => d.OvenNameNavigation)
                    .WithMany(p => p.BakeResult)
                    .HasForeignKey(d => d.OvenName)
                    .HasConstraintName("FK_BakeResult_OvenName_Oven_OvenCd");

                entity.HasOne(d => d.StartedByEmpNavigation)
                    .WithMany(p => p.BakeResultStartedByEmpNavigation)
                    .HasForeignKey(d => d.StartedByEmp)
                    .HasConstraintName("FK_BakeResult_StartedByEmp_Employee_EmpID");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.BakeResult)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_BakeResult_Status_Status_StatusCd");

                entity.HasOne(d => d.StoppedByEmpNavigation)
                    .WithMany(p => p.BakeResultStoppedByEmpNavigation)
                    .HasForeignKey(d => d.StoppedByEmp)
                    .HasConstraintName("FK_BakeResult_StoppedByEmp_Employee_EmpID");
            });

            modelBuilder.Entity<Carrier>(entity =>
            {
                entity.HasKey(e => e.CarrierCd)
                    .HasName("PK_Carrier_CarrierCd");

                entity.Property(e => e.CarrierCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OurAccount)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.HasKey(e => e.CertCd)
                    .HasName("PK_Certification_CertCd");

                entity.Property(e => e.CertCd)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ChargeAmt).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QualStdCd)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SpecId).HasColumnName("SpecID");

                entity.Property(e => e.Stamp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.QualStdCdNavigation)
                    .WithMany(p => p.Certification)
                    .HasForeignKey(d => d.QualStdCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Certification_QualStdCd_QualityStandard_QualStdCd");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.Certification)
                    .HasForeignKey(d => d.SpecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Certification_SpecID_Specification_SpecID");
            });

            modelBuilder.Entity<CommentCode>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK_CommentCode_CommentID");

                entity.Property(e => e.CommentId)
                    .HasColumnName("CommentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CommentDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PriceIncPerc).HasColumnType("decimal(9, 2)");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToId).HasColumnName("ShipToID");

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TitleCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_Contact_CustID_Customer_CustID");

                entity.HasOne(d => d.TitleCdNavigation)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.TitleCd)
                    .HasConstraintName("FK_Contact_TitleCd_ContactTitle_ContactTitleCd");

                entity.HasOne(d => d.ShipTo)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => new { d.ShipToId, d.CustId })
                    .HasConstraintName("FK_Contact_ShipToID_ShipTo_ShipToID");
            });

            modelBuilder.Entity<ContactTitle>(entity =>
            {
                entity.HasKey(e => e.ContactTitleCd)
                    .HasName("PK_ContactTitle_ContactTitleCd");

                entity.Property(e => e.ContactTitleCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TitleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Container>(entity =>
            {
                entity.HasKey(e => e.ContainerCd)
                    .HasName("PK_Container_ContainerCd");

                entity.Property(e => e.ContainerCd)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK_Customer_CustID");

                entity.Property(e => e.CustId)
                    .HasColumnName("CustID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Alias)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CertCd)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreditLimit).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.CreditStatus)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultShipToId).HasColumnName("DefaultShipToID");

                entity.Property(e => e.DefaultShipVia)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultShipViaCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsIgnoreDupePos).HasColumnName("IsIgnoreDupePOs");

                entity.Property(e => e.IsTmcustomer).HasColumnName("IsTMCustomer");

                entity.Property(e => e.MinIncreasePerc).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoCredHoldUntil).HasColumnType("date");

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PriceIncreasePerc).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.SearchName)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TaxExemptNum)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TermsCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CertCdNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CertCd)
                    .HasConstraintName("FK_Customer_CertCd_Certification_CertCd");

                entity.HasOne(d => d.CreditStatusNavigation)
                    .WithMany(p => p.CustomerCreditStatusNavigation)
                    .HasForeignKey(d => d.CreditStatus)
                    .HasConstraintName("FK_Customer_CreditStatus_Status_StatusCd");

                entity.HasOne(d => d.DefaultContactNumNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.DefaultContactNum)
                    .HasConstraintName("FK_Customer_DefaultContactNum_Contact_ContactID");

                entity.HasOne(d => d.DefaultShipViaNavigation)
                    .WithMany(p => p.CustomerDefaultShipViaNavigation)
                    .HasForeignKey(d => d.DefaultShipVia)
                    .HasConstraintName("FK_Customer_DefaultShipVia_ShipVia_ShipViaCd");

                entity.HasOne(d => d.DefaultShipViaCdNavigation)
                    .WithMany(p => p.CustomerDefaultShipViaCdNavigation)
                    .HasForeignKey(d => d.DefaultShipViaCd)
                    .HasConstraintName("FK_Customer_DefaultShipViaCd_ShipVia_ShipViaCd");

                entity.HasOne(d => d.SalesPersonNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.SalesPerson)
                    .HasConstraintName("FK_Customer_SalesPerson_Employee_EmpID");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.CustomerStatusNavigation)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Customer_Status_Status_StatusCd");

                entity.HasOne(d => d.TaxJurisd)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.TaxJurisdId)
                    .HasConstraintName("FK_Customer_TaxJurisdId_TaxJurisdiction_JurisdictionID");

                entity.HasOne(d => d.TermsCdNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.TermsCd)
                    .HasConstraintName("FK_Customer_TermsCd_Terms_TermsCd");

                entity.HasOne(d => d.ShipAccount)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => new { d.CustId, d.DefaultShipAccount })
                    .HasConstraintName("FK_Customer_DefaultShipAccount_ShipAccount_ShipAccountID");

                entity.HasOne(d => d.ShipTo)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => new { d.DefaultShipToId, d.CustId })
                    .HasConstraintName("FK_Customer_DefaultShipToID_ShipTo_ShipToID");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartmentType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HelperBurRate).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.LeadTime).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.LoadTypeCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoTimeReportGroup)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PlaterBurRate).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.ReworkBurRate).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.ScheduleAreaId).HasColumnName("ScheduleAreaID");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.LoadTypeCdNavigation)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.LoadTypeCd)
                    .HasConstraintName("FK_Department_LoadTypeCd_LoadType_LoadTypeCd");

                entity.HasOne(d => d.ScheduleArea)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.ScheduleAreaId)
                    .HasConstraintName("FK_Department_ScheduleAreaID_Area_AreaID");
            });

            modelBuilder.Entity<DeptArea>(entity =>
            {
                entity.HasKey(e => new { e.AreaId, e.DepartmentId })
                    .HasName("PK_DeptArea_AreaID_DepartmentID");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.DeptArea)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptArea_AreaID_Area_AreaID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DeptArea)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptArea_DepartmentID_Department_DepartmentID");
            });

            modelBuilder.Entity<DeptOperations>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.OperationId })
                    .HasName("PK_DeptOperations_DepartmentID_OperationID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.OperationId).HasColumnName("OperationID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DeptOperations)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptOperations_DepartmentID_Department_DepartmentID");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.DeptOperations)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptOperations_OperationID_Operation_OperationID");
            });

            modelBuilder.Entity<DeptSpecs>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.SpecId })
                    .HasName("PK_DeptSpecs_DepartmentID_SpecID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.SpecId).HasColumnName("SpecID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DeptSpecs)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptSpecs_DepartmentID_Department_DepartmentID");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.DeptSpecs)
                    .HasForeignKey(d => d.SpecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptSpecs_SpecID_Specification_SpecID");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.DriverId)
                    .HasColumnName("DriverID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AssignedDate).HasColumnType("date");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Driver_CustID_Customer_CustID");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_Employee_EmpID");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EmpID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("EMailAddress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExtUserId)
                    .HasColumnName("ExtUserID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_Employee_AreaID_Area_AreaID");
            });

            modelBuilder.Entity<HandlingCharge>(entity =>
            {
                entity.HasKey(e => e.HandlingChargeCd)
                    .HasName("PK_HandlingCharge_HandlingChargeCd");

                entity.Property(e => e.HandlingChargeCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Charge).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.ChargeDescription)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hardness>(entity =>
            {
                entity.HasKey(e => e.HardnessCd)
                    .HasName("PK_Hardness_HardnessCd");

                entity.Property(e => e.HardnessCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HardnessMax).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.HardnessMin).HasColumnType("decimal(19, 4)");
            });

            modelBuilder.Entity<LoadType>(entity =>
            {
                entity.HasKey(e => e.LoadTypeCd)
                    .HasName("PK_LoadType_LoadTypeCd");

                entity.Property(e => e.LoadTypeCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LoadTypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AreaNavigation)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_Location_AreaID_Area_AreaID");
            });

            modelBuilder.Entity<MaterialAlloy>(entity =>
            {
                entity.HasKey(e => e.AlloyCd)
                    .HasName("PK_MaterialAlloy_AlloyCd");

                entity.Property(e => e.AlloyCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeriesCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.SeriesCdNavigation)
                    .WithMany(p => p.MaterialAlloy)
                    .HasForeignKey(d => d.SeriesCd)
                    .HasConstraintName("FK_MaterialAlloy_SeriesCd_MaterialSeries_SeriesCd");
            });

            modelBuilder.Entity<MaterialSeries>(entity =>
            {
                entity.HasKey(e => e.SeriesCd)
                    .HasName("PK_MaterialSeries_SeriesCd");

                entity.Property(e => e.SeriesCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.BaseMetal)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Memo>(entity =>
            {
                entity.Property(e => e.MemoId).HasColumnName("MemoID");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.FollowupDate).HasColumnType("date");

                entity.Property(e => e.InteractionDate).HasColumnType("date");

                entity.Property(e => e.InteractionGroup)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InteractionMethod)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InteractionTime).HasColumnType("time(0)");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Memo)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Memo_ContactID_Contact_ContactID");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Memo)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_Memo_CustID_Customer_CustID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Memo)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Memo_DepartmentID_Department_DepartmentID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Memo)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Memo_OrderID_OrderHead_OrderID");
            });

            modelBuilder.Entity<MiscCharge>(entity =>
            {
                entity.HasKey(e => e.MiscChargeCd)
                    .HasName("PK_MiscCharge_MiscChargeCd");

                entity.Property(e => e.MiscChargeCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Charge).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.ChargeDescription)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NotifyContact>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.ContactId, e.NotifyEventId })
                    .HasName("PK_NotifyContact_CustID_ContactID_NotifyEventID");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.NotifyEventId).HasColumnName("NotifyEventID");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.NotifyContact)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotifyContact_ContactID_Contact_ContactID");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.NotifyContact)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotifyContact_CustID_Customer_CustID");

                entity.HasOne(d => d.NotifyEvent)
                    .WithMany(p => p.NotifyContact)
                    .HasForeignKey(d => d.NotifyEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotifyContact_NotifyEventID_NotifyEvent_NotifyEventID");
            });

            modelBuilder.Entity<NotifyEvent>(entity =>
            {
                entity.Property(e => e.NotifyEventId)
                    .HasColumnName("NotifyEventID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.Property(e => e.OperationId)
                    .HasColumnName("OperationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OperationCd)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.OperationGroupCd)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.OperationGroupCdNavigation)
                    .WithMany(p => p.Operation)
                    .HasForeignKey(d => d.OperationGroupCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operation_OperationGroupCd_OperationGroup_OperationGroupCd");
            });

            modelBuilder.Entity<OperationGroup>(entity =>
            {
                entity.HasKey(e => e.OperationGroupCd)
                    .HasName("PK_OperationGroup_OperationGroupCd");

                entity.Property(e => e.OperationGroupCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OprLoadPrice>(entity =>
            {
                entity.Property(e => e.OprLoadPriceId)
                    .HasColumnName("OprLoadPriceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Lbprice)
                    .HasColumnName("LBPrice")
                    .HasColumnType("decimal(19, 4)");

                entity.Property(e => e.LoadType)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MinLotCharge).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.MinPiecePrice).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.OperationId).HasColumnName("OperationID");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.OprLoadPrice)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_OprLoadPrice_CustID_Customer_CustID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.OprLoadPrice)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_OprLoadPrice_DepartmentID_Department_DepartmentID");

                entity.HasOne(d => d.LoadTypeNavigation)
                    .WithMany(p => p.OprLoadPrice)
                    .HasForeignKey(d => d.LoadType)
                    .HasConstraintName("FK_OprLoadPrice_LoadType_LoadType_LoadTypeCd");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.OprLoadPrice)
                    .HasForeignKey(d => d.OperationId)
                    .HasConstraintName("FK_OprLoadPrice_OperationID_Operation_OperationID");
            });

            modelBuilder.Entity<OprMaterialPrice>(entity =>
            {
                entity.Property(e => e.OprMaterialPriceId)
                    .HasColumnName("OprMaterialPriceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.MaterialCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.MinLotInc).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.MinPiecePriceInc).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.OperationId).HasColumnName("OperationID");

                entity.Property(e => e.PercInc).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.OprMaterialPrice)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_OprMaterialPrice_CustID_Customer_CustID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.OprMaterialPrice)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_OprMaterialPrice_DepartmentID_Department_DepartmentID");

                entity.HasOne(d => d.MaterialCdNavigation)
                    .WithMany(p => p.OprMaterialPrice)
                    .HasForeignKey(d => d.MaterialCd)
                    .HasConstraintName("FK_OprMaterialPrice_MaterialCd_MaterialAlloy_AlloyCd");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.OprMaterialPrice)
                    .HasForeignKey(d => d.OperationId)
                    .HasConstraintName("FK_OprMaterialPrice_OperationID_Operation_OperationID");
            });

            modelBuilder.Entity<OprThickPrice>(entity =>
            {
                entity.Property(e => e.OprThickPriceId)
                    .HasColumnName("OprThickPriceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.MinLotInc).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.MinPiecePriceInc).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.MinThickness).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.OperationId).HasColumnName("OperationID");

                entity.Property(e => e.PercInc).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.OprThickPrice)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_OprThickPrice_CustID_Customer_CustID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.OprThickPrice)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_OprThickPrice_DepartmentID_Department_DepartmentID");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.OprThickPrice)
                    .HasForeignKey(d => d.OperationId)
                    .HasConstraintName("FK_OprThickPrice_OperationID_Operation_OperationID");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.OrderLine })
                    .HasName("PK_OrderDetail_OrderID_OrderLine");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.AssignedPrice).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.Poprice)
                    .HasColumnName("POPrice")
                    .HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PriceCd)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_OrderID_OrderHead_OrderID");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_PartID_Part_PartID");

                entity.HasOne(d => d.PriceCdNavigation)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.PriceCd)
                    .HasConstraintName("FK_OrderDetail_PriceCd_PriceCode_PriceCd");
            });

            modelBuilder.Entity<OrderExpedite>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_OrderExpedite_OrderID");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExpeditedDate).HasColumnType("date");

                entity.Property(e => e.FeeAmount).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.ApprovedByEmpNavigation)
                    .WithMany(p => p.OrderExpediteApprovedByEmpNavigation)
                    .HasForeignKey(d => d.ApprovedByEmp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderExpedite_ApprovedByEmp_Employee_EmpID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.OrderExpedite)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_OrderExpedite_DepartmentId_Department_DepartmentID");

                entity.HasOne(d => d.ExpeditedByEmpNavigation)
                    .WithMany(p => p.OrderExpediteExpeditedByEmpNavigation)
                    .HasForeignKey(d => d.ExpeditedByEmp)
                    .HasConstraintName("FK_OrderExpedite_ExpeditedByEmp_Employee_EmpID");

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.OrderExpediteOrder)
                    .HasForeignKey<OrderExpedite>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderExpedite_OrderID_OrderHead_OrderID");

                entity.HasOne(d => d.ReworkOrderNavigation)
                    .WithMany(p => p.OrderExpediteReworkOrderNavigation)
                    .HasForeignKey(d => d.ReworkOrder)
                    .HasConstraintName("FK_OrderExpedite_ReworkOrder_OrderHead_OrderID");
            });

            modelBuilder.Entity<OrderHead>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_OrderHead_OrderID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CertCd)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CredAuthComments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.DoneDate).HasColumnType("date");

                entity.Property(e => e.DoneTime).HasColumnType("time(0)");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.ExpediteStatus)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.HandlingChargeCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.HardnessCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.JobHoldComments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastCompleteRemSentDt).HasColumnType("date");

                entity.Property(e => e.LotCharge).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.MaterialAlloyCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.MiscChargeCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.OrderComments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.PackagingCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Ponum)
                    .HasColumnName("PONum")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PriceStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.ProcessRevId).HasColumnName("ProcessRevID");

                entity.Property(e => e.PromiseDate).HasColumnType("date");

                entity.Property(e => e.PromiseTime).HasColumnType("time(0)");

                entity.Property(e => e.QualStdCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Raicomments)
                    .HasColumnName("RAIComments")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RecvDate).HasColumnType("date");

                entity.Property(e => e.RecvTime).HasColumnType("time(0)");

                entity.Property(e => e.ReqDate).HasColumnType("date");

                entity.Property(e => e.ShipChargeCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ShipDate).HasColumnType("date");

                entity.Property(e => e.ShipTime).HasColumnType("time(0)");

                entity.Property(e => e.ShipViaCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SpecId).HasColumnName("SpecID");

                entity.Property(e => e.Staddress1)
                    .HasColumnName("STAddress1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Staddress2)
                    .HasColumnName("STAddress2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Staddress3)
                    .HasColumnName("STAddress3")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stattn)
                    .HasColumnName("STAttn")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stcity)
                    .HasColumnName("STCity")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stname)
                    .HasColumnName("STName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stphone)
                    .HasColumnName("STPhone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ststate)
                    .HasColumnName("STState")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stzip)
                    .HasColumnName("STZip")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.TargetDate).HasColumnType("date");

                entity.Property(e => e.VoidComments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CertCdNavigation)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.CertCd)
                    .HasConstraintName("FK_OrderHead_CertCd_Certification_CertCd");

                entity.HasOne(d => d.CreditAuthByEmpNavigation)
                    .WithMany(p => p.OrderHeadCreditAuthByEmpNavigation)
                    .HasForeignKey(d => d.CreditAuthByEmp)
                    .HasConstraintName("FK_OrderHead_CreditAuthByEmp_Employee_EmpID");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_OrderHead_CustID_Customer_CustID");

                entity.HasOne(d => d.ExpediteStatusNavigation)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.ExpediteStatus)
                    .HasConstraintName("FK_OrderHead_ExpediteStatus_Status_StatusCd");

                entity.HasOne(d => d.HandlingChargeCdNavigation)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.HandlingChargeCd)
                    .HasConstraintName("FK_OrderHead_HandlingChargeCd_HandlingCharge_HandlingChargeCd");

                entity.HasOne(d => d.HardnessCdNavigation)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.HardnessCd)
                    .HasConstraintName("FK_OrderHead_HardnessCd_Hardness_HardnessCd");

                entity.HasOne(d => d.JobHoldByEmpNavigation)
                    .WithMany(p => p.OrderHeadJobHoldByEmpNavigation)
                    .HasForeignKey(d => d.JobHoldByEmp)
                    .HasConstraintName("FK_OrderHead_JobHoldByEmp_Employee_EmpID");

                entity.HasOne(d => d.JobHoldToEmpNavigation)
                    .WithMany(p => p.OrderHeadJobHoldToEmpNavigation)
                    .HasForeignKey(d => d.JobHoldToEmp)
                    .HasConstraintName("FK_OrderHead_JobHoldToEmp_Employee_EmpID");

                entity.HasOne(d => d.MaterialAlloyCdNavigation)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.MaterialAlloyCd)
                    .HasConstraintName("FK_OrderHead_MaterialAlloyCd_MaterialAlloy_AlloyCd");

                entity.HasOne(d => d.MiscChargeCdNavigation)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.MiscChargeCd)
                    .HasConstraintName("FK_OrderHead_MiscChargeCd_MiscCharge_MiscChargeCd");

                entity.HasOne(d => d.PackagingCdNavigation)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.PackagingCd)
                    .HasConstraintName("FK_OrderHead_PackagingCd_PackageCode_PackageCd");

                entity.HasOne(d => d.QualStdCdNavigation)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.QualStdCd)
                    .HasConstraintName("FK_OrderHead_QualStdCd_QualityStandard_QualStdCd");

                entity.HasOne(d => d.ShipChargeCdNavigation)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.ShipChargeCd)
                    .HasConstraintName("FK_OrderHead_ShipChargeCd_ShipCharge_ShipChargeCd");

                entity.HasOne(d => d.ShipViaCdNavigation)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.ShipViaCd)
                    .HasConstraintName("FK_OrderHead_ShipViaCd_ShipVia_ShipViaCd");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.SpecId)
                    .HasConstraintName("FK_OrderHead_SpecID_Specification_SpecID");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => new { d.ProcessRevId, d.ProcessId })
                    .HasConstraintName("FK_OrderHead_ProcessRevID_ProcessRevision_ProcessRevID");
            });

            modelBuilder.Entity<OrderLocation>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.OrderLine, e.LocationId })
                    .HasName("PK_OrderLocation_OrderID_OrderLine_LocationID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ContainerCd)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.ContainerCdNavigation)
                    .WithMany(p => p.OrderLocation)
                    .HasForeignKey(d => d.ContainerCd)
                    .HasConstraintName("FK_OrderLocation_ContainerCd_Container_ContainerCd");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.OrderLocation)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderLocation_LocationID_Location_LocationID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLocation)
                    .HasForeignKey(d => new { d.OrderId, d.OrderLine })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderLocation_OrderLine_OrderDetail_OrderLine");
            });

            modelBuilder.Entity<Oven>(entity =>
            {
                entity.HasKey(e => e.OvenCd)
                    .HasName("PK_Oven_OvenCd");

                entity.Property(e => e.OvenCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.OvenName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PackageCode>(entity =>
            {
                entity.HasKey(e => e.PackageCd)
                    .HasName("PK_PackageCode_PackageCd");

                entity.Property(e => e.PackageCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.Property(e => e.PartId)
                    .HasColumnName("PartID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alloy)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Bake)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dimensions)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IntendedPpl).HasColumnName("IntendedPPL");

                entity.Property(e => e.PartNum)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PieceWeight).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.ProcessComments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SamplePlanCd)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SauoM)
                    .HasColumnName("SAUoM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Series)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SurfaceArea)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Weight).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.AlloyNavigation)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.Alloy)
                    .HasConstraintName("FK_Part_Alloy_MaterialAlloy_AlloyCd");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Part_CustID_Customer_CustID");

                entity.HasOne(d => d.SamplePlanCdNavigation)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.SamplePlanCd)
                    .HasConstraintName("FK_Part_SamplePlanCd_SamplePlan_SamplePlanCd");

                entity.HasOne(d => d.SeriesNavigation)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.Series)
                    .HasConstraintName("FK_Part_Series_MaterialSeries_SeriesCd");

                entity.HasOne(d => d.StandardDeptNavigation)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.StandardDept)
                    .HasConstraintName("FK_Part_StandardDept_Department_DepartmentID");

                entity.HasOne(d => d.PartRev)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => new { d.PartId, d.CurrentRev })
                    .HasConstraintName("FK_Part_CurrentRev_PartRev_PartRevID");
            });

            modelBuilder.Entity<PartHist>(entity =>
            {
                entity.HasKey(e => e.TranSeqNum)
                    .HasName("PK_PartHist_TranSeqNum");

                entity.Property(e => e.TranSeqNum).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.LegacyProcess)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PiecePrice).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PriceCd)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.SysDate).HasColumnType("date");

                entity.Property(e => e.SysTime).HasColumnType("time(0)");

                entity.Property(e => e.TranType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PartHist)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_PartHist_OrderID_OrderHead_OrderID");

                entity.HasOne(d => d.PriceCdNavigation)
                    .WithMany(p => p.PartHist)
                    .HasForeignKey(d => d.PriceCd)
                    .HasConstraintName("FK_PartHist_PriceCd_PriceCode_PriceCd");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.PartHist)
                    .HasForeignKey(d => d.ProcessId)
                    .HasConstraintName("FK_PartHist_ProcessID_Process_ProcessID");
            });

            modelBuilder.Entity<PartRev>(entity =>
            {
                entity.HasKey(e => new { e.PartId, e.PartRevId })
                    .HasName("PK_PartRev_PartID_PartRevID");

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.PartRevId).HasColumnName("PartRevID");

                entity.HasOne(d => d.PartNavigation)
                    .WithMany(p => p.PartRevNavigation)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartRev_PartID_Part_PartID");
            });

            modelBuilder.Entity<PlateResult>(entity =>
            {
                entity.Property(e => e.PlateResultId).HasColumnName("PlateResultID");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LoadType)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.RunDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.PlateResult)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_PlateResult_AreaID_Area_AreaID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.PlateResult)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_PlateResult_DepartmentId_Department_DepartmentID");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.PlateResult)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_PlateResult_Employee_Employee_EmpID");

                entity.HasOne(d => d.LoadTypeNavigation)
                    .WithMany(p => p.PlateResult)
                    .HasForeignKey(d => d.LoadType)
                    .HasConstraintName("FK_PlateResult_LoadType_LoadType_LoadTypeCd");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PlateResult)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_PlateResult_OrderID_OrderHead_OrderID");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.PlateResult)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_PlateResult_Status_Status_StatusCd");
            });

            modelBuilder.Entity<PriceCode>(entity =>
            {
                entity.HasKey(e => e.PriceCd)
                    .HasName("PK_PriceCode_PriceCd");

                entity.Property(e => e.PriceCd)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PriceCdDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.Property(e => e.ProcessId)
                    .HasColumnName("ProcessID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Process)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_Process_CustID_Customer_CustID");
            });

            modelBuilder.Entity<ProcessLoad>(entity =>
            {
                entity.Property(e => e.ProcessLoadId)
                    .HasColumnName("ProcessLoadID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.LoadTypeCd)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MinLotCharge).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PiecePrice).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.ProcessLoad)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_ProcessLoad_DepartmentID_Department_DepartmentID");

                entity.HasOne(d => d.LoadTypeCdNavigation)
                    .WithMany(p => p.ProcessLoad)
                    .HasForeignKey(d => d.LoadTypeCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessLoad_LoadTypeCd_LoadType_LoadTypeCd");

                entity.HasOne(d => d.RackNavigation)
                    .WithMany(p => p.ProcessLoad)
                    .HasForeignKey(d => d.Rack)
                    .HasConstraintName("FK_ProcessLoad_Rack_Rack_RackID");
            });

            modelBuilder.Entity<ProcessRevision>(entity =>
            {
                entity.HasKey(e => new { e.ProcessRevId, e.ProcessId })
                    .HasName("PK_ProcessRevision_ProcessRevID_ProcessID");

                entity.Property(e => e.ProcessRevId)
                    .HasColumnName("ProcessRevID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.Notes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasColumnType("time(0)");

                entity.HasOne(d => d.CreatedByEmpNavigation)
                    .WithMany(p => p.ProcessRevision)
                    .HasForeignKey(d => d.CreatedByEmp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessRevision_CreatedByEmp_Employee_EmpID");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProcessRevision)
                    .HasForeignKey(d => d.ProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessRevision_ProcessID_Process_ProcessID");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.ProcessRevision)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessRevision_Status_Status_StatusCd");
            });

            modelBuilder.Entity<ProcessSubOprList>(entity =>
            {
                entity.HasKey(e => new { e.ProcessId, e.ProcessRevId, e.SubOpSeq })
                    .HasName("PK_ProcessSubOprList_ProcessID_ProcessRevID_SubOpSeq");

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.ProcessRevId).HasColumnName("ProcessRevID");

                entity.Property(e => e.OperationId).HasColumnName("OperationID");

                entity.Property(e => e.SubOpId).HasColumnName("SubOpID");

                entity.Property(e => e.SubOpRevId).HasColumnName("SubOpRevID");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.ProcessSubOprList)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessSubOprList_OperationID_Operation_OperationID");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProcessSubOprList)
                    .HasForeignKey(d => new { d.ProcessRevId, d.ProcessId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessSubOprList_ProcessRevID_ProcessRevision_ProcessRevID");

                entity.HasOne(d => d.SubOp)
                    .WithMany(p => p.ProcessSubOprList)
                    .HasForeignKey(d => new { d.SubOpRevId, d.SubOpId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessSubOprList_SubOpRevID_SubOpRevision_SubOpRevID");
            });

            modelBuilder.Entity<ProcessVarOverride>(entity =>
            {
                entity.HasKey(e => new { e.ProcessId, e.ProcessRevId, e.SubOpId, e.SubOpRevId, e.StepId, e.StepVariableId })
                    .HasName("PK_ProcessVarOverride_ProcessID_ProcessRevID_SubOpID_SubOpRevID_StepID_StepVariableID");

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.ProcessRevId).HasColumnName("ProcessRevID");

                entity.Property(e => e.SubOpId).HasColumnName("SubOpID");

                entity.Property(e => e.SubOpRevId).HasColumnName("SubOpRevID");

                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.Property(e => e.StepVariableId).HasColumnName("StepVariableID");

                entity.Property(e => e.OverrideMax).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.OverrideMin).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.ProcessVarOverride)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessVarOverride_StepID_Step_StepID");

                entity.HasOne(d => d.StepVariable)
                    .WithMany(p => p.ProcessVarOverride)
                    .HasForeignKey(d => d.StepVariableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessVarOverride_StepVariableID_StepVariable_StepVariableID");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProcessVarOverride)
                    .HasForeignKey(d => new { d.ProcessRevId, d.ProcessId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessVarOverride_ProcessRevID_ProcessRevision_ProcessRevID");

                entity.HasOne(d => d.SubOp)
                    .WithMany(p => p.ProcessVarOverride)
                    .HasForeignKey(d => new { d.SubOpRevId, d.SubOpId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessVarOverride_SubOpRevID_SubOpRevision_SubOpRevID");
            });

            modelBuilder.Entity<QualityStandard>(entity =>
            {
                entity.HasKey(e => e.QualStdCd)
                    .HasName("PK_QualityStandard_QualStdCd");

                entity.Property(e => e.QualStdCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Qsdescription)
                    .IsRequired()
                    .HasColumnName("QSDescription")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rack>(entity =>
            {
                entity.Property(e => e.RackId)
                    .HasColumnName("RackID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dimensions)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Rack)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_Rack_AreaID_Area_AreaID");

                entity.HasOne(d => d.MaterialCdNavigation)
                    .WithMany(p => p.Rack)
                    .HasForeignKey(d => d.MaterialCd)
                    .HasConstraintName("FK_Rack_MaterialCd_MaterialAlloy_AlloyCd");
            });

            modelBuilder.Entity<RemarkCode>(entity =>
            {
                entity.HasKey(e => e.RemarkId)
                    .HasName("PK_RemarkCode_RemarkID");

                entity.Property(e => e.RemarkId)
                    .HasColumnName("RemarkID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tmupdate).HasColumnName("TMUpdate");
            });

            modelBuilder.Entity<ReworkCode>(entity =>
            {
                entity.HasKey(e => e.ReworkCid)
                    .HasName("PK_ReworkCode_ReworkCID");

                entity.Property(e => e.ReworkCid)
                    .HasColumnName("ReworkCID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SamplePlan>(entity =>
            {
                entity.HasKey(e => e.SamplePlanCd)
                    .HasName("PK_SamplePlan_SamplePlanCd");

                entity.Property(e => e.SamplePlanCd)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.SamplePlan)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_SamplePlan_CustID_Customer_CustID");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.SamplePlan)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK_SamplePlan_TestID_TestHead_TestID");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.SignInDate).HasColumnType("date");

                entity.Property(e => e.SignInTime).HasColumnType("time(0)");

                entity.Property(e => e.SignOutDate).HasColumnType("date");

                entity.Property(e => e.SignOutTime).HasColumnType("time(0)");

                entity.Property(e => e.Status)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Session_EmployeeID_Employee_EmpID");

                entity.HasOne(d => d.LoginAreaNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.LoginArea)
                    .HasConstraintName("FK_Session_LoginArea_Area_AreaID");

                entity.HasOne(d => d.LoginDeptNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.LoginDept)
                    .HasConstraintName("FK_Session_LoginDept_Department_DepartmentID");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Session_Status_Status_StatusCd");
            });

            modelBuilder.Entity<ShipAccount>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.ShipAccountId })
                    .HasName("PK_ShipAccount_CustID_ShipAccountID");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.ShipAccountId).HasColumnName("ShipAccountID");

                entity.Property(e => e.AccountNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CarrierCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CarrierCdNavigation)
                    .WithMany(p => p.ShipAccount)
                    .HasForeignKey(d => d.CarrierCd)
                    .HasConstraintName("FK_ShipAccount_CarrierCd_Carrier_CarrierCd");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.ShipAccountNavigation)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipAccount_CustID_Customer_CustID");
            });

            modelBuilder.Entity<ShipCharge>(entity =>
            {
                entity.HasKey(e => e.ShipChargeCd)
                    .HasName("PK_ShipCharge_ShipChargeCd");

                entity.Property(e => e.ShipChargeCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Charge).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.ChargeDescription)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShipTo>(entity =>
            {
                entity.HasKey(e => new { e.ShipToId, e.CustId })
                    .HasName("PK_ShipTo_ShipToID_CustID");

                entity.Property(e => e.ShipToId).HasColumnName("ShipToID");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.ShipTo)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_ShipTo_Status_Status_StatusCd");
            });

            modelBuilder.Entity<ShipVia>(entity =>
            {
                entity.HasKey(e => e.ShipViaCd)
                    .HasName("PK_ShipVia_ShipViaCd");

                entity.Property(e => e.ShipViaCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CarrierCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CarrierCdNavigation)
                    .WithMany(p => p.ShipVia)
                    .HasForeignKey(d => d.CarrierCd)
                    .HasConstraintName("FK_ShipVia_CarrierCd_Carrier_CarrierCd");
            });

            modelBuilder.Entity<SpecialHandling>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_SpecialHandling_OrderID");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReviewDate).HasColumnType("date");

                entity.HasOne(d => d.HoldJobForEmpNavigation)
                    .WithMany(p => p.SpecialHandlingHoldJobForEmpNavigation)
                    .HasForeignKey(d => d.HoldJobForEmp)
                    .HasConstraintName("FK_SpecialHandling_HoldJobForEmp_Employee_EmpID");

                entity.HasOne(d => d.NotifyEmpNavigation)
                    .WithMany(p => p.SpecialHandlingNotifyEmpNavigation)
                    .HasForeignKey(d => d.NotifyEmp)
                    .HasConstraintName("FK_SpecialHandling_NotifyEmp_Employee_EmpID");

                entity.HasOne(d => d.ReviewReqByEmpNavigation)
                    .WithMany(p => p.SpecialHandlingReviewReqByEmpNavigation)
                    .HasForeignKey(d => d.ReviewReqByEmp)
                    .HasConstraintName("FK_SpecialHandling_ReviewReqByEmp_Employee_EmpID");

                entity.HasOne(d => d.SpecialPrintByEmpNavigation)
                    .WithMany(p => p.SpecialHandlingSpecialPrintByEmpNavigation)
                    .HasForeignKey(d => d.SpecialPrintByEmp)
                    .HasConstraintName("FK_SpecialHandling_SpecialPrintByEmp_Employee_EmpID");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.HasKey(e => e.SpecId)
                    .HasName("PK_Specification_SpecID");

                entity.Property(e => e.SpecId)
                    .HasColumnName("SpecID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alias)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentRev)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NadCapSamplePlan)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SamplePlan)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Stamp>(entity =>
            {
                entity.HasKey(e => e.StampCd)
                    .HasName("PK_Stamp_StampCd");

                entity.Property(e => e.StampCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.StatusCd)
                    .HasName("PK_Status_StatusCd");

                entity.Property(e => e.StatusCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatusType)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.Property(e => e.StepId)
                    .HasColumnName("StepID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Instructions)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.StepCategoryCd)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.StepName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Step)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Step_Status_Status_StatusCd");

                entity.HasOne(d => d.StepCategoryCdNavigation)
                    .WithMany(p => p.Step)
                    .HasForeignKey(d => d.StepCategoryCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Step_StepCategoryCd_StepCategory_StepCategoryCd");
            });

            modelBuilder.Entity<StepCategory>(entity =>
            {
                entity.HasKey(e => e.StepCategoryCd)
                    .HasName("PK_StepCategory_StepCategoryCd");

                entity.Property(e => e.StepCategoryCd)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StepVarList>(entity =>
            {
                entity.HasKey(e => new { e.StepId, e.VariableSeq })
                    .HasName("PK_StepVarList_StepID_VariableSeq");

                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.Property(e => e.StepVariableId).HasColumnName("StepVariableID");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.StepVarList)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StepVarList_StepID_Step_StepID");

                entity.HasOne(d => d.StepVariable)
                    .WithMany(p => p.StepVarList)
                    .HasForeignKey(d => d.StepVariableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StepVarList_StepVariableID_StepVariable_StepVariableID");
            });

            modelBuilder.Entity<StepVariable>(entity =>
            {
                entity.Property(e => e.StepVariableId)
                    .HasColumnName("StepVariableID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DefaultMax).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.DefaultMin).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.StepVarName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Uomcd)
                    .HasColumnName("UOMCd")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.VariableCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.UomcdNavigation)
                    .WithMany(p => p.StepVariable)
                    .HasForeignKey(d => d.Uomcd)
                    .HasConstraintName("FK_StepVariable_UOMCd_UOMCode_UOMCd");
            });

            modelBuilder.Entity<SubOpRevision>(entity =>
            {
                entity.HasKey(e => new { e.SubOpRevId, e.SubOpId })
                    .HasName("PK_SubOpRevision_SubOpRevID_SubOpID");

                entity.Property(e => e.SubOpRevId)
                    .HasColumnName("SubOpRevID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SubOpId).HasColumnName("SubOpID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TimeCreated).HasColumnType("time(0)");

                entity.HasOne(d => d.CreatedByEmpNavigation)
                    .WithMany(p => p.SubOpRevision)
                    .HasForeignKey(d => d.CreatedByEmp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubOpRevision_CreatedByEmp_Employee_EmpID");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.SubOpRevision)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubOpRevision_Status_Status_StatusCd");

                entity.HasOne(d => d.SubOp)
                    .WithMany(p => p.SubOpRevision)
                    .HasForeignKey(d => d.SubOpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubOpRevision_SubOpID_SubOperation_SubOpID");
            });

            modelBuilder.Entity<SubOpStepList>(entity =>
            {
                entity.HasKey(e => new { e.SubOpId, e.SubOpRevId, e.StepSeq })
                    .HasName("PK_SubOpStepList_SubOpID_SubOpRevID_StepSeq");

                entity.Property(e => e.SubOpId).HasColumnName("SubOpID");

                entity.Property(e => e.SubOpRevId).HasColumnName("SubOpRevID");

                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.SubOpStepList)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubOpStepList_StepID_Step_StepID");

                entity.HasOne(d => d.SubOp)
                    .WithMany(p => p.SubOpStepList)
                    .HasForeignKey(d => new { d.SubOpRevId, d.SubOpId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubOpStepList_SubOpRevID_SubOpRevision_SubOpRevID");
            });

            modelBuilder.Entity<SubOperation>(entity =>
            {
                entity.HasKey(e => e.SubOpId)
                    .HasName("PK_SubOperation_SubOpID");

                entity.Property(e => e.SubOpId)
                    .HasColumnName("SubOpID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TaxAuthority>(entity =>
            {
                entity.HasKey(e => new { e.TaxAuthId, e.JurisdictionId })
                    .HasName("PK_TaxAuthority_TaxAuthID_JurisdictionID");

                entity.Property(e => e.TaxAuthId).HasColumnName("TaxAuthID");

                entity.Property(e => e.JurisdictionId).HasColumnName("JurisdictionID");

                entity.Property(e => e.AuthorityLevel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SalesTaxPerc).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.Jurisdiction)
                    .WithMany(p => p.TaxAuthority)
                    .HasForeignKey(d => d.JurisdictionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaxAuthority_JurisdictionID_TaxJurisdiction_JurisdictionID");
            });

            modelBuilder.Entity<TaxJurisdiction>(entity =>
            {
                entity.HasKey(e => e.JurisdictionId)
                    .HasName("PK_TaxJurisdiction_JurisdictionID");

                entity.Property(e => e.JurisdictionId)
                    .HasColumnName("JurisdictionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Terms>(entity =>
            {
                entity.HasKey(e => e.TermsCd)
                    .HasName("PK_Terms_TermsCd");

                entity.Property(e => e.TermsCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestHead>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PK_TestHead_TestID");

                entity.Property(e => e.TestId)
                    .HasColumnName("TestID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uomcode>(entity =>
            {
                entity.HasKey(e => e.Uomcd)
                    .HasName("PK_UOMCode_UOMCd");

                entity.ToTable("UOMCode");

                entity.Property(e => e.Uomcd)
                    .HasColumnName("UOMCd")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Uomdesc)
                    .IsRequired()
                    .HasColumnName("UOMDesc")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
