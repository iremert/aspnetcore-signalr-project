using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migupdatebasket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Cars_CarID",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "CarID",
                table: "Baskets",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Baskets_CarID",
                table: "Baskets",
                newName: "IX_Baskets_CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Cars_CarId",
                table: "Baskets",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Cars_CarId",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Baskets",
                newName: "CarID");

            migrationBuilder.RenameIndex(
                name: "IX_Baskets_CarId",
                table: "Baskets",
                newName: "IX_Baskets_CarID");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Cars_CarID",
                table: "Baskets",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
