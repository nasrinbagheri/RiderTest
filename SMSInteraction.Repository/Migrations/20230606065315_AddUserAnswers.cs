using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSInteraction.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreationUtcDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmsInteractionId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserAnswers_SmsInteractions_SmsInteractionId",
                        column: x => x.SmsInteractionId,
                        principalTable: "SmsInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_AnswerId",
                table: "UserAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_MobileNo_SmsInteractionId",
                table: "UserAnswers",
                columns: new[] { "MobileNo", "SmsInteractionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_SmsInteractionId",
                table: "UserAnswers",
                column: "SmsInteractionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnswers");
        }
    }
}
