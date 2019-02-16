using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormMachineAreaBase.Migrations
{
    public partial class AddingMissingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string autoIDGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIDGenStrategyValue = SqlServerValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                autoIDGenStrategy = "MySql:ValueGenerationStrategy";
                autoIDGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            migrationBuilder.DropForeignKey(
                name: "FK_MachineAreaSite_MachineAreas_MachineAreaId",
                table: "MachineAreaSite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MachineAreaSite",
                table: "MachineAreaSite");

            migrationBuilder.RenameTable(
                name: "MachineAreaSite",
                newName: "MachineAreaSites");

            migrationBuilder.RenameIndex(
                name: "IX_MachineAreaSite_MachineAreaId",
                table: "MachineAreaSites",
                newName: "IX_MachineAreaSites_MachineAreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachineAreaSites",
                table: "MachineAreaSites",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MachineAreaSiteVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    MicrotingEFormSdkId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    MachineAreaId = table.Column<int>(nullable: false),
                    MachineAreaSiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAreaSiteVersions", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAreaSites_MachineAreas_MachineAreaId",
                table: "MachineAreaSites",
                column: "MachineAreaId",
                principalTable: "MachineAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineAreaSites_MachineAreas_MachineAreaId",
                table: "MachineAreaSites");

            migrationBuilder.DropTable(
                name: "MachineAreaSiteVersions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MachineAreaSites",
                table: "MachineAreaSites");

            migrationBuilder.RenameTable(
                name: "MachineAreaSites",
                newName: "MachineAreaSite");

            migrationBuilder.RenameIndex(
                name: "IX_MachineAreaSites_MachineAreaId",
                table: "MachineAreaSite",
                newName: "IX_MachineAreaSite_MachineAreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachineAreaSite",
                table: "MachineAreaSite",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAreaSite_MachineAreas_MachineAreaId",
                table: "MachineAreaSite",
                column: "MachineAreaId",
                principalTable: "MachineAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
