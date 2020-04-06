using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Web.Migrations
{
    public partial class TravelEntitynewAtributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Reservation",
                table: "Travels",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 6);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Travels",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Travels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Travels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Travels");

            migrationBuilder.AlterColumn<string>(
                name: "Reservation",
                table: "Travels",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12);
        }
    }
}
