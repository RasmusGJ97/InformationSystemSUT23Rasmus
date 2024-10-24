using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InformationSystemSUT23Rasmus.Migrations
{
    /// <inheritdoc />
    public partial class initialcreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarChar(50)", nullable: false),
                    CarReg = table.Column<string>(type: "nvarChar(7)", nullable: false),
                    NoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoteDescription = table.Column<string>(type: "nvarChar(150)", nullable: true),
                    ResponsibleEmployee = table.Column<string>(type: "nvarChar(50)", nullable: false),
                    BeloppUt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BeloppIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBeloppUt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBeloppIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoteDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeloppIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BeloppUt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DriverID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Drivers_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "DriverID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverID", "BeloppIn", "BeloppUt", "CarReg", "DriverName", "NoteDate", "NoteDescription", "ResponsibleEmployee", "TotalBeloppIn", "TotalBeloppUt" },
                values: new object[,]
                {
                    { 1, 1000.00m, 200.00m, "ABC123", "Peter", new DateTime(2024, 10, 23, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(2894), "Delivered supplies", "Sven", 1000.00m, 200.00m },
                    { 2, 0.00m, 500.00m, "DEF456", "Anja", new DateTime(2024, 10, 19, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(2925), "Added Fuel", "Göran", 0.00m, 500.00m },
                    { 3, 1000.00m, 100.00m, "GHI789", "Chris", new DateTime(2024, 10, 21, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(2950), "Delivered supplies", "Sven", 1000.00m, 100.00m },
                    { 4, 2000.00m, 200.00m, "CBA321", "Lena", new DateTime(2024, 10, 21, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(2970), "Delivered supplies", "Göran", 2000.00m, 200.00m },
                    { 5, 1000.00m, 500.00m, "FED654", "Fredrik", new DateTime(2024, 10, 20, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(2990), "Delivered supplies", "Sven", 1000.00m, 500.00m }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "rasmus@email.com", "Rasmus", "Rasmus@1", "Admin" },
                    { 2, "göran@email.com", "Göran", "Göran@2", "Employee" },
                    { 3, "sven@email.com", "Sven", "Sven@3", "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "BeloppIn", "BeloppUt", "DriverID", "NoteDate", "NoteDescription" },
                values: new object[,]
                {
                    { 1, 1000.00m, 0.00m, 1, new DateTime(2024, 10, 20, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3021), "Delivered supplies" },
                    { 2, 0.00m, 1000.00m, 2, new DateTime(2024, 10, 23, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3119), "Fueled Car" },
                    { 3, 500.00m, 0.00m, 3, new DateTime(2024, 10, 19, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3139), "Delivered supplies" },
                    { 4, 0.00m, 2000.00m, 4, new DateTime(2024, 10, 22, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3159), "Car Service" },
                    { 5, 1800.00m, 0.00m, 5, new DateTime(2024, 10, 22, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3180), "Delivered supplies" },
                    { 6, 700.00m, 0.00m, 1, new DateTime(2024, 10, 21, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3202), "Delivered supplies" },
                    { 7, 1200.00m, 0.00m, 2, new DateTime(2024, 10, 20, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3221), "Delivered supplies" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_DriverID",
                table: "Events",
                column: "DriverID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
