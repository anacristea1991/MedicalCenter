using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalCenter.Data.Migrations
{
    public partial class recreateMedicalStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Specialisation = table.Column<int>(type: "int", nullable: false),
                    ConsultationRoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalStaff_Room_ConsultationRoomId",
                        column: x => x.ConsultationRoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalStaff_ConsultationRoomId",
                table: "MedicalStaff",
                column: "ConsultationRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalStaff");
        }
    }
}
