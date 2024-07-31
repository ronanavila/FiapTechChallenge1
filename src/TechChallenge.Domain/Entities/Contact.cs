﻿
namespace TechChallenge.Domain.Entities;
public class Contact : BaseEntity
{
  public string Name { get; set; }  =string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  public int RegionDDD { get; set; }

  public virtual Region Region { get; set; } = new Region();
}