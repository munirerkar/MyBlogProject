using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("25cfba34-864c-4018-b018-b8202179b1e2"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("85b814c3-dc3d-4b97-89d3-aaaa68499044"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("0b363633-9cf7-4750-b620-aef4b47b63eb"), new Guid("a751f387-b6b6-4018-9a86-68254c85a3e4"), "Lorem ipsum.", "Admin Test", new DateTime(2022, 12, 7, 15, 56, 34, 224, DateTimeKind.Local).AddTicks(108), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b78f495c-995b-458e-9c49-ef26517917d6"), false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asp.net Core Deneme Makalesi 1", 15 },
                    { new Guid("3a738bab-5154-4ea2-98f9-a00ec2ca5cb8"), new Guid("93474aba-5916-42e7-a39f-b2ad533546c0"), "Visual Studio Lorem ipsum.", "Admin Test", new DateTime(2022, 12, 7, 15, 56, 34, 224, DateTimeKind.Local).AddTicks(128), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11b1a1f9-e7f7-44cc-8e3b-d408f1e59a50"), false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visual Studio Deneme Makalesi 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("960d01de-1859-48d9-add0-4779d0d8db1a"),
                column: "ConcurrencyStamp",
                value: "10899f51-7206-4381-bfcc-6627563066b1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1074d9a7-9ef6-417c-9543-b9a912d40950"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82df0756-9c4b-4c19-8e87-cd54514ca755", "AQAAAAEAACcQAAAAEAlWLMWfi5rvJKL/c/DQCw7oNif0UeA2aTrJLiwtsVu7t8t4Ehqi4fQSSwdAhDJ5JQ==", "e7316481-5b2b-4ba8-96b0-d25e0b7f97be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2a5bc656-d774-465c-9447-6e439052872a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0019721-e8b5-4371-b36a-90f935d2cc1d", "AQAAAAEAACcQAAAAEDnlbz3+x9+TdFhk/zxt0lQ7hxQ31OUy6J7ynrS8BH4tGyTTdDCv/rbDpL39lCQ0Jg==", "441e9ba9-98f0-46c7-b7a4-a4cd88023d0a" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("93474aba-5916-42e7-a39f-b2ad533546c0"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 7, 15, 56, 34, 224, DateTimeKind.Local).AddTicks(405));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a751f387-b6b6-4018-9a86-68254c85a3e4"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 7, 15, 56, 34, 224, DateTimeKind.Local).AddTicks(399));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("11b1a1f9-e7f7-44cc-8e3b-d408f1e59a50"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 7, 15, 56, 34, 224, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b78f495c-995b-458e-9c49-ef26517917d6"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 7, 15, 56, 34, 224, DateTimeKind.Local).AddTicks(565));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0b363633-9cf7-4750-b620-aef4b47b63eb"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("3a738bab-5154-4ea2-98f9-a00ec2ca5cb8"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("25cfba34-864c-4018-b018-b8202179b1e2"), new Guid("93474aba-5916-42e7-a39f-b2ad533546c0"), "Visual Studio Lorem ipsum.", "Admin Test", new DateTime(2022, 12, 7, 15, 54, 53, 375, DateTimeKind.Local).AddTicks(8045), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11b1a1f9-e7f7-44cc-8e3b-d408f1e59a50"), false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visual Studio Deneme Makalesi 1", 15 },
                    { new Guid("85b814c3-dc3d-4b97-89d3-aaaa68499044"), new Guid("a751f387-b6b6-4018-9a86-68254c85a3e4"), "Lorem ipsum.", "Admin Test", new DateTime(2022, 12, 7, 15, 54, 53, 375, DateTimeKind.Local).AddTicks(8030), "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b78f495c-995b-458e-9c49-ef26517917d6"), false, "Admin Test", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asp.net Core Deneme Makalesi 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("960d01de-1859-48d9-add0-4779d0d8db1a"),
                column: "ConcurrencyStamp",
                value: "9026f81d-a2f8-4b1d-a3ad-73a9b7f5856c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1074d9a7-9ef6-417c-9543-b9a912d40950"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2160161-eb99-418f-9f3e-a53d3068aacc", "AQAAAAEAACcQAAAAEOd6zXKn7Jg3go1FqMgqHGToDWwnLfZOGtda6XKOTH+QIT/YXjW2T4IXHQSCXsUJdw==", "ea1e49af-b213-4294-8680-fd2d201c5715" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2a5bc656-d774-465c-9447-6e439052872a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f49b0c9-20b7-4bef-a5c9-ffa323b6480d", "AQAAAAEAACcQAAAAEKVK/Xl6greSk1qEDYr143aGhVSI4S7lTNwRYeULH1dlg6oLVjhUsV/ZFqzZqCJNBQ==", "b28eb985-ccf1-4bab-b6be-48883c119c60" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("93474aba-5916-42e7-a39f-b2ad533546c0"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 7, 15, 54, 53, 375, DateTimeKind.Local).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a751f387-b6b6-4018-9a86-68254c85a3e4"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 7, 15, 54, 53, 375, DateTimeKind.Local).AddTicks(8369));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("11b1a1f9-e7f7-44cc-8e3b-d408f1e59a50"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 7, 15, 54, 53, 375, DateTimeKind.Local).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b78f495c-995b-458e-9c49-ef26517917d6"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 7, 15, 54, 53, 375, DateTimeKind.Local).AddTicks(8563));
        }
    }
}
