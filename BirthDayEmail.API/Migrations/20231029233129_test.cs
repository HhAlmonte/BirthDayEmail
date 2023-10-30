using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthDayEmail.API.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Supervisors_SupervisorId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IdEmployee",
                table: "Supervisors");

            migrationBuilder.DropColumn(
                name: "IdDepartment",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Supervisors_SupervisorId",
                table: "Departments",
                column: "SupervisorId",
                principalTable: "Supervisors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Supervisors_SupervisorId",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "IdEmployee",
                table: "Supervisors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDepartment",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Supervisors_SupervisorId",
                table: "Departments",
                column: "SupervisorId",
                principalTable: "Supervisors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
