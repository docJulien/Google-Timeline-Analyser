using Microsoft.EntityFrameworkCore.Migrations;

namespace APS.Migrations
{
    public partial class UploadDatav2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivityType",
                table: "UploadData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Distance",
                table: "UploadData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "UploadData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityType",
                table: "UploadData");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "UploadData");

            migrationBuilder.DropColumn(
                name: "User",
                table: "UploadData");
        }
    }
}
