namespace TimeForUpdate.Dtos;

// Dtos/UpdateDeviceDto.cs
using System.ComponentModel.DataAnnotations;

public class UpdateDeviceDto
{
    [Required, StringLength(150)]
    public string Name                 { get; set; } = null!;

    public bool IsEnabled              { get; set; }

    public string AdditionalProperties { get; set; } = "";

    public int? DeviceTypeId           { get; set; }
}
