using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameStore.Api.Entities;

namespace VideoGameStore.Api.Data.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        _ = builder.Property(game => game.Price)
                   .HasPrecision(5, 2);
    }
}
