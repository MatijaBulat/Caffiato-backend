using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Caffiato.Models
{
    public partial class CaffiatoDBContext : DbContext
    {
        public CaffiatoDBContext()
        {
        }

        public CaffiatoDBContext(DbContextOptions<CaffiatoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Caffe> Caffes { get; set; } = null!;
        public virtual DbSet<Challenge> Challenges { get; set; } = null!;
        public virtual DbSet<Deal> Deals { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Transact> Transacts { get; set; } = null!;
        public virtual DbSet<UserCaffe> UserCaffes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=CaffiatoDB;Uid=sa;Password=SQL;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CaffeId).HasColumnName("CaffeID");

                entity.Property(e => e.City).HasMaxLength(1024);

                entity.Property(e => e.PostCode).HasMaxLength(1024);

                entity.Property(e => e.StreetName).HasMaxLength(1024);

                entity.Property(e => e.StreetNumber).HasMaxLength(1024);

                entity.HasOne(d => d.Caffe)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CaffeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CaffeAddress");
            });

            modelBuilder.Entity<Caffe>(entity =>
            {
                entity.ToTable("Caffe");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(1024);

                entity.Property(e => e.UserCaffeId).HasColumnName("UserCaffeID");

                entity.HasOne(d => d.UserCaffe)
                    .WithMany(p => p.Caffes)
                    .HasForeignKey(d => d.UserCaffeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCaffeCaffe");
            });

            modelBuilder.Entity<Challenge>(entity =>
            {
                entity.ToTable("Challenge");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(1024);
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.ToTable("Deal");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.CaffeId).HasColumnName("CaffeID");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(1024);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Caffe)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.CaffeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CaffeDeal");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Transact>(entity =>
            {
                entity.ToTable("Transact");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.UserCaffeId).HasColumnName("UserCaffeID");

                entity.HasOne(d => d.UserCaffe)
                    .WithMany(p => p.Transacts)
                    .HasForeignKey(d => d.UserCaffeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCaffeTransact");
            });

            modelBuilder.Entity<UserCaffe>(entity =>
            {
                entity.ToTable("UserCaffe");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(1024);

                entity.Property(e => e.FirstName).HasMaxLength(1024);

                entity.Property(e => e.LastName).HasMaxLength(1024);

                entity.Property(e => e.Oib)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Username).HasMaxLength(1024);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
