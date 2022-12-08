using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCEF2.Migrations
{
    /// <inheritdoc />
    public partial class GroupUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Group_IdProject",
                table: "Group",
                column: "IdProject");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Project_IdProject",
                table: "Group",
                column: "IdProject",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Project_IdProject",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_IdProject",
                table: "Group");
        }
    }
}
