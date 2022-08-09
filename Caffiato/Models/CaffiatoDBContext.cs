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
                optionsBuilder.UseSqlServer("Server=.;Database=CaffiatoDB;Uid=sas;Password=SQL;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Idaddress)
                    .HasName("PK__Address__F31F10A0063AE6C8");

                entity.ToTable("Address");

                entity.Property(e => e.Idaddress).HasColumnName("IDAddress");

                entity.Property(e => e.CaffeId).HasColumnName("CaffeID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.PostCode).HasMaxLength(15);

                entity.Property(e => e.StreetName).HasMaxLength(50);

                entity.Property(e => e.StreetNumber).HasMaxLength(10);

                entity.HasOne(d => d.Caffe)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CaffeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__CaffeID__3D5E1FD2");
            });

            modelBuilder.Entity<Caffe>(entity =>
            {
                entity.HasKey(e => e.Idcafe)
                    .HasName("PK__Caffe__43A503680827891A");

                entity.ToTable("Caffe");

                entity.Property(e => e.Idcafe).HasColumnName("IDCafe");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.UserCaffeId).HasColumnName("UserCaffeID");

                entity.HasOne(d => d.UserCaffe)
                    .WithMany(p => p.Caffes)
                    .HasForeignKey(d => d.UserCaffeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Caffe__UserCaffe__3A81B327");
            });

            modelBuilder.Entity<Challenge>(entity =>
            {
                entity.HasKey(e => e.Idchallenge)
                    .HasName("PK__Challeng__58DEF4CF5E3B304F");

                entity.ToTable("Challenge");

                entity.Property(e => e.Idchallenge).HasColumnName("IDChallenge");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.HasKey(e => e.Iddeal)
                    .HasName("PK__Deal__327A66D441FBFA9F");

                entity.ToTable("Deal");

                entity.Property(e => e.Iddeal).HasColumnName("IDDeal");

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.CaffeId).HasColumnName("CaffeID");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Caffe)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.CaffeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deal__CaffeID__403A8C7D");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.Idfeedback)
                    .HasName("PK__Feedback__8456A50A5283C0E9");

                entity.ToTable("Feedback");

                entity.Property(e => e.Idfeedback).HasColumnName("IDFeedback");
            });

            modelBuilder.Entity<Transact>(entity =>
            {
                entity.HasKey(e => e.Idtransaction)
                    .HasName("PK__Transact__A3F081DFBA726018");

                entity.ToTable("Transact");

                entity.Property(e => e.Idtransaction).HasColumnName("IDTransaction");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.UserCaffeId).HasColumnName("UserCaffeID");

                entity.HasOne(d => d.UserCaffe)
                    .WithMany(p => p.Transacts)
                    .HasForeignKey(d => d.UserCaffeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transact__UserCa__440B1D61");
            });

            modelBuilder.Entity<UserCaffe>(entity =>
            {
                entity.HasKey(e => e.IduserCaffe)
                    .HasName("PK__UserCaff__86A6A8FB737C69FA");

                entity.ToTable("UserCaffe");

                entity.Property(e => e.IduserCaffe).HasColumnName("IDUserCaffe");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Oib).HasMaxLength(11);

                entity.Property(e => e.Surname).HasMaxLength(150);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
