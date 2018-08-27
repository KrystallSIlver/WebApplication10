﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication10.Models;

namespace WebApplication10.Migrations
{
    [DbContext(typeof(testTaskdbContext))]
    [Migration("20180821091303_t1")]
    partial class t1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication10.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnName("CustomerID");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("Role")
                        .IsRequired()
                        .IsUnicode(false);

                    b.HasKey("ContactId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("WebApplication10.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("Comments")
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .IsUnicode(false);

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("WebApplication10.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<int>("CustomerId");

                    b.Property<string>("Manager")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<int>("ManagerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false);

                    b.HasKey("DepartmentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("WebApplication10.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .IsUnicode(false);

                    b.HasKey("UserId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApplication10.Models.Contact", b =>
                {
                    b.HasOne("WebApplication10.Models.Customer", "Customer")
                        .WithMany("Contacts")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Contact__Custome__276EDEB3")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication10.Models.Department", b =>
                {
                    b.HasOne("WebApplication10.Models.Customer", "Customer")
                        .WithMany("Departments")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Departmen__Custo__32E0915F")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication10.Models.User", "ManagerNavigation")
                        .WithMany("DepartmentNavigation")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK__Departmen__Manag__30F848ED")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication10.Models.User", b =>
                {
                    b.HasOne("WebApplication10.Models.Customer", "Customer")
                        .WithMany("Users")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__User__CustomerId__2D27B809")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication10.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK__User__Department__31EC6D26")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
