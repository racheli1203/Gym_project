﻿// <auto-generated />
using System;
using Gym.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gym.Data.Migrations
{
    [DbContext(typeof(GymData))]
    partial class GymDataModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Gym.gymEquipment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateOfInspection")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("expiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("frequencyOfTesting")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("equipments");
                });

            modelBuilder.Entity("Gym.Staff", b =>
                {
                    b.Property<int>("workerNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("workerNumber"), 1L, 1);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("workerNumber");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("Gym.Subscribers", b =>
                {
                    b.Property<int>("subscriptionNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("subscriptionNumber"), 1L, 1);

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("endSubscripion")
                        .HasColumnType("datetime2");

                    b.Property<int>("idSubscriber")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("startSubscripion")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("trainerId")
                        .HasColumnType("int");

                    b.HasKey("subscriptionNumber");

                    b.HasIndex("trainerId");

                    b.ToTable("subscribers");
                });

            modelBuilder.Entity("StaffgymEquipment", b =>
                {
                    b.Property<int>("equipmentInCategoryid")
                        .HasColumnType("int");

                    b.Property<int>("staffsworkerNumber")
                        .HasColumnType("int");

                    b.HasKey("equipmentInCategoryid", "staffsworkerNumber");

                    b.HasIndex("staffsworkerNumber");

                    b.ToTable("StaffgymEquipment");
                });

            modelBuilder.Entity("Gym.Subscribers", b =>
                {
                    b.HasOne("Gym.Staff", "trainer")
                        .WithMany("subscribersId")
                        .HasForeignKey("trainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("trainer");
                });

            modelBuilder.Entity("StaffgymEquipment", b =>
                {
                    b.HasOne("Gym.gymEquipment", null)
                        .WithMany()
                        .HasForeignKey("equipmentInCategoryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gym.Staff", null)
                        .WithMany()
                        .HasForeignKey("staffsworkerNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gym.Staff", b =>
                {
                    b.Navigation("subscribersId");
                });
#pragma warning restore 612, 618
        }
    }
}
