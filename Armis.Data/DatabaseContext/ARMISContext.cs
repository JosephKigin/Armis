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
        public virtual DbSet<CustForm> CustForm { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DeptArea> DeptArea { get; set; }
        public virtual DbSet<DeptOperation> DeptOperation { get; set; }
        public virtual DbSet<DeptSpec> DeptSpec { get; set; }
        public virtual DbSet<DeptTypeCode> DeptTypeCode { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<HandlingCharge> HandlingCharge { get; set; }
        public virtual DbSet<Hardness> Hardness { get; set; }
        public virtual DbSet<LoadType> LoadType { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationTypeCode> LocationTypeCode { get; set; }
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
        public virtual DbSet<PartProcessAssign> PartProcessAssign { get; set; }
        public virtual DbSet<PartRev> PartRev { get; set; }
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
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<ShipAccount> ShipAccount { get; set; }
        public virtual DbSet<ShipCharge> ShipCharge { get; set; }
        public virtual DbSet<ShipTo> ShipTo { get; set; }
        public virtual DbSet<ShipVia> ShipVia { get; set; }
        public virtual DbSet<ShipViaTypeCode> ShipViaTypeCode { get; set; }
        public virtual DbSet<SpecChoice> SpecChoice { get; set; }
        public virtual DbSet<SpecProcessAssign> SpecProcessAssign { get; set; }
        public virtual DbSet<SpecSubLevel> SpecSubLevel { get; set; }
        public virtual DbSet<SpecialHandling> SpecialHandling { get; set; }
        public virtual DbSet<Specification> Specification { get; set; }
        public virtual DbSet<Stamp> Stamp { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Step> Step { get; set; }
        public virtual DbSet<StepCategory> StepCategory { get; set; }
        public virtual DbSet<TaxAuthLevelCode> TaxAuthLevelCode { get; set; }
        public virtual DbSet<TaxAuthority> TaxAuthority { get; set; }
        public virtual DbSet<TaxJurisAuthority> TaxJurisAuthority { get; set; }
        public virtual DbSet<TaxJurisdiction> TaxJurisdiction { get; set; }
        public virtual DbSet<Terms> Terms { get; set; }
        public virtual DbSet<TestType> TestType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; Initial Catalog = ARMIS; integrated security=True");
                optionsBuilder.UseSqlServer("Data Source = srv-armis-central.database.windows.net; Initial Catalog = ARMISTEST; User Id=armisadmin; Password=8#6C1xLopq@z;");
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
                entity.Property(e => e.AreaId)
                    .HasColumnName("AreaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DefaultLocation)
                    .HasMaxLength(8)
                    .IsUnicode(false);

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
                    .HasConstraintName("FK_Area_DefaultLocation_Location_LocationCd");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK_Area_Type_DeptTypeCode_DeptTypeCd");
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

                entity.HasOne(d => d.Remark)
                    .WithMany(p => p.AreaRemark)
                    .HasForeignKey(d => d.RemarkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AreaRemark_RemarkID_RemarkCode_RemarkID");
            });

            modelBuilder.Entity<BakeResult>(entity =>
            {
                entity.Property(e => e.BakeResultId)
                    .HasColumnName("BakeResultID")
                    .ValueGeneratedNever();

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
                    .HasMaxLength(10)
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
                    .HasName("PK_Certification_CertID");

                entity.Property(e => e.CertId).HasColumnName("CertID");

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

                entity.Property(e => e.SpecRevId).HasColumnName("SpecRevID");

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

            modelBuilder.Entity<ContComment>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK_ContComment_ContactID");

                entity.Property(e => e.ContactId)
                    .HasColumnName("ContactID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactId)
                    .HasColumnName("ContactID")
                    .ValueGeneratedNever();

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

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.Property(e => e.Zip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_Contact_CustID_Customer_CustID");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.TitleId)
                    .HasConstraintName("FK_Contact_TitleID_ContactTitle_ContactTitleID");

                entity.HasOne(d => d.ShipTo)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => new { d.CustId, d.ShipToId })
                    .HasConstraintName("FK_Contact_ShipToID_ShipTo_ShipToID");
            });

            modelBuilder.Entity<ContactTitle>(entity =>
            {
                entity.Property(e => e.ContactTitleId)
                    .HasColumnName("ContactTitleID")
                    .ValueGeneratedNever();

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
                    .HasName("PK_CustBillTo_CustID");

                entity.Property(e => e.CustId)
                    .HasColumnName("CustID")
                    .ValueGeneratedNever();

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
                    .HasConstraintName("FK_CustBillTo_CustID_Customer_CustID");
            });

            modelBuilder.Entity<CustComment>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK_CustComment_CustID");

                entity.Property(e => e.CustId)
                    .HasColumnName("CustID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.CustComment)
                    .HasForeignKey<CustComment>(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustComment_CustID_Customer_CustID");
            });

            modelBuilder.Entity<CustForm>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK_CustForm_CustID");

                entity.Property(e => e.CustId)
                    .HasColumnName("CustID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CertId).HasColumnName("CertID");

                entity.Property(e => e.ConsolidatedInvoiceId)
                    .HasColumnName("ConsolidatedInvoiceID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InspectionFormId)
                    .HasColumnName("InspectionFormID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceFormId)
                    .HasColumnName("InvoiceFormID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PackSlipFormId)
                    .HasColumnName("PackSlipFormID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnLabelFormId)
                    .HasColumnName("ReturnLabelFormID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatementFormId)
                    .HasColumnName("StatementFormID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WhenToPrint)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cert)
                    .WithMany(p => p.CustForm)
                    .HasForeignKey(d => d.CertId)
                    .HasConstraintName("FK_CustForm_CertID_Certification_CertID");

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.CustForm)
                    .HasForeignKey<CustForm>(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustForm_CustID_Customer_CustID");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK_Customer_CustID");

                entity.Property(e => e.CustId)
                    .HasColumnName("CustID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CertId).HasColumnName("CertID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.CreditLimit).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.CreditStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultShipToId).HasColumnName("DefaultShipToID");

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

                entity.Property(e => e.PriorityId).HasColumnName("PriorityID");

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

                entity.Property(e => e.TermsId).HasColumnName("TermsID");

                entity.HasOne(d => d.Cert)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CertId)
                    .HasConstraintName("FK_Customer_CertID_Certification_CertID");

                entity.HasOne(d => d.CreditStatusNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CreditStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_CreditStatus_CreditStatus_CredStatusCd");

                entity.HasOne(d => d.DefaultContactNumNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.DefaultContactNum)
                    .HasConstraintName("FK_Customer_DefaultContactNum_Contact_ContactID");

                entity.HasOne(d => d.DefaultShipViaNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.DefaultShipVia)
                    .HasConstraintName("FK_Customer_DefaultShipVia_ShipVia_ShipViaCd");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.PriorityId)
                    .HasConstraintName("FK_Customer_PriorityID_Priority_PriorityID");

                entity.HasOne(d => d.SalesPersonNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.SalesPerson)
                    .HasConstraintName("FK_Customer_SalesPerson_Employee_EmpID");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Status_Status_StatusCd");

                entity.HasOne(d => d.TaxJurisd)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.TaxJurisdId)
                    .HasConstraintName("FK_Customer_TaxJurisdId_TaxJurisdiction_JurisdictionID");

                entity.HasOne(d => d.Terms)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.TermsId)
                    .HasConstraintName("FK_Customer_TermsID_Terms_TermsID");

                entity.HasOne(d => d.ShipAccount)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => new { d.CustId, d.DefaultShipAccount })
                    .HasConstraintName("FK_Customer_DefaultShipAccount_ShipAccount_ShipAccountID");

                entity.HasOne(d => d.ShipTo)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => new { d.CustId, d.DefaultShipToId })
                    .HasConstraintName("FK_Customer_DefaultShipToID_ShipTo_ShipToID");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .ValueGeneratedNever();

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

                entity.Property(e => e.ScheduleAreaId).HasColumnName("ScheduleAreaID");

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

            modelBuilder.Entity<DeptOperation>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.OperationId })
                    .HasName("PK_DeptOperation_DepartmentID_OperationID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.OperationId).HasColumnName("OperationID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DeptOperation)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptOperation_DepartmentID_Department_DepartmentID");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.DeptOperation)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptOperation_OperationID_Operation_OperationID");
            });

            modelBuilder.Entity<DeptSpec>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.SpecId, e.SpecRevId })
                    .HasName("PK_DeptSpec_DepartmentID_SpecID_SpecRevID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.SpecId).HasColumnName("SpecID");

                entity.Property(e => e.SpecRevId).HasColumnName("SpecRevID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DeptSpec)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptSpec_DepartmentID_Department_DepartmentID");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.DeptSpec)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeptSpec_SpecID_Specification_SpecID");
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
                entity.Property(e => e.DriverId)
                    .HasColumnName("DriverID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AssignedDate).HasColumnType("date");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
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
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hardness>(entity =>
            {
                entity.Property(e => e.HardnessId)
                    .HasColumnName("HardnessID")
                    .ValueGeneratedNever();

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

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocationCd)
                    .HasName("PK_Location_LocationCd");

                entity.Property(e => e.LocationCd)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocTypeCd)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.AreaNavigation)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_Location_AreaID_Area_AreaID");

                entity.HasOne(d => d.LocTypeCdNavigation)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.LocTypeCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_LocTypeCd_LocationTypeCode_LocTypeCd");
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
                    .HasName("PK_MaterialAlloy_AlloyID");

                entity.Property(e => e.AlloyId)
                    .HasColumnName("AlloyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeriesId).HasColumnName("SeriesID");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.MaterialAlloy)
                    .HasForeignKey(d => d.SeriesId)
                    .HasConstraintName("FK_MaterialAlloy_SeriesID_MaterialSeries_SeriesID");
            });

            modelBuilder.Entity<MaterialSeries>(entity =>
            {
                entity.HasKey(e => e.SeriesId)
                    .HasName("PK_MaterialSeries_SeriesID");

                entity.Property(e => e.SeriesId)
                    .HasColumnName("SeriesID")
                    .ValueGeneratedNever();

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
                entity.Property(e => e.MemoId)
                    .HasColumnName("MemoID")
                    .ValueGeneratedNever();

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
                    .HasMaxLength(50)
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
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.Property(e => e.OperationId)
                    .HasColumnName("OperationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.OperGroupId).HasColumnName("OperGroupID");

                entity.Property(e => e.OperationCd)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.OperGroup)
                    .WithMany(p => p.Operation)
                    .HasForeignKey(d => d.OperGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operation_OperGroupID_OperationGroup_OperGroupID");
            });

            modelBuilder.Entity<OperationGroup>(entity =>
            {
                entity.HasKey(e => e.OperGroupId)
                    .HasName("PK_OperationGroup_OperGroupID");

                entity.Property(e => e.OperGroupId)
                    .HasColumnName("OperGroupID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
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
                    .HasConstraintName("FK_OprMaterialPrice_MaterialCd_MaterialAlloy_AlloyID");

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

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CertId).HasColumnName("CertID");

                entity.Property(e => e.CredAuthComments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.DoneDate).HasColumnType("date");

                entity.Property(e => e.DoneTime).HasColumnType("time(0)");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.ExpediteStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HandlingChargeCd)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.JobHoldComments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastCompleteRemSentDt).HasColumnType("date");

                entity.Property(e => e.LotCharge).HasColumnType("decimal(19, 4)");

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

                entity.Property(e => e.SpecProcessAssignId).HasColumnName("SpecProcessAssignID");

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
                    .HasMaxLength(40)
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

                entity.HasOne(d => d.Cert)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.CertId)
                    .HasConstraintName("FK_OrderHead_CertID_Certification_CertID");

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

                entity.HasOne(d => d.JobHoldByEmpNavigation)
                    .WithMany(p => p.OrderHeadJobHoldByEmpNavigation)
                    .HasForeignKey(d => d.JobHoldByEmp)
                    .HasConstraintName("FK_OrderHead_JobHoldByEmp_Employee_EmpID");

                entity.HasOne(d => d.JobHoldToEmpNavigation)
                    .WithMany(p => p.OrderHeadJobHoldToEmpNavigation)
                    .HasForeignKey(d => d.JobHoldToEmp)
                    .HasConstraintName("FK_OrderHead_JobHoldToEmp_Employee_EmpID");

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

                entity.HasOne(d => d.SpecProcessAssign)
                    .WithMany(p => p.OrderHead)
                    .HasForeignKey(d => d.SpecProcessAssignId)
                    .HasConstraintName("FK_OrderHead_SpecProcessAssignID_SpecProcessAssign_SpecProcessAssignID");
            });

            modelBuilder.Entity<OrderLocation>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.OrderLine, e.LocationCd })
                    .HasName("PK_OrderLocation_OrderID_OrderLine_LocationCd");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.LocationCd)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ContainerCd)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.ContainerCdNavigation)
                    .WithMany(p => p.OrderLocation)
                    .HasForeignKey(d => d.ContainerCd)
                    .HasConstraintName("FK_OrderLocation_ContainerCd_Container_ContainerCd");

                entity.HasOne(d => d.LocationCdNavigation)
                    .WithMany(p => p.OrderLocation)
                    .HasForeignKey(d => d.LocationCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderLocation_LocationCd_Location_LocationCd");

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

                entity.Property(e => e.Bake)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.CustPartNum)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dimensions)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IntendedPpl).HasColumnName("IntendedPPL");

                entity.Property(e => e.PieceWeight).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.ProcessComments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SamplePlanId).HasColumnName("SamplePlanID");

                entity.Property(e => e.SauoM)
                    .HasColumnName("SAUoM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SeriesId).HasColumnName("SeriesID");

                entity.Property(e => e.SurfaceArea)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Weight).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.AlloyNavigation)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.Alloy)
                    .HasConstraintName("FK_Part_Alloy_MaterialAlloy_AlloyID");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Part_CustID_Customer_CustID");

                entity.HasOne(d => d.SamplePlan)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.SamplePlanId)
                    .HasConstraintName("FK_Part_SamplePlanID_SamplePlanHead_SamplePlanID");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.SeriesId)
                    .HasConstraintName("FK_Part_SeriesID_MaterialSeries_SeriesID");

                entity.HasOne(d => d.StandardDeptNavigation)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.StandardDept)
                    .HasConstraintName("FK_Part_StandardDept_Department_DepartmentID");

                entity.HasOne(d => d.PartRev)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => new { d.PartId, d.CurrentRev })
                    .HasConstraintName("FK_Part_CurrentRev_PartRev_PartRevID");
            });

            modelBuilder.Entity<PartProcessAssign>(entity =>
            {
                entity.HasKey(e => new { e.PartId, e.SpecProcessAssignId })
                    .HasName("PK_PartProcessAssign_PartID_SpecProcessAssignID");

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.SpecProcessAssignId).HasColumnName("SpecProcessAssignID");

                entity.Property(e => e.LastUsedDate).HasColumnType("date");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.PartProcessAssign)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartProcessAssign_PartID_Part_PartID");

                entity.HasOne(d => d.SpecProcessAssign)
                    .WithMany(p => p.PartProcessAssign)
                    .HasForeignKey(d => d.SpecProcessAssignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartProcessAssign_SpecProcessAssignID_SpecProcessAssign_SpecProcessAssignID");
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

            modelBuilder.Entity<PartTran>(entity =>
            {
                entity.HasKey(e => e.TranSeqNum)
                    .HasName("PK_PartTran_TranSeqNum");

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
                    .WithMany(p => p.PartTran)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_PartTran_OrderID_OrderHead_OrderID");

                entity.HasOne(d => d.PriceCdNavigation)
                    .WithMany(p => p.PartTran)
                    .HasForeignKey(d => d.PriceCd)
                    .HasConstraintName("FK_PartTran_PriceCd_PriceCode_PriceCd");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.PartTran)
                    .HasForeignKey(d => d.ProcessId)
                    .HasConstraintName("FK_PartTran_ProcessID_Process_ProcessID");
            });

            modelBuilder.Entity<PlateResult>(entity =>
            {
                entity.Property(e => e.PlateResultId)
                    .HasColumnName("PlateResultID")
                    .ValueGeneratedNever();

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
                    .HasMaxLength(10)
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

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.Property(e => e.PriorityId).HasColumnName("PriorityID");

                entity.Property(e => e.Description)
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
                    .HasMaxLength(50)
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
                entity.HasKey(e => new { e.ProcessId, e.ProcessRevId })
                    .HasName("PK_ProcessRevision_ProcessID_ProcessRevID");

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.ProcessRevId).HasColumnName("ProcessRevID");

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
                    .HasConstraintName("FK_ProcessRevision_CreatedByEmp_Employee_EmpID");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProcessRevision)
                    .HasForeignKey(d => d.ProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessRevision_ProcessID_Process_ProcessID");

                entity.HasOne(d => d.RevStatusCdNavigation)
                    .WithMany(p => p.ProcessRevision)
                    .HasForeignKey(d => d.RevStatusCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessRevision_RevStatusCd_RevisionStatus_RevStatusCd");
            });

            modelBuilder.Entity<ProcessStepSeq>(entity =>
            {
                entity.HasKey(e => new { e.ProcessId, e.ProcessRevId, e.StepSeq })
                    .HasName("PK_ProcessStepSeq_ProcessID_ProcessRevID_StepSeq");

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.ProcessRevId).HasColumnName("ProcessRevID");

                entity.Property(e => e.OperationId).HasColumnName("OperationID");

                entity.Property(e => e.StepId).HasColumnName("StepID");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.ProcessStepSeq)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessStepSeq_OperationID_Operation_OperationID");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.ProcessStepSeq)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessStepSeq_StepID_Step_StepID");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProcessStepSeq)
                    .HasForeignKey(d => new { d.ProcessId, d.ProcessRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessStepSeq_ProcessRevID_ProcessRevision_ProcessRevID");
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
                    .HasConstraintName("FK_Rack_MaterialCd_MaterialAlloy_AlloyID");
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
                    .HasName("PK_ReworkCode_ReworkCID");

                entity.Property(e => e.ReworkCid)
                    .HasColumnName("ReworkCID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SamplePlanHead>(entity =>
            {
                entity.HasKey(e => e.SamplePlanId)
                    .HasName("PK_SamplePlanHead_SamplePlanID");

                entity.Property(e => e.SamplePlanId)
                    .HasColumnName("SamplePlanID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlanName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TestCd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.SamplePlanHead)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_SamplePlanHead_CustID_Customer_CustID");

                entity.HasOne(d => d.TestCdNavigation)
                    .WithMany(p => p.SamplePlanHead)
                    .HasForeignKey(d => d.TestCd)
                    .HasConstraintName("FK_SamplePlanHead_TestCd_TestType_TestCd");
            });

            modelBuilder.Entity<SamplePlanLevel>(entity =>
            {
                entity.HasKey(e => new { e.SamplePlanId, e.SamplePlanLevelId })
                    .HasName("PK_SamplePlanLevel_SamplePlanID_SamplePlanLevelID");

                entity.Property(e => e.SamplePlanId).HasColumnName("SamplePlanID");

                entity.Property(e => e.SamplePlanLevelId).HasColumnName("SamplePlanLevelID");

                entity.HasOne(d => d.SamplePlan)
                    .WithMany(p => p.SamplePlanLevel)
                    .HasForeignKey(d => d.SamplePlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SamplePlanLevel_SamplePlanID_SamplePlanHead_SamplePlanID");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.SessionId)
                    .HasColumnName("SessionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

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
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShipTo>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.ShipToId })
                    .HasName("PK_ShipTo_CustID_ShipToID");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.ShipToId).HasColumnName("ShipToID");

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
                    .HasConstraintName("FK_ShipTo_CustID_Customer_CustID");

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

            modelBuilder.Entity<SpecChoice>(entity =>
            {
                entity.HasKey(e => new { e.SpecId, e.SpecRevId, e.SubLevelSeqId, e.ChoiceSeqId })
                    .HasName("PK_SpecChoice_SpecID_SpecRevID_SubLevelSeqID_ChoiceSeqID");

                entity.Property(e => e.SpecId).HasColumnName("SpecID");

                entity.Property(e => e.SpecRevId).HasColumnName("SpecRevID");

                entity.Property(e => e.SubLevelSeqId).HasColumnName("SubLevelSeqID");

                entity.Property(e => e.ChoiceSeqId).HasColumnName("ChoiceSeqID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.S)
                    .WithMany(p => p.SpecChoice)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelSeqId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecChoice_SubLevelSeqID_SpecSubLevel_SubLevelSeqID");
            });

            modelBuilder.Entity<SpecProcessAssign>(entity =>
            {
                entity.Property(e => e.SpecProcessAssignId)
                    .HasColumnName("SpecProcessAssignID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.SpecId).HasColumnName("SpecID");

                entity.Property(e => e.SpecRevId).HasColumnName("SpecRevID");

                entity.HasOne(d => d.AlloyOptionNavigation)
                    .WithMany(p => p.SpecProcessAssign)
                    .HasForeignKey(d => d.AlloyOption)
                    .HasConstraintName("FK_SpecProcessAssign_AlloyOption_MaterialAlloy_AlloyID");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.SpecProcessAssign)
                    .HasForeignKey(d => d.Customer)
                    .HasConstraintName("FK_SpecProcessAssign_Customer_Customer_CustID");

                entity.HasOne(d => d.HardnessOptionNavigation)
                    .WithMany(p => p.SpecProcessAssign)
                    .HasForeignKey(d => d.HardnessOption)
                    .HasConstraintName("FK_SpecProcessAssign_HardnessOption_Hardness_HardnessID");

                entity.HasOne(d => d.MaskOptionNavigation)
                    .WithMany(p => p.SpecProcessAssignMaskOptionNavigation)
                    .HasForeignKey(d => d.MaskOption)
                    .HasConstraintName("FK_SpecProcessAssign_MaskOption_Step_StepID");

                entity.HasOne(d => d.PostBakeOptionNavigation)
                    .WithMany(p => p.SpecProcessAssignPostBakeOptionNavigation)
                    .HasForeignKey(d => d.PostBakeOption)
                    .HasConstraintName("FK_SpecProcessAssign_PostBakeOption_Step_StepID");

                entity.HasOne(d => d.PreBakeOptionNavigation)
                    .WithMany(p => p.SpecProcessAssignPreBakeOptionNavigation)
                    .HasForeignKey(d => d.PreBakeOption)
                    .HasConstraintName("FK_SpecProcessAssign_PreBakeOption_Step_StepID");

                entity.HasOne(d => d.SeriesOptionNavigation)
                    .WithMany(p => p.SpecProcessAssign)
                    .HasForeignKey(d => d.SeriesOption)
                    .HasConstraintName("FK_SpecProcessAssign_SeriesOption_MaterialSeries_SeriesID");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.SpecProcessAssign)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecProcessAssign_SpecID_Specification_SpecID");

                entity.HasOne(d => d.SpecChoice)
                    .WithMany(p => p.SpecProcessAssignSpecChoice)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelOption1, d.ChoiceOption1 })
                    .HasConstraintName("FK_SpecProcessAssign_ChoiceOption1_SpecChoice_ChoiceSeqID");

                entity.HasOne(d => d.SpecChoiceNavigation)
                    .WithMany(p => p.SpecProcessAssignSpecChoiceNavigation)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelOption2, d.ChoiceOption2 })
                    .HasConstraintName("FK_SpecProcessAssign_ChoiceOption2_SpecChoice_ChoiceSeqID");

                entity.HasOne(d => d.SpecChoice1)
                    .WithMany(p => p.SpecProcessAssignSpecChoice1)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelOption3, d.ChoiceOption3 })
                    .HasConstraintName("FK_SpecProcessAssign_ChoiceOption3_SpecChoice_ChoiceSeqID");

                entity.HasOne(d => d.SpecChoice2)
                    .WithMany(p => p.SpecProcessAssignSpecChoice2)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelOption4, d.ChoiceOption4 })
                    .HasConstraintName("FK_SpecProcessAssign_ChoiceOption4_SpecChoice_ChoiceSeqID");

                entity.HasOne(d => d.SpecChoice3)
                    .WithMany(p => p.SpecProcessAssignSpecChoice3)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelOption5, d.ChoiceOption5 })
                    .HasConstraintName("FK_SpecProcessAssign_ChoiceOption5_SpecChoice_ChoiceSeqID");

                entity.HasOne(d => d.SpecChoice4)
                    .WithMany(p => p.SpecProcessAssignSpecChoice4)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId, d.SubLevelOption6, d.ChoiceOption6 })
                    .HasConstraintName("FK_SpecProcessAssign_ChoiceOption6_SpecChoice_ChoiceSeqID");
            });

            modelBuilder.Entity<SpecSubLevel>(entity =>
            {
                entity.HasKey(e => new { e.SpecId, e.SpecRevId, e.SubLevelSeqId })
                    .HasName("PK_SpecSubLevel_SpecID_SpecRevID_SubLevelSeqID");

                entity.Property(e => e.SpecId).HasColumnName("SpecID");

                entity.Property(e => e.SpecRevId).HasColumnName("SpecRevID");

                entity.Property(e => e.SubLevelSeqId).HasColumnName("SubLevelSeqID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.SpecSubLevel)
                    .HasForeignKey(d => new { d.SpecId, d.SpecRevId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecSubLevel_SpecID_Specification_SpecID");
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
                entity.HasKey(e => new { e.SpecId, e.SpecRevId })
                    .HasName("PK_Specification_SpecID_SpecRevID");

                entity.Property(e => e.SpecId).HasColumnName("SpecID");

                entity.Property(e => e.SpecRevId).HasColumnName("SpecRevID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExternalRev)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SpecCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.NadCapSamplePlanNavigation)
                    .WithMany(p => p.SpecificationNadCapSamplePlanNavigation)
                    .HasForeignKey(d => d.NadCapSamplePlan)
                    .HasConstraintName("FK_Specification_NadCapSamplePlan_SamplePlanHead_SamplePlanID");

                entity.HasOne(d => d.SamplePlanNavigation)
                    .WithMany(p => p.SpecificationSamplePlanNavigation)
                    .HasForeignKey(d => d.SamplePlan)
                    .HasConstraintName("FK_Specification_SamplePlan_SamplePlanHead_SamplePlanID");
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
                entity.Property(e => e.StepId)
                    .HasColumnName("StepID")
                    .ValueGeneratedNever();

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
                    .HasName("PK_TaxAuthority_TaxAuthID");

                entity.Property(e => e.TaxAuthId)
                    .HasColumnName("TaxAuthID")
                    .ValueGeneratedNever();

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
                    .HasName("PK_TaxJurisAuthority_JurisdictionID_TaxAuthID");

                entity.Property(e => e.JurisdictionId).HasColumnName("JurisdictionID");

                entity.Property(e => e.TaxAuthId).HasColumnName("TaxAuthID");

                entity.HasOne(d => d.Jurisdiction)
                    .WithMany(p => p.TaxJurisAuthority)
                    .HasForeignKey(d => d.JurisdictionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaxJurisAuthority_JurisdictionID_TaxJurisdiction_JurisdictionID");

                entity.HasOne(d => d.TaxAuth)
                    .WithMany(p => p.TaxJurisAuthority)
                    .HasForeignKey(d => d.TaxAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaxJurisAuthority_TaxAuthID_TaxAuthority_TaxAuthID");
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
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Terms>(entity =>
            {
                entity.Property(e => e.TermsId).HasColumnName("TermsID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestType>(entity =>
            {
                entity.HasKey(e => e.TestCd)
                    .HasName("PK_TestType_TestCD");

                entity.Property(e => e.TestCd)
                    .HasColumnName("TestCD")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
