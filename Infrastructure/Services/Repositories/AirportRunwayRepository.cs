﻿using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Repositories;

internal class AirportRunwayRepository : IAirportRunwayRepository
{
    private readonly PostgresDbContext _dbContext;

    public AirportRunwayRepository(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task SaveAsync(AirportRunway runway)
    {
        if (!_dbContext.AirportRunways.Contains(runway))
        {
            _dbContext.AirportRunways.Add(runway);
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(AirportRunway runway)
    {
        if (_dbContext.AirportRunways.Contains(runway))
        {
            _dbContext.AirportRunways.Remove(runway);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task RemoveByIdAsync(Guid runwayId)
    {
        var runway = _dbContext.AirportRunways.FirstOrDefault(r => r.Id == runwayId);
        if (runway != null)
        {
            _dbContext.AirportRunways.Remove(runway);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task RemoveByAirportIdAsync(Guid airportId)
    {
        var runways = _dbContext.AirportRunways.Where(r => r.AirportId == airportId);
        _dbContext.RemoveRange(runways);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<AirportRunway> GetByIdAsync(Guid id)
    {
        return _dbContext.AirportRunways.First(r => r.Id == id);
    }

    public async Task<AirportRunway> GetAggregateByIdAsync(Guid id)
    {
        var runway = _dbContext.AirportRunways
            .Include(r => r.Airport)
            .Include(r => r.ArrivalFunction)
            .Include(r => r.DepartureFunction)
            .First(r => r.Id == id);
        if (runway.ArrivalFunction != null)
        {
            var arrivalFunctionPoints = _dbContext.FunctionPoints
                .OrderBy(p => p.Order)
                .Where(p => p.FunctionId == runway.ArrivalFunctionId)
                .ToArray();
            runway.ArrivalFunction.FunctionPoints = arrivalFunctionPoints;
        }
        if (runway.DepartureFunction != null)
        {
            var arrivalFunctionPoints = _dbContext.FunctionPoints
                .OrderBy(p => p.Order)
                .Where(p => p.FunctionId == runway.DepartureFunctionId)
                .ToArray();
            runway.DepartureFunction.FunctionPoints = arrivalFunctionPoints;
        }
        
        return runway;
    }

    public async Task<AirportRunway[]> GetAllByAirportId(Guid airportId)
    {
        return _dbContext.AirportRunways
            .Where(r => r.AirportId == airportId)
            .ToArray();
    }

    public async Task<AirportRunway[]> GetAggregatedRunwaysByAirportId(Guid airportId)
    {
        return _dbContext.AirportRunways
            .Include(r => r.Airport)
            .Include(r=> r.ArrivalFunction)
            .ThenInclude(f => f.FunctionPoints)
            .Include(r => r.DepartureFunction)
            .ThenInclude(f => f.FunctionPoints)
            .Where(r => r.AirportId == airportId)
            .ToArray();
    }
}