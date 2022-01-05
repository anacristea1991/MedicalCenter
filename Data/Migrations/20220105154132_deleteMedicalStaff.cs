using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalCenter.Data.Migrations
{
    public partial class deleteMedicalStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalStaff");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
