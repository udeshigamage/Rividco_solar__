﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rividco_solar__.Dbcontext;

#nullable disable

namespace Rividco_solar__.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    [Migration("20250221182105_fifthl90")]
    partial class fifthl90
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Rividco_solar__.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Customer", b =>
                {
                    b.Property<int>("Customer_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Lastupdatedby")
                        .HasColumnType("int");

                    b.Property<DateTime>("Lastupdatedtime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("mobileno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("officeno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Customer_ID");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Employee", b =>
                {
                    b.Property<int>("Employee_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Lastupdatedby")
                        .HasColumnType("int");

                    b.Property<DateTime>("Lastupdatedtime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("mobileno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("officeno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Employee_ID");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Participant", b =>
                {
                    b.Property<string>("Participant_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("Company_ID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Lastupdatedby")
                        .HasColumnType("int");

                    b.Property<DateTime>("Lastupdatedtime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("mobileno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("officeno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("profession")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Participant_ID");

                    b.HasIndex("CompanyId");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Project", b =>
                {
                    b.Property<int>("Project_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Commissioneddate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Coordinator_ID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Customer_ID")
                        .HasColumnType("int");

                    b.Property<int>("Lastupdatedby")
                        .HasColumnType("int");

                    b.Property<DateTime>("Lastupdatedtime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("estimatedcost")
                        .HasColumnType("int");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("referencedby")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("startdate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("warranty_period")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Project_ID");

                    b.HasIndex("Customer_ID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Rividco_solar__.Models.ProjectCommissionreport", b =>
                {
                    b.Property<int>("Projectcommisionrepo_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Addedby")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Project_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Project_ID")
                        .HasColumnType("int");

                    b.Property<int>("Project_ID1")
                        .HasColumnType("int");

                    b.Property<int>("commissionreportno")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Projectcommisionrepo_Id");

                    b.HasIndex("Project_ID1");

                    b.ToTable("Projectcommissionreport");
                });

            modelBuilder.Entity("Rividco_solar__.Models.ProjectResources", b =>
                {
                    b.Property<int>("Projectresource_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Addedby")
                        .HasColumnType("int");

                    b.Property<DateTime>("Addeddate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Project_ID")
                        .HasColumnType("int");

                    b.Property<int>("Project_ID1")
                        .HasColumnType("int");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("link")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Projectresource_ID");

                    b.HasIndex("Project_ID1");

                    b.ToTable("Projectresources");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Projectitem", b =>
                {
                    b.Property<int>("Projectitem_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Added_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Added_by")
                        .HasColumnType("int");

                    b.Property<int>("Project_ID")
                        .HasColumnType("int");

                    b.Property<int>("Vendoritem_ID")
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("serialno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("warranty_duration")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Projectitem_ID");

                    b.HasIndex("Project_ID");

                    b.HasIndex("Vendoritem_ID");

                    b.ToTable("Projectitem");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Projectservices", b =>
                {
                    b.Property<int>("Projectservice_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Conducted_by")
                        .HasColumnType("int");

                    b.Property<DateTime>("Conducted_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Planneddate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Project_ID")
                        .HasColumnType("int");

                    b.Property<int>("Project_ID1")
                        .HasColumnType("int");

                    b.Property<string>("Servicereportlink")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("service")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Projectservice_ID");

                    b.HasIndex("Project_ID1");

                    b.ToTable("Projectservices");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Projecttest", b =>
                {
                    b.Property<int>("ProjectTest_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Conducted_by")
                        .HasColumnType("int");

                    b.Property<DateTime>("Conducted_date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Project_ID")
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("result")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("test_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ProjectTest_ID");

                    b.HasIndex("Project_ID");

                    b.ToTable("Projecttest");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Systemuser", b =>
                {
                    b.Property<int>("Systemuser_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("contactno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("passwordhash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Systemuser_ID");

                    b.ToTable("Systemusers");
                });

            modelBuilder.Entity("Rividco_solar__.Models.TaskCIA", b =>
                {
                    b.Property<int>("Task_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Addedby")
                        .HasColumnType("int");

                    b.Property<int>("Assignedto")
                        .HasColumnType("int");

                    b.Property<int>("Project_ID")
                        .HasColumnType("int");

                    b.Property<int>("Requestedby")
                        .HasColumnType("int");

                    b.Property<string>("Urgencylevel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("callbackno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Task_ID");

                    b.HasIndex("Project_ID");

                    b.ToTable("TaskCIA");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Taskresources", b =>
                {
                    b.Property<int>("Taskresource_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Addedby")
                        .HasColumnType("int");

                    b.Property<DateTime>("Addeddate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Resourceurl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Taskresource_Id");

                    b.ToTable("Taskresources");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Taskstatus", b =>
                {
                    b.Property<int>("Taskstatus_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Addeddate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("changedby")
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Taskstatus_Id");

                    b.ToTable("Taskstatus");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Vendor", b =>
                {
                    b.Property<int>("Vendor_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Lastupdatedby")
                        .HasColumnType("int");

                    b.Property<DateTime>("Lastupdatedtime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("mobileno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("officeno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Vendor_ID");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Vendoritem", b =>
                {
                    b.Property<int>("Vendoritem_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Lastupdatedby")
                        .HasColumnType("int");

                    b.Property<DateTime>("Lastupdatedtime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Vendor_ID")
                        .HasColumnType("int");

                    b.Property<string>("Warranty_duration")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("capacity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("item_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("price")
                        .HasColumnType("float");

                    b.Property<string>("product_code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Vendoritem_ID");

                    b.HasIndex("Vendor_ID");

                    b.ToTable("Vendoritem");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Participant", b =>
                {
                    b.HasOne("Rividco_solar__.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Project", b =>
                {
                    b.HasOne("Rividco_solar__.Models.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("Customer_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("Rividco_solar__.Models.ProjectCommissionreport", b =>
                {
                    b.HasOne("Rividco_solar__.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("Project_ID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Rividco_solar__.Models.ProjectResources", b =>
                {
                    b.HasOne("Rividco_solar__.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("Project_ID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Projectitem", b =>
                {
                    b.HasOne("Rividco_solar__.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("Project_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rividco_solar__.Models.Vendoritem", "Vendoritem")
                        .WithMany()
                        .HasForeignKey("Vendoritem_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Vendoritem");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Projectservices", b =>
                {
                    b.HasOne("Rividco_solar__.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("Project_ID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Projecttest", b =>
                {
                    b.HasOne("Rividco_solar__.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("Project_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Rividco_solar__.Models.TaskCIA", b =>
                {
                    b.HasOne("Rividco_solar__.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("Project_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Rividco_solar__.Models.Vendoritem", b =>
                {
                    b.HasOne("Rividco_solar__.Models.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("Vendor_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendor");
                });
#pragma warning restore 612, 618
        }
    }
}
