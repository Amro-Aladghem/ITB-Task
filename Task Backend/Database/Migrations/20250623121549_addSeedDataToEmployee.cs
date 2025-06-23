using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class addSeedDataToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "JobTitle", "LastName", "Level" },
                values: new object[,]
                {
                    { 1, "Ali", "Backend Developer", "Khalid", "Junior" },
                    { 2, "Lina", "Frontend Developer", "Hassan", "Mid" },
                    { 3, "Salim", "Full Stack Developer", "Yousef", "Senior" },
                    { 4, "Mona", "DevOps Engineer", "Ahmad", "Mid" },
                    { 5, "Omar", "QA Engineer", "Sami", "Junior" },
                    { 6, "Sara", "Project Manager", "Nabil", "Senior" }
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
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
