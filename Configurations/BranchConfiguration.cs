using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsManagement.Models;

namespace SportsManagement.Configurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("Branches").HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("branch_id");
        builder.Property(b => b.BranchName).HasColumnName("branch_name");

        builder.HasMany(b => b.Players);

        builder.HasData(new Branch() { Id = 1, BranchName = "Football" });

    }
}
