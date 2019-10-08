using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormOuterInnerResourceBase.Infrastructure.Migrations
{
    public partial class AddingBindings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ResourceTimeRegistrationVersions_InnerResourceId",
                table: "ResourceTimeRegistrationVersions",
                column: "InnerResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTimeRegistrationVersions_MachineAreaTimeRegistrationId",
                table: "ResourceTimeRegistrationVersions",
                column: "MachineAreaTimeRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTimeRegistrationVersions_OuterResourceId",
                table: "ResourceTimeRegistrationVersions",
                column: "OuterResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTimeRegistrations_InnerResourceId",
                table: "ResourceTimeRegistrations",
                column: "InnerResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTimeRegistrations_OuterResourceId",
                table: "ResourceTimeRegistrations",
                column: "OuterResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OuterResourceVersions_OuterResourceId",
                table: "OuterResourceVersions",
                column: "OuterResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OuterInnerResourceVersions_InnerResourceId",
                table: "OuterInnerResourceVersions",
                column: "InnerResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OuterInnerResourceVersions_OuterInnerResourceId",
                table: "OuterInnerResourceVersions",
                column: "OuterInnerResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OuterInnerResourceVersions_OuterResourceId",
                table: "OuterInnerResourceVersions",
                column: "OuterResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OuterInnerResourceSites_OuterInnerResourceId",
                table: "OuterInnerResourceSites",
                column: "OuterInnerResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OuterInnerResources_InnerResourceId",
                table: "OuterInnerResources",
                column: "InnerResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OuterInnerResources_OuterResourceId",
                table: "OuterInnerResources",
                column: "OuterResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerResourceVersions_InnerResourceId",
                table: "InnerResourceVersions",
                column: "InnerResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InnerResourceVersions_InnerResources_InnerResourceId",
                table: "InnerResourceVersions",
                column: "InnerResourceId",
                principalTable: "InnerResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OuterInnerResources_InnerResources_InnerResourceId",
                table: "OuterInnerResources",
                column: "InnerResourceId",
                principalTable: "InnerResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OuterInnerResources_OuterResources_OuterResourceId",
                table: "OuterInnerResources",
                column: "OuterResourceId",
                principalTable: "OuterResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OuterInnerResourceSites_OuterInnerResources_OuterInnerResourceId",
                table: "OuterInnerResourceSites",
                column: "OuterInnerResourceId",
                principalTable: "OuterInnerResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OuterInnerResourceVersions_InnerResources_InnerResourceId",
                table: "OuterInnerResourceVersions",
                column: "InnerResourceId",
                principalTable: "InnerResources",
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
                name: "FK_OuterInnerResourceVersions_OuterResources_OuterResourceId",
                table: "OuterInnerResourceVersions",
                column: "OuterResourceId",
                principalTable: "OuterResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OuterResourceVersions_OuterResources_OuterResourceId",
                table: "OuterResourceVersions",
                column: "OuterResourceId",
                principalTable: "OuterResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTimeRegistrations_InnerResources_InnerResourceId",
                table: "ResourceTimeRegistrations",
                column: "InnerResourceId",
                principalTable: "InnerResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTimeRegistrations_OuterResources_OuterResourceId",
                table: "ResourceTimeRegistrations",
                column: "OuterResourceId",
                principalTable: "OuterResources",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InnerResourceVersions_InnerResources_InnerResourceId",
                table: "InnerResourceVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_OuterInnerResources_InnerResources_InnerResourceId",
                table: "OuterInnerResources");

            migrationBuilder.DropForeignKey(
                name: "FK_OuterInnerResources_OuterResources_OuterResourceId",
                table: "OuterInnerResources");

            migrationBuilder.DropForeignKey(
                name: "FK_OuterInnerResourceSites_OuterInnerResources_OuterInnerResourceId",
                table: "OuterInnerResourceSites");

            migrationBuilder.DropForeignKey(
                name: "FK_OuterInnerResourceVersions_InnerResources_InnerResourceId",
                table: "OuterInnerResourceVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_OuterInnerResourceVersions_OuterInnerResources_OuterInnerResourceId",
                table: "OuterInnerResourceVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_OuterInnerResourceVersions_OuterResources_OuterResourceId",
                table: "OuterInnerResourceVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_OuterResourceVersions_OuterResources_OuterResourceId",
                table: "OuterResourceVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTimeRegistrations_InnerResources_InnerResourceId",
                table: "ResourceTimeRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTimeRegistrations_OuterResources_OuterResourceId",
                table: "ResourceTimeRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_InnerResources_InnerResourceId",
                table: "ResourceTimeRegistrationVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_ResourceTimeRegistrations_MachineAreaTimeRegistrationId",
                table: "ResourceTimeRegistrationVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_OuterResources_OuterResourceId",
                table: "ResourceTimeRegistrationVersions");

            migrationBuilder.DropIndex(
                name: "IX_ResourceTimeRegistrationVersions_InnerResourceId",
                table: "ResourceTimeRegistrationVersions");

            migrationBuilder.DropIndex(
                name: "IX_ResourceTimeRegistrationVersions_MachineAreaTimeRegistrationId",
                table: "ResourceTimeRegistrationVersions");

            migrationBuilder.DropIndex(
                name: "IX_ResourceTimeRegistrationVersions_OuterResourceId",
                table: "ResourceTimeRegistrationVersions");

            migrationBuilder.DropIndex(
                name: "IX_ResourceTimeRegistrations_InnerResourceId",
                table: "ResourceTimeRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_ResourceTimeRegistrations_OuterResourceId",
                table: "ResourceTimeRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_OuterResourceVersions_OuterResourceId",
                table: "OuterResourceVersions");

            migrationBuilder.DropIndex(
                name: "IX_OuterInnerResourceVersions_InnerResourceId",
                table: "OuterInnerResourceVersions");

            migrationBuilder.DropIndex(
                name: "IX_OuterInnerResourceVersions_OuterInnerResourceId",
                table: "OuterInnerResourceVersions");

            migrationBuilder.DropIndex(
                name: "IX_OuterInnerResourceVersions_OuterResourceId",
                table: "OuterInnerResourceVersions");

            migrationBuilder.DropIndex(
                name: "IX_OuterInnerResourceSites_OuterInnerResourceId",
                table: "OuterInnerResourceSites");

            migrationBuilder.DropIndex(
                name: "IX_OuterInnerResources_InnerResourceId",
                table: "OuterInnerResources");

            migrationBuilder.DropIndex(
                name: "IX_OuterInnerResources_OuterResourceId",
                table: "OuterInnerResources");

            migrationBuilder.DropIndex(
                name: "IX_InnerResourceVersions_InnerResourceId",
                table: "InnerResourceVersions");
        }
    }
}
