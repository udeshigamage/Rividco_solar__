using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rividco_solar__.Migrations
{
    /// <inheritdoc />
    public partial class fifthl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lastupdatedby",
                table: "Systemusers");

            migrationBuilder.DropColumn(
                name: "Lastupdatedtime",
                table: "Systemusers");

            migrationBuilder.DropColumn(
                name: "Profilpic",
                table: "Systemusers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Systemusers");

            migrationBuilder.DropColumn(
                name: "category",
                table: "Systemusers");

            migrationBuilder.DropColumn(
                name: "comment",
                table: "Systemusers");

            migrationBuilder.DropColumn(
                name: "mobileno",
                table: "Systemusers");

            migrationBuilder.DropColumn(
                name: "officeno",
                table: "Systemusers");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Systemusers",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Systemusers",
                newName: "passwordhash");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Systemusers",
                newName: "contactno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address",
                table: "Systemusers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "passwordhash",
                table: "Systemusers",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "contactno",
                table: "Systemusers",
                newName: "password");

            migrationBuilder.AddColumn<int>(
                name: "Lastupdatedby",
                table: "Systemusers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Lastupdatedtime",
                table: "Systemusers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Profilpic",
                table: "Systemusers",
                type: "longblob",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Systemusers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Systemusers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "comment",
                table: "Systemusers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "mobileno",
                table: "Systemusers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "officeno",
                table: "Systemusers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
