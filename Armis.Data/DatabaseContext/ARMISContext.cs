using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Armis.Data.DatabaseContext.Entities;

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
        public virtual DbSet<ContComment> ContComment { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactTitle> ContactTitle { get; set; }
        public virtual DbSet<Container> Container { get; set; }
        public virtual DbSet<CreditStatus> CreditStatus { get; set; }
        public virtual DbSet<CustBillTo> CustBillTo { get; set; }
        public virtual DbSet<CustComment> CustComment { get; set; }
        public virtual DbSet<CustContNotify> CustContNotify { get; set; }
        public virtual DbSet<CustForm> CustForm { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerPart> CustomerPart { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DeptArea> DeptArea { get; set; }
        public virtual DbSet<DeptOperation> DeptOperation { get; set; }
        public virtual DbSet<DeptSpec> DeptSpec { get; set; }
        public virtual DbSet<DeptTypeCode> DeptTypeCode { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<HandlingCharge> HandlingCharge { get; set; }
        public virtual DbSet<Hardness> Hardness { get; set; }
        public virtual DbSet<InspectTestType> InspectTestType { get; set; }
        public virtual DbSet<LoadType> LoadType { get; set; }
        public virtual DbSet<LocationTypeCode> LocationTypeCode { get; set; }
        public virtual DbSet<MaterialAlloy> MaterialAlloy { get; set; }
        public virtual DbSet<MaterialSeries> MaterialSeries { get; set; }
        public virtual DbSet<Memo> Memo { get; set; }
        public virtual DbSet<MiscCharge> MiscCharge { get; set; }
        public virtual DbSet<NotifyEvent> NotifyEvent { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<OperationGroup> OperationGroup { get; set; }
        public virtual DbSet<OprLoadPrice> OprLoadPrice { get; set; }
        public virtual DbSet<OprMaterialPrice> OprMaterialPrice { get; set; }
        public virtual DbSet<OprThickPrice> OprThickPrice { get; set; }
        public virtual DbSet<OrderComments> OrderComments { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderExpedite> OrderExpedite { get; set; }
        public virtual DbSet<OrderHead> OrderHead { get; set; }
        public virtual DbSet<OrderLocation> OrderLocation { get; set; }
        public virtual DbSet<OrderShipToOverride> OrderShipToOverride { get; set; }
        public virtual DbSet<Oven> Oven { get; set; }
        public virtual DbSet<PackageCode> PackageCode { get; set; }
        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<PartComment> PartComment { get; set; }
        public virtual DbSet<PartRevision> PartRevision { get; set; }
        public virtual DbSet<PartSpecProcessAssign> PartSpecProcessAssign { get; set; }
        public virtual DbSet<PartTran> PartTran { get; set; }
        public virtual DbSet<PlateResult> PlateResult { get; set; }
        public virtual DbSet<PriceCode> PriceCode { get; set; }
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<ProcessLoad> ProcessLoad { get; set; }
        public virtual DbSet<ProcessRevision> ProcessRevision { get; set; }
        public virtual DbSet<ProcessStepSeq> ProcessStepSeq { get; set; }
        public virtual DbSet<QualityStandard> QualityStandard { get; set; }
        public virtual DbSet<Rack> Rack { get; set; }
        public virtual DbSet<RemarkCode> RemarkCode { get; set; }
        public virtual DbSet<RevisionStatus> RevisionStatus { get; set; }
        public virtual DbSet<ReworkCode> ReworkCode { get; set; }
        public virtual DbSet<SamplePlanHead> SamplePlanHead { get; set; }
        public virtual DbSet<SamplePlanLevel> SamplePlanLevel { get; set; }
        public virtual DbSet<SamplePlanReject> SamplePlanReject { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<ShipAccount> ShipAccount { get; set; }
        public virtual DbSet<ShipCharge> ShipCharge { get; set; }
        public virtual DbSet<ShipTo> ShipTo { get; set; }
        public virtual DbSet<ShipVia> ShipVia { get; set; }
        public virtual DbSet<ShipViaTypeCode> ShipViaTypeCode { get; set; }
        public virtual DbSet<ShopLocation> ShopLocation { get; set; }
        public virtual DbSet<SpecChoice> SpecChoice { get; set; }
        public virtual DbSet<SpecProcessAssign> SpecProcessAssign { get; set; }
        public virtual DbSet<SpecSubLevel> SpecSubLevel { get; set; }
        public virtual DbSet<SpecialHandling> SpecialHandling { get; set; }
        public virtual DbSet<Specification> Specification { get; set; }
        public virtual DbSet<SpecificationRevision> SpecificationRevision { get; set; }
        public virtual DbSet<Stamp> Stamp { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Step> Step { get; set; }
        public virtual DbSet<StepCategory> StepCategory { get; set; }
        public virtual DbSet<TaxAuthLevelCode> TaxAuthLevelCode { get; set; }
        public virtual DbSet<TaxAuthority> TaxAuthority { get; set; }
        public virtual DbSet<TaxJurisAuthority> TaxJurisAuthority { get; set; }
        public virtual DbSet<TaxJurisdiction> TaxJurisdiction { get; set; }
        public virtual DbSet<Terms> Terms { get; set; }
        public virtual DbSet<TranType> TranType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; Initial Catalog = ARMIS; integrated security=True");
                optionsBuilder.UseSqlServer("Data Source = srv-armis-central.database.windows.net; Initial Catalog = ArmisStage; User Id=armisadmin; Password=8#6C1xLopq@z;");
                //optionsBuilder.UseSqlServer("Data Source = 10.1.1.14; Initial Catalog = ARMIS; integrated security=True");
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
                entity.Property(e => e.AreaId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.DefaultLocationNavigation)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.DefaultLocation)
                    .HasConstraintName("FK_Area_DefaultLocation_ShopLocation_LocationId");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK_Area_Type_DeptTypeCode_DeptTypeCd");
            });

            modelBuilder.Entity<AreaRemark>(entity =>
            {
                entity.HasKey(e => new { e.AreaId, e.RemarkId })
                    .HasName("PK_AreaRemark_AreaId_RemarkId");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.AreaRemark)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AreaRemark_AreaId_Area_AreaId");

                entity.HasOne(d => d.Remark)
                    .WithMany(p => p.AreaRemark)
                    .HasForeignKey(d => d.RemarkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AreaRemark_RemarkId_RemarkCode_RemarkId");
            });

            modelBuilder.Entity<BakeResult>(entity =>
            {
                entity.Property(e => e.BakeResultId).ValueGeneratedNever();

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OvenName)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.OvenTemp).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.PlatedTime).HasColumnType("time(0)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.StartTime).HasColumnType("time(0)");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StopDate).HasColumnType("date");

                entity.Property(e => e.StopTime).HasColumnType("time(0)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.BakeResult)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_BakeResult_OrderId_OrderHead_OrderId");

                entity.HasOne(d => d.OvenNameNavigation)
                    .WithMany(p => p.BakeResult)
                    .HasForeignKey(d => d.OvenName)
                    .HasConstraintName("FK_BakeResult_OvenName_Oven_OvenCd");

                entity.HasOne(d => d.StartedByEmpNavigation)
                    .WithMany(p => p.BakeResultStartedByEmpNavigation)
                    .HasForeignKey(d => d.StartedByEmp)
                    .HasConstraintName("FK_BakeResult_StartedByEmp_Employee_EmpId");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.BakeResult)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_BakeResult_Status_Status_StatusCd");

                entity.HasOne(d => d.StoppedByEmpNavigation)
                    .WithMany(p => p.BakeResultStoppedByEmpNavigation)
                    .HasForeignKey(d => d.StoppedByEmp)
                    .HasConstraintName("FK_BakeResult_StoppedByEmp_Employee_EmpId");
            });

            modelBuilder.Entity<Carrier>(entity =>
            {
                entity.HasKey(e => e.CarrierCd)
                    .HasName("PK_Carrier_CarrierCd");

                entity.Property(e => e.CarrierCd)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.OurAcctNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.HasKey(e => e.CertId)
                    .HasName("PK_Certification_CertId");

                entity.Property(e => e.ChargeAmt).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QualStdCd)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

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
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Certification_SpecRevId_SpecificationRevision_SpecRevId");
            });

            modelBuilder.Entity<CommentCode>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK_CommentCode_CommentId");

                entity.Property(e => e.CommentId).ValueGeneratedNever();

                entity.Property(e => e.CommentDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PriceIncPerc).HasColumnType("decimal(9, 2)");
            });

            modelBuilder.Entity<ContComment>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK_ContComment_ContactId");

                entity.Property(e => e.ContactId).ValueGeneratedNever();

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactId).ValueGeneratedNever();

                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(40)
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

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_Contact_CustId_Customer_CustId");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.TitleId)
                    .HasConstraintName("FK_Contact_TitleId_ContactTitle_ContactTitleId");

                entity.HasOne(d => d.ShipTo)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => new { d.CustId, d.ShipToId })
                    .HasConstraintName("FK_Contact_ShipToId_ShipTo_ShipToId");
            });

            modelBuilder.Entity<ContactTitle>(entity =>
            {
                entity.Property(e => e.ContactTitleId).ValueGeneratedNever();

                entity.Property(e => e.TitleName)
                    .IsRequired()
                    .HasMaxLength(50)
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

            modelBuilder.Entity<CreditStatus>(entity =>
            {
                entity.HasKey(e => e.CredStatusCd)
                    .HasName("PK_CreditStatus_CredStatusCd");

                entity.Property(e => e.CredStatusCd)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustBillTo>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK_CustBillTo_CustId");

                entity.Property(e => e.CustId).ValueGeneratedNever();

                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.CustBillTo)
                    .HasForeignKey<CustBillTo>(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustBillTo_CustId_Customer_CustId");
            });

            modelBuilder.Entity<CustComment>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK_CustComment_CustId");

                entity.Property(e => e.CustId).ValueGeneratedNever();

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.CustComment)
                    .HasForeignKey<CustComment>(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustComment_CustId_Customer_CustId");
            });

            modelBuilder.Entity<CustContNotify>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.ContactId, e.NotifyEventId })
                    .HasName("PK_CustContNotify_CustId_ContactId_NotifyEventId");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.CustContNotify)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustContNotify_ContactId_Contact_ContactId");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.CustContNotify)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustContNotify_CustId_Customer_CustId");

                entity.HasOne(d => d.NotifyEvent)
                    .WithMany(p => p.CustContNotify)
                    .HasForeignKey(d => d.NotifyEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustContNotify_NotifyEventId_NotifyEvent_NotifyEventId");
            });

            modelBuilder.Entity<CustForm>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK_CustForm_CustId");

                entity.Property(e => e.CustId).ValueGeneratedNever();

                entity.Property(e => e.ConsolidatedInvoiceId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InspectionFormId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceFormId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PackSlipFormId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnLabelFormId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatementFormId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WhenToPrint)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cert)
                    .WithMany(p => p.CustForm)
                    .HasForeignKey(d => d.CertId)
                    .HasConstraintName("FK_CustForm_CertId_Certification_CertId");

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.CustForm)
                    .HasForeignKey<CustForm>(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustForm_CustId_Customer_CustId");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK_Customer_CustId");

                entity.Property(e => e.CustId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.CreditLimit).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.CreditStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultShipVia)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IsIgnoreDupePos).HasColumnName("IsIgnoreDupePOs");

                entity.Property(e => e.IsTmcustomer).HasColumnName("IsTMCustomer");

                entity.Property(e => e.LeaveOffCredHoldUntil).HasColumnType("date");

                entity.Property(e => e.MinIncreasePerc).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PriceIncreasePerc).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.SearchName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TaxExemptNum)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cert)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CertId)
                    .HasConstraintName("FK_Customer_CertId_Certification_CertId");

                entity.HasOne(d => d.CreditStatusNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CreditStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_CreditStatus_CreditStatus_CredStatusCd");

                entity.HasOne(d => d.DefaultContactNumNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.DefaultContactNum)
                    .HasConstraintName("FK_Customer_DefaultContactNum_Contact_ContactId");

                entity.HasOne(d => d.DefaultShipViaNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.DefaultShipVia)
                    .HasConstraintName("FK_Customer_DefaultShipVia_ShipVia_ShipViaCd");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.PriorityId)
                    .HasConstraintName("FK_Customer_PriorityId_Priority_PriorityId");

                entity.HasOne(d => d.SalesPersonNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.SalesPerson)
                    .HasConstraintName("FK_Customer_SalesPerson_Employee_EmpId");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Status_Status_StatusCd");

                entity.HasOne(d => d.TaxJurisd)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.TaxJurisdId)
                    .HasConstraintName("FK_Customer_TaxJurisdId_TaxJurisdiction_JurisdictionId");

                entity.HasOne(d => d.Terms)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.TermsId)
                    .HasConstraintName("FK_Customer_TermsId_Terms_TermsId");

                entity.HasOne(d => d.ShipAccount)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => new { d.CustId, d.DefaultShipAccount })
                    .HasConstraintName("FK_Customer_DefaultShipAccount_ShipAccount_ShipAccountId");

                entity.HasOne(d => d.ShipTo)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => new { d.CustId, d.DefaultShipToId })
                    .HasConstraintName("FK_Customer_DefaultShipToId_ShipTo_ShipToId");
            });

            modelBuilder.Entity<CustomerPart>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.PartId, e.PartRevId })
                    .HasName("PK_CustomerPart_CustId_PartId_PartRevId");

                entity.Property(e => e.LastUsedDate).HasColumnType("date");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.CustomerPart)
                    .HasForeignKey(d => new { d.PartId, d.PartRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerPart_PartRevId_PartRevision_PartRevId");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.DeptTypeCd)
                    .IsRequired()
                    .HasMaxLength(6)
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

                entity.Property(e => e.PlaterBurRate).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.ReworkBurRate).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.DeptTypeCdNavigation)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.DeptTypeCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_DeptTypeCd_DeptTypeCode_DeptTypeCd");

                entity.HasOne(d => d.LoadTypeCdNavigation)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.LoadTypeCd)
                    .HasConstraintName("FK_Department_LoadTypeCd_LoadType_LoadTypeCd");

                entity.HasOne(d => d.ScheduleArea)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.ScheduleAreaId)
                    .HasConstraintName("FK_Department_ScheduleAreaId_Area_AreaId");
            });

            modelBuilder.Entity<DeptArea>(entity =>
            {
                entity.HasKey(e => new { e.AreaId, e.DepartmentId })
                    .HasName("PK_DeptArea_AreaId_DepartmentId");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.DeptArea)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptArea_AreaId_Area_AreaId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DeptArea)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptArea_DepartmentId_Department_DepartmentId");
            });

            modelBuilder.Entity<DeptOperation>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.OperationId })
                    .HasName("PK_DeptOperation_DepartmentId_OperationId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DeptOperation)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptOperation_DepartmentId_Department_DepartmentId");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.DeptOperation)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptOperation_OperationId_Operation_OperationId");
            });

            modelBuilder.Entity<DeptSpec>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.SpecId, e.SpecRevId })
                    .HasName("PK_DeptSpec_DepartmentId_SpecId_SpecRevId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DeptSpec)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptSpec_DepartmentId_Department_DepartmentId");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.DeptSpec)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptSpec_SpecRevId_SpecificationRevision_SpecRevId");
            });

            modelBuilder.Entity<DeptTypeCode>(entity =>
            {
                entity.HasKey(e => e.DeptTypeCd)
                    .HasName("PK_DeptTypeCode_DeptTypeCd");

                entity.Property(e => e.DeptTypeCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.DriverId).ValueGeneratedNever();

                entity.Property(e => e.AssignedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Driver_CustId_Customer_CustId");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_Employee_EmpId");

                entity.Property(e => e.EmpId).ValueGeneratedNever();

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("EMailAddress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExtUserId)
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
                    .HasConstraintName("FK_Employee_AreaId_Area_AreaId");
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
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hardness>(entity =>
            {
                entity.Property(e => e.HardnessId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HardnessMax).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.HardnessMin).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InspectTestType>(entity =>
            {
                entity.HasKey(e => e.InspectTestId)
                    .HasName("PK_InspectTestType_InspectTestId");

                entity.Property(e => e.InspectTestId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TestCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
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
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LocationTypeCode>(entity =>
            {
                entity.HasKey(e => e.LocTypeCd)
                    .HasName("PK_LocationTypeCode_LocTypeCd");

                entity.Property(e => e.LocTypeCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MaterialAlloy>(entity =>
            {
                entity.HasKey(e => e.AlloyId)
                    .HasName("PK_MaterialAlloy_AlloyId");

                entity.Property(e => e.AlloyId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.MaterialAlloy)
                    .HasForeignKey(d => d.SeriesId)
                    .HasConstraintName("FK_MaterialAlloy_SeriesId_MaterialSeries_SeriesId");
            });

            modelBuilder.Entity<MaterialSeries>(entity =>
            {
                entity.HasKey(e => e.SeriesId)
                    .HasName("PK_MaterialSeries_SeriesId");

                entity.Property(e => e.SeriesId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Memo>(entity =>
            {
                entity.Property(e => e.MemoId).ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FollowupDate).HasColumnType("date");

                entity.Property(e => e.InteractionDate).HasColumnType("date");

                entity.Property(e => e.InteractionGroup)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InteractionMethod)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InteractionTime).HasColumnType("time(0)");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Memo)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Memo_ContactId_Contact_ContactId");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Memo)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_Memo_CustId_Customer_CustId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Memo)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Memo_DepartmentId_Department_DepartmentId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Memo)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Memo_OrderId_OrderHead_OrderId");
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
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NotifyEvent>(entity =>
            {
                entity.Property(e => e.NotifyEventId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.Property(e => e.OperationId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.OperationCd)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.OperGroup)
                    .WithMany(p => p.Operation)
                    .HasForeignKey(d => d.OperGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operation_OperGroupId_OperationGroup_OperGroupId");
            });

            modelBuilder.Entity<OperationGroup>(entity =>
            {
                entity.HasKey(e => e.OperGroupId)
                    .HasName("PK_OperationGroup_OperGroupId");

                entity.Property(e => e.OperGroupId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OprLoadPrice>(entity =>
            {
                entity.Property(e => e.OprLoadPriceId).ValueGeneratedNever();

                entity.Property(e => e.Lbprice)
                    .HasColumnName("LBPrice")
                    .HasColumnType("decimal(19, 4)");

                entity.Property(e => e.LoadType)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MinLotCharge).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.MinPiecePrice).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.OprLoadPrice)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_OprLoadPrice_CustId_Customer_CustId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.OprLoadPrice)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_OprLoadPrice_DepartmentId_Department_DepartmentId");

                entity.HasOne(d => d.LoadTypeNavigation)
                    .WithMany(p => p.OprLoadPrice)
                    .HasForeignKey(d => d.LoadType)
                    .HasConstraintName("FK_OprLoadPrice_LoadType_LoadType_LoadTypeCd");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.OprLoadPrice)
                    .HasForeignKey(d => d.OperationId)
                    .HasConstraintName("FK_OprLoadPrice_OperationId_Operation_OperationId");
            });

            modelBuilder.Entity<OprMaterialPrice>(entity =>
            {
                entity.Property(e => e.OprMaterialPriceId).ValueGeneratedNever();

                entity.Property(e => e.MinLotInc).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.MinPiecePriceInc).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PercInc).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.OprMaterialPrice)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_OprMaterialPrice_CustId_Customer_CustId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.OprMaterialPrice)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_OprMaterialPrice_DepartmentId_Department_DepartmentId");

                entity.HasOne(d => d.MaterialCdNavigation)
                    .WithMany(p => p.OprMaterialPrice)
                    .HasForeignKey(d => d.MaterialCd)
                    .HasConstraintName("FK_OprMaterialPrice_MaterialCd_MaterialAlloy_AlloyId");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.OprMaterialPrice)
                    .HasForeignKey(d => d.OperationId)
                    .HasConstraintName("FK_OprMaterialPrice_OperationId_Operation_OperationId");
            });

            modelBuilder.Entity<OprThickPrice>(entity =>
            {
                entity.Property(e => e.OprThickPriceId).ValueGeneratedNever();

                entity.Property(e => e.MinLotInc).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.MinPiecePriceInc).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.MinThickness).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PercInc).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.OprThickPrice)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_OprThickPrice_CustId_Customer_CustId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.OprThickPrice)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_OprThickPrice_DepartmentId_Department_DepartmentId");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.OprThickPrice)
                    .HasForeignKey(d => d.OperationId)
                    .HasConstraintName("FK_OprThickPrice_OperationId_Operation_OperationId");
            });

            modelBuilder.Entity<OrderComments>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_OrderComments_OrderId");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.CredAuthComments)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.JobHoldComments)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OrderComments1)
                    .IsRequired()
                    .HasColumnName("OrderComments")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Raicomments)
                    .HasColumnName("RAIComments")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VoidComments)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.OrderComments)
                    .HasForeignKey<OrderComments>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderComments_OrderId_OrderHead_OrderId");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.OrderLine })
                    .HasName("PK_OrderDetail_OrderId_OrderLine");

                entity.Property(e => e.AssignedPrice).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Poprice)
                    .HasColumnName("POPrice")
                    .HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ProcessComments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_OrderId_OrderHead_OrderId");

                entity.HasOne(d => d.PriceCode)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.PriceCodeId)
                    .HasConstraintName("FK_OrderDetail_PriceCodeId_PriceCode_PriceCodeId");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => new { d.PartId, d.PartRevId })
                    .HasConstraintName("FK_OrderDetail_PartRevId_PartRevision_PartRevId");
            });

            modelBuilder.Entity<OrderExpedite>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_OrderExpedite_OrderId");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.ExpeditedDate).HasColumnType("date");

                entity.Property(e => e.FeeAmount).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.ApprovedByEmpNavigation)
                    .WithMany(p => p.OrderExpediteApprovedByEmpNavigation)
                    .HasForeignKey(d => d.ApprovedByEmp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderExpedite_ApprovedByEmp_Employee_EmpId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.OrderExpedite)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_OrderExpedite_DepartmentId_Department_DepartmentId");

                entity.HasOne(d => d.ExpeditedByEmpNavigation)
                    .WithMany(p => p.OrderExpediteExpeditedByEmpNavigation)
                    .HasForeignKey(d => d.ExpeditedByEmp)
                    .HasConstraintName("FK_OrderExpedite_ExpeditedByEmp_Employee_EmpId");

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.OrderExpediteOrder)
                    .HasForeignKey<OrderExpedite>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderExpedite_OrderId_OrderHead_OrderId");

                entity.HasOne(d => d.ReworkOrderNavigation)
                    .WithMany(p => p.OrderExpediteReworkOrderNavigation)
                    .HasForeignKey(d => d.ReworkOrder)
                    .HasConstraintName("FK_OrderExpedite_ReworkOrder_OrderHead_OrderId");
            });

            modelBuilder.Entity<OrderHead>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_OrderHead_OrderId");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.DoneDate).HasColumnType("date");

                entity.Property(e => e.DoneTime).HasColumnType("time(0)");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.ExpediteStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HandlingChargeCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LastCompleteRemSentDt).HasColumnType("date");

                entity.Property(e => e.LotCharge).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.MiscChargeCd)
                    .HasMaxLength(4)
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

                entity.Property(e => e.PromiseDate).HasColumnType("date");

                entity.Property(e => e.PromiseTime).HasColumnType("time(0)");

                entity.Property(e => e.QualStdCd)
                    .HasMaxLength(6)
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

                entity.Property(e => e.SubTotal).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.TargetDate).HasColumnType("date");

                entity.HasOne(d => d.Cert)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.CertId)
                    .HasConstraintName("FK_OrderHead_CertId_Certification_CertId");

                entity.HasOne(d => d.CreditAuthByEmpNavigation)
                    .WithMany(p => p.OrderHeadCreditAuthByEmpNavigation)
                    .HasForeignKey(d => d.CreditAuthByEmp)
                    .HasConstraintName("FK_OrderHead_CreditAuthByEmp_Employee_EmpId");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_OrderHead_CustId_Customer_CustId");

                entity.HasOne(d => d.ExpediteStatusNavigation)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.ExpediteStatus)
                    .HasConstraintName("FK_OrderHead_ExpediteStatus_Status_StatusCd");

                entity.HasOne(d => d.HandlingChargeCdNavigation)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.HandlingChargeCd)
                    .HasConstraintName("FK_OrderHead_HandlingChargeCd_HandlingCharge_HandlingChargeCd");

                entity.HasOne(d => d.JobHoldByEmpNavigation)
                    .WithMany(p => p.OrderHeadJobHoldByEmpNavigation)
                    .HasForeignKey(d => d.JobHoldByEmp)
                    .HasConstraintName("FK_OrderHead_JobHoldByEmp_Employee_EmpId");

                entity.HasOne(d => d.JobHoldToEmpNavigation)
                    .WithMany(p => p.OrderHeadJobHoldToEmpNavigation)
                    .HasForeignKey(d => d.JobHoldToEmp)
                    .HasConstraintName("FK_OrderHead_JobHoldToEmp_Employee_EmpId");

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
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SpecAssignId })
                    .HasConstraintName("FK_OrderHead_SpecAssignId_SpecProcessAssign_SpecAssignId");
            });

            modelBuilder.Entity<OrderLocation>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.OrderLine, e.LocationId })
                    .HasName("PK_OrderLocation_OrderId_OrderLine_LocationId");

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
                    .HasConstraintName("FK_OrderLocation_LocationId_ShopLocation_LocationId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLocation)
                    .HasForeignKey(d => new { d.OrderId, d.OrderLine })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderLocation_OrderLine_OrderDetail_OrderLine");
            });

            modelBuilder.Entity<OrderShipToOverride>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_OrderShipToOverride_OrderId");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.Staddress1)
                    .IsRequired()
                    .HasColumnName("STAddress1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Staddress2)
                    .IsRequired()
                    .HasColumnName("STAddress2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Staddress3)
                    .IsRequired()
                    .HasColumnName("STAddress3")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stattn)
                    .HasColumnName("STAttn")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stcity)
                    .IsRequired()
                    .HasColumnName("STCity")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stname)
                    .IsRequired()
                    .HasColumnName("STName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Stphone)
                    .HasColumnName("STPhone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ststate)
                    .IsRequired()
                    .HasColumnName("STState")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stzip)
                    .IsRequired()
                    .HasColumnName("STZip")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.OrderShipToOverride)
                    .HasForeignKey<OrderShipToOverride>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderShipToOverride_OrderId_OrderHead_OrderId");
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
                entity.Property(e => e.PartId).ValueGeneratedNever();

                entity.Property(e => e.PartName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PartComment>(entity =>
            {
                entity.HasKey(e => new { e.PartId, e.PartRevId })
                    .HasName("PK_PartComment_PartId_PartRevId");

                entity.Property(e => e.MaskingInstructions)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PartComments)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PriceComments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrintWithOrder)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessComments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Part)
                    .WithOne(p => p.PartComment)
                    .HasForeignKey<PartComment>(d => new { d.PartId, d.PartRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartComment_PartRevId_PartRevision_PartRevId");
            });

            modelBuilder.Entity<PartRevision>(entity =>
            {
                entity.HasKey(e => new { e.PartId, e.PartRevId })
                    .HasName("PK_PartRevision_PartId_PartRevId");

                entity.Property(e => e.Bake)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BasePrice).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.DateModified).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dimensions)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ExternalRev)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MinLotCharge).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.PieceWeight).HasColumnType("decimal(19, 6)");

                entity.Property(e => e.SauoM)
                    .HasColumnName("SAUoM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SurfaceArea).HasColumnType("decimal(19, 6)");

                entity.Property(e => e.TimeModified).HasColumnType("time(0)");

                entity.HasOne(d => d.AlloyNavigation)
                    .WithMany(p => p.PartRevision)
                    .HasForeignKey(d => d.Alloy)
                    .HasConstraintName("FK_PartRevision_Alloy_MaterialAlloy_AlloyId");

                entity.HasOne(d => d.CreatedByEmpNavigation)
                    .WithMany(p => p.PartRevision)
                    .HasForeignKey(d => d.CreatedByEmp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartRevision_CreatedByEmp_Employee_EmpId");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.PartRevision)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartRevision_PartId_Part_PartId");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.PartRevision)
                    .HasForeignKey(d => d.SeriesId)
                    .HasConstraintName("FK_PartRevision_SeriesId_MaterialSeries_SeriesId");

                entity.HasOne(d => d.StandardDeptNavigation)
                    .WithMany(p => p.PartRevision)
                    .HasForeignKey(d => d.StandardDept)
                    .HasConstraintName("FK_PartRevision_StandardDept_Department_DepartmentId");
            });

            modelBuilder.Entity<PartSpecProcessAssign>(entity =>
            {
                entity.HasKey(e => new { e.PartId, e.PartRevId, e.SpecId, e.SpecRevId, e.SpecAssignId })
                    .HasName("PK_PartSpecProcessAssign_PartId_PartRevId_SpecId_SpecRevId_SpecAssignId");

                entity.Property(e => e.LastUsedDate).HasColumnType("date");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.PartSpecProcessAssign)
                    .HasForeignKey(d => new { d.PartId, d.PartRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartSpecProcessAssign_PartRevId_PartRevision_PartRevId");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.PartSpecProcessAssign)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SpecAssignId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartSpecProcessAssign_SpecAssignId_SpecProcessAssign_SpecAssignId");
            });

            modelBuilder.Entity<PartTran>(entity =>
            {
                entity.HasKey(e => new { e.PartId, e.PartRevId, e.TranSeqNum })
                    .HasName("PK_PartTran_PartId_PartRevId_TranSeqNum");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.LegacyProcess)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PiecePrice).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.SysDate).HasColumnType("date");

                entity.Property(e => e.SysTime).HasColumnType("time(0)");

                entity.HasOne(d => d.FromLocationNavigation)
                    .WithMany(p => p.PartTranFromLocationNavigation)
                    .HasForeignKey(d => d.FromLocation)
                    .HasConstraintName("FK_PartTran_FromLocation_ShopLocation_LocationId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PartTran)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartTran_OrderId_OrderHead_OrderId");

                entity.HasOne(d => d.PriceCode)
                    .WithMany(p => p.PartTran)
                    .HasForeignKey(d => d.PriceCodeId)
                    .HasConstraintName("FK_PartTran_PriceCodeId_PriceCode_PriceCodeId");

                entity.HasOne(d => d.ToLocationNavigation)
                    .WithMany(p => p.PartTranToLocationNavigation)
                    .HasForeignKey(d => d.ToLocation)
                    .HasConstraintName("FK_PartTran_ToLocation_ShopLocation_LocationId");

                entity.HasOne(d => d.TranType)
                    .WithMany(p => p.PartTran)
                    .HasForeignKey(d => d.TranTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartTran_TranTypeId_TranType_TranTypeId");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.PartTran)
                    .HasForeignKey(d => new { d.PartId, d.PartRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartTran_PartRevId_PartRevision_PartRevId");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.PartTran)
                    .HasForeignKey(d => new { d.ProcessId, d.ProcessRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartTran_ProcessRevId_ProcessRevision_ProcessRevId");
            });

            modelBuilder.Entity<PlateResult>(entity =>
            {
                entity.Property(e => e.PlateResultId).ValueGeneratedNever();

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LoadType)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.RunDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.PlateResult)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_PlateResult_AreaId_Area_AreaId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.PlateResult)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_PlateResult_DepartmentId_Department_DepartmentId");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.PlateResult)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_PlateResult_Employee_Employee_EmpId");

                entity.HasOne(d => d.LoadTypeNavigation)
                    .WithMany(p => p.PlateResult)
                    .HasForeignKey(d => d.LoadType)
                    .HasConstraintName("FK_PlateResult_LoadType_LoadType_LoadTypeCd");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PlateResult)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_PlateResult_OrderId_OrderHead_OrderId");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.PlateResult)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_PlateResult_Status_Status_StatusCd");
            });

            modelBuilder.Entity<PriceCode>(entity =>
            {
                entity.Property(e => e.PriceCodeId).ValueGeneratedNever();

                entity.Property(e => e.PriceCode1)
                    .HasColumnName("PriceCode")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.PriceCodeDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.Property(e => e.ProcessId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProcessLoad>(entity =>
            {
                entity.Property(e => e.ProcessLoadId).ValueGeneratedNever();

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LoadTypeCd)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MinLotCharge).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PiecePrice).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.ProcessLoad)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_ProcessLoad_DepartmentId_Department_DepartmentId");

                entity.HasOne(d => d.LoadTypeCdNavigation)
                    .WithMany(p => p.ProcessLoad)
                    .HasForeignKey(d => d.LoadTypeCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessLoad_LoadTypeCd_LoadType_LoadTypeCd");

                entity.HasOne(d => d.RackNavigation)
                    .WithMany(p => p.ProcessLoad)
                    .HasForeignKey(d => d.Rack)
                    .HasConstraintName("FK_ProcessLoad_Rack_Rack_RackId");
            });

            modelBuilder.Entity<ProcessRevision>(entity =>
            {
                entity.HasKey(e => new { e.ProcessId, e.ProcessRevId })
                    .HasName("PK_ProcessRevision_ProcessId_ProcessRevId");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateModified).HasColumnType("date");

                entity.Property(e => e.RevStatusCd)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TimeModified).HasColumnType("time(0)");

                entity.HasOne(d => d.CreatedByEmpNavigation)
                    .WithMany(p => p.ProcessRevision)
                    .HasForeignKey(d => d.CreatedByEmp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessRevision_CreatedByEmp_Employee_EmpId");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProcessRevision)
                    .HasForeignKey(d => d.ProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessRevision_ProcessId_Process_ProcessId");

                entity.HasOne(d => d.RevStatusCdNavigation)
                    .WithMany(p => p.ProcessRevision)
                    .HasForeignKey(d => d.RevStatusCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessRevision_RevStatusCd_RevisionStatus_RevStatusCd");
            });

            modelBuilder.Entity<ProcessStepSeq>(entity =>
            {
                entity.HasKey(e => new { e.ProcessId, e.ProcessRevId, e.StepSeq })
                    .HasName("PK_ProcessStepSeq_ProcessId_ProcessRevId_StepSeq");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.ProcessStepSeq)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessStepSeq_OperationId_Operation_OperationId");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.ProcessStepSeq)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessStepSeq_StepId_Step_StepId");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProcessStepSeq)
                    .HasForeignKey(d => new { d.ProcessId, d.ProcessRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessStepSeq_ProcessRevId_ProcessRevision_ProcessRevId");
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
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rack>(entity =>
            {
                entity.Property(e => e.RackId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dimensions)
                    .HasMaxLength(20)
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
                    .HasConstraintName("FK_Rack_AreaId_Area_AreaId");

                entity.HasOne(d => d.MaterialCdNavigation)
                    .WithMany(p => p.Rack)
                    .HasForeignKey(d => d.MaterialCd)
                    .HasConstraintName("FK_Rack_MaterialCd_MaterialAlloy_AlloyId");
            });

            modelBuilder.Entity<RemarkCode>(entity =>
            {
                entity.HasKey(e => e.RemarkId)
                    .HasName("PK_RemarkCode_RemarkId");

                entity.Property(e => e.RemarkId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QuickKey)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Tmupdate).HasColumnName("TMUpdate");
            });

            modelBuilder.Entity<RevisionStatus>(entity =>
            {
                entity.HasKey(e => e.RevStatusCd)
                    .HasName("PK_RevisionStatus_RevStatusCd");

                entity.Property(e => e.RevStatusCd)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReworkCode>(entity =>
            {
                entity.HasKey(e => e.ReworkCid)
                    .HasName("PK_ReworkCode_ReworkCId");

                entity.Property(e => e.ReworkCid)
                    .HasColumnName("ReworkCId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SamplePlanHead>(entity =>
            {
                entity.HasKey(e => e.SamplePlanId)
                    .HasName("PK_SamplePlanHead_SamplePlanId");

                entity.Property(e => e.SamplePlanId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlanName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SamplePlanLevel>(entity =>
            {
                entity.HasKey(e => new { e.SamplePlanId, e.SamplePlanLevelId })
                    .HasName("PK_SamplePlanLevel_SamplePlanId_SamplePlanLevelId");

                entity.HasOne(d => d.SamplePlan)
                    .WithMany(p => p.SamplePlanLevel)
                    .HasForeignKey(d => d.SamplePlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SamplePlanLevel_SamplePlanId_SamplePlanHead_SamplePlanId");
            });

            modelBuilder.Entity<SamplePlanReject>(entity =>
            {
                entity.HasKey(e => new { e.SamplePlanId, e.SamplePlanLevelId, e.InspectTestId })
                    .HasName("PK_SamplePlanReject_SamplePlanId_SamplePlanLevelId_InspectTestId");

                entity.HasOne(d => d.InspectTest)
                    .WithMany(p => p.SamplePlanReject)
                    .HasForeignKey(d => d.InspectTestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SamplePlanReject_InspectTestId_InspectTestType_InspectTestId");

                entity.HasOne(d => d.SamplePlan)
                    .WithMany(p => p.SamplePlanReject)
                    .HasForeignKey(d => new { d.SamplePlanId, d.SamplePlanLevelId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SamplePlanReject_SamplePlanLevelId_SamplePlanLevel_SamplePlanLevelId");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.SessionId).ValueGeneratedNever();

                entity.Property(e => e.SignInDate).HasColumnType("date");

                entity.Property(e => e.SignInTime).HasColumnType("time(0)");

                entity.Property(e => e.SignOutDate).HasColumnType("date");

                entity.Property(e => e.SignOutTime).HasColumnType("time(0)");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Session_EmployeeId_Employee_EmpId");

                entity.HasOne(d => d.LoginAreaNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.LoginArea)
                    .HasConstraintName("FK_Session_LoginArea_Area_AreaId");

                entity.HasOne(d => d.LoginDeptNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.LoginDept)
                    .HasConstraintName("FK_Session_LoginDept_Department_DepartmentId");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_Session_Status_Status_StatusCd");
            });

            modelBuilder.Entity<ShipAccount>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.ShipAccountId })
                    .HasName("PK_ShipAccount_CustId_ShipAccountId");

                entity.Property(e => e.AccountNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CarrierCd)
                    .HasMaxLength(8)
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
                    .HasConstraintName("FK_ShipAccount_CustId_Customer_CustId");
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
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShipTo>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.ShipToId })
                    .HasName("PK_ShipTo_CustId_ShipToId");

                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultShipVia)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.ShipToNavigation)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipTo_CustId_Customer_CustId");

                entity.HasOne(d => d.DefaultShipViaNavigation)
                    .WithMany(p => p.ShipTo)
                    .HasForeignKey(d => d.DefaultShipVia)
                    .HasConstraintName("FK_ShipTo_DefaultShipVia_ShipVia_ShipViaCd");
            });

            modelBuilder.Entity<ShipVia>(entity =>
            {
                entity.HasKey(e => e.ShipViaCd)
                    .HasName("PK_ShipVia_ShipViaCd");

                entity.Property(e => e.ShipViaCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CarrierCd)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SvtypeCd)
                    .IsRequired()
                    .HasColumnName("SVTypeCd")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.CarrierCdNavigation)
                    .WithMany(p => p.ShipVia)
                    .HasForeignKey(d => d.CarrierCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipVia_CarrierCd_Carrier_CarrierCd");

                entity.HasOne(d => d.SvtypeCdNavigation)
                    .WithMany(p => p.ShipVia)
                    .HasForeignKey(d => d.SvtypeCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipVia_SVTypeCd_ShipViaTypeCode_SVTypeCd");
            });

            modelBuilder.Entity<ShipViaTypeCode>(entity =>
            {
                entity.HasKey(e => e.SvtypeCd)
                    .HasName("PK_ShipViaTypeCode_SVTypeCd");

                entity.Property(e => e.SvtypeCd)
                    .HasColumnName("SVTypeCd")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShopLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK_ShopLocation_LocationId");

                entity.Property(e => e.LocationId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.LocTypeCd)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.AreaNavigation)
                    .WithMany(p => p.ShopLocation)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_ShopLocation_AreaId_Area_AreaId");

                entity.HasOne(d => d.LocTypeCdNavigation)
                    .WithMany(p => p.ShopLocation)
                    .HasForeignKey(d => d.LocTypeCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopLocation_LocTypeCd_LocationTypeCode_LocTypeCd");
            });

            modelBuilder.Entity<SpecChoice>(entity =>
            {
                entity.HasKey(e => new { e.SpecId, e.SpecRevId, e.SubLevelSeqId, e.ChoiceSeqId })
                    .HasName("PK_SpecChoice_SpecId_SpecRevId_SubLevelSeqId_ChoiceSeqId");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.S)
                    .WithMany(p => p.SpecChoice)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelSeqId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecChoice_SubLevelSeqId_SpecSubLevel_SubLevelSeqId");
            });

            modelBuilder.Entity<SpecProcessAssign>(entity =>
            {
                entity.HasKey(e => new { e.SpecId, e.SpecRevId, e.SpecAssignId })
                    .HasName("PK_SpecProcessAssign_SpecId_SpecRevId_SpecAssignId");

                entity.HasOne(d => d.AlloyOptionNavigation)
                    .WithMany(p => p.SpecProcessAssign)
                    .HasForeignKey(d => d.AlloyOption)
                    .HasConstraintName("FK_SpecProcessAssign_AlloyOption_MaterialAlloy_AlloyId");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.SpecProcessAssign)
                    .HasForeignKey(d => d.Customer)
                    .HasConstraintName("FK_SpecProcessAssign_Customer_Customer_CustId");

                entity.HasOne(d => d.HardnessOptionNavigation)
                    .WithMany(p => p.SpecProcessAssign)
                    .HasForeignKey(d => d.HardnessOption)
                    .HasConstraintName("FK_SpecProcessAssign_HardnessOption_Hardness_HardnessId");

                entity.HasOne(d => d.MaskOptionNavigation)
                    .WithMany(p => p.SpecProcessAssignMaskOptionNavigation)
                    .HasForeignKey(d => d.MaskOption)
                    .HasConstraintName("FK_SpecProcessAssign_MaskOption_Step_StepId");

                entity.HasOne(d => d.PostBakeOptionNavigation)
                    .WithMany(p => p.SpecProcessAssignPostBakeOptionNavigation)
                    .HasForeignKey(d => d.PostBakeOption)
                    .HasConstraintName("FK_SpecProcessAssign_PostBakeOption_Step_StepId");

                entity.HasOne(d => d.PreBakeOptionNavigation)
                    .WithMany(p => p.SpecProcessAssignPreBakeOptionNavigation)
                    .HasForeignKey(d => d.PreBakeOption)
                    .HasConstraintName("FK_SpecProcessAssign_PreBakeOption_Step_StepId");

                entity.HasOne(d => d.SeriesOptionNavigation)
                    .WithMany(p => p.SpecProcessAssign)
                    .HasForeignKey(d => d.SeriesOption)
                    .HasConstraintName("FK_SpecProcessAssign_SeriesOption_MaterialSeries_SeriesId");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.SpecProcessAssign)
                    .HasForeignKey(d => new { d.ProcessId, d.ProcessRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecProcessAssign_ProcessRevId_ProcessRevision_ProcessRevId");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.SpecProcessAssign)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecProcessAssign_SpecRevId_SpecificationRevision_SpecRevId");

                entity.HasOne(d => d.SpecChoice)
                    .WithMany(p => p.SpecProcessAssignSpecChoice)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelOption1, d.ChoiceOption1 })
                    .HasConstraintName("FK_SpecProcessAssign_ChoiceOption1_SpecChoice_ChoiceSeqId");

                entity.HasOne(d => d.SpecChoiceNavigation)
                    .WithMany(p => p.SpecProcessAssignSpecChoiceNavigation)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelOption2, d.ChoiceOption2 })
                    .HasConstraintName("FK_SpecProcessAssign_ChoiceOption2_SpecChoice_ChoiceSeqId");

                entity.HasOne(d => d.SpecChoice1)
                    .WithMany(p => p.SpecProcessAssignSpecChoice1)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelOption3, d.ChoiceOption3 })
                    .HasConstraintName("FK_SpecProcessAssign_ChoiceOption3_SpecChoice_ChoiceSeqId");

                entity.HasOne(d => d.SpecChoice2)
                    .WithMany(p => p.SpecProcessAssignSpecChoice2)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelOption4, d.ChoiceOption4 })
                    .HasConstraintName("FK_SpecProcessAssign_ChoiceOption4_SpecChoice_ChoiceSeqId");

                entity.HasOne(d => d.SpecChoice3)
                    .WithMany(p => p.SpecProcessAssignSpecChoice3)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelOption5, d.ChoiceOption5 })
                    .HasConstraintName("FK_SpecProcessAssign_ChoiceOption5_SpecChoice_ChoiceSeqId");

                entity.HasOne(d => d.SpecChoice4)
                    .WithMany(p => p.SpecProcessAssignSpecChoice4)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelOption6, d.ChoiceOption6 })
                    .HasConstraintName("FK_SpecProcessAssign_ChoiceOption6_SpecChoice_ChoiceSeqId");
            });

            modelBuilder.Entity<SpecSubLevel>(entity =>
            {
                entity.HasKey(e => new { e.SpecId, e.SpecRevId, e.SubLevelSeqId })
                    .HasName("PK_SpecSubLevel_SpecId_SpecRevId_SubLevelSeqId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.SpecSubLevel)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecSubLevel_SpecRevId_SpecificationRevision_SpecRevId");

                entity.HasOne(d => d.SpecChoiceNavigation)
                    .WithMany(p => p.SpecSubLevel)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelSeqId, d.DefaultChoice })
                    .HasConstraintName("FK_SpecSubLevel_DefaultChoice_SpecChoice_ChoiceSeqId");
            });

            modelBuilder.Entity<SpecialHandling>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_SpecialHandling_OrderId");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReviewDate).HasColumnType("date");

                entity.HasOne(d => d.HoldJobForEmpNavigation)
                    .WithMany(p => p.SpecialHandlingHoldJobForEmpNavigation)
                    .HasForeignKey(d => d.HoldJobForEmp)
                    .HasConstraintName("FK_SpecialHandling_HoldJobForEmp_Employee_EmpId");

                entity.HasOne(d => d.NotifyEmpNavigation)
                    .WithMany(p => p.SpecialHandlingNotifyEmpNavigation)
                    .HasForeignKey(d => d.NotifyEmp)
                    .HasConstraintName("FK_SpecialHandling_NotifyEmp_Employee_EmpId");

                entity.HasOne(d => d.ReviewReqByEmpNavigation)
                    .WithMany(p => p.SpecialHandlingReviewReqByEmpNavigation)
                    .HasForeignKey(d => d.ReviewReqByEmp)
                    .HasConstraintName("FK_SpecialHandling_ReviewReqByEmp_Employee_EmpId");

                entity.HasOne(d => d.SpecialPrintByEmpNavigation)
                    .WithMany(p => p.SpecialHandlingSpecialPrintByEmpNavigation)
                    .HasForeignKey(d => d.SpecialPrintByEmp)
                    .HasConstraintName("FK_SpecialHandling_SpecialPrintByEmp_Employee_EmpId");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.HasKey(e => e.SpecId)
                    .HasName("PK_Specification_SpecId");

                entity.Property(e => e.SpecId).ValueGeneratedNever();

                entity.Property(e => e.SpecCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SpecificationRevision>(entity =>
            {
                entity.HasKey(e => new { e.SpecId, e.SpecRevId })
                    .HasName("PK_SpecificationRevision_SpecId_SpecRevId");

                entity.Property(e => e.DateModified).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExternalRev)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TimeModified).HasColumnType("time(0)");

                entity.HasOne(d => d.CreatedByEmpNavigation)
                    .WithMany(p => p.SpecificationRevision)
                    .HasForeignKey(d => d.CreatedByEmp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecificationRevision_CreatedByEmp_Employee_EmpId");

                entity.HasOne(d => d.SamplePlanNavigation)
                    .WithMany(p => p.SpecificationRevision)
                    .HasForeignKey(d => d.SamplePlan)
                    .HasConstraintName("FK_SpecificationRevision_SamplePlan_SamplePlanHead_SamplePlanId");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.SpecificationRevision)
                    .HasForeignKey(d => d.SpecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecificationRevision_SpecId_Specification_SpecId");
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
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.Property(e => e.StepId).ValueGeneratedNever();

                entity.Property(e => e.Instructions)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StepCategoryCd)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.StepName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

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
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TaxAuthLevelCode>(entity =>
            {
                entity.HasKey(e => e.AuthorityLevelCd)
                    .HasName("PK_TaxAuthLevelCode_AuthorityLevelCd");

                entity.Property(e => e.AuthorityLevelCd)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TaxAuthority>(entity =>
            {
                entity.HasKey(e => e.TaxAuthId)
                    .HasName("PK_TaxAuthority_TaxAuthId");

                entity.Property(e => e.TaxAuthId).ValueGeneratedNever();

                entity.Property(e => e.AuthorityLevelCd)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalesTaxPerc).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.AuthorityLevelCdNavigation)
                    .WithMany(p => p.TaxAuthority)
                    .HasForeignKey(d => d.AuthorityLevelCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaxAuthority_AuthorityLevelCd_TaxAuthLevelCode_AuthorityLevelCd");
            });

            modelBuilder.Entity<TaxJurisAuthority>(entity =>
            {
                entity.HasKey(e => new { e.JurisdictionId, e.TaxAuthId })
                    .HasName("PK_TaxJurisAuthority_JurisdictionId_TaxAuthId");

                entity.HasOne(d => d.Jurisdiction)
                    .WithMany(p => p.TaxJurisAuthority)
                    .HasForeignKey(d => d.JurisdictionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaxJurisAuthority_JurisdictionId_TaxJurisdiction_JurisdictionId");

                entity.HasOne(d => d.TaxAuth)
                    .WithMany(p => p.TaxJurisAuthority)
                    .HasForeignKey(d => d.TaxAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaxJurisAuthority_TaxAuthId_TaxAuthority_TaxAuthId");
            });

            modelBuilder.Entity<TaxJurisdiction>(entity =>
            {
                entity.HasKey(e => e.JurisdictionId)
                    .HasName("PK_TaxJurisdiction_JurisdictionId");

                entity.Property(e => e.JurisdictionId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Terms>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TranType>(entity =>
            {
                entity.Property(e => e.TranTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TranCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
