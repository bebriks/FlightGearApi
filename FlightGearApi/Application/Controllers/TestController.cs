﻿using FlightGearApi.Application.DTO;
using FlightGearApi.Domain.Enums;
using FlightGearApi.Domain.FlightGearCore;
using FlightGearApi.Domain.Records;
using FlightGearApi.Domain.UtilityClasses;
using Microsoft.AspNetCore.Mvc;

namespace FlightGearApi.Application.Controllers;

[Route("api/test")]
public class TestController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly IoManager _ioManager;
    private readonly FlightGearLauncher _launcher;
    private readonly ConnectionListener _listener;
    private readonly FlightGearManipulator _manipulator;
    
    public TestController(IConfiguration configuration, IoManager ioManager, FlightGearLauncher launcher, 
        ConnectionListener listener, FlightGearManipulator manipulator)
    {
        _configuration = configuration;
        _ioManager = ioManager;
        _launcher = launcher;
        _listener = listener;
        _manipulator = manipulator;
    }
    
    [HttpGet("get-launch-string")]
    public async Task<IActionResult> GetLaunchString()
    {
        var result = _launcher.GenerateLaunchArguments();
        
        return Ok(result);
    }
    
    [HttpGet("current-properties")]
    public async Task<IActionResult> GetCurrentProperties()
    {
        var result = await _listener.GetCurrentValuesAsync();
        
        return Ok(result);
    }
    
    [HttpGet("current-utility-properties")]
    public async Task<IActionResult> GetCurrentUtilityProperties()
    {
        var result = await _listener.GetCurrentValuesAsync(true);
        
        return Ok(result);
    }
    
    [HttpPost("xml-file")]
    public async Task<IActionResult> GetXmlFileContent([FromBody] IoType type)
    {
        var result = _ioManager.GenerateXmlInputFileContent();
        return Ok(result);
    }
    
    [HttpPost("set-parameter")]
    public async Task<IActionResult> SetParameterTest()
    {
        await _manipulator.SendParametersAsync(new Dictionary<UtilityProperty, double>()
        {
            { UtilityProperty.ParkingBrake, 0},
            { UtilityProperty.Aileron, 0.1}
        });
        return Ok();
    }
    
    [HttpPost("fly-forward")]
    public async Task<IActionResult> FlyForwardTest()
    {
        _manipulator.ShouldFlyForward = true;
        _manipulator.FlyCycle();
        return Ok();
    }
    
    [HttpPost("Get-results-for-analytics")]
    public async Task<IActionResult> GetResultsTest([FromBody] GetResultRequest request)
    {
        var result = new List<FlightResultResponse>();
        if (!_listener.ListenResults.TryGetValue(request.SessionName, out var list))
        {
            return BadRequest("No results for that session");
        }
        
        foreach (var msg in list)
        {
            foreach (var pairNameValue in msg.Values)
            {
                var item = result.FirstOrDefault(r => r.Name == pairNameValue.Key);
                if (item == null)
                {
                    item = new FlightResultResponse() { Name = pairNameValue.Key, Data = new List<PropertyValue>()};
                    result.Add(item);
                }
                item.Data.Add(new PropertyValue(item.Data.Count, pairNameValue.Value));
            }
        }
        return Ok(result);
    }
}