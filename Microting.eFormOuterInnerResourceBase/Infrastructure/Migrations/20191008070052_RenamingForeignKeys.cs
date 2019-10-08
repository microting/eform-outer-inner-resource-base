using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormOuterInnerResourceBase.Infrastructure.Migrations
{
    public partial class RenamingForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "ResourceTimeRegistrationVersions",
                newName: "OuterResourceId");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "ResourceTimeRegistrationVersions",
                newName: "InnerResourceId");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "ResourceTimeRegistrations",
                newName: "OuterResourceId");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "ResourceTimeRegistrations",
                newName: "InnerResourceId");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "OuterResourceVersions",
                newName: "OuterResourceId");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "OuterInnerResourceVersions",
                newName: "OuterResourceId");

            migrationBuilder.RenameColumn(
                name: "MachineAreaId",
                table: "OuterInnerResourceVersions",
                newName: "OuterInnerResourceId");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "OuterInnerResourceVersions",
                newName: "InnerResourceId");

            migrationBuilder.RenameColumn(
                name: "MachineAreaSiteId",
                table: "OuterInnerResourceSiteVersions",
                newName: "OuterInnerResourceSiteId");

            migrationBuilder.RenameColumn(
                name: "MachineAreaId",
                table: "OuterInnerResourceSiteVersions",
                newName: "OuterInnerResourceId");

            migrationBuilder.RenameColumn(
                name: "MachineAreaId",
                table: "OuterInnerResourceSites",
                newName: "OuterInnerResourceId");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "OuterInnerResources",
                newName: "OuterResourceId");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "OuterInnerResources",
                newName: "InnerResourceId");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "InnerResourceVersions",
                newName: "InnerResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OuterResourceId",
                table: "ResourceTimeRegistrationVersions",
                newName: "MachineId");

            migrationBuilder.RenameColumn(
                name: "InnerResourceId",
                table: "ResourceTimeRegistrationVersions",
                newName: "AreaId");

            migrationBuilder.RenameColumn(
                name: "OuterResourceId",
                table: "ResourceTimeRegistrations",
                newName: "MachineId");

            migrationBuilder.RenameColumn(
                name: "InnerResourceId",
                table: "ResourceTimeRegistrations",
                newName: "AreaId");

            migrationBuilder.RenameColumn(
                name: "OuterResourceId",
                table: "OuterResourceVersions",
                newName: "AreaId");

            migrationBuilder.RenameColumn(
                name: "OuterResourceId",
                table: "OuterInnerResourceVersions",
                newName: "MachineId");

            migrationBuilder.RenameColumn(
                name: "OuterInnerResourceId",
                table: "OuterInnerResourceVersions",
                newName: "MachineAreaId");

            migrationBuilder.RenameColumn(
                name: "InnerResourceId",
                table: "OuterInnerResourceVersions",
                newName: "AreaId");

            migrationBuilder.RenameColumn(
                name: "OuterInnerResourceSiteId",
                table: "OuterInnerResourceSiteVersions",
                newName: "MachineAreaSiteId");

            migrationBuilder.RenameColumn(
                name: "OuterInnerResourceId",
                table: "OuterInnerResourceSiteVersions",
                newName: "MachineAreaId");

            migrationBuilder.RenameColumn(
                name: "OuterInnerResourceId",
                table: "OuterInnerResourceSites",
                newName: "MachineAreaId");

            migrationBuilder.RenameColumn(
                name: "OuterResourceId",
                table: "OuterInnerResources",
                newName: "MachineId");

            migrationBuilder.RenameColumn(
                name: "InnerResourceId",
                table: "OuterInnerResources",
                newName: "AreaId");

            migrationBuilder.RenameColumn(
                name: "InnerResourceId",
                table: "InnerResourceVersions",
                newName: "MachineId");
        }
    }
}
