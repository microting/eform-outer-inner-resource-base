using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormMachineAreaBase.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Setup for SQL Server Provider

            var autoIDGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIDGenStrategyValue = SqlServerValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                autoIDGenStrategy = "MySql:ValueGenerationStrategy";
                autoIDGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            migrationBuilder.CreateTable(
                name: "Areas",
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
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineAreaSettings",
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
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAreaSettings", x => x.Id);
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
                    MachineAreaSiteId = table.Column<int>(nullable: false),
                    MicrotingSdkSiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAreaSiteVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
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
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

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
                name: "MachineAreas",
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
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineAreas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineAreas_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineAreaTimeRegistrations",
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
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAreaTimeRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineAreaTimeRegistrations_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineAreaTimeRegistrations_Machines_MachineId",
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

            migrationBuilder.CreateTable(
                name: "MachineAreaSites",
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
                    MicrotingSdkSiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAreaSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineAreaSites_MachineAreas_MachineAreaId",
                        column: x => x.MachineAreaId,
                        principalTable: "MachineAreas",
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
                    Version = table.Column<int>(nullable: false),
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
                    MachineAreaTimeRegistrationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAreaTimeRegistrationVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineAreaTimeRegistrationVersions_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineAreaTimeRegistrationVersions_MachineAreaTimeRegistrations_MachineAreaTimeRegistrationId",
                        column: x => x.MachineAreaTimeRegistrationId,
                        principalTable: "MachineAreaTimeRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineAreaTimeRegistrationVersions_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CreatedByUserId",
                table: "Areas",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Name",
                table: "Areas",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_UpdatedByUserId",
                table: "Areas",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaVersions_AreaId",
                table: "AreaVersions",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreas_AreaId",
                table: "MachineAreas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreas_MachineId",
                table: "MachineAreas",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaSites_MachineAreaId",
                table: "MachineAreaSites",
                column: "MachineAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaTimeRegistrations_AreaId",
                table: "MachineAreaTimeRegistrations",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaTimeRegistrations_MachineId",
                table: "MachineAreaTimeRegistrations",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaTimeRegistrationVersions_AreaId",
                table: "MachineAreaTimeRegistrationVersions",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaTimeRegistrationVersions_MachineAreaTimeRegistrationId",
                table: "MachineAreaTimeRegistrationVersions",
                column: "MachineAreaTimeRegistrationId");

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
                name: "IX_Machines_CreatedByUserId",
                table: "Machines",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_Name",
                table: "Machines",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_UpdatedByUserId",
                table: "Machines",
                column: "UpdatedByUserId");

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
                name: "MachineAreaSettings");

            migrationBuilder.DropTable(
                name: "MachineAreaSettingVersions");

            migrationBuilder.DropTable(
                name: "MachineAreaSites");

            migrationBuilder.DropTable(
                name: "MachineAreaSiteVersions");

            migrationBuilder.DropTable(
                name: "MachineAreaTimeRegistrationVersions");

            migrationBuilder.DropTable(
                name: "MachineAreaVersions");

            migrationBuilder.DropTable(
                name: "MachineVersions");

            migrationBuilder.DropTable(
                name: "MachineAreaTimeRegistrations");

            migrationBuilder.DropTable(
                name: "MachineAreas");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
