using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormMachineAreaBase.Migrations
{
    public partial class AddingMissingAttributesToMachineAreaTimeRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SDKSiteId",
                table: "MachineAreaTimeRegistrations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeInHours",
                table: "MachineAreaTimeRegistrations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeInMinutes",
                table: "MachineAreaTimeRegistrations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SDKSiteId",
                table: "MachineAreaTimeRegistrations");

            migrationBuilder.DropColumn(
                name: "TimeInHours",
                table: "MachineAreaTimeRegistrations");

            migrationBuilder.DropColumn(
                name: "TimeInMinutes",
                table: "MachineAreaTimeRegistrations");
        }
    }
}
