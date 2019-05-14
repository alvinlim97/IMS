using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMS.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskToDo",
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
                    EDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    SDate = table.Column<DateTime>(nullable: false),
                    EID = table.Column<int>(nullable: true),
                    Ename = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskToDo", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskToDo");
        }
    }
}
