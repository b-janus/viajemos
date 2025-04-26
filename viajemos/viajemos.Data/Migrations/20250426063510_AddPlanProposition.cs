using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace viajemos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanProposition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TripProposition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BudgetMax = table.Column<int>(type: "integer", nullable: false),
                    ParticipantsMin = table.Column<int>(type: "integer", nullable: false),
                    ParticipantsMax = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripProposition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripProposition_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripPropositionPlace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TripPropositionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripPropositionPlace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripPropositionPlace_TripProposition_TripPropositionId",
                        column: x => x.TripPropositionId,
                        principalTable: "TripProposition",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripProposition_OwnerId",
                table: "TripProposition",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TripProposition_StartDate_EndDate",
                table: "TripProposition",
                columns: new[] { "StartDate", "EndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_TripPropositionPlace_Name",
                table: "TripPropositionPlace",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_TripPropositionPlace_TripPropositionId",
                table: "TripPropositionPlace",
                column: "TripPropositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripPropositionPlace");

            migrationBuilder.DropTable(
                name: "TripProposition");
        }
    }
}
