﻿// <auto-generated />
using System;
using Infrastructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructures.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entitys.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeleteBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModificationBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("fullName")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Domain.Entitys.BussinessPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AmountDay")
                        .HasColumnType("integer");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeleteBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModificationBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("BussinessPlans");
                });

            modelBuilder.Entity("Domain.Entitys.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeleteBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModificationBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("Domain.Entitys.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeleteBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModificationBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("PostPetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostPetId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Domain.Entitys.Kind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeleteBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModificationBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Kinds");
                });

            modelBuilder.Entity("Domain.Entitys.Meet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int?>("BuyerID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeleteBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModificationBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("PostPetID")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BuyerID");

                    b.HasIndex("PostPetID");

                    b.ToTable("Meets");
                });

            modelBuilder.Entity("Domain.Entitys.PostPet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeleteBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<int?>("HealthStatus")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Isvalid")
                        .HasColumnType("text");

                    b.Property<int?>("ModificationBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<float?>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("ShopID")
                        .HasColumnType("integer");

                    b.Property<int?>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ShopID");

                    b.HasIndex("TypeId");

                    b.ToTable("PostPets");
                });

            modelBuilder.Entity("Domain.Entitys.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int?>("BusinessPlanId")
                        .HasColumnType("integer");

                    b.Property<int>("BussinessPlanId")
                        .HasColumnType("integer");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateBusinessPlan")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeleteBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModificationBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("text");

                    b.Property<double?>("Rating")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("BussinessPlanId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Domain.Entitys.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeleteBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("KindId")
                        .HasColumnType("integer");

                    b.Property<int?>("ModificationBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("KindId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Domain.Entitys.Buyer", b =>
                {
                    b.HasOne("Domain.Entitys.Account", "Account")
                        .WithOne("Buyer")
                        .HasForeignKey("Domain.Entitys.Buyer", "AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.Entitys.Image", b =>
                {
                    b.HasOne("Domain.Entitys.PostPet", "PostPet")
                        .WithMany("Images")
                        .HasForeignKey("PostPetId");

                    b.Navigation("PostPet");
                });

            modelBuilder.Entity("Domain.Entitys.Meet", b =>
                {
                    b.HasOne("Domain.Entitys.Buyer", "Buyer")
                        .WithMany("Meets")
                        .HasForeignKey("BuyerID");

                    b.HasOne("Domain.Entitys.PostPet", "PostPet")
                        .WithMany("Meets")
                        .HasForeignKey("PostPetID");

                    b.Navigation("Buyer");

                    b.Navigation("PostPet");
                });

            modelBuilder.Entity("Domain.Entitys.PostPet", b =>
                {
                    b.HasOne("Domain.Entitys.Shop", "Shop")
                        .WithMany("PostPets")
                        .HasForeignKey("ShopID");

                    b.HasOne("Domain.Entitys.Type", "Type")
                        .WithMany("PostPets")
                        .HasForeignKey("TypeId");

                    b.Navigation("Shop");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Domain.Entitys.Shop", b =>
                {
                    b.HasOne("Domain.Entitys.Account", "Account")
                        .WithOne("Shop")
                        .HasForeignKey("Domain.Entitys.Shop", "AccountId");

                    b.HasOne("Domain.Entitys.BussinessPlan", "BussinessPlan")
                        .WithMany("Shops")
                        .HasForeignKey("BussinessPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("BussinessPlan");
                });

            modelBuilder.Entity("Domain.Entitys.Type", b =>
                {
                    b.HasOne("Domain.Entitys.Kind", "Kind")
                        .WithMany("Types")
                        .HasForeignKey("KindId");

                    b.Navigation("Kind");
                });

            modelBuilder.Entity("Domain.Entitys.Account", b =>
                {
                    b.Navigation("Buyer");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Domain.Entitys.BussinessPlan", b =>
                {
                    b.Navigation("Shops");
                });

            modelBuilder.Entity("Domain.Entitys.Buyer", b =>
                {
                    b.Navigation("Meets");
                });

            modelBuilder.Entity("Domain.Entitys.Kind", b =>
                {
                    b.Navigation("Types");
                });

            modelBuilder.Entity("Domain.Entitys.PostPet", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Meets");
                });

            modelBuilder.Entity("Domain.Entitys.Shop", b =>
                {
                    b.Navigation("PostPets");
                });

            modelBuilder.Entity("Domain.Entitys.Type", b =>
                {
                    b.Navigation("PostPets");
                });
#pragma warning restore 612, 618
        }
    }
}
