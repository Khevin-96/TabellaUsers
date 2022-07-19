﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TabellaUsers.DataModel;

#nullable disable

namespace TabellaUsers.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TabellaUsers.DataModel.ModelAzienda", b =>
                {
                    b.Property<int>("IdAzienda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAzienda"), 1L, 1);

                    b.Property<string>("NameAzienda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("IdAzienda");

                    b.ToTable("Azienda");
                });

            modelBuilder.Entity("TabellaUsers.DataModel.ModelContract", b =>
                {
                    b.Property<int>("IdContract")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContract"), 1L, 1);

                    b.Property<string>("NameContract")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("IdContract");

                    b.ToTable("Contratto");
                });

            modelBuilder.Entity("TabellaUsers.DataModel.ModelUsers", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int?>("Azienda_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.HasIndex("Azienda_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TabellaUsers.DataModel.PivotUserContract", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Contract_id")
                        .HasColumnType("int");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("Contract_id");

                    b.HasIndex("User_id");

                    b.ToTable("ContractUsersPivot");
                });

            modelBuilder.Entity("TabellaUsers.DataModel.ModelUsers", b =>
                {
                    b.HasOne("TabellaUsers.DataModel.ModelAzienda", "Azienda")
                        .WithMany("Users")
                        .HasForeignKey("Azienda_Id");

                    b.Navigation("Azienda");
                });

            modelBuilder.Entity("TabellaUsers.DataModel.PivotUserContract", b =>
                {
                    b.HasOne("TabellaUsers.DataModel.ModelContract", "contract")
                        .WithMany("Users")
                        .HasForeignKey("Contract_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TabellaUsers.DataModel.ModelUsers", "user")
                        .WithMany("Contracts")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("contract");

                    b.Navigation("user");
                });

            modelBuilder.Entity("TabellaUsers.DataModel.ModelAzienda", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TabellaUsers.DataModel.ModelContract", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TabellaUsers.DataModel.ModelUsers", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
