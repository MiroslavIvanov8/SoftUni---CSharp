using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeminarHub.Data.Migrations
{
    public partial class MappingTableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeminarParticipant_AspNetUsers_ParticipantId",
                table: "SeminarParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_SeminarParticipant_Seminars_SeminarId",
                table: "SeminarParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeminarParticipant",
                table: "SeminarParticipant");

            migrationBuilder.RenameTable(
                name: "SeminarParticipant",
                newName: "SeminarsParticipants");

            migrationBuilder.RenameIndex(
                name: "IX_SeminarParticipant_ParticipantId",
                table: "SeminarsParticipants",
                newName: "IX_SeminarsParticipants_ParticipantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeminarsParticipants",
                table: "SeminarsParticipants",
                columns: new[] { "SeminarId", "ParticipantId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SeminarsParticipants_AspNetUsers_ParticipantId",
                table: "SeminarsParticipants",
                column: "ParticipantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeminarsParticipants_Seminars_SeminarId",
                table: "SeminarsParticipants",
                column: "SeminarId",
                principalTable: "Seminars",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeminarsParticipants_AspNetUsers_ParticipantId",
                table: "SeminarsParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_SeminarsParticipants_Seminars_SeminarId",
                table: "SeminarsParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeminarsParticipants",
                table: "SeminarsParticipants");

            migrationBuilder.RenameTable(
                name: "SeminarsParticipants",
                newName: "SeminarParticipant");

            migrationBuilder.RenameIndex(
                name: "IX_SeminarsParticipants_ParticipantId",
                table: "SeminarParticipant",
                newName: "IX_SeminarParticipant_ParticipantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeminarParticipant",
                table: "SeminarParticipant",
                columns: new[] { "SeminarId", "ParticipantId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SeminarParticipant_AspNetUsers_ParticipantId",
                table: "SeminarParticipant",
                column: "ParticipantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeminarParticipant_Seminars_SeminarId",
                table: "SeminarParticipant",
                column: "SeminarId",
                principalTable: "Seminars",
                principalColumn: "Id");
        }
    }
}
