using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminGym.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migration_UserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "SecondName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaternalSurname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaternalSurname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaternalSurname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PaternalSurname",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "AspNetUsers",
                newName: "FullName");
        }
    }
}
