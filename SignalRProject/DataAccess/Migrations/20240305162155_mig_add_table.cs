using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migaddtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "TableNumberId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TableNumber",
                columns: table => new
                {
                    TableNumberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Table = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableNumber", x => x.TableNumberId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableNumberId",
                table: "Orders",
                column: "TableNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TableNumber_TableNumberId",
                table: "Orders",
                column: "TableNumberId",
                principalTable: "TableNumber",
                principalColumn: "TableNumberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TableNumber_TableNumberId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "TableNumber");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TableNumberId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TableNumberId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "TableNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
