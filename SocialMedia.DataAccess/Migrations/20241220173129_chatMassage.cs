using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class chatMassage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_AspNetUsers_FromUserId",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_AspNetUsers_ToUserId",
                table: "messages");

            migrationBuilder.DropIndex(
                name: "IX_messages_ToUserId",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "ToUserId",
                table: "messages");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "messages",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_messages_FromUserId",
                table: "messages",
                newName: "IX_messages_SenderId");

            migrationBuilder.AddColumn<int>(
                name: "ChatId",
                table: "messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserChat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserChat_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserChat_Chat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_messages_ChatId",
                table: "messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserChat_AppUserId",
                table: "AppUserChat",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserChat_ChatId",
                table: "AppUserChat",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_AspNetUsers_SenderId",
                table: "messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_Chat_ChatId",
                table: "messages",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_AspNetUsers_SenderId",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_Chat_ChatId",
                table: "messages");

            migrationBuilder.DropTable(
                name: "AppUserChat");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_messages_ChatId",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "messages");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "messages",
                newName: "FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_messages_SenderId",
                table: "messages",
                newName: "IX_messages_FromUserId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ToUserId",
                table: "messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_messages_ToUserId",
                table: "messages",
                column: "ToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_AspNetUsers_FromUserId",
                table: "messages",
                column: "FromUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_AspNetUsers_ToUserId",
                table: "messages",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
