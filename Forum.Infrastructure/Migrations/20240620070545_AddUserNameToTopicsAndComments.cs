using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNameToTopicsAndComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8716071C-1D9B-48FD-B3D0-F059C4FB8031",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56b12de3-ff57-4911-986e-83b62ceb6008", "AQAAAAIAAYagAAAAENTMHlW0g6OhQB2Zdr8B86vhv/sXRBTdcmQdYt6dqX5Z2RGpZg6XcBnRUIXldBoWng==", "abc40ab6-a3c2-4e65-911c-6500b4e2e5f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87746F88-DC38-4756-924A-B95CFF3A1D8A",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "464b1588-f6fd-49bc-99c7-624c0f5e77b9", "AQAAAAIAAYagAAAAEEljNTqYDDWdSL6yIdrh743SO699NfclTJswivEwAifUDe6aJVfiQKzFyjILlwKhdA==", "2702cd6d-aeb2-4f29-a1cd-2fb0eae2546a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D514EDC9-94BB-416F-AF9D-7C13669689C9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64d7274e-a3bf-4977-984f-9212251b9e8b", "AQAAAAIAAYagAAAAEITqNzvsWKfFFhTYJivIiDU60lZ/wAOfin5xtgnm+oxneFT/L8U2WKrmSk74ESrBPA==", "a82089ee-3e6a-4f55-84a8-66bae6517498" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UserName" },
                values: new object[] { new DateTime(2024, 6, 20, 11, 5, 44, 337, DateTimeKind.Local).AddTicks(9344), "" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UserName" },
                values: new object[] { new DateTime(2024, 6, 20, 11, 25, 44, 337, DateTimeKind.Local).AddTicks(9348), "" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UserName" },
                values: new object[] { new DateTime(2024, 6, 20, 11, 55, 44, 337, DateTimeKind.Local).AddTicks(9352), "" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "UserName" },
                values: new object[] { new DateTime(2024, 6, 21, 11, 5, 44, 337, DateTimeKind.Local).AddTicks(9355), "" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "UserName" },
                values: new object[] { new DateTime(2024, 6, 20, 11, 5, 44, 337, DateTimeKind.Local).AddTicks(9225), "" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "UserName" },
                values: new object[] { new DateTime(2024, 6, 20, 12, 5, 44, 337, DateTimeKind.Local).AddTicks(9246), "" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "UserName" },
                values: new object[] { new DateTime(2024, 6, 20, 13, 5, 44, 337, DateTimeKind.Local).AddTicks(9257), "" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8716071C-1D9B-48FD-B3D0-F059C4FB8031",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff6ddcda-38b6-4261-bc9c-a39a6ff6dbd8", "AQAAAAIAAYagAAAAEE8nwGHALx0PsHGIotX5YChsBDc3v3dYfxz3TMAIxWRKM0FyJgBVbBt25/8YSP+v6A==", "d3505439-63aa-4cac-8983-b02e7ad6cf3a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87746F88-DC38-4756-924A-B95CFF3A1D8A",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05dfcb80-4035-4667-9fdd-fd32cd0d05c2", "AQAAAAIAAYagAAAAEDvE8bLGdbvWBnUyMkUnPDh8wsra+I8WxH+R4wDFt+ilRcVlObXXkO60Ooji1EAgrg==", "79acdfa7-9e29-4006-bd8f-7ac727271732" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D514EDC9-94BB-416F-AF9D-7C13669689C9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51b95037-fad0-4b17-b3dd-56ca28f06c97", "AQAAAAIAAYagAAAAENwCrwlkHJxu2xWZ9EQlbsKZUPcIY9ZA+GKxwca0e8Js52RVgznEEP7TvCSLjSOfQg==", "da366b6c-baa2-451d-84d0-79672386eddb" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 14, 21, 52, 294, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 14, 41, 52, 294, DateTimeKind.Local).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 15, 11, 52, 294, DateTimeKind.Local).AddTicks(4107));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 14, 21, 52, 294, DateTimeKind.Local).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 14, 21, 52, 294, DateTimeKind.Local).AddTicks(3886));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 15, 21, 52, 294, DateTimeKind.Local).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 6, 11, 16, 21, 52, 294, DateTimeKind.Local).AddTicks(3919));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
