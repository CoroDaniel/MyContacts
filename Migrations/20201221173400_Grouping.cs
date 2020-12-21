using Microsoft.EntityFrameworkCore.Migrations;

namespace MyContacts.Migrations
{
    public partial class Grouping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupingID",
                table: "PhoneBook",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Grouping",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupingName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grouping", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBook_GroupingID",
                table: "PhoneBook",
                column: "GroupingID");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneBook_Grouping_GroupingID",
                table: "PhoneBook",
                column: "GroupingID",
                principalTable: "Grouping",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneBook_Grouping_GroupingID",
                table: "PhoneBook");

            migrationBuilder.DropTable(
                name: "Grouping");

            migrationBuilder.DropIndex(
                name: "IX_PhoneBook_GroupingID",
                table: "PhoneBook");

            migrationBuilder.DropColumn(
                name: "GroupingID",
                table: "PhoneBook");
        }
    }
}
