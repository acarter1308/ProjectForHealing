using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectForHealing.Models
{
    public partial class CRMSContext : DbContext
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
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=projectforhealing.database.windows.net;Database=CRMS; User Id=Demo1; Password=Helprefugees1; Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__Admin__C9F284579AD856AC");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminPassWord)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasColumnName("LName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pnumber)
                    .HasColumnName("PNumber")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProfilePic).HasColumnType("image");
            });

            modelBuilder.Entity<Editor>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__tmp_ms_x__C9F284579E4AD40A");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EditorPassWord)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasColumnName("LName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pnumber)
                    .HasColumnName("PNumber")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProfilePicUrl).IsUnicode(false);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.ResourceId).ValueGeneratedNever();

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasColumnName("LName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgDescription).HasMaxLength(1000);

                entity.Property(e => e.OrgEmail)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OrgName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OrgSte)
                    .HasColumnName("OrgSTE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OrgZip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RepEmail)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RepNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WebsiteUrl)
                    .HasColumnName("WebsiteURL")
                    .HasMaxLength(1000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
