﻿// <auto-generated />
using Laboratory_WebApi.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Laboratory_WebApi.Persistance.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220415112841_commit1")]
    partial class commit1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Laboratory_WebApi.Domain.Entities.Laboratory.SubTest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long>("TestsGroupId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TestsGroupId");

                    b.ToTable("subTests");
                });

            modelBuilder.Entity("Laboratory_WebApi.Domain.Entities.Laboratory.TestsGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ReceptionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("testsGroups");
                });

            modelBuilder.Entity("Laboratory_WebApi.Domain.Entities.Laboratory.SubTest", b =>
                {
                    b.HasOne("Laboratory_WebApi.Domain.Entities.Laboratory.TestsGroup", "TestsGroup")
                        .WithMany("SubTests")
                        .HasForeignKey("TestsGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestsGroup");
                });

            modelBuilder.Entity("Laboratory_WebApi.Domain.Entities.Laboratory.TestsGroup", b =>
                {
                    b.Navigation("SubTests");
                });
#pragma warning restore 612, 618
        }
    }
}
