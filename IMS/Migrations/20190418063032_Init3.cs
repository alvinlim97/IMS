using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IMS.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Iname = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Solution = table.Column<string>(nullable: true),
                    Images = table.Column<byte>(nullable: true),
                    Videos = table.Column<byte>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incident");
        }
    }
}
