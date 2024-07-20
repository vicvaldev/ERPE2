using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERPE2.Context.Migrations
{
    /// <inheritdoc />
    public partial class correction_entity_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_CaseTypes_CaseTypeId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Colors_ColorId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_CaseTypeId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_ColorId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "CaseTypeId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Models");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Models",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: true),
                    ColorId = table.Column<int>(type: "integer", nullable: true),
                    CaseTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_CaseTypes_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "CaseTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cases_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cases_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseTypeId",
                table: "Cases",
                column: "CaseTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ColorId",
                table: "Cases",
                column: "ColorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ModelId",
                table: "Cases",
                column: "ModelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Models",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CaseTypeId",
                table: "Models",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Models",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_CaseTypeId",
                table: "Models",
                column: "CaseTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_ColorId",
                table: "Models",
                column: "ColorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_CaseTypes_CaseTypeId",
                table: "Models",
                column: "CaseTypeId",
                principalTable: "CaseTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Colors_ColorId",
                table: "Models",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");
        }
    }
}
