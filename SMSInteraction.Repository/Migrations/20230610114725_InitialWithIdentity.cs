using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSInteraction.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmsInteractions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    InteractionType = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreationUtcDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    EnabledUtcDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisabledUtcDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LotteryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsInteractions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SmsInteractionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_SmsInteractions_SmsInteractionId",
                        column: x => x.SmsInteractionId,
                        principalTable: "SmsInteractions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lottaries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    WinnerCount = table.Column<int>(type: "int", nullable: false),
                    CreationDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmsInteractionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lottaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lottaries_SmsInteractions_SmsInteractionId",
                        column: x => x.SmsInteractionId,
                        principalTable: "SmsInteractions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAnswers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreationUtcDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmsInteractionId = table.Column<long>(type: "bigint", nullable: false),
                    AnswerId = table.Column<long>(type: "bigint", nullable: false),
                    LotteryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAnswers_Lottaries_LotteryId",
                        column: x => x.LotteryId,
                        principalTable: "Lottaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAnswers_SmsInteractions_SmsInteractionId",
                        column: x => x.SmsInteractionId,
                        principalTable: "SmsInteractions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_SmsInteractionId",
                table: "Answers",
                column: "SmsInteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Lottaries_SmsInteractionId",
                table: "Lottaries",
                column: "SmsInteractionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_AnswerId",
                table: "UserAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_LotteryId",
                table: "UserAnswers",
                column: "LotteryId");

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

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Lottaries");

            migrationBuilder.DropTable(
                name: "SmsInteractions");
        }
    }
}
