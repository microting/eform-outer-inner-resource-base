using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormMachineAreaBase.Infrastructure.Migrations
{
    public partial class SmallRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MicrotingEFormSdkId",
                table: "MachineAreaSiteVersions",
                newName: "MicrotingSdkeFormId");

            migrationBuilder.RenameColumn(
                name: "MicrotingEFormSdkId",
                table: "MachineAreaSites",
                newName: "MicrotingSdkeFormId");

            migrationBuilder.AddColumn<int>(
                name: "MicrotingSdkCaseId",
                table: "MachineAreaSiteVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MicrotingSdkCaseId",
                table: "MachineAreaSites",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MicrotingSdkCaseId",
                table: "MachineAreaSiteVersions");

            migrationBuilder.DropColumn(
                name: "MicrotingSdkCaseId",
                table: "MachineAreaSites");

            migrationBuilder.RenameColumn(
                name: "MicrotingSdkeFormId",
                table: "MachineAreaSiteVersions",
                newName: "MicrotingEFormSdkId");

            migrationBuilder.RenameColumn(
                name: "MicrotingSdkeFormId",
                table: "MachineAreaSites",
                newName: "MicrotingEFormSdkId");
        }
    }
}
