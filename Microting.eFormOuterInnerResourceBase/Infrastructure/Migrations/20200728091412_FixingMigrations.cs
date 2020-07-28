using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormOuterInnerResourceBase.Infrastructure.Migrations
{
    public partial class FixingMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OuterInnerResourceSites_OuterInnerResources_OuterInnerResourc",
                table: "OuterInnerResourceSites");

            migrationBuilder.DropForeignKey(
                name: "FK_OuterInnerResourceVersions_OuterInnerResources_OuterInnerReso",
                table: "OuterInnerResourceVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginPermissions_PermissionId",
                table: "PluginGroupPermissionVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_ResourceTimeRegistrations_Ma",
                table: "ResourceTimeRegistrationVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_OuterResources_OuterResource",
                table: "ResourceTimeRegistrationVersions");

            // migrationBuilder.DropIndex(
            //     name: "IX_PluginGroupPermissionVersions_PermissionId",
            //     table: "PluginGroupPermissionVersions");

            // migrationBuilder.DropColumn(
            //     name: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
            //     table: "PluginGroupPermissionVersions");

            // migrationBuilder.RenameIndex(
            //     name: "IX_ResourceTimeRegistrationVersions_MachineAreaTimeRegistrationId",
            //     table: "ResourceTimeRegistrationVersions",
            //     newName: "IX_ResourceTimeRegistrationVersions_MachineAreaTimeRegistration~");

            migrationBuilder.AddForeignKey(
                name: "FK_OuterInnerResourceSites_OuterInnerResources_OuterInnerResour~",
                table: "OuterInnerResourceSites",
                column: "OuterInnerResourceId",
                principalTable: "OuterInnerResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OuterInnerResourceVersions_OuterInnerResources_OuterInnerRes~",
                table: "OuterInnerResourceVersions",
                column: "OuterInnerResourceId",
                principalTable: "OuterInnerResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_InnerResources_InnerResourc~",
                table: "ResourceTimeRegistrationVersions",
                column: "InnerResourceId",
                principalTable: "InnerResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_ResourceTimeRegistrations_M~",
                table: "ResourceTimeRegistrationVersions",
                column: "MachineAreaTimeRegistrationId",
                principalTable: "ResourceTimeRegistrations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_OuterResources_OuterResourc~",
                table: "ResourceTimeRegistrationVersions",
                column: "OuterResourceId",
                principalTable: "OuterResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OuterInnerResourceSites_OuterInnerResources_OuterInnerResour~",
                table: "OuterInnerResourceSites");

            migrationBuilder.DropForeignKey(
                name: "FK_OuterInnerResourceVersions_OuterInnerResources_OuterInnerRes~",
                table: "OuterInnerResourceVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_InnerResources_InnerResourc~",
                table: "ResourceTimeRegistrationVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_ResourceTimeRegistrations_M~",
                table: "ResourceTimeRegistrationVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_OuterResources_OuterResourc~",
                table: "ResourceTimeRegistrationVersions");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceTimeRegistrationVersions_MachineAreaTimeRegistration~",
                table: "ResourceTimeRegistrationVersions",
                newName: "IX_ResourceTimeRegistrationVersions_MachineAreaTimeRegistrationId");

            migrationBuilder.AddColumn<int>(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissionVersions_FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                column: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissionVersions_PermissionId",
                table: "PluginGroupPermissionVersions",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_OuterInnerResourceSites_OuterInnerResources_OuterInnerResourceId",
                table: "OuterInnerResourceSites",
                column: "OuterInnerResourceId",
                principalTable: "OuterInnerResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OuterInnerResourceVersions_OuterInnerResources_OuterInnerResourceId",
                table: "OuterInnerResourceVersions",
                column: "OuterInnerResourceId",
                principalTable: "OuterInnerResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginGroupPermissions_FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                column: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                principalTable: "PluginGroupPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PluginGroupPermissionVersions_PluginPermissions_PermissionId",
                table: "PluginGroupPermissionVersions",
                column: "PermissionId",
                principalTable: "PluginPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_InnerResources_InnerResourceId",
                table: "ResourceTimeRegistrationVersions",
                column: "InnerResourceId",
                principalTable: "InnerResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_ResourceTimeRegistrations_MachineAreaTimeRegistrationId",
                table: "ResourceTimeRegistrationVersions",
                column: "MachineAreaTimeRegistrationId",
                principalTable: "ResourceTimeRegistrations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_OuterResources_OuterResourceId",
                table: "ResourceTimeRegistrationVersions",
                column: "OuterResourceId",
                principalTable: "OuterResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
