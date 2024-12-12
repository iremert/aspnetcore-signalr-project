using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migaddtableagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TableNumber_TableNumberId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TableNumber",
                table: "TableNumber");

            migrationBuilder.RenameTable(
                name: "TableNumber",
                newName: "TableNumbers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableNumbers",
                table: "TableNumbers",
                column: "TableNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TableNumbers_TableNumberId",
                table: "Orders",
                column: "TableNumberId",
                principalTable: "TableNumbers",
                principalColumn: "TableNumberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TableNumbers_TableNumberId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TableNumbers",
                table: "TableNumbers");

            migrationBuilder.RenameTable(
                name: "TableNumbers",
                newName: "TableNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableNumber",
                table: "TableNumber",
                column: "TableNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TableNumber_TableNumberId",
                table: "Orders",
                column: "TableNumberId",
                principalTable: "TableNumber",
                principalColumn: "TableNumberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
