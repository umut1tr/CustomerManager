using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManager.Data.Migrations
{
    public partial class cleanedCustomersData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "CustomerData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "CustomerData");
        }
    }
}
