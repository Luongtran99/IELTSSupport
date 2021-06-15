using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportingIELTSWriting.Data.Migrations
{
    public partial class updateRoleUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRoleID",
                table: "AspNetUserRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleID",
                table: "AspNetUserRoles",
                nullable: true);
        }
    }
}
