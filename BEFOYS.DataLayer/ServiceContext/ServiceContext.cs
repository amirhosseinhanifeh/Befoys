
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
            ChangeTracker.LazyLoadingEnabled = false;
           
        }
        public virtual DbSet<TblAddress> TblAddress { get; set; }
        public virtual DbSet<TblAreaCode> TblAreaCode { get; set; }
        public virtual DbSet<TblCity> TblCity { get; set; }
        public virtual DbSet<TblCode> TblCode { get; set; }
        public virtual DbSet<TblCodeGroup> TblCodeGroup { get; set; }
        public virtual DbSet<TblDocument> TblDocument { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblEmployeeRegistrationCode> TblEmployeeRegistrationCode { get; set; }
        public virtual DbSet<TblGroup> TblGroup { get; set; }
        public virtual DbSet<TblGroupPermission> TblGroupPermission { get; set; }
        public virtual DbSet<TblLogin> TblLogin { get; set; }
        public virtual DbSet<TblOrganization> TblOrganization { get; set; }
        public virtual DbSet<TblOrganizationDocument> TblOrganizationDocument { get; set; }
        public virtual DbSet<TblOrganizationDocumentFeatures> TblOrganizationDocumentFeatures { get; set; }
        public virtual DbSet<TblOrganizationDocumentNavigator> TblOrganizationDocumentNavigator { get; set; }
        public virtual DbSet<TblOrganizationInformation> TblOrganizationInformation { get; set; }
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
        public virtual DbSet<TblProductDetails> TblProductDetails { get; set; }
        public virtual DbSet<TblProductOrganization> TblProductOrganization { get; set; }
        public virtual DbSet<TblProductOrganizationDetails> TblProductOrganizationDetails { get; set; }
        public virtual DbSet<TblProvince> TblProvince { get; set; }
        public virtual DbSet<TblSiteArea> TblSiteArea { get; set; }
        public virtual DbSet<TblSmsproviderConfiguration> TblSmsproviderConfiguration { get; set; }
        public virtual DbSet<TblSmsproviderNumber> TblSmsproviderNumber { get; set; }
        public virtual DbSet<TblSmsresponse> TblSmsresponse { get; set; }
        public virtual DbSet<TblSmssetting> TblSmssetting { get; set; }
        public virtual DbSet<TblSmstemplate> TblSmstemplate { get; set; }
        public virtual DbSet<TblToken> TblToken { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=89.42.208.109;Database=Befoys_Organization;user id=sa;password=A@rd123456;");
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

            modelBuilder.Entity<TblDocument>(entity =>
            {
                entity.Property(e => e.DocumentGuid).HasDefaultValueSql("(newid())");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Employee_Tbl_OrganizationRole");
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

            modelBuilder.Entity<TblOrganizationDocumentFeatures>(entity =>
            {
                entity.Property(e => e.OdfGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.OdfKindCode)
                    .WithMany(p => p.TblOrganizationDocumentFeaturesOdfKindCode)
                    .HasForeignKey(d => d.OdfKindCodeId)
                    .HasConstraintName("FK_Tbl_OrganizationDocumentFeatures_Tbl_Code1");

                entity.HasOne(d => d.OdfTypeCode)
                    .WithMany(p => p.TblOrganizationDocumentFeaturesOdfTypeCode)
                    .HasForeignKey(d => d.OdfTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationDocumentFeatures_Tbl_Code");
            });

            modelBuilder.Entity<TblOrganizationDocumentNavigator>(entity =>
            {
                entity.Property(e => e.OdnGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.OdnOdf)
                    .WithMany(p => p.TblOrganizationDocumentNavigator)
                    .HasForeignKey(d => d.OdnOdfid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationDocumentNavigator_Tbl_OrganizationDocumentFeatures");

                entity.HasOne(d => d.OdnOt)
                    .WithMany(p => p.TblOrganizationDocumentNavigator)
                    .HasForeignKey(d => d.OdnOtid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationDocumentNavigator_Tbl_OrganizationType");
            });

            modelBuilder.Entity<TblOrganizationInformation>(entity =>
            {
                entity.Property(e => e.OiGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.OiOrganization)
                    .WithMany(p => p.TblOrganizationInformation)
                    .HasForeignKey(d => d.OiOrganizationId)
                    .HasConstraintName("FK_Tbl_OrganizationInformation_Tbl_Organization");

                entity.HasOne(d => d.OiTypeCode)
                    .WithMany(p => p.TblOrganizationInformation)
                    .HasForeignKey(d => d.OiTypeCodeId)
                    .HasConstraintName("FK_Tbl_OrganizationInformation_Tbl_Code");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
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

            modelBuilder.Entity<TblProductOrganization>(entity =>
            {
                entity.Property(e => e.PoGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.PoOrganization)
                    .WithMany(p => p.TblProductOrganization)
                    .HasForeignKey(d => d.PoOrganizationId)
                    .HasConstraintName("FK_Tbl_ProductOrganization_Tbl_Organization");

                entity.HasOne(d => d.PoProduct)
                    .WithMany(p => p.TblProductOrganization)
                    .HasForeignKey(d => d.PoProductId)
                    .HasConstraintName("FK_Tbl_ProductOrganization_Tbl_Product");

                entity.HasOne(d => d.PoSa)
                    .WithMany(p => p.TblProductOrganization)
                    .HasForeignKey(d => d.PoSaid)
                    .HasConstraintName("FK_Tbl_ProductOrganization_Tbl_SiteArea");
            });

            modelBuilder.Entity<TblProductOrganizationDetails>(entity =>
            {
                entity.Property(e => e.PodGuid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblProvince>(entity =>
            {
                entity.Property(e => e.ProvinceGuid).HasDefaultValueSql("(newid())");
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
