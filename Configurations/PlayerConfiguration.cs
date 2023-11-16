using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsManagement.Models;

namespace SportsManagement.Configurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.ToTable("Players").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("player_id");
        builder.Property(x => x.Name).HasColumnName("player_name");
        builder.Property(x => x.Age).HasColumnName("player_age");
        builder.Property(x => x.Price).HasColumnName("player_price");
        builder.Property(x => x.TeamId).HasColumnName("team_id");
        builder.Property(x => x.BranchId).HasColumnName("branch_id");
        builder.Property(x => x.OutfitId).HasColumnName("outfit_id");

        builder.HasOne(x => x.Team);
        builder.HasOne(x => x.Branch);
        builder.HasOne(x => x.Outfit);

        builder.HasData(
            new Player()
            {
                Id = 1,
                Age = 30,
                BranchId = 1,
                TeamId = 1,
                Name = "Icardi",
                OutfitId = 1,
                Price = 3000000,
            });



    }
}
