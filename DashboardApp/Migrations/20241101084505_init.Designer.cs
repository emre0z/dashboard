﻿// <auto-generated />
using System;
using DashboardApp.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DashboardApp.Migrations
{
    [DbContext(typeof(DashboardDb))]
    [Migration("20241101084505_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DashboardApp.Data.Entity.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InfoKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubTopicId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubTopicId");

                    b.ToTable("Infos");
                });

            modelBuilder.Entity("DashboardApp.Data.Entity.MainTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MainTopics");
                });

            modelBuilder.Entity("DashboardApp.Data.Entity.SubTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MainTopicId")
                        .HasColumnType("int");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainTopicId");

                    b.ToTable("SubTopics");
                });

            modelBuilder.Entity("DashboardApp.Data.Entity.URL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubTopicId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubTopicId");

                    b.ToTable("URLs");
                });

            modelBuilder.Entity("DashboardApp.Data.Entity.Info", b =>
                {
                    b.HasOne("DashboardApp.Data.Entity.SubTopic", "SubTopic")
                        .WithMany("Infos")
                        .HasForeignKey("SubTopicId");

                    b.Navigation("SubTopic");
                });

            modelBuilder.Entity("DashboardApp.Data.Entity.SubTopic", b =>
                {
                    b.HasOne("DashboardApp.Data.Entity.MainTopic", "MainTopic")
                        .WithMany("SubTopics")
                        .HasForeignKey("MainTopicId");

                    b.Navigation("MainTopic");
                });

            modelBuilder.Entity("DashboardApp.Data.Entity.URL", b =>
                {
                    b.HasOne("DashboardApp.Data.Entity.SubTopic", "SubTopic")
                        .WithMany("URLs")
                        .HasForeignKey("SubTopicId");

                    b.Navigation("SubTopic");
                });

            modelBuilder.Entity("DashboardApp.Data.Entity.MainTopic", b =>
                {
                    b.Navigation("SubTopics");
                });

            modelBuilder.Entity("DashboardApp.Data.Entity.SubTopic", b =>
                {
                    b.Navigation("Infos");

                    b.Navigation("URLs");
                });
#pragma warning restore 612, 618
        }
    }
}
