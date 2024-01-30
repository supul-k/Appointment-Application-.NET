using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class initdata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_Appointments_AppointmentId",
                table: "AppointmentSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentSchedules_AppointmentId",
                table: "AppointmentSchedules");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "AppointmentSchedules");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_AppoinmentId",
                table: "AppointmentSchedules",
                column: "AppoinmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_Appointments_AppoinmentId",
                table: "AppointmentSchedules",
                column: "AppoinmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_Appointments_AppoinmentId",
                table: "AppointmentSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentSchedules_AppoinmentId",
                table: "AppointmentSchedules");

            migrationBuilder.AddColumn<string>(
                name: "AppointmentId",
                table: "AppointmentSchedules",
                type: "nvarchar(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_AppointmentId",
                table: "AppointmentSchedules",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_Appointments_AppointmentId",
                table: "AppointmentSchedules",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
