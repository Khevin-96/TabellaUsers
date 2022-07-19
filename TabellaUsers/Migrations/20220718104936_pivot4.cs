using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabellaUsers.Migrations
{
    public partial class pivot4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isdeleted",
                table: "ContractUsersPivot",
                newName: "isDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "ContractUsersPivot",
                newName: "isdeleted");
        }
    }
}
