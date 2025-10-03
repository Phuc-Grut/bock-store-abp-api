using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class Add_Education_and_UserEducation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppBooks");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AbpUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "EducationId",
                table: "AbpUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppEducation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppEducation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_EducationId",
                table: "AbpUsers",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AppEducation_EducationId",
                table: "AbpUsers",
                column: "EducationId",
                principalTable: "AppEducation",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AppEducation_EducationId",
                table: "AbpUsers");

            migrationBuilder.DropTable(
                name: "AppEducation");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_EducationId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "AbpUsers");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppBooks",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppBooks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppBooks",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
