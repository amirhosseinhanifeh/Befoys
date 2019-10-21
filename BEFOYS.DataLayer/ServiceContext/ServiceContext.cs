
using BEFOYS.DataLayer.Entity.Account;
using BEFOYS.DataLayer.Entity.Address;
using BEFOYS.DataLayer.Entity.City;
using BEFOYS.DataLayer.Entity.Code;
using BEFOYS.DataLayer.Entity.Document;
using BEFOYS.DataLayer.Entity.Group;
using BEFOYS.DataLayer.Entity.Panel;
using BEFOYS.DataLayer.Entity.Permission;
using BEFOYS.DataLayer.Entity.Province;
using BEFOYS.DataLayer.Entity.Role;
using BEFOYS.DataLayer.Entity.Supplier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ServiceContext
{
    public class ServiceContext:DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
           
        }
        public virtual DbSet<Tbl_Login> Tbl_Login { get; set; }
        public virtual DbSet<Tbl_Supplier> Tbl_Supplier { get; set; }
        public virtual DbSet<Tbl_SupplierDocument> Tbl_SupplierDocument { get; set; }
        public virtual DbSet<Tbl_BaseRole> Tbl_BaseRole { get; set; }
        public virtual DbSet<Tbl_ForgetPassword> Tbl_ForgetPassword { get; set; }
        public virtual DbSet<Tbl_SupplierLegal> Tbl_SupplierLegal { get; set; }
        public virtual DbSet<Tbl_SupplierReal> Tbl_SupplierReal { get; set; }
        public virtual DbSet<Tbl_Address> Tbl_Address { get; set; }
        public virtual DbSet<Tbl_City> Tbl_City { get; set; }
        public virtual DbSet<Tbl_Code> Tbl_Code { get; set; }
        public virtual DbSet<Tbl_CodeGroup> Tbl_CodeGroup { get; set; }
        public virtual DbSet<Tbl_Document> Tbl_Document { get; set; }
        public virtual DbSet<Tbl_Permission> Tbl_Permission { get; set; }
        public virtual DbSet<Tbl_GroupPermission> Tbl_GroupPermission { get; set; }
        public virtual DbSet<Tbl_Province> Tbl_Province { get; set; }
        public virtual DbSet<Tbl_Phone> Tbl_Phone { get; set; }
        public virtual DbSet<Tbl_Group> Tbl_Group{ get; set; }
        public virtual DbSet<Tbl_PanelType> Tbl_PanelType { get; set; }
        public virtual DbSet<Tbl_PanelTypePermission> Tbl_PanelTypePermission { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=185.173.104.205;Database=Befoys_Core;userId=sa;password=A@rd123456;");
            }
        }
    }
}
