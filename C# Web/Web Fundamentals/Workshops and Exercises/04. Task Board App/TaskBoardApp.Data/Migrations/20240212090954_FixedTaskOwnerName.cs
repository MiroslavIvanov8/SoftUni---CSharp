using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class FixedTaskOwnerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("0ab67c39-78b3-4c86-b7c8-aa2e8c0271dd"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("9b402d2a-12cb-4c25-b4e4-cf49548df525"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("cea413e7-fe5d-4a28-9fbf-4411813b1197"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("ff0d8b04-9cef-49c9-b0fd-9d27b97da369"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("12e79c43-c732-4f5b-be57-c9f93cf37050"), 2, new DateTime(2024, 1, 12, 9, 9, 53, 769, DateTimeKind.Utc).AddTicks(7673), "Create Desktop Client App for the TaskBoard RESTful Api", "f38b3838-25da-49a2-9b80-9dad1bcb50f7", "Desktop Client App" },
                    { new Guid("26146e20-ecc1-4bb9-8991-0c7b7ff49518"), 1, new DateTime(2023, 9, 12, 9, 9, 53, 769, DateTimeKind.Utc).AddTicks(7668), "Create Android Client App for the TaskBoard RESTful Api", "89f5eb8c-e95a-47c1-8990-f4eae71cbdbd", "Android Client App" },
                    { new Guid("75502fad-3e48-44b0-9a22-85d963560131"), 1, new DateTime(2023, 7, 27, 9, 9, 53, 769, DateTimeKind.Utc).AddTicks(7646), "Implement better styling for the pages", "89f5eb8c-e95a-47c1-8990-f4eae71cbdbd", "Improve CSS" },
                    { new Guid("e666c5b6-3e60-470d-91b9-617741e422a2"), 3, new DateTime(2023, 2, 12, 9, 9, 53, 769, DateTimeKind.Utc).AddTicks(7687), "Implement [Create Task] page for adding new tasks", "f38b3838-25da-49a2-9b80-9dad1bcb50f7", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_OwnerId",
                table: "Tasks",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_OwnerId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("12e79c43-c732-4f5b-be57-c9f93cf37050"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("26146e20-ecc1-4bb9-8991-0c7b7ff49518"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("75502fad-3e48-44b0-9a22-85d963560131"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("e666c5b6-3e60-470d-91b9-617741e422a2"));

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: true);

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
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
