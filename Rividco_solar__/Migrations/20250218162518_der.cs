using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rividco_solar__.Migrations
{
    /// <inheritdoc />
    public partial class der : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projecttest_Projects_Project_ID1",
                table: "Projecttest");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCIA_Company_CompanyId",
                table: "TaskCIA");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCIA_Projects_Project_ID1",
                table: "TaskCIA");

            migrationBuilder.DropIndex(
                name: "IX_TaskCIA_CompanyId",
                table: "TaskCIA");

            migrationBuilder.DropIndex(
                name: "IX_TaskCIA_Project_ID1",
                table: "TaskCIA");

            migrationBuilder.DropIndex(
                name: "IX_Projecttest_Project_ID1",
                table: "Projecttest");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "TaskCIA");

            migrationBuilder.DropColumn(
                name: "Company_ID",
                table: "TaskCIA");

            migrationBuilder.DropColumn(
                name: "Project_ID1",
                table: "TaskCIA");

            migrationBuilder.DropColumn(
                name: "Project_ID1",
                table: "Projecttest");

            migrationBuilder.CreateIndex(
                name: "IX_TaskCIA_Project_ID",
                table: "TaskCIA",
                column: "Project_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Projecttest_Project_ID",
                table: "Projecttest",
                column: "Project_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projecttest_Projects_Project_ID",
                table: "Projecttest",
                column: "Project_ID",
                principalTable: "Projects",
                principalColumn: "Project_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCIA_Projects_Project_ID",
                table: "TaskCIA",
                column: "Project_ID",
                principalTable: "Projects",
                principalColumn: "Project_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projecttest_Projects_Project_ID",
                table: "Projecttest");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskCIA_Projects_Project_ID",
                table: "TaskCIA");

            migrationBuilder.DropIndex(
                name: "IX_TaskCIA_Project_ID",
                table: "TaskCIA");

            migrationBuilder.DropIndex(
                name: "IX_Projecttest_Project_ID",
                table: "Projecttest");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "TaskCIA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Company_ID",
                table: "TaskCIA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Project_ID1",
                table: "TaskCIA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Project_ID1",
                table: "Projecttest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TaskCIA_CompanyId",
                table: "TaskCIA",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskCIA_Project_ID1",
                table: "TaskCIA",
                column: "Project_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Projecttest_Project_ID1",
                table: "Projecttest",
                column: "Project_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Projecttest_Projects_Project_ID1",
                table: "Projecttest",
                column: "Project_ID1",
                principalTable: "Projects",
                principalColumn: "Project_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCIA_Company_CompanyId",
                table: "TaskCIA",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCIA_Projects_Project_ID1",
                table: "TaskCIA",
                column: "Project_ID1",
                principalTable: "Projects",
                principalColumn: "Project_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
