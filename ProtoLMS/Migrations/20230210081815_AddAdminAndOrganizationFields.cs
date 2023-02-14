using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProtoLMS.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminAndOrganizationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Administrator",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Administrator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Administrator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Administrator",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_OrganizationId",
                table: "Administrator",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrator_Organization_OrganizationId",
                table: "Administrator",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrator_Organization_OrganizationId",
                table: "Administrator");

            migrationBuilder.DropIndex(
                name: "IX_Administrator_OrganizationId",
                table: "Administrator");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Administrator");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Administrator");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Administrator");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Administrator",
                newName: "Name");
        }
    }
}
