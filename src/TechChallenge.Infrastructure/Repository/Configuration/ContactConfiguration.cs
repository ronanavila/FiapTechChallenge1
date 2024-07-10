using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infrastructure.Repository.Configuration;
internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
  public void Configure(EntityTypeBuilder<Contact> builder)
  {
    builder.ToTable("Contact");
    builder.HasKey(p => p.Guid);
    builder.Property(p => p.Guid)
        .HasColumnType("UNIQUEIDENTIFIER");     
    builder.Property(p => p.DDD)
                .HasColumnType("INT")
                .IsRequired();               ;
    builder.Property(P => P.Phone)
        .HasColumnType("VARCHAR(10)")
        .IsRequired();
    builder.Property(P => P.Name)
                .HasColumnType("VARCHAR(150)")
                .IsRequired();
    builder.Property(p => p.Email)
                .HasColumnType("VARCHAR(150)")
                .IsRequired();

    builder.HasIndex(x => x.DDD, "IX_Contact_DDD");

    builder.HasOne<Region>().WithMany().HasForeignKey("DDD").OnDelete(DeleteBehavior.NoAction);
  }
}
