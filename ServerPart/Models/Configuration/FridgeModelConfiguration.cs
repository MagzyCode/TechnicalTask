using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ServerPart.Models.Configuration
{
    public class FridgeModelConfiguration : IEntityTypeConfiguration<FridgeModel>
    {
        public void Configure(EntityTypeBuilder<FridgeModel> builder)
        {
            builder.HasData(
                new FridgeModel()
                {
                    Id = new Guid("8f645d5f-5ce9-41af-a118-d56a1a88bbcc"),
                    Name = "Atlant",
                    Year = 1956
                },
                new FridgeModel()
                {
                    Id = new Guid("b4878a69-c34a-4eeb-be2c-eccd92436568"), 
                    Name = "Bosch",
                    Year = 1886
                },
                new FridgeModel()
                {
                    Id = new Guid("60972bb8-2811-4216-b8f8-a67c3cea12e8"), 
                    Name = "LG",
                    Year = 1958
                },
                new FridgeModel()
                {
                    Id = new Guid("fceff18a-43f6-4286-ab11-f6d0ad6d3200"), 
                    Name = "Samsung",
                    Year = 1938
                },
                new FridgeModel()
                {
                    Id = new Guid("aea85d9c-8fda-4fa6-bb30-d059bc073b1e"), 
                    Name = "Panasonic",
                    Year = 1918
                }
            );
        }
    }
}
