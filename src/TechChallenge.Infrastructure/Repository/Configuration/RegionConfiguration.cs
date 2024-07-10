﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infrastructure.Repository.Configuration;
internal class RegionConfiguration : IEntityTypeConfiguration<Region>
{
  public void Configure(EntityTypeBuilder<Region> builder)
  {
    builder.ToTable("Region");
    builder.HasKey(p => p.DDD);
    builder.Property(p => p.DDD)
        .HasColumnType("INT")
        .ValueGeneratedNever();
    builder.Property(P => P.Location)
        .HasColumnType("VARCHAR(100)")
        .IsRequired();
  }
}