namespace TimeForUpdate.Dtos;

// Dtos/DeviceDto.cs
public class DeviceDto
{
    public int    Id                     { get; set; }
    public string Name                   { get; set; } = null!;
    public bool   IsEnabled              { get; set; }
    public string AdditionalProperties   { get; set; } = null!;
    public int?   DeviceTypeId           { get; set; }
}
    