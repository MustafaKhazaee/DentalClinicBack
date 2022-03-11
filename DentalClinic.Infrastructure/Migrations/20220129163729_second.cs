using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Infrastructure.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserId", "RoleId" },
                keyValues: new object[] { new Guid("81cae438-d33c-42eb-b165-f1703ae1b2f4"), new Guid("8efb4c1d-a853-49fd-a56a-573c7a3de365") });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("671d8781-f0ed-4320-98cf-b6a8f06a35e9"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("be0d65e2-9236-4989-8471-82ef2d8f13a5"), new Guid("8efb4c1d-a853-49fd-a56a-573c7a3de365") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("81cae438-d33c-42eb-b165-f1703ae1b2f4"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("be0d65e2-9236-4989-8471-82ef2d8f13a5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8efb4c1d-a853-49fd-a56a-573c7a3de365"));

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Patients",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Employees",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Doctors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Password", "Salt", "UserName", "UserType", "isLocked" },
                values: new object[] { new Guid("34055031-2274-4be8-97cc-c2f45b265c22"), "System", new DateTime(2022, 1, 29, 21, 7, 28, 361, DateTimeKind.Local).AddTicks(6465), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ce59ef57b130deda9e5bbc3a877ebbad16ad72291f12d917166bcd7a0bbcc90b", "21da6093f43b52e12f101745b2ccbe5a", "mustafa", 0, false });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code" },
                values: new object[] { new Guid("49a62ad3-51ef-4a44-b4fe-57a008867414"), "r" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("ac4b45dc-05ef-49f0-b958-6549987e499a"), "System Developer" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserId", "RoleId" },
                values: new object[] { new Guid("34055031-2274-4be8-97cc-c2f45b265c22"), new Guid("ac4b45dc-05ef-49f0-b958-6549987e499a") });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "AppUserId", "CreatedBy", "CreatedDate", "DateOfBirth", "Email", "FirstName", "Gender", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "LastName", "Mobile", "Photo" },
                values: new object[] { new Guid("63fbbd24-c37d-490d-8abe-8532c1c6d727"), null, new Guid("34055031-2274-4be8-97cc-c2f45b265c22"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mustafakhazaee@gmail.com", "Mustafa", 0, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khazaee", "+93747286603", null });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("49a62ad3-51ef-4a44-b4fe-57a008867414"), new Guid("ac4b45dc-05ef-49f0-b958-6549987e499a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserId", "RoleId" },
                keyValues: new object[] { new Guid("34055031-2274-4be8-97cc-c2f45b265c22"), new Guid("ac4b45dc-05ef-49f0-b958-6549987e499a") });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("63fbbd24-c37d-490d-8abe-8532c1c6d727"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("49a62ad3-51ef-4a44-b4fe-57a008867414"), new Guid("ac4b45dc-05ef-49f0-b958-6549987e499a") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("34055031-2274-4be8-97cc-c2f45b265c22"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("49a62ad3-51ef-4a44-b4fe-57a008867414"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ac4b45dc-05ef-49f0-b958-6549987e499a"));

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Doctors");

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Password", "Salt", "UserName", "UserType", "isLocked" },
                values: new object[] { new Guid("81cae438-d33c-42eb-b165-f1703ae1b2f4"), "System", new DateTime(2021, 12, 17, 13, 32, 29, 741, DateTimeKind.Local).AddTicks(6234), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "51c3f087d8915b91a53f00a4068f4c58defad56fa93fa756830a647c2989bb22", "f67efd51e433d4cbdbd2af85dceceda1", "mustafa", 0, false });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code" },
                values: new object[] { new Guid("be0d65e2-9236-4989-8471-82ef2d8f13a5"), "r" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("8efb4c1d-a853-49fd-a56a-573c7a3de365"), "System Developer" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserId", "RoleId" },
                values: new object[] { new Guid("81cae438-d33c-42eb-b165-f1703ae1b2f4"), new Guid("8efb4c1d-a853-49fd-a56a-573c7a3de365") });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "AppUserId", "CreatedBy", "CreatedDate", "DateOfBirth", "Email", "FirstName", "Gender", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "LastName", "Mobile" },
                values: new object[] { new Guid("671d8781-f0ed-4320-98cf-b6a8f06a35e9"), null, new Guid("81cae438-d33c-42eb-b165-f1703ae1b2f4"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mustafakhazaee@gmail.com", "Mustafa", 0, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khazaee", "+93747286603" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { new Guid("be0d65e2-9236-4989-8471-82ef2d8f13a5"), new Guid("8efb4c1d-a853-49fd-a56a-573c7a3de365") });
        }
    }
}
