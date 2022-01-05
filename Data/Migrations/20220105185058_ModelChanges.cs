using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalCenter.Data.Migrations
{
    public partial class ModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalStaff_Room_ConsultationRoomId",
                table: "MedicalStaff");

            migrationBuilder.RenameColumn(
                name: "ConsultationRoomId",
                table: "MedicalStaff",
                newName: "ConsultationRoomId1");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalStaff_ConsultationRoomId",
                table: "MedicalStaff",
                newName: "IX_MedicalStaff_ConsultationRoomId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalStaff_Room_ConsultationRoomId1",
                table: "MedicalStaff",
                column: "ConsultationRoomId1",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalStaff_Room_ConsultationRoomId1",
                table: "MedicalStaff");

            migrationBuilder.RenameColumn(
                name: "ConsultationRoomId1",
                table: "MedicalStaff",
                newName: "ConsultationRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalStaff_ConsultationRoomId1",
                table: "MedicalStaff",
                newName: "IX_MedicalStaff_ConsultationRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalStaff_Room_ConsultationRoomId",
                table: "MedicalStaff",
                column: "ConsultationRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
