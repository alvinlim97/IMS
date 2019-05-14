using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMS.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sname = table.Column<string>(nullable: true),
                    IC = table.Column<long>(nullable: false),
                    Designation = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    MobileNo = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Spoint = table.Column<int>(nullable: false),
                    Pass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
