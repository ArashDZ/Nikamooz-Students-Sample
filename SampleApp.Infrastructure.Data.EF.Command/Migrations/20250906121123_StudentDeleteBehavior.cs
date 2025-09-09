using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleApp.Infrastructure.Data.EF.Command.Migrations
{
    /// <inheritdoc />
    public partial class StudentDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAddresses_Addresses_AddressId",
                table: "StudentAddresses");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAddresses_Addresses_AddressId",
                table: "StudentAddresses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAddresses_Addresses_AddressId",
                table: "StudentAddresses");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAddresses_Addresses_AddressId",
                table: "StudentAddresses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
