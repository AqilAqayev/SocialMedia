using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BaseAuditableEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "StoryVideos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "StoryVideos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StoryVideos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "StoryVideos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "StoryVideos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "StoryImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "StoryImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StoryImage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "StoryImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "StoryImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Stories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Stories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Stories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Stories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SendNatfications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "SendNatfications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SendNatfications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SendNatfications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "SendNatfications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PostVideos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "PostVideos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostVideos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PostVideos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "PostVideos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PostLikes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "PostLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostLikes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PostLikes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "PostLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PostImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "PostImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PostImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "PostImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Follows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Follows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Follows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Follows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Follows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FollowConnections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "FollowConnections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FollowConnections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "FollowConnections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "FollowConnections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CommentLikes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "CommentLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CommentLikes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CommentLikes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "CommentLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Chats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AppUserChats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "AppUserChats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppUserChats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "AppUserChats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "AppUserChats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StoryVideos");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "StoryVideos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StoryVideos");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "StoryVideos");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "StoryVideos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StoryImage");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "StoryImage");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StoryImage");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "StoryImage");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "StoryImage");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SendNatfications");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "SendNatfications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SendNatfications");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SendNatfications");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "SendNatfications");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PostVideos");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "PostVideos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostVideos");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PostVideos");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "PostVideos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PostImages");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "PostImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostImages");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PostImages");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "PostImages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FollowConnections");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "FollowConnections");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FollowConnections");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "FollowConnections");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "FollowConnections");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AppUserChats");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "AppUserChats");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppUserChats");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AppUserChats");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "AppUserChats");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
