using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_last_order_editing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderProcess",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Kaputhane",
                table: "Products",
                newName: "IsKaputhane");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsKaputhane",
                table: "Products",
                newName: "Kaputhane");

            migrationBuilder.AddColumn<int>(
                name: "OrderProcess",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
