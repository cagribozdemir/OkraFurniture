using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_order_edits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FabricColors_FabricColorId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Feet_FootId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FabricColorId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FootId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FabricColorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FootId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FabricColorId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FootId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FabricColorId",
                table: "Orders",
                column: "FabricColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FootId",
                table: "Orders",
                column: "FootId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FabricColors_FabricColorId",
                table: "Orders",
                column: "FabricColorId",
                principalTable: "FabricColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Feet_FootId",
                table: "Orders",
                column: "FootId",
                principalTable: "Feet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
