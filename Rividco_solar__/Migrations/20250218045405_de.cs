using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rividco_solar__.Migrations
{
    /// <inheritdoc />
    public partial class de : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projectitem_Vendor_Vendor_ID",
                table: "Projectitem");

            migrationBuilder.DropIndex(
                name: "IX_Projectitem_Vendor_ID",
                table: "Projectitem");

            migrationBuilder.DropColumn(
                name: "Vendor_ID",
                table: "Projectitem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Vendor_ID",
                table: "Projectitem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projectitem_Vendor_ID",
                table: "Projectitem",
                column: "Vendor_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projectitem_Vendor_Vendor_ID",
                table: "Projectitem",
                column: "Vendor_ID",
                principalTable: "Vendor",
                principalColumn: "Vendor_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
