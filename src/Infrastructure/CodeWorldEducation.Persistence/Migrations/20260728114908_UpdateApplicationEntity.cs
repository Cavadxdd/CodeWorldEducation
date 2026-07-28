using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeWorldEducation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "GitHubUrl",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "TeachingMode",
                table: "Applications",
                newName: "EducationMode");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Applications",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Applications",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Field",
                table: "Applications",
                newName: "ReviewedBy");

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppRedirectUrl",
                table: "Applications",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppMessage",
                table: "Applications",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedAt",
                table: "Applications",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 7, 16, 13, 27, 1, 615, DateTimeKind.Utc).AddTicks(4753));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Applications",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BehanceUrl",
                table: "Applications",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DribbbleUrl",
                table: "Applications",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Applications",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedAt",
                table: "Applications",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DribbbleUrl",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ReviewedAt",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "ReviewedBy",
                table: "Applications",
                newName: "Field");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Applications",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Applications",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "EducationMode",
                table: "Applications",
                newName: "TeachingMode");

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppRedirectUrl",
                table: "Applications",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppMessage",
                table: "Applications",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedAt",
                table: "Applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 7, 16, 13, 27, 1, 615, DateTimeKind.Utc).AddTicks(4753),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Applications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BehanceUrl",
                table: "Applications",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Applications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GitHubUrl",
                table: "Applications",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Applications",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true);
        }
    }
}
