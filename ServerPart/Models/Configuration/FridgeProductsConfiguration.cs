using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace ServerPart.Models.Configuration
{
    public class FridgeProductsConfiguration : IEntityTypeConfiguration<FridgeProducts>
    {
        public void Configure(EntityTypeBuilder<FridgeProducts> builder)
        {
            var listOfFridges = new List<Guid>
            {
                new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"),
                new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"),
                new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"),
                new Guid("d2040364-25aa-45b4-a54c-4e1423901c6d"),
                new Guid("aa97781b-3594-498b-9a48-21b2e86fd3f1"),
                new Guid("90d8b2a7-8cc7-443f-954a-b78695807ed7"),
                new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"),
                new Guid("f03ea2a2-91ed-4058-89b2-f3407e5bdf3c"),
                new Guid("333bdc53-3381-4337-87a3-7f9d2be00ad4"),
                new Guid("7bda868b-9656-4406-8e54-65e626718fb1")
            };
            var listOfProducts = new List<Guid> 
            {
                new Guid("e6106a3d-e706-4f12-8878-f8c1af6cd007"),
                new Guid("11f16b19-ae65-4543-8a15-cec3ec17055b"),
                new Guid("73d4c6cd-9a89-4cdd-840a-77e04f7f86ce"),
                new Guid("12e42051-8563-4b4a-9b2a-51b101b14236"),
                new Guid("a08e676d-a53f-4310-94e7-ab6731d34f0c"),
                new Guid("81f35705-f46a-4a4b-a16d-f861194e6698")
            };
            builder.HasData(
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[0], ProductId = listOfProducts[0], Quantity = 1},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[0], ProductId = listOfProducts[1], Quantity = 3},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[0], ProductId = listOfProducts[5], Quantity = 4},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[1], ProductId = listOfProducts[3], Quantity = 1},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[1], ProductId = listOfProducts[4], Quantity = 5},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[1], ProductId = listOfProducts[5], Quantity = 9},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[2], ProductId = listOfProducts[0], Quantity = 1},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[2], ProductId = listOfProducts[1], Quantity = 2},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[2], ProductId = listOfProducts[2], Quantity = 2},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[3], ProductId = listOfProducts[2], Quantity = 9},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[4], ProductId = listOfProducts[0], Quantity = 5},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[4], ProductId = listOfProducts[5], Quantity = 19},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[5], ProductId = listOfProducts[2], Quantity = 1},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[5], ProductId = listOfProducts[3], Quantity = 4},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[6], ProductId = listOfProducts[0], Quantity = 2},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[6], ProductId = listOfProducts[1], Quantity = 3},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[6], ProductId = listOfProducts[4], Quantity = 2},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[7], ProductId = listOfProducts[5], Quantity = 3},
                new FridgeProducts() {Id = Guid.NewGuid(), FridgeId = listOfFridges[9], ProductId = listOfProducts[2], Quantity = 3}
            );
        }
    }
}
