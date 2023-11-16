using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsManagement.Models;

namespace SportsManagement.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("team_id");
        builder.Property(x => x.TeamName).HasColumnName("team_name");

        builder.HasMany(x => x.Players);

        builder.HasData(
    new Team() { Id = 1, TeamName = "Galatasaray" });

    }
}
