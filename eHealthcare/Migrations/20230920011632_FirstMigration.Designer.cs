﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eHealthcare.Data;

#nullable disable

namespace eHealthcare.Migrations
{
    [DbContext(typeof(eHealthcareContext))]
    [Migration("20230920011632_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eHealthcare.Entities.ATCCode", b =>
                {
                    b.Property<int>("ATCCodeId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ATCCodeId");

                    b.ToTable("ATCCode");
                });

            modelBuilder.Entity("eHealthcare.Entities.ActiveIngredient", b =>
                {
                    b.Property<int>("ActiveIngredientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActiveIngredientId");

                    b.ToTable("ActiveIngredients");
                });

            modelBuilder.Entity("eHealthcare.Entities.PharmaceuticalForm", b =>
                {
                    b.Property<int>("PharmaceuticalFormId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PharmaceuticalFormId");

                    b.ToTable("PharmaceuticalForms");
                });

            modelBuilder.Entity("eHealthcare.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ATCCodeID")
                        .HasColumnType("int");

                    b.Property<int>("ActiveIngredientID")
                        .HasColumnType("int");

                    b.Property<string>("Classifications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompetentAuthorityStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PharmaceuticalFormID")
                        .HasColumnType("int");

                    b.Property<int>("ProductUnitID")
                        .HasColumnType("int");

                    b.Property<int>("TherapeuticClassID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ATCCodeID");

                    b.HasIndex("ActiveIngredientID");

                    b.HasIndex("PharmaceuticalFormID");

                    b.HasIndex("ProductUnitID");

                    b.HasIndex("TherapeuticClassID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("eHealthcare.Entities.ProductUnit", b =>
                {
                    b.Property<int>("ProductUnitId")
                        .HasColumnType("int");

                    b.Property<string>("UnitValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductUnitId");

                    b.ToTable("ProductUnits");
                });

            modelBuilder.Entity("eHealthcare.Entities.TherapeuticClass", b =>
                {
                    b.Property<int>("TherapeuticClassId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TherapeuticClassId");

                    b.ToTable("TherapeuticClass");
                });

            modelBuilder.Entity("eHealthcare.Entities.Product", b =>
                {
                    b.HasOne("eHealthcare.Entities.ATCCode", "ATCCode")
                        .WithMany("Products")
                        .HasForeignKey("ATCCodeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eHealthcare.Entities.ActiveIngredient", "ActiveIngredient")
                        .WithMany("Products")
                        .HasForeignKey("ActiveIngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eHealthcare.Entities.PharmaceuticalForm", "PharmaceuticalForm")
                        .WithMany("Products")
                        .HasForeignKey("PharmaceuticalFormID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eHealthcare.Entities.ProductUnit", "ProductUnit")
                        .WithMany("Products")
                        .HasForeignKey("ProductUnitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eHealthcare.Entities.TherapeuticClass", "TherapeuticClass")
                        .WithMany("Products")
                        .HasForeignKey("TherapeuticClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ATCCode");

                    b.Navigation("ActiveIngredient");

                    b.Navigation("PharmaceuticalForm");

                    b.Navigation("ProductUnit");

                    b.Navigation("TherapeuticClass");
                });

            modelBuilder.Entity("eHealthcare.Entities.ATCCode", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("eHealthcare.Entities.ActiveIngredient", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("eHealthcare.Entities.PharmaceuticalForm", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("eHealthcare.Entities.ProductUnit", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("eHealthcare.Entities.TherapeuticClass", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
