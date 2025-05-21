namespace TimeForUpdate.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeForUpdate.Models;
using TimeForUpdate.Dtos;

[ApiController]
[Route("api/[controller]")]
public class DevicesController : ControllerBase
{
    private readonly TimeForUpdateContext _db;
    public DevicesController(TimeForUpdateContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DeviceDto>>> GetAll()
    {
        var devices = await _db.Devices
            .Select(d => new DeviceDto {
                Id                   = d.Id,
                Name                 = d.Name,
                IsEnabled            = d.IsEnabled,
                AdditionalProperties = d.AdditionalProperties,
                DeviceTypeId         = d.DeviceTypeId
            })
            .ToListAsync();
        return Ok(devices);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DeviceDto>> Get(int id)
    {
        var d = await _db.Devices.FindAsync(id);
        if (d == null) return NotFound();
        return Ok(new DeviceDto {
            Id                   = d.Id,
            Name                 = d.Name,
            IsEnabled            = d.IsEnabled,
            AdditionalProperties = d.AdditionalProperties,
            DeviceTypeId         = d.DeviceTypeId
        });
    }

    [HttpPost]
    public async Task<ActionResult<DeviceDto>> Create(CreateDeviceDto dto)
    {
        var d = new Device {
            Name                 = dto.Name,
            IsEnabled            = dto.IsEnabled,
            AdditionalProperties = dto.AdditionalProperties,
            DeviceTypeId         = dto.DeviceTypeId
        };
        _db.Devices.Add(d);
        await _db.SaveChangesAsync();
        var result = new DeviceDto {
            Id                   = d.Id,
            Name                 = d.Name,
            IsEnabled            = d.IsEnabled,
            AdditionalProperties = d.AdditionalProperties,
            DeviceTypeId         = d.DeviceTypeId
        };
        return CreatedAtAction(nameof(Get), new { id = d.Id }, result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateDeviceDto dto)
    {
        var d = await _db.Devices.FindAsync(id);
        if (d == null) return NotFound();
        d.Name                 = dto.Name;
        d.IsEnabled            = dto.IsEnabled;
        d.AdditionalProperties = dto.AdditionalProperties;
        d.DeviceTypeId         = dto.DeviceTypeId;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var d = await _db.Devices.FindAsync(id);
        if (d == null) return NotFound();
        _db.Devices.Remove(d);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
