using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormOuterInnerResourceBase.Infrastructure.Migrations
{
    public partial class RenamingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable("AreaVersions", null,"OuterResourceVersions");
            migrationBuilder.RenameTable("MachineAreaSites", null, "OuterInnerResourceSites");
            migrationBuilder.RenameTable("MachineAreaSiteVersions", null, "OuterInnerResourceSiteVersions");
            migrationBuilder.RenameTable("MachineAreaTimeRegistrationVersions", null, "ResourceTimeRegistrationVersions");
            migrationBuilder.RenameTable("MachineAreaVersions", null, "OuterInnerResourceVersions");
            migrationBuilder.RenameTable("MachineVersions", null, "InnerResourceVersions");
            migrationBuilder.RenameTable("MachineAreaTimeRegistrations", null, "ResourceTimeRegistrations");
            migrationBuilder.RenameTable("MachineAreas", null, "OuterInnerResources");
            migrationBuilder.RenameTable("Areas", null, "OuterResources");
            migrationBuilder.RenameTable("Machines", null, "InnerResources");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
