using EmployeeApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.API.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController: ControllerBase
{
    private readonly IEmployeeService _employeeService;
    
    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _employeeService.GetAllAsync();
        return Ok(result);
    }
}