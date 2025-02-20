﻿// <auto-generated />
using System;
using FunShield.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FunShield.Migrations
{
    [DbContext(typeof(FunShieldDbContext))]
    partial class FunShieldDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("FunShield.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("FunShield.Models.Session", b =>
                {
                    b.Property<string>("SessionID")
                        .HasColumnType("TEXT");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionType")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("SessionID");

                    b.HasIndex("CourseID");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("FunShield.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EnrollmentHistory")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("FunShield.Models.StudentCourse", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("FunShield.Models.Session", b =>
                {
                    b.HasOne("FunShield.Models.Course", "Course")
                        .WithMany("Sessions")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("FunShield.Models.StudentCourse", b =>
                {
                    b.HasOne("FunShield.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FunShield.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("FunShield.Models.Course", b =>
                {
                    b.Navigation("Sessions");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("FunShield.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
