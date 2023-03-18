using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SPS.Data.Models
{
    public partial class SPSContext : DbContext
    {
        public SPSContext()
        {
        }

        public SPSContext(DbContextOptions<SPSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryDetail> CategoryDetails { get; set; } = null!;
        public virtual DbSet<Subscriber> Subscriber { get; set; } = null!;

        public virtual DbSet<PhotoGallaryFunction> PhotoGallaryFunction { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //    optionsBuilder.UseSqlServer("Server=45.64.104.120,52894;Initial Catalog=DBSPS; uid=smartpreschool;Password=sara!@#123; Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("smartpreschool");

            modelBuilder.Entity<CategoryDetail>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
                entity.Property(e => e.CategoryDesc).HasMaxLength(500);
                entity.Property(e => e.CategoryName).HasMaxLength(250);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });
            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.HasKey(e => e.SubscriberMasterId);
                entity.Property(e => e.SubscroberCode).HasMaxLength(8);
                entity.Property(e => e.SubscriberName).HasMaxLength(250);
                entity.Property(e => e.SubscriberAddress).HasMaxLength(250);
                entity.Property(e => e.Email).HasMaxLength(250);
                entity.Property(e => e.Mobile).HasMaxLength(250);
                entity.Property(e => e.IsStatus).HasMaxLength(250);
                entity.Property(e => e.CreatedBy).HasMaxLength(250);
                entity.Property(e => e.ModifiedBy).HasMaxLength(250);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PhotoGallaryFunction>(entity =>
            {
                entity.HasKey(e => e.FunctionId);
                entity.HasKey(e =>e.SubscriberMasterId);
                entity.Property(e => e.FunctionName).HasMaxLength(250);
                entity.Property(e => e.FunctionDescription).HasMaxLength(250);
                entity.Property(e => e.IsStatus).HasMaxLength(250);
                entity.Property(e => e.CreatedBy).HasMaxLength(250);
                entity.Property(e => e.ModifiedBy).HasMaxLength(250);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
