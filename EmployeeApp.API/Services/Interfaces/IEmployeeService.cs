using EmployeeApp.API.Data.Models;

namespace EmployeeApp.API.Services.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeModel>> GetAllAsync();
}