using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagement.Migrations
{
    /// <inheritdoc />
    public partial class seedinfdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Designation",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Intern" },
                    { 2, "Software Engineer" },
                    { 3, "Senior Software Engineer" }
                });

            migrationBuilder.InsertData(
                table: "PaymentRule",
                columns: new[] { "Id", "RuleName" },
                values: new object[,]
                {
                    { 1, "Cash" },
                    { 2, "Card" },
                    { 3, "UPI" }
                });

            migrationBuilder.InsertData(
                table: "WorkingHour",
                columns: new[] { "Id", "CompanyMonthlyWorkingHour", "EmployeeMonthlyWorkingHour" },
                values: new object[,]
                {
                    { 1, 12, 8 },
                    { 2, 12, 7 },
                    { 3, 12, 6 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DesignationId", "Name", "PaymentRuleId", "WorkingHourId" },
                values: new object[,]
                {
                    { 1, 1, "smith", 1, 1 },
                    { 2, 2, "Nobitha", 2, 2 },
                    { 3, 3, "Doremon", 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Designation",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PaymentRule",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentRule",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentRule",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkingHour",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkingHour",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkingHour",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
