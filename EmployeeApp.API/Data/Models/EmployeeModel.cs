using EmployeeApp.API.Data.Enums;

namespace EmployeeApp.API.Data.Models;

public class EmployeeModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public GenderEnum Gender { get; set; }
    public CompanyModel Company { get; set; }
}