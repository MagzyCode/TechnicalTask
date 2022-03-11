using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerPart.Migrations
{
    public partial class CreatingIdentityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("0c76422f-9f76-4045-bd21-8d42ee8be8d8"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("1a27db8f-c49d-4681-afd9-5effcbe2d129"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("33fbac7e-b1b7-4c77-b20c-39f849e906ec"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("4b8c62cf-a399-4256-8aed-047b96b2ca08"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("4d44173f-58d8-44f0-b546-a8404835dade"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("50ee0c45-8bff-49e8-a110-184e11bd0543"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("53a6f44f-c7fc-45a9-bfa5-59a91a813469"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("55415e8a-12cc-4929-885a-13b67fee4755"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("65b11ec0-253c-4a84-959c-e61cd3eeba9b"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("8c0152ad-30fd-4c9f-88f0-4b3e511e96d5"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("93badec8-1d74-4a9c-b768-ab2c09d71504"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("96a80df8-7b46-45e0-a072-4f1319af1132"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("9c400578-92a5-4f7c-ba85-14479911ca76"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("9d2d11fa-2d60-4b9d-8ad6-8cf2064afbd8"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("9e52af32-9d0c-408b-b205-fc82f30da9a4"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("b9b99d09-d15a-4777-b598-fbf63f42e6b7"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("caefbb34-e64a-41ad-a8a8-91057813c9e1"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ce447ce5-a476-4d45-9409-d67b8957fbab"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("f14ac6d7-9a7d-47ea-b78c-fbe4a0fea25c"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "ProductsId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("61cfdc38-9d41-432d-8b19-8576306604c6"), new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 1 },
                    { new Guid("ae1217b6-6453-4611-b957-274b71747f40"), new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"), new Guid("a08e676d-a53f-4310-94e7-ab6731d34f0c"), null, 2 },
                    { new Guid("7e647e19-ad4a-4d95-ae22-a482f0db0054"), new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"), new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"), null, 3 },
                    { new Guid("5a35cca6-5215-4eca-adad-8b01d0b818b7"), new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 2 },
                    { new Guid("9b2dba44-7f32-417b-98e6-9c564d0a6b45"), new Guid("90d8b2a7-8cc7-443f-954a-b78695807ed7"), new Guid("12e42051-8563-4b4a-9b2a-51b101b14236"), null, 4 },
                    { new Guid("9139fe8e-5543-4d9c-9087-38f96f4c85ab"), new Guid("90d8b2a7-8cc7-443f-954a-b78695807ed7"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 1 },
                    { new Guid("9087aed7-911b-4a4f-985c-61e9d6bc7a08"), new Guid("aa97781b-3594-498b-9a48-21b2e86fd3f1"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 19 },
                    { new Guid("59a861a9-3940-4c11-8284-19b10448c39d"), new Guid("aa97781b-3594-498b-9a48-21b2e86fd3f1"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 5 },
                    { new Guid("8b128453-c895-45d3-8138-8a7a1a0eb244"), new Guid("f03ea2a2-91ed-4058-89b2-f3407e5bdf3c"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 3 },
                    { new Guid("fefb8ee0-017e-4a25-967b-98dd8cbf886f"), new Guid("d2040364-25aa-45b4-a54c-4e1423901c6d"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 9 },
                    { new Guid("d80e8fc9-806f-4925-85d7-02edce40a6f6"), new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"), new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"), null, 2 },
                    { new Guid("c753baf2-fa17-48f3-8b6f-299dd3911bae"), new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 1 },
                    { new Guid("fc9a03ee-c0e6-47d9-a0f6-77fb7f2d44b5"), new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 9 },
                    { new Guid("2d667b36-2ebd-4107-b748-d38d29e460a5"), new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"), new Guid("a08e676d-a53f-4310-94e7-ab6731d34f0c"), null, 5 },
                    { new Guid("906d553a-6603-41f2-82f6-d5d9cd40657a"), new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"), new Guid("12e42051-8563-4b4a-9b2a-51b101b14236"), null, 1 },
                    { new Guid("4f64746e-3cca-44a5-917f-8e854162bff1"), new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 4 },
                    { new Guid("7d2b8c45-d470-404b-a9db-71e04abcf8df"), new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"), new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"), null, 3 },
                    { new Guid("20f3fa73-2255-4a1d-8db3-6269a316b850"), new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 2 },
                    { new Guid("ab1b8c9f-747d-44ef-a323-aaf5bf60f013"), new Guid("7bda868b-9656-4406-8e54-65e626718fb1"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("20f3fa73-2255-4a1d-8db3-6269a316b850"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("2d667b36-2ebd-4107-b748-d38d29e460a5"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("4f64746e-3cca-44a5-917f-8e854162bff1"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("59a861a9-3940-4c11-8284-19b10448c39d"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("5a35cca6-5215-4eca-adad-8b01d0b818b7"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("61cfdc38-9d41-432d-8b19-8576306604c6"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("7d2b8c45-d470-404b-a9db-71e04abcf8df"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("7e647e19-ad4a-4d95-ae22-a482f0db0054"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("8b128453-c895-45d3-8138-8a7a1a0eb244"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("906d553a-6603-41f2-82f6-d5d9cd40657a"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("9087aed7-911b-4a4f-985c-61e9d6bc7a08"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("9139fe8e-5543-4d9c-9087-38f96f4c85ab"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("9b2dba44-7f32-417b-98e6-9c564d0a6b45"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ab1b8c9f-747d-44ef-a323-aaf5bf60f013"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ae1217b6-6453-4611-b957-274b71747f40"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("c753baf2-fa17-48f3-8b6f-299dd3911bae"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("d80e8fc9-806f-4925-85d7-02edce40a6f6"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("fc9a03ee-c0e6-47d9-a0f6-77fb7f2d44b5"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("fefb8ee0-017e-4a25-967b-98dd8cbf886f"));

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "ProductsId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("9c400578-92a5-4f7c-ba85-14479911ca76"), new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 1 },
                    { new Guid("4b8c62cf-a399-4256-8aed-047b96b2ca08"), new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"), new Guid("a08e676d-a53f-4310-94e7-ab6731d34f0c"), null, 2 },
                    { new Guid("8c0152ad-30fd-4c9f-88f0-4b3e511e96d5"), new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"), new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"), null, 3 },
                    { new Guid("65b11ec0-253c-4a84-959c-e61cd3eeba9b"), new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 2 },
                    { new Guid("4d44173f-58d8-44f0-b546-a8404835dade"), new Guid("90d8b2a7-8cc7-443f-954a-b78695807ed7"), new Guid("12e42051-8563-4b4a-9b2a-51b101b14236"), null, 4 },
                    { new Guid("1a27db8f-c49d-4681-afd9-5effcbe2d129"), new Guid("90d8b2a7-8cc7-443f-954a-b78695807ed7"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 1 },
                    { new Guid("0c76422f-9f76-4045-bd21-8d42ee8be8d8"), new Guid("aa97781b-3594-498b-9a48-21b2e86fd3f1"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 19 },
                    { new Guid("53a6f44f-c7fc-45a9-bfa5-59a91a813469"), new Guid("aa97781b-3594-498b-9a48-21b2e86fd3f1"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 5 },
                    { new Guid("ce447ce5-a476-4d45-9409-d67b8957fbab"), new Guid("f03ea2a2-91ed-4058-89b2-f3407e5bdf3c"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 3 },
                    { new Guid("f14ac6d7-9a7d-47ea-b78c-fbe4a0fea25c"), new Guid("d2040364-25aa-45b4-a54c-4e1423901c6d"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 9 },
                    { new Guid("50ee0c45-8bff-49e8-a110-184e11bd0543"), new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"), new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"), null, 2 },
                    { new Guid("9d2d11fa-2d60-4b9d-8ad6-8cf2064afbd8"), new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 1 },
                    { new Guid("33fbac7e-b1b7-4c77-b20c-39f849e906ec"), new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 9 },
                    { new Guid("9e52af32-9d0c-408b-b205-fc82f30da9a4"), new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"), new Guid("a08e676d-a53f-4310-94e7-ab6731d34f0c"), null, 5 },
                    { new Guid("96a80df8-7b46-45e0-a072-4f1319af1132"), new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"), new Guid("12e42051-8563-4b4a-9b2a-51b101b14236"), null, 1 },
                    { new Guid("93badec8-1d74-4a9c-b768-ab2c09d71504"), new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 4 },
                    { new Guid("55415e8a-12cc-4929-885a-13b67fee4755"), new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"), new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"), null, 3 },
                    { new Guid("b9b99d09-d15a-4777-b598-fbf63f42e6b7"), new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 2 },
                    { new Guid("caefbb34-e64a-41ad-a8a8-91057813c9e1"), new Guid("7bda868b-9656-4406-8e54-65e626718fb1"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 3 }
                });
        }
    }
}
