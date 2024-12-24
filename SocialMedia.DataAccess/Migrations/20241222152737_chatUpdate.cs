using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class chatUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserChat_AspNetUsers_AppUserId",
                table: "AppUserChat");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserChat_Chat_ChatId",
                table: "AppUserChat");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_AspNetUsers_SenderId",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_Chat_ChatId",
                table: "messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_messages",
                table: "messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chat",
                table: "Chat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserChat",
                table: "AppUserChat");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "messages",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "Chat",
                newName: "Chats");

            migrationBuilder.RenameTable(
                name: "AppUserChat",
                newName: "AppUserChats");

            migrationBuilder.RenameIndex(
                name: "IX_messages_SenderId",
                table: "Messages",
                newName: "IX_Messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_messages_ChatId",
                table: "Messages",
                newName: "IX_Messages_ChatId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comments_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserChat_ChatId",
                table: "AppUserChats",
                newName: "IX_AppUserChats_ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserChat_AppUserId",
                table: "AppUserChats",
                newName: "IX_AppUserChats_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserChats",
                table: "AppUserChats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserChats_AspNetUsers_AppUserId",
                table: "AppUserChats",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserChats_Chats_ChatId",
                table: "AppUserChats",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments",
                column: "ParentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserChats_AspNetUsers_AppUserId",
                table: "AppUserChats");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserChats_Chats_ChatId",
                table: "AppUserChats");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserChats",
                table: "AppUserChats");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "messages");

            migrationBuilder.RenameTable(
                name: "Chats",
                newName: "Chat");

            migrationBuilder.RenameTable(
                name: "AppUserChats",
                newName: "AppUserChat");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderId",
                table: "messages",
                newName: "IX_messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatId",
                table: "messages",
                newName: "IX_messages_ChatId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserChats_ChatId",
                table: "AppUserChat",
                newName: "IX_AppUserChat_ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserChats_AppUserId",
                table: "AppUserChat",
                newName: "IX_AppUserChat_AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_messages",
                table: "messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chat",
                table: "Chat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserChat",
                table: "AppUserChat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserChat_AspNetUsers_AppUserId",
                table: "AppUserChat",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserChat_Chat_ChatId",
                table: "AppUserChat",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
