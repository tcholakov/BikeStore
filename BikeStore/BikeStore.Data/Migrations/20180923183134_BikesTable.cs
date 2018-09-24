using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeStore.Data.Migrations
{
    public partial class BikesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(maxLength: 150, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    FrameType = table.Column<int>(nullable: false),
                    Frame = table.Column<string>(maxLength: 150, nullable: false),
                    Handlebar = table.Column<string>(maxLength: 150, nullable: false),
                    Brakes = table.Column<string>(maxLength: 150, nullable: false),
                    DriveTrain = table.Column<string>(maxLength: 150, nullable: false),
                    Suspension = table.Column<int>(nullable: false),
                    Fork = table.Column<string>(maxLength: 150, nullable: false),
                    RearSuspension = table.Column<string>(maxLength: 150, nullable: true),
                    Seatpost = table.Column<string>(maxLength: 150, nullable: true),
                    Saddle = table.Column<string>(maxLength: 150, nullable: false),
                    TireType = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Gears = table.Column<string>(maxLength: 150, nullable: true),
                    Battery = table.Column<string>(maxLength: 150, nullable: true),
                    ElectricMotor = table.Column<string>(maxLength: 150, nullable: true),
                    Tires = table.Column<string>(maxLength: 150, nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 450, nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_UserId",
                table: "Bikes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
