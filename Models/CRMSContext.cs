using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectForHealing.Models
{
    public partial class CRMSContext :DbContext
    {
        public CRMSContext()
        {
        }

        public CRMSContext(DbContextOptions<CRMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Editor> Editor { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {/*
            if (!optionsBuilder.IsConfigured)
            {

                    optionsBuilder.UseSqlServer("Server=projectforhealing.database.windows.net;Database=CRMS; User Id=Demo1; Password=Helprefugees1; Trusted_Connection=False;");
            }*/
        }
    }
}
