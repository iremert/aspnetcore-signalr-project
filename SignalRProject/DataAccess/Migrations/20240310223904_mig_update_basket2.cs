using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migupdatebasket2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableNumberId1",
                table: "TableNumbers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableNumbers_TableNumberId1",
                table: "TableNumbers",
                column: "TableNumberId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TableNumbers_TableNumbers_TableNumberId1",
                table: "TableNumbers",
                column: "TableNumberId1",
                principalTable: "TableNumbers",
                principalColumn: "TableNumberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableNumbers_TableNumbers_TableNumberId1",
                table: "TableNumbers");

            migrationBuilder.DropIndex(
                name: "IX_TableNumbers_TableNumberId1",
                table: "TableNumbers");

            migrationBuilder.DropColumn(
                name: "TableNumberId1",
                table: "TableNumbers");
        }
    }
}
