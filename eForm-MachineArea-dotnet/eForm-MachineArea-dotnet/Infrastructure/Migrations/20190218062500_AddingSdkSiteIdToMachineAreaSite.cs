using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormMachineAreaBase.Migrations
{
    public partial class AddingSdkSiteIdToMachineAreaSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MicrotingSdkSiteId",
                table: "MachineAreaSiteVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MicrotingSdkSiteId",
                table: "MachineAreaSites",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MicrotingSdkSiteId",
                table: "MachineAreaSiteVersions");

            migrationBuilder.DropColumn(
                name: "MicrotingSdkSiteId",
                table: "MachineAreaSites");
        }
    }
}
