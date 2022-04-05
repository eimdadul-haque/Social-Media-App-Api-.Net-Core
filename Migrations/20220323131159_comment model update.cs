using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_Media_App_Api_.Net_Core.Migrations
{
    public partial class commentmodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_commentD_AspNetUsers_appUserId",
                table: "commentD");

            migrationBuilder.DropForeignKey(
                name: "FK_postModelD_AspNetUsers_appUserId",
                table: "postModelD");

            migrationBuilder.AlterColumn<string>(
                name: "appUserId",
                table: "postModelD",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "appUserId",
                table: "commentD",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_commentD_AspNetUsers_appUserId",
                table: "commentD",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_postModelD_AspNetUsers_appUserId",
                table: "postModelD",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_commentD_AspNetUsers_appUserId",
                table: "commentD");

            migrationBuilder.DropForeignKey(
                name: "FK_postModelD_AspNetUsers_appUserId",
                table: "postModelD");

            migrationBuilder.AlterColumn<string>(
                name: "appUserId",
                table: "postModelD",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "appUserId",
                table: "commentD",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_commentD_AspNetUsers_appUserId",
                table: "commentD",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_postModelD_AspNetUsers_appUserId",
                table: "postModelD",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
