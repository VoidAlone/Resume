using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Migrations
{
    /// <inheritdoc />
    public partial class UserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_AccountId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_AccountId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Socials",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Skills",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Projects",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Profiles",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Experiences",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Education",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Courses",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Contacts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Certificates",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Socials",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Skills",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Projects",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Profiles",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Experiences",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Education",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Courses",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Contacts",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Certificates",
                newName: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AccountId",
                table: "Profiles",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_AccountId",
                table: "Profiles",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
