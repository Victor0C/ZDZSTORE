using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZDZSTORE.Migrations
{
    /// <inheritdoc />
    public partial class CretaSaleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    userID = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    customerCPF = table.Column<long>(type: "bigint", nullable: false),
                    price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sales_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_userID",
                table: "Sales",
                column: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
