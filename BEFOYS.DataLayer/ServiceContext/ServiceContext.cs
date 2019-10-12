using BEFOYS.DataLayer.Entity;
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
         
        }
        public virtual DbSet<Tbl_Login> Tbl_Login { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=185.173.104.205;Database=Befoys_Core;userId=sa;password=A@rd123456;");
            }
        }
    }
}
