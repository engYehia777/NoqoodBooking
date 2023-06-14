using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoqoodBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class forignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Trips_TripId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TripId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TripId1",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TripId",
                table: "Reservations",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Trips_TripId",
                table: "Reservations",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Trips_TripId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TripId",
                table: "Reservations");

            migrationBuilder.AddColumn<Guid>(
                name: "TripId1",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TripId1",
                table: "Reservations",
                column: "TripId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Trips_TripId1",
                table: "Reservations",
                column: "TripId1",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
