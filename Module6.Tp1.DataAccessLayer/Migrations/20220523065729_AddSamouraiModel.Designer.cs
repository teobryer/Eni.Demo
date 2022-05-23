﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Module6.Tp1.DataAccessLayer;

namespace Module6.Tp1.DataAccessLayer.Migrations
{
    [DbContext(typeof(DojoContext))]
    [Migration("20220523065729_AddSamouraiModel")]
    partial class AddSamouraiModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Module6.Tp1.DataAccessLayer.Entities.Arme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Degats")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Armes");
                });

            modelBuilder.Entity("Module6.Tp1.DataAccessLayer.Entities.Samourai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArmeId")
                        .HasColumnType("int");

                    b.Property<int>("Force")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArmeId");

                    b.ToTable("Samourais");
                });

            modelBuilder.Entity("Module6.Tp1.DataAccessLayer.Entities.Samourai", b =>
                {
                    b.HasOne("Module6.Tp1.DataAccessLayer.Entities.Arme", "Arme")
                        .WithMany()
                        .HasForeignKey("ArmeId");

                    b.Navigation("Arme");
                });
#pragma warning restore 612, 618
        }
    }
}
