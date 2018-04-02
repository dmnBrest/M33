using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace M33.Data.Migrations
{
    public partial class AddedTrackableInterface : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Post",
                newName: "LastUpdatedAt");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Post",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "Post",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedAt",
                table: "Post",
                newName: "UpdatedAt");
        }
    }
}
