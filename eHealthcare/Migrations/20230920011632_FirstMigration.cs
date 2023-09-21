using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHealthcare.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveIngredients",
                columns: table => new
                {
                    ActiveIngredientId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveIngredients", x => x.ActiveIngredientId);
                });

            migrationBuilder.CreateTable(
                name: "ATCCode",
                columns: table => new
                {
                    ATCCodeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATCCode", x => x.ATCCodeId);
                });

            migrationBuilder.CreateTable(
                name: "PharmaceuticalForms",
                columns: table => new
                {
                    PharmaceuticalFormId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaceuticalForms", x => x.PharmaceuticalFormId);
                });

            migrationBuilder.CreateTable(
                name: "ProductUnits",
                columns: table => new
                {
                    ProductUnitId = table.Column<int>(type: "int", nullable: false),
                    UnitValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUnits", x => x.ProductUnitId);
                });

            migrationBuilder.CreateTable(
                name: "TherapeuticClass",
                columns: table => new
                {
                    TherapeuticClassId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapeuticClass", x => x.TherapeuticClassId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompetentAuthorityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveIngredientID = table.Column<int>(type: "int", nullable: false),
                    PharmaceuticalFormID = table.Column<int>(type: "int", nullable: false),
                    ProductUnitID = table.Column<int>(type: "int", nullable: false),
                    ATCCodeID = table.Column<int>(type: "int", nullable: false),
                    TherapeuticClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ATCCode_ATCCodeID",
                        column: x => x.ATCCodeID,
                        principalTable: "ATCCode",
                        principalColumn: "ATCCodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ActiveIngredients_ActiveIngredientID",
                        column: x => x.ActiveIngredientID,
                        principalTable: "ActiveIngredients",
                        principalColumn: "ActiveIngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_PharmaceuticalForms_PharmaceuticalFormID",
                        column: x => x.PharmaceuticalFormID,
                        principalTable: "PharmaceuticalForms",
                        principalColumn: "PharmaceuticalFormId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductUnits_ProductUnitID",
                        column: x => x.ProductUnitID,
                        principalTable: "ProductUnits",
                        principalColumn: "ProductUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_TherapeuticClass_TherapeuticClassID",
                        column: x => x.TherapeuticClassID,
                        principalTable: "TherapeuticClass",
                        principalColumn: "TherapeuticClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ActiveIngredientID",
                table: "Product",
                column: "ActiveIngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ATCCodeID",
                table: "Product",
                column: "ATCCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PharmaceuticalFormID",
                table: "Product",
                column: "PharmaceuticalFormID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductUnitID",
                table: "Product",
                column: "ProductUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TherapeuticClassID",
                table: "Product",
                column: "TherapeuticClassID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ATCCode");

            migrationBuilder.DropTable(
                name: "ActiveIngredients");

            migrationBuilder.DropTable(
                name: "PharmaceuticalForms");

            migrationBuilder.DropTable(
                name: "ProductUnits");

            migrationBuilder.DropTable(
                name: "TherapeuticClass");
        }
    }
}
