using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminGym.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_description_Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c4c9995-bb28-48ec-b996-08dce30ff7b4"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 13, 34, 57, 891, DateTimeKind.Local).AddTicks(9974), new DateTime(2024, 10, 2, 13, 34, 57, 891, DateTimeKind.Local).AddTicks(9975) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("079037ca-3268-412d-8e94-027f0ae516bc"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 13, 34, 57, 891, DateTimeKind.Local).AddTicks(8838), new DateTime(2024, 10, 2, 13, 34, 57, 891, DateTimeKind.Local).AddTicks(8839) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("38c56b87-e1ac-4f7e-8210-5592cc336147"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 13, 34, 57, 891, DateTimeKind.Local).AddTicks(8819), new DateTime(2024, 10, 2, 13, 34, 57, 891, DateTimeKind.Local).AddTicks(8834) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("59f84721-14d7-40cf-aba7-d2f7857bed0f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 13, 34, 57, 891, DateTimeKind.Local).AddTicks(8845), new DateTime(2024, 10, 2, 13, 34, 57, 891, DateTimeKind.Local).AddTicks(8847) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("7f51c649-2241-49cd-a6b9-4480619f8dad"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 13, 34, 57, 891, DateTimeKind.Local).AddTicks(8842), new DateTime(2024, 10, 2, 13, 34, 57, 891, DateTimeKind.Local).AddTicks(8843) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c4c9995-bb28-48ec-b996-08dce30ff7b4"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 13, 27, 57, 891, DateTimeKind.Local).AddTicks(7577), new DateTime(2024, 10, 2, 13, 27, 57, 891, DateTimeKind.Local).AddTicks(7580) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("079037ca-3268-412d-8e94-027f0ae516bc"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 13, 27, 57, 891, DateTimeKind.Local).AddTicks(6162), new DateTime(2024, 10, 2, 13, 27, 57, 891, DateTimeKind.Local).AddTicks(6163) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("38c56b87-e1ac-4f7e-8210-5592cc336147"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 13, 27, 57, 891, DateTimeKind.Local).AddTicks(6123), new DateTime(2024, 10, 2, 13, 27, 57, 891, DateTimeKind.Local).AddTicks(6154) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("59f84721-14d7-40cf-aba7-d2f7857bed0f"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 13, 27, 57, 891, DateTimeKind.Local).AddTicks(6179), new DateTime(2024, 10, 2, 13, 27, 57, 891, DateTimeKind.Local).AddTicks(6181) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("7f51c649-2241-49cd-a6b9-4480619f8dad"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 13, 27, 57, 891, DateTimeKind.Local).AddTicks(6171), new DateTime(2024, 10, 2, 13, 27, 57, 891, DateTimeKind.Local).AddTicks(6172) });
        }
    }
}
