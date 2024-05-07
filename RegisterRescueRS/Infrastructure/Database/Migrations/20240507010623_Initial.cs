﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisterRescueRS.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    ShelterId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Login = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ShelterName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.ShelterId);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    FamilyId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ShelterId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ResponsableId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    RegisteredAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.FamilyId);
                    table.ForeignKey(
                        name: "FK_Families_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "ShelterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houseds",
                columns: table => new
                {
                    HousedId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    FamilyId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Cellphone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsFamilyResponsable = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FamilyResponsableId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    RegisteredAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houseds", x => x.HousedId);
                    table.ForeignKey(
                        name: "FK_Houseds_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Families_ResponsableId",
                table: "Families",
                column: "ResponsableId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Families_ShelterId",
                table: "Families",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Houseds_FamilyId",
                table: "Houseds",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Families_Houseds_ResponsableId",
                table: "Families",
                column: "ResponsableId",
                principalTable: "Houseds",
                principalColumn: "HousedId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_Houseds_ResponsableId",
                table: "Families");

            migrationBuilder.DropTable(
                name: "Houseds");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "Shelters");
        }
    }
}
