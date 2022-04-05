using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_Media_App_Api_.Net_Core.Migrations
{
    public partial class messagemodelupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userName",
                table: "messageD",
                newName: "sender");

            migrationBuilder.AddColumn<string>(
                name: "receiver",
                table: "messageD",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "receiver",
                table: "messageD");

            migrationBuilder.RenameColumn(
                name: "sender",
                table: "messageD",
                newName: "userName");
        }
    }
}
