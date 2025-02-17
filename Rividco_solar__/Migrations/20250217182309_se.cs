using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rividco_solar__.Migrations
{
    /// <inheritdoc />
    public partial class se : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Company_Company_ID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_Company_ID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Company_ID",
                table: "Projects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Company_ID",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Company_ID",
                table: "Projects",
                column: "Company_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Company_Company_ID",
                table: "Projects",
                column: "Company_ID",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
