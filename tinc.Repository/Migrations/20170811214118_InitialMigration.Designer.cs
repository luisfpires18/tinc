using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using tinc.Repository.Context;
using tinc.Domain.Entities;

namespace tinc.Repository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20170811214118_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("tinc.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AthleteType");

                    b.Property<Guid?>("CompetitionID");

                    b.Property<string>("Description");

                    b.Property<string>("Gender");

                    b.Property<int>("MaxAge");

                    b.Property<int>("MinAge");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfWinners");

                    b.Property<string>("Responsible");

                    b.HasKey("ID");

                    b.HasIndex("CompetitionID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Competition", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<float>("Distance");

                    b.Property<Guid?>("EventID");

                    b.Property<string>("Name");

                    b.Property<float>("Price");

                    b.Property<string>("Responsible");

                    b.HasKey("ID");

                    b.HasIndex("EventID");

                    b.ToTable("Competition");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Enrollment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryID");

                    b.Property<string>("Notes");

                    b.Property<Guid?>("PersonID");

                    b.Property<string>("RegistrationBy");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<int>("Size");

                    b.Property<bool>("Status");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("PersonID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("FilePath");

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Local");

                    b.Property<string>("Name");

                    b.Property<string>("Responsible");

                    b.Property<Guid?>("SportID");

                    b.Property<string>("Website");

                    b.HasKey("ID");

                    b.HasIndex("SportID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Extra", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid?>("EventID");

                    b.Property<string>("Name");

                    b.Property<float>("Price");

                    b.Property<string>("Responsible");

                    b.HasKey("ID");

                    b.HasIndex("EventID");

                    b.ToTable("Extra");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("City");

                    b.Property<string>("Contact");

                    b.Property<string>("Email");

                    b.Property<string>("Gender");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Nacionality");

                    b.Property<string>("Name");

                    b.Property<Guid?>("TeamID");

                    b.HasKey("ID");

                    b.HasIndex("TeamID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Result", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryID");

                    b.Property<Guid?>("CompetitionID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Responsible");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("CompetitionID");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Sport", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Responsible");

                    b.HasKey("ID");

                    b.HasIndex("Name");

                    b.ToTable("Sport");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Team", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Category", b =>
                {
                    b.HasOne("tinc.Domain.Entities.Competition", "Competition")
                        .WithMany("Categories")
                        .HasForeignKey("CompetitionID");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Competition", b =>
                {
                    b.HasOne("tinc.Domain.Entities.Event", "Event")
                        .WithMany("Competitions")
                        .HasForeignKey("EventID");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Enrollment", b =>
                {
                    b.HasOne("tinc.Domain.Entities.Category", "Category")
                        .WithMany("Enrollments")
                        .HasForeignKey("CategoryID");

                    b.HasOne("tinc.Domain.Entities.Person", "Person")
                        .WithMany("Enrollments")
                        .HasForeignKey("PersonID");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Event", b =>
                {
                    b.HasOne("tinc.Domain.Entities.Sport", "Sport")
                        .WithMany("Events")
                        .HasForeignKey("SportID");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Extra", b =>
                {
                    b.HasOne("tinc.Domain.Entities.Event", "Event")
                        .WithMany("Extras")
                        .HasForeignKey("EventID");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Person", b =>
                {
                    b.HasOne("tinc.Domain.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamID");
                });

            modelBuilder.Entity("tinc.Domain.Entities.Result", b =>
                {
                    b.HasOne("tinc.Domain.Entities.Category", "Category")
                        .WithMany("Results")
                        .HasForeignKey("CategoryID");

                    b.HasOne("tinc.Domain.Entities.Competition", "Competition")
                        .WithMany("Results")
                        .HasForeignKey("CompetitionID");
                });
        }
    }
}
