using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeStore.Data.Migrations
{
    public partial class BikeTableDrivetrainUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriveTrain",
                table: "Bikes",
                newName: "Drivetrain");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Drivetrain",
                table: "Bikes",
                newName: "DriveTrain");
        }
    }
}
