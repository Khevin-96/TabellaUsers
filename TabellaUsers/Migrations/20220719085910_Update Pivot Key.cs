using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabellaUsers.Migrations
{
    public partial class UpdatePivotKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractUsersPivot",
                table: "ContractUsersPivot");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "ContractUsersPivot",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractUsersPivot",
                table: "ContractUsersPivot",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_ContractUsersPivot_User_id",
                table: "ContractUsersPivot",
                column: "User_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractUsersPivot",
                table: "ContractUsersPivot");

            migrationBuilder.DropIndex(
                name: "IX_ContractUsersPivot_User_id",
                table: "ContractUsersPivot");

            migrationBuilder.DropColumn(
                name: "id",
                table: "ContractUsersPivot");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractUsersPivot",
                table: "ContractUsersPivot",
                columns: new[] { "User_id", "Contract_id" });
        }
    }
}
