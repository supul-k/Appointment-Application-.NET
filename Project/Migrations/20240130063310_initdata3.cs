using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class initdata3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_Appointments_AppoinmentId",
                table: "AppointmentSchedules");

            migrationBuilder.RenameColumn(
                name: "AppoinmentId",
                table: "AppointmentSchedules",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentSchedules_AppoinmentId",
                table: "AppointmentSchedules",
                newName: "IX_AppointmentSchedules_AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_Appointments_AppointmentId",
                table: "AppointmentSchedules",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSchedules_Appointments_AppointmentId",
                table: "AppointmentSchedules");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "AppointmentSchedules",
                newName: "AppoinmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentSchedules_AppointmentId",
                table: "AppointmentSchedules",
                newName: "IX_AppointmentSchedules_AppoinmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSchedules_Appointments_AppoinmentId",
                table: "AppointmentSchedules",
                column: "AppoinmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
