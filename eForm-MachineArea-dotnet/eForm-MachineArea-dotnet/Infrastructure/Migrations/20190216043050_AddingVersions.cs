using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormMachineAreaBase.Migrations
{
    public partial class AddingVersions : Migration
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
            migrationBuilder.DropColumn(
                name: "SelectedeFormId",
                table: "MachineAreaSettings");

            migrationBuilder.RenameColumn(
                name: "SelectedeFormName",
                table: "MachineAreaSettings",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "MicrotingeFormSdkId",
                table: "MachineAreas",
                newName: "Verseion");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Machines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "MachineAreaTimeRegistrations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MachineAreaSettings",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "MachineAreaSettings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Areas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AreaVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Version = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaVersions_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineAreaSettingVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<string>(nullable: true),
                    MachineAreaSettingId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAreaSettingVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineAreaTimeRegistrationVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    MachineId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    DoneAt = table.Column<DateTime>(nullable: false),
                    SDKCaseId = table.Column<int>(nullable: false),
                    SDKFieldValueId = table.Column<int>(nullable: false),
                    TimeInSeconds = table.Column<int>(nullable: false),
                    TimeInMinutes = table.Column<int>(nullable: false),
                    TimeInHours = table.Column<int>(nullable: false),
                    SDKSiteId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    MachineAreaTimeRegistrationId = table.Column<int>(nullable: false),
                    MachineAreaTimeRegistrationId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAreaTimeRegistrationVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineAreaTimeRegistrationVersions_Areas_MachineAreaTimeRegistrationId",
                        column: x => x.MachineAreaTimeRegistrationId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineAreaTimeRegistrationVersions_MachineAreaTimeRegistrations_MachineAreaTimeRegistrationId1",
                        column: x => x.MachineAreaTimeRegistrationId1,
                        principalTable: "MachineAreaTimeRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MachineAreaTimeRegistrationVersions_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineAreaVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    MachineId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    Verseion = table.Column<int>(nullable: false),
                    MachineAreaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAreaVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineAreaVersions_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineAreaVersions_MachineAreas_MachineAreaId",
                        column: x => x.MachineAreaId,
                        principalTable: "MachineAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineAreaVersions_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Version = table.Column<int>(nullable: false),
                    MachineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineVersions_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaVersions_AreaId",
                table: "AreaVersions",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaTimeRegistrationVersions_MachineAreaTimeRegistrationId",
                table: "MachineAreaTimeRegistrationVersions",
                column: "MachineAreaTimeRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaTimeRegistrationVersions_MachineAreaTimeRegistrationId1",
                table: "MachineAreaTimeRegistrationVersions",
                column: "MachineAreaTimeRegistrationId1");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaTimeRegistrationVersions_MachineId",
                table: "MachineAreaTimeRegistrationVersions",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaVersions_AreaId",
                table: "MachineAreaVersions",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaVersions_MachineAreaId",
                table: "MachineAreaVersions",
                column: "MachineAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaVersions_MachineId",
                table: "MachineAreaVersions",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineVersions_MachineId",
                table: "MachineVersions",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaVersions");

            migrationBuilder.DropTable(
                name: "MachineAreaSettingVersions");

            migrationBuilder.DropTable(
                name: "MachineAreaTimeRegistrationVersions");

            migrationBuilder.DropTable(
                name: "MachineAreaVersions");

            migrationBuilder.DropTable(
                name: "MachineVersions");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "MachineAreaTimeRegistrations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MachineAreaSettings");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "MachineAreaSettings");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Areas");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "MachineAreaSettings",
                newName: "SelectedeFormName");

            migrationBuilder.RenameColumn(
                name: "Verseion",
                table: "MachineAreas",
                newName: "MicrotingeFormSdkId");

            migrationBuilder.AddColumn<int>(
                name: "SelectedeFormId",
                table: "MachineAreaSettings",
                nullable: true);
        }
    }
}
