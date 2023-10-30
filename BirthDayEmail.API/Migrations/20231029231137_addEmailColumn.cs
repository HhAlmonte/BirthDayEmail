using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthDayEmail.API.Migrations
{
    /// <inheritdoc />
    public partial class addEmailColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Supervisor_SupervisorId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisor_Employees_EmployeeId",
                table: "Supervisor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supervisor",
                table: "Supervisor");

            migrationBuilder.RenameTable(
                name: "Supervisor",
                newName: "Supervisors");

            migrationBuilder.RenameIndex(
                name: "IX_Supervisor_EmployeeId",
                table: "Supervisors",
                newName: "IX_Supervisors_EmployeeId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supervisors",
                table: "Supervisors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Supervisors_SupervisorId",
                table: "Departments",
                column: "SupervisorId",
                principalTable: "Supervisors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisors_Employees_EmployeeId",
                table: "Supervisors",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Supervisors_SupervisorId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisors_Employees_EmployeeId",
                table: "Supervisors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supervisors",
                table: "Supervisors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Supervisors",
                newName: "Supervisor");

            migrationBuilder.RenameIndex(
                name: "IX_Supervisors_EmployeeId",
                table: "Supervisor",
                newName: "IX_Supervisor_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supervisor",
                table: "Supervisor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Supervisor_SupervisorId",
                table: "Departments",
                column: "SupervisorId",
                principalTable: "Supervisor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisor_Employees_EmployeeId",
                table: "Supervisor",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
