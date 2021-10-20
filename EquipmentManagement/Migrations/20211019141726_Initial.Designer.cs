﻿// <auto-generated />
using System;
using Equipment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EquipmentManagement.Migrations
{
    [DbContext(typeof(EquipmentDBContext))]
    [Migration("20211019141726_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Equipment.Models.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("equipment_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit")
                        .HasColumnName("is_available");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .HasColumnName("type")
                        .IsFixedLength(true);

                    b.HasKey("EquipmentId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("Equipment.Models.Ticket", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int")
                        .HasColumnName("equipment_id");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("date")
                        .HasColumnName("borrow_date");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("date")
                        .HasColumnName("return_date");

                    b.HasKey("UserId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Equipment.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("is_admin");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .HasColumnName("user_name")
                        .IsFixedLength(true);

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Equipment.Models.Ticket", b =>
                {
                    b.HasOne("Equipment.Models.Equipment", "Equipment")
                        .WithMany("Tickets")
                        .HasForeignKey("EquipmentId")
                        .HasConstraintName("FK_Ticket_Equipment")
                        .IsRequired();

                    b.HasOne("Equipment.Models.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Ticket_User")
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Equipment.Models.Equipment", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Equipment.Models.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
