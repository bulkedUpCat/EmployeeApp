using Bogus;
using EmployeeApp.API.Data.Enums;
using EmployeeApp.API.Data.Models;
using EmployeeApp.API.Services.Interfaces;

namespace EmployeeApp.API.Data.FakeGenerators;

public class EmployeeDataGenerator
{
    private readonly Faker<EmployeeModel> _faker;

    public EmployeeDataGenerator()
    {
        var companyDataGenerator = new CompanyDataGenerator();

        _faker = new Faker<EmployeeModel>()
            .RuleFor(x => x.Id, _ => Guid.NewGuid())
            .RuleFor(x => x.FirstName, faker => faker.Person.FirstName)
            .RuleFor(x => x.LastName, faker => faker.Person.LastName)
            .RuleFor(x => x.Address, faker => faker.Address.FullAddress())
            .RuleFor(x => x.Email, faker => faker.Person.Email)
            .RuleFor(x => x.Gender, faker => faker.PickRandom<GenderEnum>())
            .RuleFor(x => x.Company, _ => companyDataGenerator.Generate());
    }

    public EmployeeModel Generate()
    {
        return _faker
            .Generate();
    }

    public IEnumerable<EmployeeModel> Generate(int count)
    {
        return _faker
            .Generate(count);
    }
}