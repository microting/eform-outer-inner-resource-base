using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormMachineAreaBase.Migrations
{
    public partial class FixingTypo : Migration
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
            migrationBuilder.RenameColumn(
                name: "Verseion",
                table: "MachineAreaVersions",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "Verseion",
                table: "MachineAreas",
                newName: "Version");

            migrationBuilder.CreateTable(
                name: "MachineAreaSite",
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
                    MachineAreaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAreaSite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineAreaSite_MachineAreas_MachineAreaId",
                        column: x => x.MachineAreaId,
                        principalTable: "MachineAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaSite_MachineAreaId",
                table: "MachineAreaSite",
                column: "MachineAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineAreaSite");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "MachineAreaVersions",
                newName: "Verseion");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "MachineAreas",
                newName: "Verseion");
        }
    }
}
