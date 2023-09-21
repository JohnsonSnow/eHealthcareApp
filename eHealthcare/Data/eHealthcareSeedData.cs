using eHealthcare.Entities;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace eHealthcare.Data
{
    public static class eHealthcareSeedData 
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ATCCode>().HasData(
               new { ATCCodeId = 1, Code = "A01AA01" },
               new { ATCCodeId = 2, Code = "A01AB03" },
               new { ATCCodeId = 3, Code = "A01AB09" },
               new { ATCCodeId = 4, Code = "A01AB11" },
               new { ATCCodeId = 5, Code = "A01AB12" },
               new { ATCCodeId = 6, Code = "A01AB13" },
               new { ATCCodeId = 7, Code = "A01AB17" },
               new { ATCCodeId = 8, Code = "A01AD02" },
               new { ATCCodeId = 9, Code = "A01AD11" },
               new { ATCCodeId = 10, Code = "A02AA01" },
               new { ATCCodeId = 11, Code = "A02AA04" },
               new { ATCCodeId = 12, Code = "A02AB10" },
               new { ATCCodeId = 13, Code = "A02AC01" },
               new { ATCCodeId = 14, Code = "A02AD01" },
               new { ATCCodeId = 15, Code = "A02AF02" },
               new { ATCCodeId = 16, Code = "A02AH" },
               new { ATCCodeId = 17, Code = "A02AX" },
               new { ATCCodeId = 18, Code = "A02BA" },
               new { ATCCodeId = 19, Code = "A02BA01" },
               new { ATCCodeId = 20, Code = "A02BA02" },
               new { ATCCodeId = 21, Code = "A02BA03" },
               new { ATCCodeId = 22, Code = "A02BB01" },
               new { ATCCodeId = 23, Code = "A02BC01" },
               new { ATCCodeId = 24, Code = "A02BC02" },
               new { ATCCodeId = 25, Code = "A02BC03" },
               new { ATCCodeId = 26, Code = "A02BC04" },
               new { ATCCodeId = 27, Code = "A02BC05" },
               new { ATCCodeId = 28, Code = "R07AA02" },
               new { ATCCodeId = 29, Code = "A02BX" }
               );

            modelBuilder.Entity<ActiveIngredient>().HasData(
                new { ActiveIngredientId = 1, Name = "PHOSPHOLIPIDS 80 milligram(s)/millilitre" },
                new { ActiveIngredientId = 2, Name = "CHLORHEXIDINE DIGLUCONATE 0.2 percent weight/volume" }
                );

            modelBuilder.Entity<PharmaceuticalForm>().HasData(
               new { PharmaceuticalFormId = 1, Name = "ENDOTRACHEOPULMONARY INSTILLATION, SUSPENSION" },
               new { PharmaceuticalFormId = 2, Name = "OROMUCOSAL SOLUTION" }
               );

            modelBuilder.Entity<TherapeuticClass>().HasData(
              new { TherapeuticClassId = 1, Name = "STOMATOLOGICAL PREPARATIONS" },
              new { TherapeuticClassId = 2, Name = "DRUGS FOR ACID RELATED DISORDERS" },
              new { TherapeuticClassId = 3, Name = "OTHER RESPIRATORY SYSTEM PRODUCTS" }
              );
            
            modelBuilder.Entity<ProductUnit>().HasData(
              new { ProductUnitId = 1, UnitValue = "mg(s)/ml(s)" },
              new { ProductUnitId = 2, UnitValue = "mg(s)" },
              new { ProductUnitId = 3, UnitValue = "ml(s)" },
              new { ProductUnitId = 4, UnitValue = "drop(s)" },
              new { ProductUnitId = 5, UnitValue = "tablet(s)" },
              new { ProductUnitId = 6, UnitValue = "capsule(s)" },
              new { ProductUnitId = 7, UnitValue = "lozenge(s)" },
              new { ProductUnitId = 8, UnitValue = "granule(s)" },
              new { ProductUnitId = 9, UnitValue = "spray" }
              );
        }
    }
}
