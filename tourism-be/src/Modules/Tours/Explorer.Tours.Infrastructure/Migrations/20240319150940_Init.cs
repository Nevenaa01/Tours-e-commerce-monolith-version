using System;
using System.Collections.Generic;
using Explorer.Blog.Core.Domain;
using Explorer.Tours.Core.Domain.Sessions;
using Explorer.Tours.Core.Domain.Tours;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Explorer.Tours.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tours");

            migrationBuilder.CreateTable(
                name: "Equipment",
                schema: "tours",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTrackings",
                schema: "tours",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TouristId = table.Column<long>(type: "bigint", nullable: false),
                    NeededEquipment = table.Column<List<long>>(type: "bigint[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTrackings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                schema: "tours",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    CreatorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionSimulators",
                schema: "tours",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    TouristId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionSimulators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                schema: "tours",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "integer", nullable: false),
                    WalkingRate = table.Column<int>(type: "integer", nullable: false),
                    BicycleRate = table.Column<int>(type: "integer", nullable: false),
                    CarRate = table.Column<int>(type: "integer", nullable: false),
                    BoatRate = table.Column<int>(type: "integer", nullable: false),
                    Tags = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tour",
                schema: "tours",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    Tags = table.Column<List<string>>(type: "text[]", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    Equipment = table.Column<int[]>(type: "integer[]", nullable: false),
                    DistanceInKm = table.Column<double>(type: "double precision", nullable: false),
                    ArchivedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Durations = table.Column<List<TourDuration>>(type: "jsonb", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourProblems",
                schema: "tours",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TouristId = table.Column<long>(type: "bigint", nullable: false),
                    TourId = table.Column<long>(type: "bigint", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsSolved = table.Column<bool>(type: "boolean", nullable: false),
                    Messages = table.Column<List<TourProblemMessage>>(type: "jsonb", nullable: false),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourProblems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourRatings",
                schema: "tours",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    TourId = table.Column<long>(type: "bigint", nullable: false),
                    Mark = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    DateOfVisit = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateOfCommenting = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Images = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourRatings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                schema: "tours",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TourId = table.Column<long>(type: "bigint", nullable: false),
                    TouristId = table.Column<long>(type: "bigint", nullable: false),
                    LocationId = table.Column<long>(type: "bigint", nullable: false),
                    SessionStatus = table.Column<int>(type: "integer", nullable: false),
                    Transportation = table.Column<int>(type: "integer", nullable: false),
                    DistanceCrossedPercent = table.Column<int>(type: "integer", nullable: false),
                    LastActivity = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedKeyPoints = table.Column<List<CompletedKeyPoint>>(type: "jsonb", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_PositionSimulators_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "tours",
                        principalTable: "PositionSimulators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Tour_TourId",
                        column: x => x.TourId,
                        principalSchema: "tours",
                        principalTable: "Tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourKeyPoints",
                schema: "tours",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    TourId = table.Column<long>(type: "bigint", nullable: true),
                    Secret = table.Column<string>(type: "text", nullable: true),
                    PositionInTour = table.Column<int>(type: "integer", nullable: true),
                    PublicPointId = table.Column<long>(type: "bigint", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    CreatorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourKeyPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourKeyPoints_Tour_TourId",
                        column: x => x.TourId,
                        principalSchema: "tours",
                        principalTable: "Tour",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DomainEvent",
                schema: "tours",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AggregateRootId = table.Column<long>(type: "bigint", nullable: false),
                    EventType = table.Column<string>(type: "text", nullable: false),
                    SessionId = table.Column<long>(type: "bigint", nullable: true),
                    TimeOfCompletion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true),
                    TimeOfCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DomainEvent_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalSchema: "tours",
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_SessionId",
                schema: "tours",
                table: "DomainEvent",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionSimulators_TouristId",
                schema: "tours",
                table: "PositionSimulators",
                column: "TouristId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_LocationId",
                schema: "tours",
                table: "Sessions",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TourId",
                schema: "tours",
                table: "Sessions",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourKeyPoints_TourId",
                schema: "tours",
                table: "TourKeyPoints",
                column: "TourId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DomainEvent",
                schema: "tours");

            migrationBuilder.DropTable(
                name: "Equipment",
                schema: "tours");

            migrationBuilder.DropTable(
                name: "EquipmentTrackings",
                schema: "tours");

            migrationBuilder.DropTable(
                name: "Facilities",
                schema: "tours");

            migrationBuilder.DropTable(
                name: "Preferences",
                schema: "tours");

            migrationBuilder.DropTable(
                name: "TourKeyPoints",
                schema: "tours");

            migrationBuilder.DropTable(
                name: "TourProblems",
                schema: "tours");

            migrationBuilder.DropTable(
                name: "TourRatings",
                schema: "tours");

            migrationBuilder.DropTable(
                name: "Sessions",
                schema: "tours");

            migrationBuilder.DropTable(
                name: "PositionSimulators",
                schema: "tours");

            migrationBuilder.DropTable(
                name: "Tour",
                schema: "tours");
        }
    }
}
