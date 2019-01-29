using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public partial class ResearchStudyContext : DbContext
    {
        public ResearchStudyContext(DbContextOptions<ResearchStudyContext> options)
             : base(options)
        {
            // FH 6/10/2018 turn tracking off
            // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<EthnicGroup> EthnicGroup { get; set; }
        public virtual DbSet<Ethnicity> Ethnicity { get; set; }
        public virtual DbSet<LabResult> LabResult { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<PhoneType> PhoneType { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning   To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            // optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ResearchStudy;Trusted_Connection=True;");
            // 6-12-2018 FH added for debugging
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.SubjectId)
                    .HasName("IX_Address_SubjectID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.City).HasColumnType("varchar(50)");

                entity.Property(e => e.State).HasColumnType("char(2)");

                entity.Property(e => e.Street).HasColumnType("varchar(50)");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.Zip)
                    .HasColumnName("ZIP")
                    .HasColumnType("varchar(9)");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Address_Subject");
            });

            modelBuilder.Entity<EthnicGroup>(entity =>
            {
                entity.Property(e => e.EthnicGroupId).HasColumnName("EthnicGroupID");

                entity.Property(e => e.EthnicGroupName)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Ethnicity>(entity =>
            {
                entity.HasIndex(e => e.EthnicGroupId)
                    .HasName("IX_Ethnicity_EthnicGroupID");

                entity.HasIndex(e => e.SubjectId)
                    .HasName("IX_Ethnicity_SubjectID");

                entity.Property(e => e.EthnicityId).HasColumnName("EthnicityID");

                entity.Property(e => e.EthnicGroupId).HasColumnName("EthnicGroupID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.EthnicGroup)
                    .WithMany(p => p.Ethnicity)
                    .HasForeignKey(d => d.EthnicGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Ethnicity_EthnicGroup");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Ethnicity)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Ethnicity_Subject");
            });

            modelBuilder.Entity<LabResult>(entity =>
            {
                entity.HasIndex(e => e.ExamDate)
                    .HasName("UQ_LabResult_ExamDate")
                    .IsUnique();

                entity.HasIndex(e => e.SubjectId)
                    .HasName("IX_LabResult_SubjectID");

                entity.Property(e => e.LabResultId).HasColumnName("LabResultID");

                entity.Property(e => e.ExamDate).HasColumnType("date");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.LabResult)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_LabResult_Subject");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasIndex(e => e.PhoneTypeId)
                    .HasName("IX_Phone_PhoneTypeID");

                entity.HasIndex(e => e.SubjectId)
                    .HasName("IX_Phone_SubjectID");

                entity.Property(e => e.PhoneId).HasColumnName("PhoneID");

                entity.Property(e => e.Extention).HasColumnType("varchar(10)");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.PhoneTypeId).HasColumnName("PhoneTypeID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.PhoneType)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.PhoneTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Phone_PhoneType");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Phone_Subject");
            });

            modelBuilder.Entity<PhoneType>(entity =>
            {
                entity.HasIndex(e => e.PhoneType1)
                    .HasName("UQ_PhoneType_PhoneType")
                    .IsUnique();

                entity.Property(e => e.PhoneTypeId).HasColumnName("PhoneTypeID");

                entity.Property(e => e.PhoneType1)
                    .IsRequired()
                    .HasColumnName("PhoneType")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasIndex(e => e.Ssn)
                    .HasName("UQ_Subject_SSN")
                    .IsUnique();

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Gender).HasColumnType("char(1)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MiddleInitial).HasColumnType("char(1)");

                entity.Property(e => e.Occupation).HasColumnType("varchar(50)");

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasColumnName("SSN")
                    .HasColumnType("char(9)");
            });
        }
    }
}
