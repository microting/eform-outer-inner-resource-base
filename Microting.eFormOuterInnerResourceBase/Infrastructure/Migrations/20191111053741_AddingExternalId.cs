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
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExternalId",
                table: "OuterResources",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExternalId",
                table: "InnerResourceVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExternalId",
                table: "InnerResources",
                nullable: false,
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
