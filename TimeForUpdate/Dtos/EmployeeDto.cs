namespace TimeForUpdate.Dtos;

// Dtos/EmployeeDto.cs
public class EmployeeDto
{
    public int    Id         { get; set; }
    public decimal Salary    { get; set; }
    public int    PositionId { get; set; }
    public int    PersonId   { get; set; }
    public DateTime HireDate { get; set; }
}
