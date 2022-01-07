using Microsoft.EntityFrameworkCore.Migrations;

namespace JudgeSystem.Data.Migrations
{
    public partial class placeholderToProblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MethodPlaceholder",
                table: "Problems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartPlaceholder",
                table: "Problems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MethodPlaceholder",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "StartPlaceholder",
                table: "Problems");
        }
    }
}
