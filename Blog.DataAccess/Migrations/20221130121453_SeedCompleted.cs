using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("93474aba-5916-42e7-a39f-b2ad533546c0"), "Admin Test", new DateTime(2022, 11, 30, 15, 14, 52, 738, DateTimeKind.Local).AddTicks(7039), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visual Studio" },
                    { new Guid("a751f387-b6b6-4018-9a86-68254c85a3e4"), "Admin Test", new DateTime(2022, 11, 30, 15, 14, 52, 738, DateTimeKind.Local).AddTicks(7033), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("11b1a1f9-e7f7-44cc-8e3b-d408f1e59a50"), "Admin Test", new DateTime(2022, 11, 30, 15, 14, 52, 738, DateTimeKind.Local).AddTicks(7253), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/vstest", "png", false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b78f495c-995b-458e-9c49-ef26517917d6"), "Admin Test", new DateTime(2022, 11, 30, 15, 14, 52, 738, DateTimeKind.Local).AddTicks(7248), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/testimage", "jpg", false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("693a0e5d-b2ba-4a40-b872-4c8b15410fe5"), new Guid("93474aba-5916-42e7-a39f-b2ad533546c0"), "Visual Studio Lorem ipsum.", "Admin Test", new DateTime(2022, 11, 30, 15, 14, 52, 738, DateTimeKind.Local).AddTicks(6552), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11b1a1f9-e7f7-44cc-8e3b-d408f1e59a50"), false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visual Studio Deneme Makalesi 1", 15 },
                    { new Guid("ed160efb-4037-4430-ad42-2789c1f9a147"), new Guid("a751f387-b6b6-4018-9a86-68254c85a3e4"), "Lorem ipsum.", "Admin Test", new DateTime(2022, 11, 30, 15, 14, 52, 738, DateTimeKind.Local).AddTicks(6535), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b78f495c-995b-458e-9c49-ef26517917d6"), false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asp.net Core Deneme Makalesi 1", 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("693a0e5d-b2ba-4a40-b872-4c8b15410fe5"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ed160efb-4037-4430-ad42-2789c1f9a147"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("93474aba-5916-42e7-a39f-b2ad533546c0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a751f387-b6b6-4018-9a86-68254c85a3e4"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("11b1a1f9-e7f7-44cc-8e3b-d408f1e59a50"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b78f495c-995b-458e-9c49-ef26517917d6"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
