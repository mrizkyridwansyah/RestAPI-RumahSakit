﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(LibDbContext))]
    [Migration("20210723125747_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Service.Entities.Diagnosa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdRegistrasi")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Keterangan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdRegistrasi");

                    b.ToTable("Diagnosa");
                });

            modelBuilder.Entity("Service.Entities.Dokter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dokter");
                });

            modelBuilder.Entity("Service.Entities.Pasien", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NIK")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NIK")
                        .IsUnique();

                    b.ToTable("Pasien");
                });

            modelBuilder.Entity("Service.Entities.Registrasi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdDokter")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPasien")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Jadwal")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoRegistrasi")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IdDokter");

                    b.HasIndex("IdPasien");

                    b.HasIndex("NoRegistrasi")
                        .IsUnique()
                        .HasFilter("[NoRegistrasi] IS NOT NULL");

                    b.ToTable("Registrasi");
                });

            modelBuilder.Entity("Service.Entities.Tindakan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdRegistrasi")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Keterangan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdRegistrasi");

                    b.ToTable("Tindakan");
                });

            modelBuilder.Entity("Service.Entities.Diagnosa", b =>
                {
                    b.HasOne("Service.Entities.Registrasi", "Registrasi")
                        .WithMany("Diagnosa")
                        .HasForeignKey("IdRegistrasi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Service.Entities.Registrasi", b =>
                {
                    b.HasOne("Service.Entities.Dokter", "Dokter")
                        .WithMany()
                        .HasForeignKey("IdDokter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Service.Entities.Pasien", "Pasien")
                        .WithMany()
                        .HasForeignKey("IdPasien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Service.Entities.Tindakan", b =>
                {
                    b.HasOne("Service.Entities.Registrasi", "Registrasi")
                        .WithMany("Tindakan")
                        .HasForeignKey("IdRegistrasi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}