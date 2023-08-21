using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingApp.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Update_Photo_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Photos");

            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "Photos",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
