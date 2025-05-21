namespace TimeForUpdate.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeForUpdate.Models;
using TimeForUpdate.Dtos;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly TimeForUpdateContext _db;
    public EmployeesController(TimeForUpdateContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
    {
        var list = await _db.Employees
            .Select(e => new EmployeeDto {
                Id         = e.Id,
                Salary     = e.Salary,
                PositionId = e.PositionId,
                PersonId   = e.PersonId,
                HireDate   = e.HireDate
            })
            .ToListAsync();
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EmployeeDto>> Get(int id)
    {
        var e = await _db.Employees.FindAsync(id);
        if (e == null) return NotFound();
        return Ok(new EmployeeDto {
            Id         = e.Id,
            Salary     = e.Salary,
            PositionId = e.PositionId,
            PersonId   = e.PersonId,
            HireDate   = e.HireDate
        });
    }
}
