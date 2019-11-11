using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormOuterInnerResourceBase.Infrastructure.Migrations
{
    public partial class AddingExternalId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExternalId",
                table: "OuterResourceVersions",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExternalId",
                table: "OuterResources",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExternalId",
                table: "InnerResourceVersions",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExternalId",
                table: "InnerResources",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "OuterResourceVersions");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "OuterResources");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "InnerResourceVersions");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "InnerResources");
        }
    }
}
