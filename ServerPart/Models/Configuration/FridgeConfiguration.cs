using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ServerPart.Models.Configuration
{
    public class FridgeConfiguration : IEntityTypeConfiguration<Fridge>
    {
        public void Configure(EntityTypeBuilder<Fridge> builder)
        {
            builder.HasData(
                new Fridge()
                {
                    Id = new Guid("07ca8c3c-2a1b-4423-98fd-f4bb8359feb8"), 
                    Name = "ATLANT М 7184-003",
                    OwnerName = "ATLANT",
                    ModelId = new Guid("8f645d5f-5ce9-41af-a118-d56a1a88bbcc")
                },
                new Fridge()
                {
                    Id = new Guid("0d292ea1-2e4b-4568-8f80-794fd96c9857"), 
                    Name = "ATLANT ХМ 4008-022",
                    OwnerName = "ATLANT",
                    ModelId = new Guid("8f645d5f-5ce9-41af-a118-d56a1a88bbcc")
                },
                new Fridge()
                {
                    Id = new Guid("bda10308-d7f7-4547-89f4-dcccc748c265"), 
                    Name = "Bosch KIN86AF30",
                    OwnerName = "Bosch",
                    ModelId = new Guid("b4878a69-c34a-4eeb-be2c-eccd92436568")
                },
                new Fridge()
                {
                    Id = new Guid("d2040364-25aa-45b4-a54c-4e1423901c6d"), 
                    Name = "Bosch GUD15A50",
                    OwnerName = "Bosch",
                    ModelId = new Guid("b4878a69-c34a-4eeb-be2c-eccd92436568")
                },
                new Fridge()
                {
                    Id = new Guid("aa97781b-3594-498b-9a48-21b2e86fd3f1"), 
                    Name = "LG GA-B489 YMQZ",
                    OwnerName = "LG",
                    ModelId = new Guid("60972bb8-2811-4216-b8f8-a67c3cea12e8")
                },
                new Fridge()
                {
                    Id = new Guid("90d8b2a7-8cc7-443f-954a-b78695807ed7"), 
                    Name = "LG GA-B379 SVQA",
                    OwnerName = "LG",
                    ModelId = new Guid("60972bb8-2811-4216-b8f8-a67c3cea12e8")
                },
                new Fridge()
                {
                    Id = new Guid("0ba92888-4491-4a21-ac0e-8186b16b7bf2"), 
                    Name = "Samsung RSA1STWP",
                    OwnerName = "Samsung",
                    ModelId = new Guid("fceff18a-43f6-4286-ab11-f6d0ad6d3200")
                },
                new Fridge()
                {
                    Id = new Guid("f03ea2a2-91ed-4058-89b2-f3407e5bdf3c"), 
                    Name = "Samsung RL-59 GYBSW",
                    OwnerName = "Samsung",
                    ModelId = new Guid("fceff18a-43f6-4286-ab11-f6d0ad6d3200")
                },
                new Fridge()
                {
                    Id = new Guid("333bdc53-3381-4337-87a3-7f9d2be00ad4"), 
                    Name = "Panasonic NR-BW465VC",
                    OwnerName = "Panasonic",
                    ModelId = new Guid("aea85d9c-8fda-4fa6-bb30-d059bc073b1e")
                },
                new Fridge()
                {
                    Id = new Guid("7bda868b-9656-4406-8e54-65e626718fb1"), 
                    Name = "Panasonic NR-BY602XC",
                    OwnerName = "Panasonic",
                    ModelId = new Guid("aea85d9c-8fda-4fa6-bb30-d059bc073b1e")
                }
            );
        }
    }
}
