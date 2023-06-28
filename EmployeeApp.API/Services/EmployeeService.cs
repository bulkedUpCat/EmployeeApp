using EmployeeApp.API.Data.FakeGenerators;
using EmployeeApp.API.Data.Models;
using EmployeeApp.API.Services.Interfaces;

namespace EmployeeApp.API.Services;

public class EmployeeService: IEmployeeService
{
    private readonly EmployeeDataGenerator _employeeDataGenerator;
    private readonly int _employeesCount = 2000;
    
    public EmployeeService()
    {
        _employeeDataGenerator = new EmployeeDataGenerator();
    }
    
    public Task<IEnumerable<EmployeeModel>> GetAllAsync()
    {
        var employees = _employeeDataGenerator.Generate(_employeesCount);
        return Task.FromResult(employees);
    }
}