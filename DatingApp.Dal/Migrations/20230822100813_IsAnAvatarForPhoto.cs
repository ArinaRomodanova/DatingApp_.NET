using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingApp.Dal.Migrations
{
    /// <inheritdoc />
    public partial class IsAnAvatarForPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnAvatar",
                table: "Photos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnAvatar",
                table: "Photos");
        }
    }
}
