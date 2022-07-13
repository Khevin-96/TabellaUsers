using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabellaUsers.Migrations
{
    public partial class pivot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Azienda",
                columns: table => new
                {
                    IdAzienda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAzienda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Azienda", x => x.IdAzienda);
                });

            migrationBuilder.CreateTable(
                name: "Contratto",
                columns: table => new
                {
                    IdContract = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameContract = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratto", x => x.IdContract);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Azienda_Id = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Azienda_Azienda_Id",
                        column: x => x.Azienda_Id,
                        principalTable: "Azienda",
                        principalColumn: "IdAzienda");
                });

            migrationBuilder.CreateTable(
                name: "ContractUsersPivot",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Contract_id = table.Column<int>(type: "int", nullable: false),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractUsersPivot", x => new { x.User_id, x.Contract_id });
                    table.ForeignKey(
                        name: "FK_ContractUsersPivot_Contratto_Contract_id",
                        column: x => x.Contract_id,
                        principalTable: "Contratto",
                        principalColumn: "IdContract",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractUsersPivot_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractUsersPivot_Contract_id",
                table: "ContractUsersPivot",
                column: "Contract_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Azienda_Id",
                table: "Users",
                column: "Azienda_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractUsersPivot");

            migrationBuilder.DropTable(
                name: "Contratto");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Azienda");
        }
    }
}
