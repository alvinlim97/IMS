using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMS.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncidentTask",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ESname = table.Column<string>(nullable: true),
                    SID = table.Column<int>(nullable: true),
                    Floor = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    TableNo = table.Column<string>(nullable: true),
                    IID = table.Column<int>(nullable: true),
                    Iname = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    SDate = table.Column<DateTime>(nullable: true),
                    EID = table.Column<int>(nullable: true),
                    Ename = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentTask", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncidentTask");
            
        }
    }
}
