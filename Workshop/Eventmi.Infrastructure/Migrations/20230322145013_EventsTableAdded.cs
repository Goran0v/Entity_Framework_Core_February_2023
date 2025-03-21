﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventmi.Infrastructure.Migrations
{
    public partial class EventsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор на запис")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Име на събитието"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Начална дата и час"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Крайна дата и час"),
                    Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Място на събитието")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                },
                comment: "Събития");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
