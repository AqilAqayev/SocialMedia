using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class natficationSend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SewnderId",
                table: "SendNatfications",
                newName: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "SendNatfications",
                newName: "SewnderId");
        }
    }
}
