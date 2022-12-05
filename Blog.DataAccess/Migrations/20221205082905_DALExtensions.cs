using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DALExtensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("693a0e5d-b2ba-4a40-b872-4c8b15410fe5"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ed160efb-4037-4430-ad42-2789c1f9a147"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("7bdf9924-45ba-4978-b96f-47805b3cb539"), new Guid("a751f387-b6b6-4018-9a86-68254c85a3e4"), "Lorem ipsum.", "Admin Test", new DateTime(2022, 12, 5, 11, 29, 5, 576, DateTimeKind.Local).AddTicks(3219), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b78f495c-995b-458e-9c49-ef26517917d6"), false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asp.net Core Deneme Makalesi 1", 15 },
                    { new Guid("a05e8c50-9c53-4970-9195-76bb9c57a23d"), new Guid("93474aba-5916-42e7-a39f-b2ad533546c0"), "Visual Studio Lorem ipsum.", "Admin Test", new DateTime(2022, 12, 5, 11, 29, 5, 576, DateTimeKind.Local).AddTicks(3246), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11b1a1f9-e7f7-44cc-8e3b-d408f1e59a50"), false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visual Studio Deneme Makalesi 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("93474aba-5916-42e7-a39f-b2ad533546c0"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 5, 11, 29, 5, 576, DateTimeKind.Local).AddTicks(3821));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a751f387-b6b6-4018-9a86-68254c85a3e4"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 5, 11, 29, 5, 576, DateTimeKind.Local).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("11b1a1f9-e7f7-44cc-8e3b-d408f1e59a50"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 5, 11, 29, 5, 576, DateTimeKind.Local).AddTicks(4237));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b78f495c-995b-458e-9c49-ef26517917d6"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 5, 11, 29, 5, 576, DateTimeKind.Local).AddTicks(4228));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("7bdf9924-45ba-4978-b96f-47805b3cb539"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a05e8c50-9c53-4970-9195-76bb9c57a23d"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("693a0e5d-b2ba-4a40-b872-4c8b15410fe5"), new Guid("93474aba-5916-42e7-a39f-b2ad533546c0"), "Visual Studio Lorem ipsum.", "Admin Test", new DateTime(2022, 11, 30, 15, 14, 52, 738, DateTimeKind.Local).AddTicks(6552), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11b1a1f9-e7f7-44cc-8e3b-d408f1e59a50"), false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visual Studio Deneme Makalesi 1", 15 },
                    { new Guid("ed160efb-4037-4430-ad42-2789c1f9a147"), new Guid("a751f387-b6b6-4018-9a86-68254c85a3e4"), "Lorem ipsum.", "Admin Test", new DateTime(2022, 11, 30, 15, 14, 52, 738, DateTimeKind.Local).AddTicks(6535), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b78f495c-995b-458e-9c49-ef26517917d6"), false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asp.net Core Deneme Makalesi 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("93474aba-5916-42e7-a39f-b2ad533546c0"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 15, 14, 52, 738, DateTimeKind.Local).AddTicks(7039));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a751f387-b6b6-4018-9a86-68254c85a3e4"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 15, 14, 52, 738, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("11b1a1f9-e7f7-44cc-8e3b-d408f1e59a50"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 15, 14, 52, 738, DateTimeKind.Local).AddTicks(7253));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b78f495c-995b-458e-9c49-ef26517917d6"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 30, 15, 14, 52, 738, DateTimeKind.Local).AddTicks(7248));
        }
    }
}
