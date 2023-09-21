using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eHealthcare.Entities;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace eHealthcare.Data
{
    public class eHealthcareContext : DbContext
    {
        public eHealthcareContext (DbContextOptions<eHealthcareContext> options)
            : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as IRelationalDatabaseCreator;
                if (databaseCreator != null )
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public eHealthcareContext()
        {

        }

        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<ActiveIngredient> ActiveIngredients { get; set; } = default!;
        public DbSet<PharmaceuticalForm> PharmaceuticalForms { get; set; } = default!;
        public DbSet<ProductUnit> ProductUnits { get; set; } = default!;
        public DbSet<ATCCode> ATCCode { get; set; } = default!;
        public DbSet<TherapeuticClass> TherapeuticClass { get; set; } = default!;


       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships using Fluent API...
            //modelBuilder.Entity<ActiveIngredient>()
            //    .HasOne<Product>(ad => ad.Product)
            //    .WithOne(s => s.ActiveIngredient)
            //    .HasForeignKey<ActiveIngredient>(ad => ad.ProductOfActiveIngredientId);

            //modelBuilder.Entity<PharmaceuticalForm>()
            //   .HasOne<Product>(ad => ad.Product)
            //   .WithOne(s => s.PharmaceuticalForm)
            //   .HasForeignKey<PharmaceuticalForm>(ad => ad.ProductOfPharmaceuticalFormId);

            //modelBuilder.Entity<ProductUnit>()
            //  .HasOne<Product>(ad => ad.Product)
            //  .WithOne(s => s.ProductUnit)
            //  .HasForeignKey<ProductUnit>(ad => ad.ProductOfProductUnitId);

            //modelBuilder.Entity<ATCCode>()
            //  .HasOne<Product>(ad => ad.Product)
            //  .WithOne(s => s.ATCCode)
            //  .HasForeignKey<ATCCode>(ad => ad.ProductOfATCCodeId);

            //modelBuilder.Entity<TherapeuticClass>()
            //  .HasOne<Product>(ad => ad.Product)
            //  .WithOne(s => s.TherapeuticClass)
            //  .HasForeignKey<TherapeuticClass>(ad => ad.ProductOfTherapeuticClassId);

           

            modelBuilder.Entity<ATCCode>()
              .Property(p => p.ATCCodeId)
              .ValueGeneratedNever();

            modelBuilder.Entity<TherapeuticClass>()
              .Property(p => p.TherapeuticClassId)
              .ValueGeneratedNever();

            modelBuilder.Entity<ProductUnit>()
              .Property(p => p.ProductUnitId)
              .ValueGeneratedNever();

            modelBuilder.Entity<PharmaceuticalForm>()
              .Property(p => p.PharmaceuticalFormId)
              .ValueGeneratedNever();

            modelBuilder.Entity<ActiveIngredient>()
              .Property(p => p.ActiveIngredientId)
              .ValueGeneratedNever();

            modelBuilder.Seed();
        }
    }

}
