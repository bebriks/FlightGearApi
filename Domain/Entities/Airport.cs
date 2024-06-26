﻿using Domain.Base;

namespace Domain.Entities;

public class Airport : BaseEntityWithKey<Guid>
{
    public required string Title { get; set; }
    
    public required string Code { get; set; }
    
    public required string City { get; set; }
    
    public ICollection<AirportRunway> Runways { get; set; }
}