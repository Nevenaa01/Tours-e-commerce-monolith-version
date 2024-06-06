using System;
using Explorer.Stakeholders.Core.Domain.Followers;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Explorer.Stakeholders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "stakeholders");

            migrationBuilder.CreateTable(
                name: "ApplicationRatings",
                schema: "stakeholders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRatings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "stakeholders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    RecipientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserNews",
                schema: "stakeholders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TouristId = table.Column<long>(type: "bigint", nullable: false),
                    LastSendMs = table.Column<long>(type: "bigint", nullable: false),
                    SendingPeriod = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "stakeholders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ResetPasswordToken = table.Column<string>(type: "text", nullable: true),
                    EmailVerificationToken = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                schema: "stakeholders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ClubPicture = table.Column<string>(type: "text", nullable: false),
                    TouristId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_Users_TouristId",
                        column: x => x.TouristId,
                        principalSchema: "stakeholders",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                schema: "stakeholders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ProfilePic = table.Column<string>(type: "text", nullable: true),
                    Biography = table.Column<string>(type: "text", nullable: true),
                    Motto = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "stakeholders",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JoinRequests",
                schema: "stakeholders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClubId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RequestStatus = table.Column<string>(type: "text", nullable: false),
                    RequestDirection = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JoinRequests_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalSchema: "stakeholders",
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JoinRequests_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "stakeholders",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Followers",
                schema: "stakeholders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FollowerId = table.Column<long>(type: "bigint", nullable: false),
                    FollowedId = table.Column<long>(type: "bigint", nullable: false),
                    Notification = table.Column<FollowerNotification>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Followers_People_FollowedId",
                        column: x => x.FollowedId,
                        principalSchema: "stakeholders",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Followers_People_FollowerId",
                        column: x => x.FollowerId,
                        principalSchema: "stakeholders",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_TouristId",
                schema: "stakeholders",
                table: "Clubs",
                column: "TouristId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Followers_FollowedId",
                schema: "stakeholders",
                table: "Followers",
                column: "FollowedId");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_FollowerId",
                schema: "stakeholders",
                table: "Followers",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_JoinRequests_ClubId",
                schema: "stakeholders",
                table: "JoinRequests",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_JoinRequests_UserId",
                schema: "stakeholders",
                table: "JoinRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_People_UserId",
                schema: "stakeholders",
                table: "People",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                schema: "stakeholders",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationRatings",
                schema: "stakeholders");

            migrationBuilder.DropTable(
                name: "Followers",
                schema: "stakeholders");

            migrationBuilder.DropTable(
                name: "JoinRequests",
                schema: "stakeholders");

            migrationBuilder.DropTable(
                name: "Messages",
                schema: "stakeholders");

            migrationBuilder.DropTable(
                name: "UserNews",
                schema: "stakeholders");

            migrationBuilder.DropTable(
                name: "People",
                schema: "stakeholders");

            migrationBuilder.DropTable(
                name: "Clubs",
                schema: "stakeholders");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "stakeholders");
        }
    }
}
