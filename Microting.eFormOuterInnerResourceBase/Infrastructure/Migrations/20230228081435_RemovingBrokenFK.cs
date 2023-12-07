using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microting.eFormOuterInnerResourceBase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovingBrokenFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_MachineAreaTimeRegistrationVersions_MachineAreaTimeRegistrati",
            //     table: "ResourceTimeRegistrationVersions");
            //
            migrationBuilder.RenameColumn(
                name: "MachineAreaTimeRegistrationId",
                table: "ResourceTimeRegistrationVersions",
                newName: "ResourceTimeRegistrationId");
            //
            // migrationBuilder.RenameIndex(
            //     name: "IX_MachineAreaTimeRegistrationVersions_MachineAreaTimeRegistrati",
            //     table: "ResourceTimeRegistrationVersions",
            //     newName: "IX_ResourceTimeRegistrationVersions_ResourceTimeRegistrationId");
            //
            // migrationBuilder.AddForeignKey(
            //     name: "FK_ResourceTimeRegistrationVersions_ResourceTimeRegistrations_R~",
            //     table: "ResourceTimeRegistrationVersions",
            //     column: "ResourceTimeRegistrationId",
            //     principalTable: "ResourceTimeRegistrations",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_ResourceTimeRegistrations_R~",
                table: "ResourceTimeRegistrationVersions");

            migrationBuilder.RenameColumn(
                name: "ResourceTimeRegistrationId",
                table: "ResourceTimeRegistrationVersions",
                newName: "MachineAreaTimeRegistrationId");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceTimeRegistrationVersions_ResourceTimeRegistrationId",
                table: "ResourceTimeRegistrationVersions",
                newName: "IX_ResourceTimeRegistrationVersions_MachineAreaTimeRegistration~");

            migrationBuilder.AlterColumn<string>(
                name: "PermissionName",
                table: "PluginPermissions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ClaimName",
                table: "PluginPermissions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "PluginConfigurationValueVersions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PluginConfigurationValueVersions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "PluginConfigurationValues",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PluginConfigurationValues",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTimeRegistrationVersions_ResourceTimeRegistrations_M~",
                table: "ResourceTimeRegistrationVersions",
                column: "MachineAreaTimeRegistrationId",
                principalTable: "ResourceTimeRegistrations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}