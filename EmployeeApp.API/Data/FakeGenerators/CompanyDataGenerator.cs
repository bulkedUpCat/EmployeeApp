using Bogus;
using EmployeeApp.API.Data.Models;

namespace EmployeeApp.API.Data.FakeGenerators;

public class CompanyDataGenerator
{
    private readonly Faker<CompanyModel> _faker;

    public CompanyDataGenerator()
    {
        _faker = new Faker<CompanyModel>()
            .RuleFor(x => x.Id, _ => Guid.NewGuid())
            .RuleFor(x => x.Name, faker => faker.Company.CompanyName());
    }

    public CompanyModel Generate()
    {
        return _faker
            .Generate();
    }

    public IEnumerable<CompanyModel> Generate(int count)
    {
        return _faker
            .Generate(count);
    }
}