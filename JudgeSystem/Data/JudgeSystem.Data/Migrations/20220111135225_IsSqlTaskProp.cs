using Microsoft.EntityFrameworkCore.Migrations;

namespace JudgeSystem.Data.Migrations
{
    public partial class IsSqlTaskProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSqlTask",
                table: "Problems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SqlProcedureName",
                table: "Problems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSqlTask",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "SqlProcedureName",
                table: "Problems");
        }
    }
}
