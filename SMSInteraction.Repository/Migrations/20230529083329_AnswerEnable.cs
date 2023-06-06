using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSInteraction.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AnswerEnable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Answers");
        }
    }
}
