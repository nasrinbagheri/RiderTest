using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSInteraction.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddLottary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LottaryId",
                table: "UserAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LottaryId",
                table: "SmsInteractions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lottaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinnerCount = table.Column<int>(type: "int", nullable: false),
                    CreationDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmsInteractionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lottaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lottaries_SmsInteractions_SmsInteractionId",
                        column: x => x.SmsInteractionId,
                        principalTable: "SmsInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_LottaryId",
                table: "UserAnswers",
                column: "LottaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Lottaries_SmsInteractionId",
                table: "Lottaries",
                column: "SmsInteractionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Lottaries_LottaryId",
                table: "UserAnswers",
                column: "LottaryId",
                principalTable: "Lottaries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Lottaries_LottaryId",
                table: "UserAnswers");

            migrationBuilder.DropTable(
                name: "Lottaries");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_LottaryId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "LottaryId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "LottaryId",
                table: "SmsInteractions");
        }
    }
}
