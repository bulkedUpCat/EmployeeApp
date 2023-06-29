using System.Threading.Tasks;
using ChoETL;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

namespace EmployeeApp.Functions.EmployeeDataProcessing;

public static class JsonToCsvConverterFunction
{
    [FunctionName(nameof(Convert))]
    public static Task Convert([ActivityTrigger]  IDurableActivityContext context, ILogger log)
    {
        var jsonFileName = context.GetInput<string>();
        
        using var reader = new ChoJSONReader(jsonFileName);
        using var writer = new ChoCSVWriter("employees.csv").WithFirstLineHeader();
        
        writer.Write(reader);
        
        return Task.CompletedTask;
    }
}