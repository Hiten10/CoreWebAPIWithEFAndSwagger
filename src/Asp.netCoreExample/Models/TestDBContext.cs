using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Asp.netCoreExample.Models
{
    public partial class TestDBContext : DbContext
    {
        public static string ConnectionString { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<JobInfo>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("PK__JobInfo__056690E27F60ED59");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.LastExecutionDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<JobInfo> JobInfo { get; set; }
    }
}