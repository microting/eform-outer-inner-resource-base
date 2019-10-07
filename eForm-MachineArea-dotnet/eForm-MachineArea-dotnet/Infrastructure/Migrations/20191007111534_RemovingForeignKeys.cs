/*
The MIT License (MIT)
Copyright (c) 2007 - 2019 Microting A/S
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormMachineAreaBase.Infrastructure.Migrations
{
    public partial class RemovingForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaVersions_Areas_AreaId",
                table: "AreaVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineAreas_Areas_AreaId",
                table: "MachineAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineAreas_Machines_MachineId",
                table: "MachineAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineAreaSites_MachineAreas_MachineAreaId",
                table: "MachineAreaSites");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineAreaTimeRegistrations_Areas_AreaId",
                table: "MachineAreaTimeRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineAreaTimeRegistrations_Machines_MachineId",
                table: "MachineAreaTimeRegistrations");

//            migrationBuilder.DropForeignKey(
//                name: "FK_MachineAreaTimeRegistrationVersions_Areas_AreaId",
//                table: "MachineAreaTimeRegistrationVersions");

//            migrationBuilder.DropForeignKey(
//                name: "FK_MachineAreaTimeRegistrationVersions_MachineAreaTimeRegistrations_MachineAreaTimeRegistrationId",
//                table: "MachineAreaTimeRegistrationVersions");

//            migrationBuilder.DropForeignKey(
//                name: "FK_MachineAreaTimeRegistrationVersions_Machines_MachineId",
//                table: "MachineAreaTimeRegistrationVersions");

//            migrationBuilder.DropForeignKey(
//                name: "FK_MachineAreaVersions_Areas_AreaId",
//                table: "MachineAreaVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineAreaVersions_MachineAreas_MachineAreaId",
                table: "MachineAreaVersions");

//            migrationBuilder.DropForeignKey(
//                name: "FK_MachineAreaVersions_Machines_MachineId",
//                table: "MachineAreaVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineVersions_Machines_MachineId",
                table: "MachineVersions");

            migrationBuilder.DropIndex(
                name: "IX_MachineVersions_MachineId",
                table: "MachineVersions");

            migrationBuilder.DropIndex(
                name: "IX_MachineAreaVersions_AreaId",
                table: "MachineAreaVersions");

            migrationBuilder.DropIndex(
                name: "IX_MachineAreaVersions_MachineAreaId",
                table: "MachineAreaVersions");

            migrationBuilder.DropIndex(
                name: "IX_MachineAreaVersions_MachineId",
                table: "MachineAreaVersions");

            migrationBuilder.DropIndex(
                name: "IX_MachineAreaTimeRegistrationVersions_AreaId",
                table: "MachineAreaTimeRegistrationVersions");

//            migrationBuilder.DropIndex(
//                name: "IX_MachineAreaTimeRegistrationVersions_MachineAreaTimeRegistrationId",
//                table: "MachineAreaTimeRegistrationVersions");

            migrationBuilder.DropIndex(
                name: "IX_MachineAreaTimeRegistrationVersions_MachineId",
                table: "MachineAreaTimeRegistrationVersions");

            migrationBuilder.DropIndex(
                name: "IX_MachineAreaTimeRegistrations_AreaId",
                table: "MachineAreaTimeRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_MachineAreaTimeRegistrations_MachineId",
                table: "MachineAreaTimeRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_MachineAreaSites_MachineAreaId",
                table: "MachineAreaSites");

            migrationBuilder.DropIndex(
                name: "IX_MachineAreas_AreaId",
                table: "MachineAreas");

            migrationBuilder.DropIndex(
                name: "IX_MachineAreas_MachineId",
                table: "MachineAreas");

            migrationBuilder.DropIndex(
                name: "IX_AreaVersions_AreaId",
                table: "AreaVersions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MachineVersions_MachineId",
                table: "MachineVersions",
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
                name: "IX_MachineAreaTimeRegistrations_AreaId",
                table: "MachineAreaTimeRegistrations",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaTimeRegistrations_MachineId",
                table: "MachineAreaTimeRegistrations",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreaSites_MachineAreaId",
                table: "MachineAreaSites",
                column: "MachineAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreas_AreaId",
                table: "MachineAreas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAreas_MachineId",
                table: "MachineAreas",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaVersions_AreaId",
                table: "AreaVersions",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaVersions_Areas_AreaId",
                table: "AreaVersions",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAreas_Areas_AreaId",
                table: "MachineAreas",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAreas_Machines_MachineId",
                table: "MachineAreas",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAreaSites_MachineAreas_MachineAreaId",
                table: "MachineAreaSites",
                column: "MachineAreaId",
                principalTable: "MachineAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAreaTimeRegistrations_Areas_AreaId",
                table: "MachineAreaTimeRegistrations",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAreaTimeRegistrations_Machines_MachineId",
                table: "MachineAreaTimeRegistrations",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAreaTimeRegistrationVersions_Areas_AreaId",
                table: "MachineAreaTimeRegistrationVersions",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAreaTimeRegistrationVersions_MachineAreaTimeRegistrations_MachineAreaTimeRegistrationId",
                table: "MachineAreaTimeRegistrationVersions",
                column: "MachineAreaTimeRegistrationId",
                principalTable: "MachineAreaTimeRegistrations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAreaTimeRegistrationVersions_Machines_MachineId",
                table: "MachineAreaTimeRegistrationVersions",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAreaVersions_Areas_AreaId",
                table: "MachineAreaVersions",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAreaVersions_MachineAreas_MachineAreaId",
                table: "MachineAreaVersions",
                column: "MachineAreaId",
                principalTable: "MachineAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAreaVersions_Machines_MachineId",
                table: "MachineAreaVersions",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineVersions_Machines_MachineId",
                table: "MachineVersions",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
