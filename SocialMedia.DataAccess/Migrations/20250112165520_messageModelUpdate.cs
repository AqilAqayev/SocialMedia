using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class messageModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SendNatfications_AspNetUsers_UserId",
                table: "SendNatfications");

            migrationBuilder.DropIndex(
                name: "IX_SendNatfications_UserId",
                table: "SendNatfications");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SendNatfications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "SendNatfications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_SendNatfications_SenderId",
                table: "SendNatfications",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_SendNatfications_AspNetUsers_SenderId",
                table: "SendNatfications",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SendNatfications_AspNetUsers_SenderId",
                table: "SendNatfications");

            migrationBuilder.DropIndex(
                name: "IX_SendNatfications_SenderId",
                table: "SendNatfications");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SendNatfications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "SendNatfications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_SendNatfications_UserId",
                table: "SendNatfications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SendNatfications_AspNetUsers_UserId",
                table: "SendNatfications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
