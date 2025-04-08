using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RadioCabs.Migrations
{
    /// <inheritdoc />
    public partial class AddCompaniesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Companie__3214EC07850F81E5",
                table: "Companies");

            migrationBuilder.RenameIndex(
                name: "UQ__Companie__A9D10534EB5CED38",
                table: "Companies",
                newName: "UQ__Companie__A9D10534D00E1802");

            migrationBuilder.AddColumn<string>(
                name: "CompanyID",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Companie__3214EC0744289DAD",
                table: "Companies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Advertis__3214EC07972A687F", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DriverID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Drivers__3214EC07760719A6", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__3214EC07A9378ED9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3214EC076DD407FF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PaymentFor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "Pending")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payments__3214EC0700D43165", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Payments__UserId__6383C8BA",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Companie__2D971C4D5E878B4B",
                table: "Companies",
                column: "CompanyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Drivers__A9D1053479C68E5D",
                table: "Drivers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Drivers__F1B1CD255A5EEA55",
                table: "Drivers",
                column: "DriverID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D10534E707C702",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Companie__3214EC0744289DAD",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "UQ__Companie__2D971C4D5E878B4B",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Companies");

            migrationBuilder.RenameIndex(
                name: "UQ__Companie__A9D10534D00E1802",
                table: "Companies",
                newName: "UQ__Companie__A9D10534EB5CED38");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Companie__3214EC07850F81E5",
                table: "Companies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    AvailableCity = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FarePerKm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Services__3214EC076A56C5E5", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Services__FarePe__6FE99F9F",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_CompanyId",
                table: "Services",
                column: "CompanyId");
        }
    }
}
