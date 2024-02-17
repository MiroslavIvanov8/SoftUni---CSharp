using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts.Data.Migrations
{
    public partial class DbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserContact_AspNetUsers_IdentityUserId",
                table: "IdentityUserContact");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserContact_Contact_ContactId",
                table: "IdentityUserContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserContact",
                table: "IdentityUserContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "IdentityUserContact",
                newName: "IdentityUsersContacts");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserContact_IdentityUserId",
                table: "IdentityUsersContacts",
                newName: "IX_IdentityUsersContacts_IdentityUserId");

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUsersContacts",
                table: "IdentityUsersContacts",
                columns: new[] { "ContactId", "IdentityUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatorId",
                value: "5e819879-3de3-4b39-ba9c-a208b98ee46a");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CreatorId",
                table: "Contacts",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_CreatorId",
                table: "Contacts",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsersContacts_AspNetUsers_IdentityUserId",
                table: "IdentityUsersContacts",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsersContacts_Contacts_ContactId",
                table: "IdentityUsersContacts",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_CreatorId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsersContacts_AspNetUsers_IdentityUserId",
                table: "IdentityUsersContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsersContacts_Contacts_ContactId",
                table: "IdentityUsersContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUsersContacts",
                table: "IdentityUsersContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CreatorId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "IdentityUsersContacts",
                newName: "IdentityUserContact");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUsersContacts_IdentityUserId",
                table: "IdentityUserContact",
                newName: "IX_IdentityUserContact_IdentityUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserContact",
                table: "IdentityUserContact",
                columns: new[] { "ContactId", "IdentityUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserContact_AspNetUsers_IdentityUserId",
                table: "IdentityUserContact",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserContact_Contact_ContactId",
                table: "IdentityUserContact",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id");
        }
    }
}
