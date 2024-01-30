﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.DataBaseAccess;

#nullable disable

namespace Project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240129145828_newtable")]
    partial class newtable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project.Models.AppointmentModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("AppointmentId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Email");

                    b.Property<string>("ServiceTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("ServiceTypeId");

                    b.Property<int>("SessionCount")
                        .HasColumnType("int")
                        .HasColumnName("SessionCount");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("UserId");

                    b.Property<string>("contactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ContactNumber");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FullName");

                    b.HasKey("Id");

                    b.HasIndex("ServiceTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Project.Models.AppointmentSchedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("AppointmentScheduleId");

                    b.Property<string>("AppoinmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("AppoinmentId");

                    b.Property<string>("AppointmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("DateTime");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("AppointmentSchedules");
                });

            modelBuilder.Entity("Project.Models.ContactUsModel", b =>
                {
                    b.Property<string>("ContactId")
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("ContactId");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("ContactNumber");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("Email");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Message");

                    b.Property<string>("MessageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("MessageType");

                    b.HasKey("ContactId");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("Project.Models.ServiceTypeModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("TypeId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TypeName");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("ServiceTypePrice");

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("Project.Models.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("UserId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("UserEmail");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("UserName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Password");

                    b.Property<string>("contactNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UserContactNumber");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Project.Models.AppointmentModel", b =>
                {
                    b.HasOne("Project.Models.ServiceTypeModel", "ServiceType")
                        .WithMany("Appointments")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Models.UserModel", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project.Models.AppointmentSchedule", b =>
                {
                    b.HasOne("Project.Models.AppointmentModel", "Appointment")
                        .WithMany("AppointmentSchedules")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Project.Models.AppointmentModel", b =>
                {
                    b.Navigation("AppointmentSchedules");
                });

            modelBuilder.Entity("Project.Models.ServiceTypeModel", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Project.Models.UserModel", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}