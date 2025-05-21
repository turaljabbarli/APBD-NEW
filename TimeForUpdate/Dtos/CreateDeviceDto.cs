namespace TimeForUpdate.Dtos;

// Dtos/CreateDeviceDto.cs
using System.ComponentModel.DataAnnotations;

public class CreateDeviceDto
{
    [Required, StringLength(150)]
    public string Name                 { get; set; } = null!;

    public bool IsEnabled              { get; set; } = true;

    public string AdditionalProperties { get; set; } = "";

    public int? DeviceTypeId           { get; set; }
}
