using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class TablesBoardsAndTasksCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("0ab67c39-78b3-4c86-b7c8-aa2e8c0271dd"), 1, new DateTime(2023, 7, 27, 8, 22, 49, 114, DateTimeKind.Utc).AddTicks(1498), "Implement better styling for the pages", "89f5eb8c-e95a-47c1-8990-f4eae71cbdbd", "Improve CSS", null },
                    { new Guid("9b402d2a-12cb-4c25-b4e4-cf49548df525"), 1, new DateTime(2023, 9, 12, 8, 22, 49, 114, DateTimeKind.Utc).AddTicks(1524), "Create Android Client App for the TaskBoard RESTful Api", "89f5eb8c-e95a-47c1-8990-f4eae71cbdbd", "Android Client App", null },
                    { new Guid("cea413e7-fe5d-4a28-9fbf-4411813b1197"), 3, new DateTime(2023, 2, 12, 8, 22, 49, 114, DateTimeKind.Utc).AddTicks(1583), "Implement [Create Task] page for adding new tasks", "f38b3838-25da-49a2-9b80-9dad1bcb50f7", "Create Tasks", null },
                    { new Guid("ff0d8b04-9cef-49c9-b0fd-9d27b97da369"), 2, new DateTime(2024, 1, 12, 8, 22, 49, 114, DateTimeKind.Utc).AddTicks(1580), "Create Desktop Client App for the TaskBoard RESTful Api", "f38b3838-25da-49a2-9b80-9dad1bcb50f7", "Desktop Client App", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
