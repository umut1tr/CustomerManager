using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManager.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerDescriptionField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerConsultant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerProjectLead = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerActivitySelection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerData");
        }
    }
}
