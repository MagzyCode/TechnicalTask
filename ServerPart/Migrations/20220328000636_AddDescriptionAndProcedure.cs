using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerPart.Migrations
{
    public partial class AddDescriptionAndProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedureCheck = "IF OBJECT_ID('sp_TaskMethod', 'P')\n" +
                "IS NOT NULL DROP PROCEDURE sp_TaskMethod;";
            var createSp =
                "CREATE PROCEDURE sp_TaskMethod\n" +
                "AS\n" +
                "BEGIN UPDATE FridgeProducts\n" +
                "SET Quantity = (SELECT DefaultQuantity FROM Products WHERE Products.Id = FridgeProducts.ProductId)\n" +
                "WHERE Quantity = 0 \n" +
                "END \n";
            migrationBuilder.Sql(procedureCheck);
            migrationBuilder.Sql(createSp);

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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Fridges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05c37f05-f9da-43fa-9523-1d33d6dbd277", "53e081b9-4a5e-4bae-b9aa-0c28b9378f79", "Client", "CLIENT" },
                    { "c4a678fb-130a-4be6-b553-7eeb0d9eed00", "e7dccda4-04da-49a0-bf37-70bcd22e7fc5", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "ProductsId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("1f5ad6fe-6aac-45f3-a40e-f2263bbe3169"), new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"), new Guid("a08e676d-a53f-4310-94e7-ab6731d34f0c"), null, 2 },
                    { new Guid("f0b08d68-8a17-415f-82a2-8049d77f6767"), new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"), new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"), null, 3 },
                    { new Guid("8eb2daa3-2dcb-4f94-94d0-14551af6076b"), new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 2 },
                    { new Guid("53a517f5-8056-476f-af55-91112a34db2b"), new Guid("90d8b2a7-8cc7-443f-954a-b78695807ed7"), new Guid("12e42051-8563-4b4a-9b2a-51b101b14236"), null, 4 },
                    { new Guid("9a1eb12a-bbe1-4dea-87e7-fc252c6b4b82"), new Guid("90d8b2a7-8cc7-443f-954a-b78695807ed7"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 1 },
                    { new Guid("aeedcf9a-2891-4248-806a-402335850dac"), new Guid("aa97781b-3594-498b-9a48-21b2e86fd3f1"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 19 },
                    { new Guid("00abe7fc-c661-4e11-98d7-89e64238c6c1"), new Guid("aa97781b-3594-498b-9a48-21b2e86fd3f1"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 5 },
                    { new Guid("15868159-f8fe-4d55-b59f-786499d9f7f4"), new Guid("d2040364-25aa-45b4-a54c-4e1423901c6d"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 9 },
                    { new Guid("a499cd8b-5aa7-4368-846a-7ec89bb76f74"), new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 2 },
                    { new Guid("3e8896db-f79e-45e0-8524-8f5457de0129"), new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"), new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"), null, 2 },
                    { new Guid("799a699f-17ac-44e1-9bce-6f17391ee5ad"), new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 1 },
                    { new Guid("c660fa5b-94b3-410a-810d-7fea78cc82c0"), new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 9 },
                    { new Guid("d9d21d95-b681-4019-bb3d-9ad47d6be9eb"), new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"), new Guid("a08e676d-a53f-4310-94e7-ab6731d34f0c"), null, 5 },
                    { new Guid("71bfd494-ed78-4a61-8dd3-74fdba46e451"), new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"), new Guid("12e42051-8563-4b4a-9b2a-51b101b14236"), null, 1 },
                    { new Guid("5e70a069-7070-4e94-8977-adf1265b8eaf"), new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 4 },
                    { new Guid("0215e9bb-4929-44e5-ae24-8995e4d73348"), new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"), new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"), null, 3 },
                    { new Guid("14c9aa7e-0539-4ecf-a2fa-7824d2f77623"), new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"), new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"), null, 1 },
                    { new Guid("ba1b3931-39ee-4a29-9b46-57b1cd0dedb6"), new Guid("f03ea2a2-91ed-4058-89b2-f3407e5bdf3c"), new Guid("81f35705-f46a-4a4b-a16d-f861194e6698"), null, 3 },
                    { new Guid("4f248adb-4cb0-4235-a8a6-757a056c5cca"), new Guid("7bda868b-9656-4406-8e54-65e626718fb1"), new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"), null, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropProcSql = "DROP PROC sp_MethodTask";
            migrationBuilder.Sql(dropProcSql);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05c37f05-f9da-43fa-9523-1d33d6dbd277");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4a678fb-130a-4be6-b553-7eeb0d9eed00");

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("00abe7fc-c661-4e11-98d7-89e64238c6c1"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("0215e9bb-4929-44e5-ae24-8995e4d73348"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("14c9aa7e-0539-4ecf-a2fa-7824d2f77623"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("15868159-f8fe-4d55-b59f-786499d9f7f4"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("1f5ad6fe-6aac-45f3-a40e-f2263bbe3169"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("3e8896db-f79e-45e0-8524-8f5457de0129"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("4f248adb-4cb0-4235-a8a6-757a056c5cca"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("53a517f5-8056-476f-af55-91112a34db2b"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("5e70a069-7070-4e94-8977-adf1265b8eaf"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("71bfd494-ed78-4a61-8dd3-74fdba46e451"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("799a699f-17ac-44e1-9bce-6f17391ee5ad"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("8eb2daa3-2dcb-4f94-94d0-14551af6076b"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("9a1eb12a-bbe1-4dea-87e7-fc252c6b4b82"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("a499cd8b-5aa7-4368-846a-7ec89bb76f74"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("aeedcf9a-2891-4248-806a-402335850dac"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ba1b3931-39ee-4a29-9b46-57b1cd0dedb6"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("c660fa5b-94b3-410a-810d-7fea78cc82c0"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("d9d21d95-b681-4019-bb3d-9ad47d6be9eb"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("f0b08d68-8a17-415f-82a2-8049d77f6767"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Fridges");

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
    }
}
