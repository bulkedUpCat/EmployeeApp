using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeApp.Functions.Models;
using EmployeeApp.Functions.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using static EmployeeApp.Functions.Constants.Constants;

namespace EmployeeApp.Functions.EmployeeDataProcessing;

public static class CosmosDbAccessingFunction
{
    [FunctionName(nameof(SaveToDatabase))]
    public static async Task<AcceptedResult> SaveToDatabase(
        [ActivityTrigger]  IDurableActivityContext context,
        [CosmosDB(
            CosmosDbEmployeeDatabaseName,
            CosmosDbEmployeeContainerName,
            Connection = CosmosDbConnectionStringName)] IAsyncCollector<EmployeeModel> employees,
        ILogger log)
    {
        var fileName = context.GetInput<string>();
        var employeesInput = JsonFileUtilities.DeserializeFromFile<IEnumerable<EmployeeModel>>(fileName);

        foreach (var employee in employeesInput)
        {
            await employees.AddAsync(employee);
        }

        return new AcceptedResult();
    }
}