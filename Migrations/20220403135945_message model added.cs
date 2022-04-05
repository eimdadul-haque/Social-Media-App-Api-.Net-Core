using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_Media_App_Api_.Net_Core.Migrations
{
    public partial class messagemodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_commentD_AspNetUsers_appUserId",
                table: "commentD");

            migrationBuilder.AlterColumn<string>(
                name: "appUserId",
                table: "commentD",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "messageD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    msgBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    when = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messageD", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_commentD_AspNetUsers_appUserId",
                table: "commentD",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_commentD_AspNetUsers_appUserId",
                table: "commentD");

            migrationBuilder.DropTable(
                name: "messageD");

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
        }
    }
}
