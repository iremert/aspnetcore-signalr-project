using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migaddbrandcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Cars",
                newName: "BrandID");

            migrationBuilder.AddColumn<int>(
                name: "BrandsBrandId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandsBrandId",
                table: "Cars",
                column: "BrandsBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandsBrandId",
                table: "Cars",
                column: "BrandsBrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandsBrandId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_BrandsBrandId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "BrandsBrandId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "BrandID",
                table: "Cars",
                newName: "Brand");
        }
    }
}
