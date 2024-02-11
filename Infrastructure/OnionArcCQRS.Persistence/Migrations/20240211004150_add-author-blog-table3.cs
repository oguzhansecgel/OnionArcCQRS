using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionArcCQRS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addauthorblogtable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AouthorID",
                table: "Blogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AouthorID",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
