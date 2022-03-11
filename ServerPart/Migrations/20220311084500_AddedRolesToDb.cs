using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerPart.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a6b54992-29e4-402c-bc34-7b06afc84786", "a5b0d6e5-e346-4ddd-b510-0ec205551410", "Client", "CLIENT" },
                    { "90946914-6610-47e6-b427-45217cef4180", "b623ab63-d587-4e7f-80fe-f5249ac7e178", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "ProductsId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0faea642-6cd4-4037-b8ef-8dd79d769c3d"), new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"), new Guid("a08e676d-a53f-4310-94e7-ab6731d34f0c"), null, 2 },
                    { new Guid("be0b0e86-16d9-4e7a-8b34-3d0629694d01"), new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"), new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"), null, 3 },
                    { new Guid("0536a2fe-16c0-4fdf-882a-172c32d4817e"), new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 2 },
                    { new Guid("ed128756-9804-444f-b033-7e9a5df35ba3"), new Guid("90d8b2a7-8cc7-443f-954a-b78695807ed7"), new Guid("12e42051-8563-4b4a-9b2a-51b101b14236"), null, 4 },
                    { new Guid("4d6c802f-d376-4be4-932c-399892b24da9"), new Guid("90d8b2a7-8cc7-443f-954a-b78695807ed7"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 1 },
                    { new Guid("40b2a731-2e98-4cec-bf70-afa5cff353d1"), new Guid("aa97781b-3594-498b-9a48-21b2e86fd3f1"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 19 },
                    { new Guid("dd3b8721-aa3e-4a7b-b91b-9c11c859acc8"), new Guid("aa97781b-3594-498b-9a48-21b2e86fd3f1"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 5 },
                    { new Guid("2ca3124f-5046-4ada-a173-8b9618f85561"), new Guid("d2040364-25aa-45b4-a54c-4e1423901c6d"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 9 },
                    { new Guid("ba50cbdc-b2b9-4499-a73f-e7878c487921"), new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 2 },
                    { new Guid("5bb59564-7add-49c2-96a0-8506a1c94837"), new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"), new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"), null, 2 },
                    { new Guid("43f40185-01da-4a82-b7e7-150b56d3e5fa"), new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 1 },
                    { new Guid("248d67a7-8fa9-406e-8437-a7a24ada5264"), new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 9 },
                    { new Guid("d5b66aaf-dbff-44cc-bc27-9e169dde88c4"), new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"), new Guid("a08e676d-a53f-4310-94e7-ab6731d34f0c"), null, 5 },
                    { new Guid("1a3288a5-fa23-4b03-aabc-ae5e044e4744"), new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"), new Guid("12e42051-8563-4b4a-9b2a-51b101b14236"), null, 1 },
                    { new Guid("5b51c1c8-ab27-4156-afc9-ae094af978df"), new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 4 },
                    { new Guid("c5b46f1a-b9f3-4180-9269-4d6c412f4c5a"), new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"), new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"), null, 3 },
                    { new Guid("02fa2d69-2027-418c-ad24-5fdc030156ab"), new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 1 },
                    { new Guid("c93186c9-5a70-497e-8142-852c32ff39c9"), new Guid("f03ea2a2-91ed-4058-89b2-f3407e5bdf3c"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 3 },
                    { new Guid("df140895-ba9d-4f1e-bcda-b396466e8f1e"), new Guid("7bda868b-9656-4406-8e54-65e626718fb1"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90946914-6610-47e6-b427-45217cef4180");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6b54992-29e4-402c-bc34-7b06afc84786");

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("02fa2d69-2027-418c-ad24-5fdc030156ab"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("0536a2fe-16c0-4fdf-882a-172c32d4817e"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("0faea642-6cd4-4037-b8ef-8dd79d769c3d"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("1a3288a5-fa23-4b03-aabc-ae5e044e4744"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("248d67a7-8fa9-406e-8437-a7a24ada5264"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("2ca3124f-5046-4ada-a173-8b9618f85561"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("40b2a731-2e98-4cec-bf70-afa5cff353d1"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("43f40185-01da-4a82-b7e7-150b56d3e5fa"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("4d6c802f-d376-4be4-932c-399892b24da9"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("5b51c1c8-ab27-4156-afc9-ae094af978df"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("5bb59564-7add-49c2-96a0-8506a1c94837"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ba50cbdc-b2b9-4499-a73f-e7878c487921"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("be0b0e86-16d9-4e7a-8b34-3d0629694d01"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("c5b46f1a-b9f3-4180-9269-4d6c412f4c5a"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("c93186c9-5a70-497e-8142-852c32ff39c9"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("d5b66aaf-dbff-44cc-bc27-9e169dde88c4"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("dd3b8721-aa3e-4a7b-b91b-9c11c859acc8"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("df140895-ba9d-4f1e-bcda-b396466e8f1e"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ed128756-9804-444f-b033-7e9a5df35ba3"));

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
        }
    }
}
