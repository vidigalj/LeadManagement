﻿namespace LeadManagement.Domain.Entities;

public class EntityBase
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
