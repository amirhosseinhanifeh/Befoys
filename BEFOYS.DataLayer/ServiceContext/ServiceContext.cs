
using BEFOYS.DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ServiceContext
{
    public partial class ServiceContext:DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options)
        {
           
        }
        public virtual DbSet<TblAddress> TblAddress { get; set; }
        public virtual DbSet<TblAreaCode> TblAreaCode { get; set; }
        public virtual DbSet<TblBrands> TblBrands { get; set; }
        public virtual DbSet<TblCity> TblCity { get; set; }
        public virtual DbSet<TblCode> TblCode { get; set; }
        public virtual DbSet<TblCodeGroup> TblCodeGroup { get; set; }
        public virtual DbSet<TblColors> TblColors { get; set; }
        public virtual DbSet<TblColorsGroup> TblColorsGroup { get; set; }
        public virtual DbSet<TblDocument> TblDocument { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblEmployeeRegistrationCode> TblEmployeeRegistrationCode { get; set; }
        public virtual DbSet<TblGroup> TblGroup { get; set; }
        public virtual DbSet<TblGroupPermission> TblGroupPermission { get; set; }
        public virtual DbSet<TblGuarantee> TblGuarantee { get; set; }
        public virtual DbSet<TblLogin> TblLogin { get; set; }
        public virtual DbSet<TblMessage> TblMessage { get; set; }
        public virtual DbSet<TblOrganization> TblOrganization { get; set; }
        public virtual DbSet<TblOrganizationDocument> TblOrganizationDocument { get; set; }
        public virtual DbSet<TblOrganizationFeatures> TblOrganizationFeatures { get; set; }
        public virtual DbSet<TblOrganizationInformation> TblOrganizationInformation { get; set; }
        public virtual DbSet<TblOrganizationNavigator> TblOrganizationNavigator { get; set; }
        public virtual DbSet<TblOrganizationPanelType> TblOrganizationPanelType { get; set; }
        public virtual DbSet<TblOrganizationRole> TblOrganizationRole { get; set; }
        public virtual DbSet<TblOrganizationRolePermission> TblOrganizationRolePermission { get; set; }
        public virtual DbSet<TblOrganizationType> TblOrganizationType { get; set; }
        public virtual DbSet<TblPanelType> TblPanelType { get; set; }
        public virtual DbSet<TblPanelTypeControl> TblPanelTypeControl { get; set; }
        public virtual DbSet<TblPanelTypePermission> TblPanelTypePermission { get; set; }
        public virtual DbSet<TblPart> TblPart { get; set; }
        public virtual DbSet<TblPermission> TblPermission { get; set; }
        public virtual DbSet<TblPhone> TblPhone { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblProductCategory> TblProductCategory { get; set; }
        public virtual DbSet<TblProductCategoryDocument> TblProductCategoryDocument { get; set; }
        public virtual DbSet<TblProductCategoryTags> TblProductCategoryTags { get; set; }
        public virtual DbSet<TblProductColors> TblProductColors { get; set; }
        public virtual DbSet<TblProductCustomOrganizationForm> TblProductCustomOrganizationForm { get; set; }
        public virtual DbSet<TblProductCustomRequest> TblProductCustomRequest { get; set; }
        public virtual DbSet<TblProductCustomRequestAttachment> TblProductCustomRequestAttachment { get; set; }
        public virtual DbSet<TblProductCustomRequestFormValue> TblProductCustomRequestFormValue { get; set; }
        public virtual DbSet<TblProductCustomRequestMessage> TblProductCustomRequestMessage { get; set; }
        public virtual DbSet<TblProductDetails> TblProductDetails { get; set; }
        public virtual DbSet<TblProductDocument> TblProductDocument { get; set; }
        public virtual DbSet<TblProductOrganization> TblProductOrganization { get; set; }
        public virtual DbSet<TblProductTags> TblProductTags { get; set; }
        public virtual DbSet<TblProvince> TblProvince { get; set; }
        public virtual DbSet<TblServer> TblServer { get; set; }
        public virtual DbSet<TblSetting> TblSetting { get; set; }
        public virtual DbSet<TblSiteArea> TblSiteArea { get; set; }
        public virtual DbSet<TblSmsproviderConfiguration> TblSmsproviderConfiguration { get; set; }
        public virtual DbSet<TblSmsproviderNumber> TblSmsproviderNumber { get; set; }
        public virtual DbSet<TblSmsresponse> TblSmsresponse { get; set; }
        public virtual DbSet<TblSmssetting> TblSmssetting { get; set; }
        public virtual DbSet<TblSmstemplate> TblSmstemplate { get; set; }
        public virtual DbSet<TblTags> TblTags { get; set; }
        public virtual DbSet<TblTicket> TblTicket { get; set; }
        public virtual DbSet<TblTicketAnswer> TblTicketAnswer { get; set; }
        public virtual DbSet<TblToken> TblToken { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=89.42.208.109;Database=Befoys_Organization;user id=sa;password=A@rd123456;").UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAddress>(entity =>
            {
                entity.Property(e => e.AddressGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.AddressCity)
                    .WithMany(p => p.TblAddress)
                    .HasForeignKey(d => d.AddressCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Address_Tbl_City");

                entity.HasOne(d => d.AddressTypeCode)
                    .WithMany(p => p.TblAddress)
                    .HasForeignKey(d => d.AddressTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Address_Tbl_Code");
            });

            modelBuilder.Entity<TblAreaCode>(entity =>
            {
                entity.Property(e => e.AcGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.AcCity)
                    .WithMany(p => p.TblAreaCode)
                    .HasForeignKey(d => d.AcCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_AreaCode_Tbl_City");
            });

            modelBuilder.Entity<TblBrands>(entity =>
            {
                entity.Property(e => e.BrandsGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.BrandsLogoDocument)
                    .WithMany(p => p.TblBrands)
                    .HasForeignKey(d => d.BrandsLogoDocumentId)
                    .HasConstraintName("FK_Tbl_Brands_Tbl_Document");
            });

            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.Property(e => e.CityGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.CityProvince)
                    .WithMany(p => p.TblCity)
                    .HasForeignKey(d => d.CityProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_City_Tbl_Province");
            });

            modelBuilder.Entity<TblCode>(entity =>
            {
                entity.HasKey(e => e.CodeId)
                    .HasName("PK_Tbl_Code_1");

                entity.Property(e => e.CodeGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.CodeCg)
                    .WithMany(p => p.TblCode)
                    .HasForeignKey(d => d.CodeCgid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Code_Tbl_CodeGroup");
            });

            modelBuilder.Entity<TblCodeGroup>(entity =>
            {
                entity.HasKey(e => e.CgId)
                    .HasName("PK_Tbl_CodeGroup_1");

                entity.Property(e => e.CgGuid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblColors>(entity =>
            {
                entity.Property(e => e.ColorsGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.ColorsCg)
                    .WithMany(p => p.TblColors)
                    .HasForeignKey(d => d.ColorsCgid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Colors_Tbl_ColorsGroup");

                entity.HasOne(d => d.ColorsTypeCode)
                    .WithMany(p => p.TblColors)
                    .HasForeignKey(d => d.ColorsTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Colors_Tbl_Code");
            });

            modelBuilder.Entity<TblColorsGroup>(entity =>
            {
                entity.Property(e => e.CgGuid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblDocument>(entity =>
            {
                entity.Property(e => e.DocumentGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.DocumentServer)
                    .WithMany(p => p.TblDocument)
                    .HasForeignKey(d => d.DocumentServerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Document_Tbl_Server");

                entity.HasOne(d => d.DocumentTypeCode)
                    .WithMany(p => p.TblDocument)
                    .HasForeignKey(d => d.DocumentTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Document_Tbl_Code");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.Property(e => e.EmployeeGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.EmployeeLogin)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.EmployeeLoginId)
                    .HasConstraintName("FK_Tbl_Employee_Tbl_Login");

                entity.HasOne(d => d.EmployeeOrganization)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.EmployeeOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Employee_Tbl_Organization");

                entity.HasOne(d => d.EmployeeOr)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.EmployeeOrid)
                    .HasConstraintName("FK_Tbl_Employee_Tbl_OrganizationRole");

                entity.HasOne(d => d.EmployeeTypeCode)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.EmployeeTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Employee_Tbl_Code");
            });

            modelBuilder.Entity<TblEmployeeRegistrationCode>(entity =>
            {
                entity.Property(e => e.ErcGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.ErcEmployee)
                    .WithMany(p => p.TblEmployeeRegistrationCode)
                    .HasForeignKey(d => d.ErcEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeRegistrationCode_Tbl_Employee");
            });

            modelBuilder.Entity<TblGroup>(entity =>
            {
                entity.Property(e => e.GroupGuid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblGroupPermission>(entity =>
            {
                entity.Property(e => e.GpGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.GpGroup)
                    .WithMany(p => p.TblGroupPermission)
                    .HasForeignKey(d => d.GpGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_GroupPermission_Tbl_Group");

                entity.HasOne(d => d.GpPermission)
                    .WithMany(p => p.TblGroupPermission)
                    .HasForeignKey(d => d.GpPermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_GroupPermission_Tbl_Permission");
            });

            modelBuilder.Entity<TblGuarantee>(entity =>
            {
                entity.Property(e => e.GuaranteeGuid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PK_Tbl_Login_1");

                entity.Property(e => e.LoginCreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LoginGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LoginModifyDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.LoginPictureDocument)
                    .WithMany(p => p.TblLogin)
                    .HasForeignKey(d => d.LoginPictureDocumentId)
                    .HasConstraintName("FK_Tbl_Login_Tbl_Document");
            });

            modelBuilder.Entity<TblMessage>(entity =>
            {
                entity.HasOne(d => d.MessagePriorityCode)
                    .WithMany(p => p.TblMessageMessagePriorityCode)
                    .HasForeignKey(d => d.MessagePriorityCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Message_Tbl_Code");

                entity.HasOne(d => d.MessageReceiverLogin)
                    .WithMany(p => p.TblMessageMessageReceiverLogin)
                    .HasForeignKey(d => d.MessageReceiverLoginId)
                    .HasConstraintName("FK_Tbl_Message_Tbl_Login");

                entity.HasOne(d => d.MessageReceiverOrganization)
                    .WithMany(p => p.TblMessage)
                    .HasForeignKey(d => d.MessageReceiverOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Message_Tbl_Organization");

                entity.HasOne(d => d.MessageSenderLogin)
                    .WithMany(p => p.TblMessageMessageSenderLogin)
                    .HasForeignKey(d => d.MessageSenderLoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Message_Tbl_Login1");

                entity.HasOne(d => d.MessageTypeCode)
                    .WithMany(p => p.TblMessageMessageTypeCode)
                    .HasForeignKey(d => d.MessageTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Message_Tbl_Code1");
            });

            modelBuilder.Entity<TblOrganization>(entity =>
            {
                entity.HasKey(e => e.OrganizationId)
                    .HasName("PK_Tbl_Organization_1");

                entity.Property(e => e.OrganizationCreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrganizationGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.OrganizationIsMotherOrganization).HasDefaultValueSql("((1))");

                entity.Property(e => e.OrganizationModifyDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OrganizationDefaultPt)
                    .WithMany(p => p.TblOrganization)
                    .HasForeignKey(d => d.OrganizationDefaultPtid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Organization_Tbl_PanelType");

                entity.HasOne(d => d.OrganizationMotherOrganization)
                    .WithMany(p => p.InverseOrganizationMotherOrganization)
                    .HasForeignKey(d => d.OrganizationMotherOrganizationId)
                    .HasConstraintName("FK_Tbl_Organization_Tbl_Organization");

                entity.HasOne(d => d.OrganizationNameInformation)
                    .WithMany(p => p.TblOrganization)
                    .HasForeignKey(d => d.OrganizationNameInformationId)
                    .HasConstraintName("FK_Tbl_Organization_Tbl_OrganizationInformation");

                entity.HasOne(d => d.OrganizationOt)
                    .WithMany(p => p.TblOrganization)
                    .HasForeignKey(d => d.OrganizationOtid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Organization_Tbl_OrganizationType");
            });

            modelBuilder.Entity<TblOrganizationDocument>(entity =>
            {
                entity.Property(e => e.OdGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.OdDocument)
                    .WithMany(p => p.TblOrganizationDocument)
                    .HasForeignKey(d => d.OdDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationDocument_Tbl_Document");

                entity.HasOne(d => d.OdOrganization)
                    .WithMany(p => p.TblOrganizationDocument)
                    .HasForeignKey(d => d.OdOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationDocument_Tbl_Organization");
            });

            modelBuilder.Entity<TblOrganizationFeatures>(entity =>
            {
                entity.HasKey(e => e.OdfId)
                    .HasName("PK_Tbl_OrganizationDocumentFeatures");

                entity.Property(e => e.OdfGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.OdfKindCode)
                    .WithMany(p => p.TblOrganizationFeaturesOdfKindCode)
                    .HasForeignKey(d => d.OdfKindCodeId)
                    .HasConstraintName("FK_Tbl_OrganizationDocumentFeatures_Tbl_Code1");

                entity.HasOne(d => d.OdfTypeCode)
                    .WithMany(p => p.TblOrganizationFeaturesOdfTypeCode)
                    .HasForeignKey(d => d.OdfTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationDocumentFeatures_Tbl_Code");
            });

            modelBuilder.Entity<TblOrganizationInformation>(entity =>
            {
                entity.Property(e => e.OiGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.OiOrganization)
                    .WithMany(p => p.TblOrganizationInformation)
                    .HasForeignKey(d => d.OiOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationInformation_Tbl_Organization");

                entity.HasOne(d => d.OiTypeCode)
                    .WithMany(p => p.TblOrganizationInformation)
                    .HasForeignKey(d => d.OiTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationInformation_Tbl_Code");
            });

            modelBuilder.Entity<TblOrganizationNavigator>(entity =>
            {
                entity.HasKey(e => e.OdnId)
                    .HasName("PK_Tbl_OrganizationDocumentNavigator");

                entity.Property(e => e.OdnGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.OdnOdf)
                    .WithMany(p => p.TblOrganizationNavigator)
                    .HasForeignKey(d => d.OdnOdfid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationDocumentNavigator_Tbl_OrganizationDocumentFeatures");

                entity.HasOne(d => d.OdnOt)
                    .WithMany(p => p.TblOrganizationNavigator)
                    .HasForeignKey(d => d.OdnOtid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationDocumentNavigator_Tbl_OrganizationType");
            });

            modelBuilder.Entity<TblOrganizationPanelType>(entity =>
            {
                entity.Property(e => e.OptGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.OptOt)
                    .WithMany(p => p.TblOrganizationPanelType)
                    .HasForeignKey(d => d.OptOtid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationPanelType_Tbl_OrganizationType");

                entity.HasOne(d => d.OptPtp)
                    .WithMany(p => p.TblOrganizationPanelType)
                    .HasForeignKey(d => d.OptPtpid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationPanelType_Tbl_PanelTypePermission");
            });

            modelBuilder.Entity<TblOrganizationRole>(entity =>
            {
                entity.Property(e => e.OrGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.OrOrganization)
                    .WithMany(p => p.TblOrganizationRole)
                    .HasForeignKey(d => d.OrOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationRole_Tbl_Organization");

                entity.HasOne(d => d.OrOr)
                    .WithMany(p => p.InverseOrOr)
                    .HasForeignKey(d => d.OrOrid)
                    .HasConstraintName("FK_Tbl_OrganizationRole_Tbl_OrganizationRole");
            });

            modelBuilder.Entity<TblOrganizationRolePermission>(entity =>
            {
                entity.Property(e => e.OrpGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.OrpOr)
                    .WithMany(p => p.TblOrganizationRolePermission)
                    .HasForeignKey(d => d.OrpOrid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationRolePermission_Tbl_OrganizationRole");

                entity.HasOne(d => d.OrpPermission)
                    .WithMany(p => p.TblOrganizationRolePermission)
                    .HasForeignKey(d => d.OrpPermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationRolePermission_Tbl_Permission");
            });

            modelBuilder.Entity<TblOrganizationType>(entity =>
            {
                entity.Property(e => e.OtGuid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblPanelType>(entity =>
            {
                entity.Property(e => e.PtGuid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblPanelTypeControl>(entity =>
            {
                entity.Property(e => e.PtcGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.PtcOrganization)
                    .WithMany(p => p.TblPanelTypeControl)
                    .HasForeignKey(d => d.PtcOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PanelTypeControl_Tbl_Organization");

                entity.HasOne(d => d.PtcPt)
                    .WithMany(p => p.TblPanelTypeControl)
                    .HasForeignKey(d => d.PtcPtid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PanelTypeControl_Tbl_PanelType");
            });

            modelBuilder.Entity<TblPanelTypePermission>(entity =>
            {
                entity.Property(e => e.PtpGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.PtpPermission)
                    .WithMany(p => p.TblPanelTypePermission)
                    .HasForeignKey(d => d.PtpPermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PanelTypePermission_Tbl_Permission");

                entity.HasOne(d => d.PtpPt)
                    .WithMany(p => p.TblPanelTypePermission)
                    .HasForeignKey(d => d.PtpPtid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PanelTypePermission_Tbl_PanelType");
            });

            modelBuilder.Entity<TblPart>(entity =>
            {
                entity.Property(e => e.PartGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.PartCity)
                    .WithMany(p => p.TblPart)
                    .HasForeignKey(d => d.PartCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Part_Tbl_City");
            });

            modelBuilder.Entity<TblPermission>(entity =>
            {
                entity.Property(e => e.PermissionGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.PermissionIsFree).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TblPhone>(entity =>
            {
                entity.Property(e => e.PhoneGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.PhoneAddress)
                    .WithMany(p => p.TblPhone)
                    .HasForeignKey(d => d.PhoneAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Phone_Tbl_Address");

                entity.HasOne(d => d.PhoneAreaCode)
                    .WithMany(p => p.TblPhone)
                    .HasForeignKey(d => d.PhoneAreaCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Phone_Tbl_AreaCode");

                entity.HasOne(d => d.PhoneTypeCode)
                    .WithMany(p => p.TblPhone)
                    .HasForeignKey(d => d.PhoneTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Phone_Tbl_Code");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.Property(e => e.ProductGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.ProductBrands)
                    .WithMany(p => p.TblProduct)
                    .HasForeignKey(d => d.ProductBrandsId)
                    .HasConstraintName("FK_Tbl_Product_Tbl_Brands");

                entity.HasOne(d => d.ProductPc)
                    .WithMany(p => p.TblProduct)
                    .HasForeignKey(d => d.ProductPcid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Product_Tbl_ProductCategory");
            });

            modelBuilder.Entity<TblProductCategory>(entity =>
            {
                entity.Property(e => e.PcGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.PcPcd)
                    .WithMany(p => p.InversePcPcd)
                    .HasForeignKey(d => d.PcPcdid)
                    .HasConstraintName("FK_Tbl_ProductCategory_Tbl_ProductCategory");
            });

            modelBuilder.Entity<TblProductCategoryDocument>(entity =>
            {
                entity.HasKey(e => e.PcdId)
                    .HasName("PK_Tbl_CategoryDocument");

                entity.HasOne(d => d.PcdDocument)
                    .WithMany(p => p.TblProductCategoryDocument)
                    .HasForeignKey(d => d.PcdDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CategoryDocument_Tbl_Document");

                entity.HasOne(d => d.PcdPc)
                    .WithMany(p => p.TblProductCategoryDocument)
                    .HasForeignKey(d => d.PcdPcid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductCategoryDocument_Tbl_ProductCategory");

                entity.HasOne(d => d.PcdTypeCode)
                    .WithMany(p => p.TblProductCategoryDocument)
                    .HasForeignKey(d => d.PcdTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CategoryDocument_Tbl_Code");
            });

            modelBuilder.Entity<TblProductCategoryTags>(entity =>
            {
                entity.Property(e => e.PctId).ValueGeneratedNever();

                entity.HasOne(d => d.PctPc)
                    .WithMany(p => p.TblProductCategoryTags)
                    .HasForeignKey(d => d.PctPcid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductCategoryTags_Tbl_ProductCategory");

                entity.HasOne(d => d.PctTags)
                    .WithMany(p => p.TblProductCategoryTags)
                    .HasForeignKey(d => d.PctTagsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductCategoryTags_Tbl_Tags");
            });

            modelBuilder.Entity<TblProductColors>(entity =>
            {
                entity.Property(e => e.PcId).ValueGeneratedNever();

                entity.HasOne(d => d.PcColors)
                    .WithMany(p => p.TblProductColors)
                    .HasForeignKey(d => d.PcColorsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductColors_Tbl_Colors");

                entity.HasOne(d => d.PcPd)
                    .WithMany(p => p.TblProductColors)
                    .HasForeignKey(d => d.PcPdid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductColors_Tbl_ProductDocument");

                entity.HasOne(d => d.PcProduct)
                    .WithMany(p => p.TblProductColors)
                    .HasForeignKey(d => d.PcProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductColors_Tbl_Product");
            });

            modelBuilder.Entity<TblProductCustomOrganizationForm>(entity =>
            {
                entity.HasKey(e => e.PcofId)
                    .HasName("PK_Tbl_ProductOrganizationDetails");

                entity.Property(e => e.PcofGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.PcofPo)
                    .WithMany(p => p.TblProductCustomOrganizationForm)
                    .HasForeignKey(d => d.PcofPoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductCustomOrganizationForm_Tbl_ProductOrganization");
            });

            modelBuilder.Entity<TblProductCustomRequest>(entity =>
            {
                entity.Property(e => e.PcrGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.PcrOrganiziton)
                    .WithMany(p => p.TblProductCustomRequest)
                    .HasForeignKey(d => d.PcrOrganizitonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductCustomRequest_Tbl_Organization");

                entity.HasOne(d => d.PcrPo)
                    .WithMany(p => p.TblProductCustomRequest)
                    .HasForeignKey(d => d.PcrPoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductCustomRequest_Tbl_ProductOrganization");
            });

            modelBuilder.Entity<TblProductCustomRequestAttachment>(entity =>
            {
                entity.HasOne(d => d.PcraPcr)
                    .WithMany(p => p.TblProductCustomRequestAttachment)
                    .HasForeignKey(d => d.PcraPcrid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductCustomRequestAttachment_Tbl_ProductCustomRequest");
            });

            modelBuilder.Entity<TblProductCustomRequestFormValue>(entity =>
            {
                entity.Property(e => e.PcrfvGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.PcrfvPcof)
                    .WithMany(p => p.TblProductCustomRequestFormValue)
                    .HasForeignKey(d => d.PcrfvPcofid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductCustomRequestFormValue_Tbl_ProductCustomOrganizationForm");

                entity.HasOne(d => d.PcrfvPcr)
                    .WithMany(p => p.TblProductCustomRequestFormValue)
                    .HasForeignKey(d => d.PcrfvPcrid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductCustomRequestFormValue_Tbl_ProductCustomRequest");
            });

            modelBuilder.Entity<TblProductCustomRequestMessage>(entity =>
            {
                entity.Property(e => e.PcrmGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.PcrmDocument)
                    .WithMany(p => p.TblProductCustomRequestMessage)
                    .HasForeignKey(d => d.PcrmDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductCustomRequestMessage_Tbl_Document");

                entity.HasOne(d => d.PcrmPcr)
                    .WithMany(p => p.TblProductCustomRequestMessage)
                    .HasForeignKey(d => d.PcrmPcrid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductCustomRequestMessage_Tbl_ProductCustomRequest");
            });

            modelBuilder.Entity<TblProductDetails>(entity =>
            {
                entity.Property(e => e.PdGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.PdProductNavigation)
                    .WithMany(p => p.TblProductDetails)
                    .HasForeignKey(d => d.PdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductDetails_Tbl_Product");
            });

            modelBuilder.Entity<TblProductDocument>(entity =>
            {
                entity.Property(e => e.PdId).ValueGeneratedNever();

                entity.HasOne(d => d.PdDocument)
                    .WithMany(p => p.TblProductDocument)
                    .HasForeignKey(d => d.PdDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductDocument_Tbl_Document");

                entity.HasOne(d => d.PdKindCode)
                    .WithMany(p => p.TblProductDocumentPdKindCode)
                    .HasForeignKey(d => d.PdKindCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductDocument_Tbl_Code1");

                entity.HasOne(d => d.PdProduct)
                    .WithMany(p => p.TblProductDocument)
                    .HasForeignKey(d => d.PdProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductDocument_Tbl_Product");

                entity.HasOne(d => d.PdTypeCode)
                    .WithMany(p => p.TblProductDocumentPdTypeCode)
                    .HasForeignKey(d => d.PdTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductDocument_Tbl_Code");
            });

            modelBuilder.Entity<TblProductOrganization>(entity =>
            {
                entity.Property(e => e.PoGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.PoGuarantee)
                    .WithMany(p => p.TblProductOrganization)
                    .HasForeignKey(d => d.PoGuaranteeId)
                    .HasConstraintName("FK_Tbl_ProductOrganization_Tbl_Guarantee");

                entity.HasOne(d => d.PoOrganization)
                    .WithMany(p => p.TblProductOrganization)
                    .HasForeignKey(d => d.PoOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductOrganization_Tbl_Organization");

                entity.HasOne(d => d.PoProduct)
                    .WithMany(p => p.TblProductOrganization)
                    .HasForeignKey(d => d.PoProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductOrganization_Tbl_Product");

                entity.HasOne(d => d.PoSa)
                    .WithMany(p => p.TblProductOrganization)
                    .HasForeignKey(d => d.PoSaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductOrganization_Tbl_SiteArea");
            });

            modelBuilder.Entity<TblProductTags>(entity =>
            {
                entity.Property(e => e.PtId).ValueGeneratedNever();

                entity.HasOne(d => d.PtProduct)
                    .WithMany(p => p.TblProductTags)
                    .HasForeignKey(d => d.PtProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductTags_Tbl_Product");

                entity.HasOne(d => d.PtTags)
                    .WithMany(p => p.TblProductTags)
                    .HasForeignKey(d => d.PtTagsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductTags_Tbl_Tags");
            });

            modelBuilder.Entity<TblProvince>(entity =>
            {
                entity.Property(e => e.ProvinceGuid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblServer>(entity =>
            {
                entity.Property(e => e.ServerGuid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblSetting>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<TblSiteArea>(entity =>
            {
                entity.Property(e => e.SaGuid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblSmsproviderConfiguration>(entity =>
            {
                entity.Property(e => e.SpcCreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SpcGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SpcModifiedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblSmsproviderNumber>(entity =>
            {
                entity.Property(e => e.SpnCreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SpnGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SpnModifiedDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.SpnSpc)
                    .WithMany(p => p.TblSmsproviderNumber)
                    .HasForeignKey(d => d.SpnSpcid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_SMSProviderNumber_Tbl_SMSProviderConfiguration");
            });

            modelBuilder.Entity<TblSmsresponse>(entity =>
            {
                entity.Property(e => e.SmsCreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SmsGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SmsModifiedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblSmssetting>(entity =>
            {
                entity.Property(e => e.SsCreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SsGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SsModifiedDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.SsSpc)
                    .WithMany(p => p.TblSmssetting)
                    .HasForeignKey(d => d.SsSpcid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_SMSSetting_Tbl_SMSProviderConfiguration");

                entity.HasOne(d => d.SsSt)
                    .WithMany(p => p.TblSmssetting)
                    .HasForeignKey(d => d.SsStid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_SMSSetting_Tbl_SMSTemplate");
            });

            modelBuilder.Entity<TblSmstemplate>(entity =>
            {
                entity.Property(e => e.StCreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.StModifiedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblTags>(entity =>
            {
                entity.Property(e => e.TagsGuid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblTicket>(entity =>
            {
                entity.HasOne(d => d.TicketPriorityCode)
                    .WithMany(p => p.TblTicket)
                    .HasForeignKey(d => d.TicketPriorityCodeId)
                    .HasConstraintName("FK_Tbl_Ticket_Tbl_Code");

                entity.HasOne(d => d.TicketReciverLogin)
                    .WithMany(p => p.TblTicketTicketReciverLogin)
                    .HasForeignKey(d => d.TicketReciverLoginId)
                    .HasConstraintName("FK_Tbl_Ticket_Tbl_Login1");

                entity.HasOne(d => d.TicketSenderLogin)
                    .WithMany(p => p.TblTicketTicketSenderLogin)
                    .HasForeignKey(d => d.TicketSenderLoginId)
                    .HasConstraintName("FK_Tbl_Ticket_Tbl_Login");
            });

            modelBuilder.Entity<TblTicketAnswer>(entity =>
            {
                entity.Property(e => e.TaGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.TaTicket)
                    .WithMany(p => p.TblTicketAnswer)
                    .HasForeignKey(d => d.TaTicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_TicketAnswer_Tbl_Ticket");
            });

            modelBuilder.Entity<TblToken>(entity =>
            {
                entity.Property(e => e.TokenGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.TokenLogin)
                    .WithMany(p => p.TblToken)
                    .HasForeignKey(d => d.TokenLoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Token_Tbl_Login");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
