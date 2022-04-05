using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_Media_App_Api_.Net_Core.Migrations
{
    public partial class useridadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_postModelD_AspNetUsers_appUserId",
                table: "postModelD");

            migrationBuilder.AlterColumn<string>(
                name: "photoName",
                table: "postModelD",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "appUserId",
                table: "postModelD",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_postModelD_AspNetUsers_appUserId",
                table: "postModelD",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_postModelD_AspNetUsers_appUserId",
                table: "postModelD");

            migrationBuilder.AlterColumn<string>(
                name: "photoName",
                table: "postModelD",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "appUserId",
                table: "postModelD",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_postModelD_AspNetUsers_appUserId",
                table: "postModelD",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
