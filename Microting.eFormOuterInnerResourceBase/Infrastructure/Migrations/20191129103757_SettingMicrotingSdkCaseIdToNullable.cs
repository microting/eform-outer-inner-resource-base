using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormOuterInnerResourceBase.Infrastructure.Migrations
{
    public partial class SettingMicrotingSdkCaseIdToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MicrotingSdkCaseId",
                table: "OuterInnerResourceSiteVersions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MicrotingSdkCaseId",
                table: "OuterInnerResourceSites",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MicrotingSdkCaseId",
                table: "OuterInnerResourceSiteVersions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MicrotingSdkCaseId",
                table: "OuterInnerResourceSites",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
