using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLastCommentDateToTopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastCommentDate",
                table: "Topics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                columns: new[] { "CreationDate", "LastCommentDate" },
                values: new object[] { new DateTime(2024, 6, 11, 14, 21, 52, 294, DateTimeKind.Local).AddTicks(3886), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastCommentDate" },
                values: new object[] { new DateTime(2024, 6, 11, 15, 21, 52, 294, DateTimeKind.Local).AddTicks(3906), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "LastCommentDate" },
                values: new object[] { new DateTime(2024, 6, 11, 16, 21, 52, 294, DateTimeKind.Local).AddTicks(3919), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastCommentDate",
                table: "Topics");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8716071C-1D9B-48FD-B3D0-F059C4FB8031",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "729a322f-d2ad-4687-8535-036fbc4d5d28", "AQAAAAIAAYagAAAAEMXB8ZozWF0McQvCnn64Wc8W9c2ZetKRuHzCRHkOszh1J+D7Ji/t+U9JjI8lThXIWQ==", "d181716c-192b-4880-a811-928e8940b8fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87746F88-DC38-4756-924A-B95CFF3A1D8A",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "524c6312-e9ed-4080-b02b-79dd4b3f94c6", "AQAAAAIAAYagAAAAEDtLNeyHzf0wYq16gC9xt368BNl0wJJAuvLPIdYoe0X0P/MsP7x0xZ3Cm0pe16msPQ==", "e89c4667-e007-460b-8f7c-67cd4d59040d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D514EDC9-94BB-416F-AF9D-7C13669689C9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8976ae6d-85ba-4f3b-bfe3-0201384de846", "AQAAAAIAAYagAAAAEHP8SRPEGbx6tOHe7P5wGCF2RLOMVRPHPGTUD6aTF846rEn1ftImdet9Vgu6M84scQ==", "43ea8050-c0b1-4c49-a25b-19d5175c801d" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 24, 21, 16, 6, 53, DateTimeKind.Local).AddTicks(5967));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 24, 21, 36, 6, 53, DateTimeKind.Local).AddTicks(5969));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 24, 22, 6, 6, 53, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 5, 25, 21, 16, 6, 53, DateTimeKind.Local).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 5, 24, 21, 16, 6, 53, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 5, 24, 22, 16, 6, 53, DateTimeKind.Local).AddTicks(5777));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 5, 24, 23, 16, 6, 53, DateTimeKind.Local).AddTicks(5787));
        }
    }
}
