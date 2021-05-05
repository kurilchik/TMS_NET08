using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.Migrations
{
    public partial class Abc_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "andrew.kurilchik@gmail.com_Abc.A",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_andrew.kurilchik@gmail.com_Abc.A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "andrew.kurilchik@gmail.com_Abc.B",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_andrew.kurilchik@gmail.com_Abc.B", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "andrew.kurilchik@gmail.com_Abc.A");

            migrationBuilder.DropTable(
                name: "andrew.kurilchik@gmail.com_Abc.B");
        }
    }
}
