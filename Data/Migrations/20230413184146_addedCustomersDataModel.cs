using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManager.Data.Migrations
{
    public partial class addedCustomersDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerStatus",
                table: "CustomerData",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "CustomerData",
                newName: "CustomerStatus");
        }
    }
}
