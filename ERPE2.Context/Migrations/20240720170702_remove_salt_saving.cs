using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPE2.Context.Migrations
{
    /// <inheritdoc />
    public partial class remove_salt_saving : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
