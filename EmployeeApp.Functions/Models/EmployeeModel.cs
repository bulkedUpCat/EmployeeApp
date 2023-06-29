using EmployeeApp.Functions.Enums;
using Newtonsoft.Json;

namespace EmployeeApp.Functions.Models;

public class EmployeeModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public GenderEnum Gender { get; set; }
    public CompanyModel Company { get; set; }
}